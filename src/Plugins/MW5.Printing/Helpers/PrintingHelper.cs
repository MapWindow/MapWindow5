// -------------------------------------------------------------------------------------------
// <copyright file="PrintingHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

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
using MW5.Shared;

namespace MW5.Plugins.Printing.Helpers
{
    internal static class PrintingHelper
    {
        private static LayoutPages _pages;
        private static List<LayoutElement> _elements;

        /// <summary>
        /// Runs printing including printer selection
        /// </summary>
        public static void Print(LayoutPages pages, PrinterSettings printerSettings, List<LayoutElement> elements)
        {
            var pd = CreatePrintDialog(pages, printerSettings);

            _pages = pages;
            _elements = elements;

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

        /// <summary>
        /// Creates the print dialog.
        /// </summary>
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
        /// Gets elements within certai page.
        /// </summary>
        private static IEnumerable<LayoutElement> GetElementsWithinPage(int pageX, int pageY)
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
        /// Renders a page to the specified graphics object
        /// </summary>
        private static void PrintPage(int pageX, int pageY, Graphics g)
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
                    if (PrintingConstants.UseElementClipping)
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
    }
}