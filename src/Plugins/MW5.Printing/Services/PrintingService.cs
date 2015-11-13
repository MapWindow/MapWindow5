// -------------------------------------------------------------------------------------------
// <copyright file="PrintingService.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins.Printing.Services
{
    internal class PrintingService: IDisposable
    {
        private readonly bool _useElementClipping;
        private LayoutPages _pages;
        private IEnumerable<LayoutElement> _elements;
        public event EventHandler<PrintEventArgs> EndPrint;

        public PrintingService()
        {
            _useElementClipping = false;
        }

        /// <summary>
        /// Runs printing including printer selection
        /// </summary>
        public void Print(LayoutPages pages, PrinterSettings printerSettings, IEnumerable<LayoutElement> elements)
        {
            var pd = CreateAndShowPrintDialog(pages, printerSettings);

            if (pd == null)
            {
                return;
            }

            _pages = pages;
            _elements = elements;

            SchedulePages(pages, pd);

            var _printDocument = new PrintDocument { OriginAtMargins = true, PrinterSettings = printerSettings };
            _printDocument.PrintPage += PrintNextPage;
            _printDocument.EndPrint += (s, e) => DelegateHelper.FireEvent(this, EndPrint, e);
            _printDocument.PrintController = new StandardPrintController();

            _printDocument.Print();
        }

        /// <summary>
        /// Prints to XPS file.
        /// </summary>
        public bool PrintToXpsFile(LayoutPages pages, PrinterSettings printerSettings, IEnumerable<LayoutElement> elements, string filename)
        {
            _pages = pages;
            _elements = elements;

            const string printer = "Microsoft XPS Document Writer";
            if (!PrinterSettings.InstalledPrinters.OfType<string>().Contains(printer))
            {
                MessageService.Current.Info("Failed to find \"Microsoft XPS Document Writer\" which is used for PDF conversion.");
                return false;
            }

            printerSettings.PrinterName = printer;
            printerSettings.PrintFileName = filename;
            printerSettings.PrintToFile = true;

            var _printDocument = new PrintDocument { OriginAtMargins = true, PrinterSettings = printerSettings };
            _printDocument.PrintPage += PrintNextPage;
            _printDocument.EndPrint += (s, e) => DelegateHelper.FireEvent(this, EndPrint, e);
            _printDocument.PrintController = new StandardPrintController();

            _printDocument.Print();

            return true;
        }

        /// <summary>
        /// Creates the print dialog.
        /// </summary>
        private PrintDialog CreateAndShowPrintDialog(LayoutPages pages, PrinterSettings printerSettings)
        {
            var pd = new PrintDialog();
            bool hasSelection = pages.SelectedCount > 0;
            pd.AllowSelection = hasSelection;
            pd.AllowSomePages = true;
            pd.PrinterSettings = printerSettings;
            pd.PrinterSettings.FromPage = 1;
            pd.PrinterSettings.ToPage = 1;
            pd.PrinterSettings.PrintRange = hasSelection ? PrintRange.Selection : PrintRange.AllPages;

            return pd.ShowDialog() == DialogResult.OK ? pd : null;
        }

        /// <summary>
        /// Gets elements within certai page.
        /// </summary>
        private IEnumerable<LayoutElement> GetElementsWithinPage(int pageX, int pageY)
        {
            var page = _pages.GetPageRectange(pageX, pageY);

            foreach (var el in _elements)
            {
                if (el.IntersectsWith(page))
                {
                    yield return el;
                }
            }
        }

        /// <summary>
        /// This event handler is fired by the print document when it prints and draws the layout to the print document
        /// </summary>
        private void PrintNextPage(object sender, PrintPageEventArgs e)
        {
            var page = _pages.FirstOrDefault(p => (p.Scheduled || !_pages.HasScheduled) && !p.Printed);
            if (page != null)
            {
                PrintPage(page.X, page.Y, e.Graphics);
            }

            e.HasMorePages = _pages.HasUnprintedPages;
        }

        /// <summary>
        /// Renders a page to the specified graphics object
        /// </summary>
        private void PrintPage(int pageX, int pageY, Graphics g)
        {
            var page = _pages.GetPageRectange(pageX, pageY);

            var list = GetElementsWithinPage(pageX, pageY);

            g.PageScale = 1f;
            g.PageUnit = GraphicsUnit.Display;

            foreach (var el in list.Reverse())
            {
                var matrix = g.Transform;

                var r = el.Rectangle;
                var clip = RectangleHelper.GetIntersection(page, r);

                float offsetX = el is LayoutMap ? clip.X - page.X : r.X - page.X;
                float offsetY = el is LayoutMap ? clip.Y - page.Y : r.Y - page.Y;

                g.TranslateTransform(offsetX, offsetY);

                if (el is LayoutMap)
                {
                    // origin is a beginning of map on this page
                    var translatedClip = new RectangleF(0.0f, 0.0f, clip.Width + 1.0f, clip.Height + 1.0f);

                    g.SetClip(translatedClip);

                    // wait for the response from tilesLoaded and perform drawing
                    (el as LayoutMap).Print(g, clip, false);
                }
                else
                {
                    // origin is beginning of element (even if lies outside current page)
                    if (_useElementClipping)
                    {
                        offsetX = offsetX > 0 ? 0f : -offsetX;
                        offsetY = offsetY > 0 ? 0f : -offsetY;

                        g.SetClip(new RectangleF(offsetX, offsetY, clip.Width, clip.Height));
                    }

                    el.DrawElement(g, true, false);
                }

                g.Transform = matrix;
                g.ResetClip();
            }

            _pages.GetPage(pageX, pageY).Printed = true;
        }

        /// <summary>
        /// Schedules which pages should be rendered depending on print dialog.
        /// </summary>
        private void SchedulePages(LayoutPages pages, PrintDialog pd)
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
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            //_printDocument.Dispose();
        }
    }
}