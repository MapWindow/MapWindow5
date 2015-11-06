// -------------------------------------------------------------------------------------------
// <copyright file="LayoutPages.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using MW5.Plugins.Printing.Helpers;
using MW5.Shared;

namespace MW5.Plugins.Printing.Model
{
    public class LayoutPages : List<LayoutPage>
    {
        private int _pageCountX;
        private int _pageCountY;
        private int _pageHeight;
        private int _pageWidth;

        public LayoutPages()
        {
            PageCountX = 1;
            PageCountY = 1;

            MarkPageSizeDirty();
        }

        public bool HasScheduled
        {
            get { return this.Count(p => p.Scheduled) != 0; }
        }

        /// <summary>
        /// Do we have at least one selected page
        /// </summary>
        public bool HasSelection
        {
            get { return this.Count(p => p.Selected) != 0; }
        }

        /// <summary>
        /// Do we have any page left unprinted
        /// </summary>
        public bool HasUnprintedPages
        {
            get
            {
                if (!HasScheduled)
                {
                    return this.Count(p => !p.Printed) > 0;
                }

                return this.Count(p => !p.Printed && p.Scheduled) > 0;
            }
        }

        /// <summary>
        /// Returns total number of pages
        /// </summary>
        public int PageCount
        {
            get { return PageCountX * PageCountY; }
        }

        /// <summary>
        /// Number of horizontal pages
        /// </summary>
        public int PageCountX
        {
            get { return _pageCountX; }
            set
            {
                _pageCountX = value;
                UpdatePages();
            }
        }

        /// <summary>
        /// Number of vertical pages
        /// </summary>
        public int PageCountY
        {
            get { return _pageCountY; }
            set
            {
                _pageCountY = value;
                UpdatePages();
            }
        }

        /// <summary>
        /// Changes the number of pages in the layout.
        /// </summary>
        public void Resize(int pageCountX, int pageCountY)
        {
            if (pageCountX <= 0 || PageCountY <= 0 || pageCountX > 20 || pageCountY > 20)
            {
                Logger.Current.Warn("Unable to resize layout. Invalid number of pages: {0} × {1}.");
                return;
            }

            _pageCountX = pageCountX;
            _pageCountY = pageCountY;

            UpdatePages();
        }

        /// <summary>
        /// Gets a height of a single page in 1/100 of an inch
        /// </summary>
        public int PageHeight
        {
            get
            {
                if (_pageHeight == -1)
                {
                    _pageHeight = PageSettings.Landscape ? GetPaperWidth() : GetPaperHeight();
                }

                return _pageHeight;
            }
        }

        /// <summary>
        /// Gets a width of a single page in 1/100 of an inch
        /// </summary>
        public int PageWidth
        {
            get
            {
                if (_pageWidth == -1)
                {
                    _pageWidth = PageSettings.Landscape ? GetPaperHeight() : GetPaperWidth();
                }

                return _pageWidth;
            }
        }

        public int SelectedCount
        {
            get { return this.Count(p => p.Selected); }
        }

        /// <summary>
        /// Gets the height of the paper (all pages) in 1/100 of an inch
        /// </summary>
        public int TotalHeight
        {
            get { return PageHeight * PageCountY; }
        }

        /// <summary>
        /// Gets the width of the paper (all the pages) in 1/100 of an inch
        /// </summary>
        public int TotalWidth
        {
            get { return PageWidth * PageCountX; }
        }

        private PageSettings PageSettings
        {
            get { return PrinterManager.PageSettings; }
        }

        public LayoutPage GetPage(int pageIndexX, int pageIndexY)
        {
            int index = pageIndexY * PageCountX + pageIndexX;
            return index >= 0 && index < Count ? this[index] : null;
        }

        /// <summary>
        /// Gets index of page which corresponds to the specified position in paper coordinates
        /// </summary>
        public int GetPageIndex(float positionX)
        {
            for (int i = 0; i < 10; i++)
            {
                if (GetPagePositionX(i + 1) > positionX) return i;
            }
            return -1;
        }

        /// <summary>
        /// Returns X coordinate of page with specified index (in paper coordinates 1/100 of inch)
        /// </summary>
        public float GetPagePositionX(int pageIndex)
        {
            return pageIndex * PageWidth;
        }

        /// <summary>
        /// Returns Y coordinate of page with specified index (in paper coordinates 1/100 of inch)
        /// </summary>
        public float GetPagePositionY(int pageIndex)
        {
            return pageIndex * PageHeight;
        }

        /// <summary>
        /// Returns page rectangle in paper coordinates (1/100 of inch)
        /// </summary>
        public Rectangle GetPageRectange(int x, int y)
        {
            return new Rectangle(x * PageWidth, y * PageHeight, PageWidth, PageHeight);
        }

        public void MarkPageSizeDirty()
        {
            _pageHeight = -1;
            _pageWidth = -1;
        }

        public void MarkUnprinted()
        {
            foreach (var page in this)
            {
                page.Printed = false;
                page.Scheduled = false;
            }
        }

        /// <summary>
        /// Finds page located at specific screen coordinates
        /// </summary>
        public LayoutPage PageByClick(PointF pointPaper)
        {
            var x = (int)Math.Floor((pointPaper.X / PageWidth));
            var y = (int)Math.Floor((pointPaper.Y / PageHeight));

            return GetPage(x, y);
        }

        public int PageIndex(LayoutPage page)
        {
            return page.Y * PageCountX + page.X + 1;
        }

        /// <summary>
        /// Returns user readable string with selected pages
        /// </summary>
        public override string ToString()
        {
            if (this.Count(p => p.Selected) == 0)
            {
                return Count > 1 ? string.Format("{0}-{1}", 1, Count) : "1";
            }

            var builder = new StringBuilder();
            int groupStart = 0;

            for (int i = 0; i < Count - 1; i++)
            {
                if (this[i].Selected)
                {
                    if (this[i + 1].Selected && groupStart == -1)
                    {
                        groupStart = i + 1;
                    }
                    else
                    {
                        if (builder.Length > 0)
                        {
                            builder.Append(", ");
                        }

                        builder.Append((i + 1).ToString(CultureInfo.InvariantCulture));
                    }
                }
                else if (groupStart != 0)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.AppendFormat("{0}-{1}", groupStart, i + 1);
                    groupStart = 0;
                }
            }

            return builder.ToString();
        }

        private int GetPaperHeight()
        {
            try
            {
                var sett = PageSettings;

                return sett.PaperSize.Height - sett.Margins.Top - sett.Margins.Bottom;
            }
            catch (InvalidPrinterException)
            {
                return 1169;
            }
        }

        private int GetPaperWidth()
        {
            try
            {
                var sett = PageSettings;

                return sett.PaperSize.Width - sett.Margins.Left - sett.Margins.Right;
            }
            catch (InvalidPrinterException)
            {
                return 827;
            }
        }

        /// <summary>
        /// Updates a list of pages when number of pages changes
        /// </summary>
        private void UpdatePages()
        {
            Clear();

            for (int y = 0; y < PageCountY; y++)
            {
                for (int x = 0; x < PageCountX; x++)
                {
                    Add(new LayoutPage { Selected = false, X = x, Y = y });
                }
            }
        }
    }
}