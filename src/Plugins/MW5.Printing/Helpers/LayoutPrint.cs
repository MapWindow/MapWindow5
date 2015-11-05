// -------------------------------------------------------------------------------------------
// <copyright file="LayoutPrint.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MW5.Plugins.Printing.Model;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Plugins.Services;

namespace MW5.Plugins.Printing.Helpers
{
    // TODO: implement as service
    internal static class LayoutPrint
    {
        public static bool Cancelled = false;
        public static readonly AutoResetEvent autoEvent = new AutoResetEvent(false);

        private static LayoutPages _pages;
        private static List<LayoutElement> _elements;
        private static int _pageWidth;
        private static int _pageHeight;

        private static bool _useElementClipping = false;

        /// <summary>
        /// Draws the whole contents of the control to the specified graphics object
        /// </summary>
        private static void DrawToBitmap(Graphics g, IEnumerable<LayoutElement> layoutElements)
        {
            IEnumerable<LayoutElement> list = layoutElements;
            list = list.Reverse();

            float dpiRatio = g.DpiX / PrintingConstants.EXPORT_BASE_DPI; // layout units = 1/100 inch
            int dpi = (int)g.DpiX;

            foreach (var el in list)
            {
                var r = new RectangleF(el.Rectangle.X, el.Rectangle.Y, el.Rectangle.Width, el.Rectangle.Height);
                var rectNew = new RectangleF(r.X * dpiRatio, r.Y * dpiRatio, r.Width * dpiRatio, r.Height * dpiRatio);

                var matrix = g.Transform;

                if (el is LayoutMap)
                {
                    g.PageScale = g.DpiX / PrintingConstants.EXPORT_BASE_DPI; // 1.0f
                    g.PageUnit = GraphicsUnit.Display; //pixels for displays, 1/100 inch for printers

                    g.TranslateTransform(rectNew.X, rectNew.Y);

                    if (_useElementClipping)
                    {
                        g.SetClip(new RectangleF(0.0f, 0.0f, rectNew.Width + 1.0f, rectNew.Height + 1.0f));
                    }

                    // wait for the response from tilesLoaded and perform drawing
                    var mapEl = el as LayoutMap;
                    if (mapEl.DrawTiles && dpi > (int)ScreenHelper.ScreenDpi)
                    {
                        // if requested dpi differs, tiles should be loaded anew
                        autoEvent.Reset();
                        bool result = mapEl.LoadTiles(dpi, r);
                        if (!result)
                        {
                            autoEvent.WaitOne(PrintingConstants.DEADLOCK_TIMEOUT_MILLISECONDS); // they should be loaded
                        }
                    }
                    if (Cancelled) return;
                    mapEl.Draw(g, r, true);
                }
                else
                {
                    // "normal" size is considered at 96 dpi
                    // we can't set GraphicUnit.Display and wait .NET to do all the job as for printing
                    // as in this case GraphicUnit.Display will be equal to pixel, so elements won't be expanded to proper size
                    g.PageScale = g.DpiX / PrintingConstants.EXPORT_BASE_DPI;
                    g.PageUnit = GraphicsUnit.Pixel;
                    g.ResetClip();
                    g.TranslateTransform(r.X, r.Y);

                    if (_useElementClipping)
                    {
                        g.SetClip(new RectangleF(0.0f, 0.0f, rectNew.Width + 1.0f, rectNew.Height + 1.0f));
                    }

                    el.DrawElement(g, true, true);
                }

                g.ResetClip();
                g.Transform = matrix;
            }
        }

        /// <summary>
        /// Exports to bitmap at specified dpi
        /// </summary>
        internal static void ExportToBitmap(
            LayoutPages pages,
            int pageWidth,
            int pageHeight,
            List<LayoutElement> elements)
        {
            Cancelled = false;
            float dpi = 96; // TODO: choose

            var dlg = new SaveFileDialog { Filter = PrintingConstants.EXPORT_FILTER };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int width = (int)((float)pageWidth * pages.PageCountX / PrintingConstants.EXPORT_BASE_DPI * dpi);
                int height = (int)((float)pageHeight * pages.PageCountY / PrintingConstants.EXPORT_BASE_DPI * dpi);

                var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                bmp.SetResolution(dpi, dpi);

                var g = Graphics.FromImage(bmp);
                g.PageUnit = GraphicsUnit.Display;
                if (dlg.FilterIndex != 1)
                {
                    g.Clear(Color.White);
                }

                DrawToBitmap(g, elements);

                if (Cancelled)
                {
                    MessageService.Current.Info("Export operation was aborted by user.");
                    return;
                }
                
                var format = ImageFormat.Png;
                switch (dlg.FilterIndex)
                {
                    case 2:
                        format = ImageFormat.Tiff;
                        break;
                    case 3:
                        format = ImageFormat.Jpeg;
                        break;
                    case 4:
                        format = ImageFormat.Bmp;
                        break;
                }

                bmp.Save(dlg.FileName, format);
                MessageService.Current.Info("Export operation has completed successfully.");
            }
        }

        private static PrintDialog CreatePrintDialog(LayoutPages pages, PrinterSettings printerSettings)
        {
            var pd = new PrintDialog();
            bool hasSelection = pages.SelectedCount > 0;
            pd.AllowSelection = hasSelection;
            pd.AllowSomePages = true;
            pd.PrinterSettings = printerSettings;
            pd.PrinterSettings.FromPage = 1;
            pd.PrinterSettings.ToPage = 1;
            pd.PrinterSettings.PrintRange = hasSelection ? PrintRange.Selection : PrintRange.AllPages;
            return pd;
        }

        /// <summary>
        /// Runs printing including printer selection
        /// </summary>
        internal static void Print(
            LayoutPages pages,
            PrinterSettings printerSettings,
            List<LayoutElement> elements,
            int pageWidth,
            int pageHeight)
        {
            var pd = CreatePrintDialog(pages, printerSettings);

            _pages = pages;
            _elements = elements;
            _pageWidth = pageWidth;
            _pageHeight = pageHeight;

            if (pd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            SchedulePages(pages, pd);

            var doc = new PrintDocument { OriginAtMargins = true, PrinterSettings = printerSettings };
            doc.PrintPage += PrintNextPage;
            doc.PrintController = new StandardPrintController();

            doc.Print();
        }

        private static void SchedulePages(LayoutPages pages, PrintDialog pd)
        {
            pages.MarkUnprinted();
            switch (pd.PrinterSettings.PrintRange)
            {
                case PrintRange.AllPages:
                    foreach (var page in pages)
                    {
                        page.Scheduled = true;
                    }
                    break;
                case PrintRange.Selection:
                    foreach (var page in pages)
                    {
                        page.Scheduled = page.Selected;
                    }
                    break;
                case PrintRange.SomePages:
                    foreach (var page in pages)
                    {
                        var index = pages.PageIndex(page);
                        page.Scheduled = (index >= pd.PrinterSettings.FromPage && index <= pd.PrinterSettings.ToPage);
                    }
                    break;
            }
        }

        /// <summary>
        /// This event handler is fired by the print document when it prints and draws the layout to the print document
        /// </summary>
        private static void PrintNextPage(object sender, PrintPageEventArgs e)
        {
            var page = _pages.FirstOrDefault(p => (p.Scheduled || !_pages.HasScheduled) && !p.Printed);
            if (page != null)
            {
                PrintPage(page.X, page.Y, e.Graphics);
            }

            e.HasMorePages = _pages.HasUnprintedPages;
        }

        /// <summary>
        /// Draws a page to the specified graphics object
        /// </summary>
        private static void PrintPage(int pageX, int pageY, Graphics g)
        {
            var page = _pages.GetPageRectange(pageX, pageY);
            var list =
                _elements.Where(
                    el =>
                    !((el.Location.X + el.Size.Width < page.X) || (el.Location.X > page.X + page.Width) ||
                      (el.Location.Y + el.Size.Height < page.Y) || (el.Location.Y > page.Y + page.Height)));
            foreach (var el in list.Reverse())
            {
                var r = new RectangleF(el.Rectangle.X, el.Rectangle.Y, el.Rectangle.Width, el.Rectangle.Height);

                var matrix = g.Transform;

                // calculate intersection with page rectangle
                RectangleF clip = new Rectangle(0, 0, 5000, 5000);

                float offsetX, offsetY;

                if (el is LayoutMap)
                {
                    clip.X = Math.Max(r.X, page.X);
                    clip.Y = Math.Max(r.Y, page.Y);
                    clip.Width = Math.Min(r.Right, page.Right) - clip.X;
                    clip.Height = Math.Min(r.Bottom, page.Bottom) - clip.Y;

                    g.PageScale = 1.0f;
                    g.PageUnit = GraphicsUnit.Display;

                    // all elements should be drawn from 0;0 as coordinates system begins from the point of their location
                    offsetX = (clip.X - page.X);
                    offsetY = (clip.Y - page.Y);
                    g.TranslateTransform(offsetX, offsetY);
                    g.SetClip(new RectangleF(0.0f, 0.0f, clip.Width + 1.0f, clip.Height + 1.0f));

                    // first shedule tile loading for the page
                    var mapEl = el as LayoutMap;

                    // wait for the response from tilesLoaded and perform drawing
                    mapEl.Draw(g, clip, false);
                }
                else
                {
                    if (page.X > r.X) clip.X = Math.Max(r.X, page.X);
                    if (page.Y > r.Y) clip.Y = Math.Max(r.Y, page.Y);
                    if (page.Right < r.Right) clip.Width = Math.Min(r.Right, page.Right) - Math.Max(r.X, page.X);
                    if (page.Bottom < r.Bottom) clip.Height = Math.Min(r.Bottom, page.Bottom) - Math.Max(r.Y, page.Y);

                    // we are printing the whole element; origin may be at some other page, clipping rectangle will ensure page margins
                    g.PageUnit = GraphicsUnit.Display;
                    g.PageScale = 1f;

                    offsetX = (r.X - page.X);
                    offsetY = (r.Y - page.Y);

                    g.TranslateTransform(offsetX, offsetY);

                    offsetX = offsetX > 0 ? 0f : -offsetX;
                    offsetY = offsetY > 0 ? 0f : -offsetY;

                    g.ResetClip();

                    if (_useElementClipping)
                    {
                        g.SetClip(new RectangleF(offsetX, offsetY, clip.Width, clip.Height));
                    }

                    el.DrawElement(g, true, false);
                    g.ResetTransform();
                }
                g.Transform = matrix;
            }

            _pages.GetPage(pageX, pageY).Printed = true;
        }
    }
}