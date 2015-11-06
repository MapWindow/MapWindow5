using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Printing.Model;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Plugins.Services;

namespace MW5.Plugins.Printing.Helpers
{
    /// <summary>
    /// Exports layout int a file.
    /// </summary>
    internal static class ExportHelper
    {
        public static bool Cancelled = false;
        public static readonly AutoResetEvent autoEvent = new AutoResetEvent(false);

        /// <summary>
        /// Exports to bitmap at specified dpi
        /// </summary>
        internal static void ExportToBitmap(LayoutPages pages, IEnumerable<LayoutElement> elements)
        {
            Cancelled = false;

            int filterIndex;
            string filename;

            if (!ChooseFilename(out filename, out filterIndex))
            {
                return;
            }

            const float dpi = 96; // TODO: choose

            var bmp = CreateBitmap(pages, dpi);

            var g = Graphics.FromImage(bmp);
            
            g.PageUnit = GraphicsUnit.Display;
            if (filterIndex != 1)
            {
                g.Clear(Color.White);
            }

            DrawToBitmap(g, elements);

            if (Cancelled)
            {
                MessageService.Current.Info("Export operation was aborted by user.");
                return;
            }

            bmp.Save(filename, ChooseFormat(filterIndex));

            MessageService.Current.Info("Export operation has completed successfully.");
        }

        /// <summary>
        /// Creates ouput bitmap to accomodate all the pages
        /// </summary>
        /// <param name="pages">The pages.</param>
        /// <param name="dpi">The dpi.</param>
        private static Bitmap CreateBitmap(LayoutPages pages, float dpi)
        {
            float pageWidth = pages.PageWidth;
            float pageHeight = pages.PageHeight;

            var width = (int)(pageWidth * pages.PageCountX / PrintingConstants.EXPORT_BASE_DPI * dpi);
            var height = (int)(pageHeight * pages.PageCountY / PrintingConstants.EXPORT_BASE_DPI * dpi);

            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            bmp.SetResolution(dpi, dpi);

            return bmp;
        }

        /// <summary>
        /// Chooses the filename to save bitmap.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="filterIndex">Index of the filter.</param>
        private static bool ChooseFilename(out string filename, out int filterIndex)
        {
            filterIndex = -1;
            filename = string.Empty;

            using (var dlg = new SaveFileDialog { Filter = PrintingConstants.EXPORT_FILTER })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    filterIndex = dlg.FilterIndex;
                    filename = dlg.FileName;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Chooses output image format.
        /// </summary>
        /// <param name="filterIndex">Index of the filter.</param>
        private static ImageFormat ChooseFormat(int filterIndex)
        {
            var format = ImageFormat.Png;
            switch (filterIndex)
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

            return format;
        }

        /// <summary>
        /// Draws the whole contents of the control to the specified graphics object
        /// </summary>
        private static void DrawToBitmap(Graphics g, IEnumerable<LayoutElement> layoutElements)
        {
            // TODO: revisit
            var list = layoutElements;
            list = list.Reverse();

            float dpiRatio = g.DpiX / PrintingConstants.EXPORT_BASE_DPI; // layout units = 1/100 inch
            var dpi = (int)g.DpiX;

            foreach (var el in list)
            {
                var r = new RectangleF(el.Rectangle.X, el.Rectangle.Y, el.Rectangle.Width, el.Rectangle.Height);
                var rectNew = new RectangleF(r.X * dpiRatio, r.Y * dpiRatio, r.Width * dpiRatio, r.Height * dpiRatio);

                var matrix = g.Transform;

                if (el is LayoutMap)
                {
                    g.PageScale = g.DpiX / PrintingConstants.EXPORT_BASE_DPI; // 1.0f

                    //pixels for displays, 1/100 inch for printers
                    g.PageUnit = GraphicsUnit.Display;

                    g.TranslateTransform(rectNew.X, rectNew.Y);

                    if (PrintingConstants.UseElementClipping)
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

                    mapEl.Print(g, r, true);
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

                    if (PrintingConstants.UseElementClipping)
                    {
                        g.SetClip(new RectangleF(0.0f, 0.0f, rectNew.Width + 1.0f, rectNew.Height + 1.0f));
                    }

                    el.DrawElement(g, true, true);
                }

                g.ResetClip();
                g.Transform = matrix;
            }
        }
    }
}
