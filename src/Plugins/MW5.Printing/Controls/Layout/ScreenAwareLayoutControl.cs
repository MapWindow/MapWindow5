// -------------------------------------------------------------------------------------------
// <copyright file="ScreenAwareLayoutControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Shared;

namespace MW5.Plugins.Printing.Controls.Layout
{
    [ToolboxItem(false)]
    public class ScreenAwareLayoutControl : ZoomableLayoutControl
    {
        private readonly SolidBrush _selectionBrush;
        private readonly Pen _selectionPen;
        protected RectangleF _mouseBox;
        protected MouseMode _mouseMode;
        protected Bitmap _resizeTempBitmap;
        protected bool _showPageNumbers;

        protected ScreenAwareLayoutControl()
        {
            _selectionBrush = new SolidBrush(Color.Transparent);
            _selectionPen = new Pen(Color.Orange, 2f);
            DrawingQuality = SmoothingMode.HighQuality;
        }

        /// <summary>
        /// Gets or sets the smoothing mode to use to draw the map
        /// </summary>
        public SmoothingMode DrawingQuality { get; set; }

        public LayoutMap MainMap
        {
            get { return _layoutElements.OfType<LayoutMap>().FirstOrDefault(map => map.MainMap); }
        }

        public bool MutipleMaps
        {
            get { return _layoutElements.OfType<LayoutMap>().Count() > 1; }
        }

        /// <summary>
        /// Sets a boolean flag indicating if margins should be shown.
        /// </summary>
        public bool ShowMargins
        {
            get { return Pages.ShowMargins; }
            set
            {
                Pages.ShowMargins = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets whether page numbers will be displayed
        /// </summary>
        public virtual bool ShowPageNumbers
        {
            get { return _showPageNumbers; }
            set
            {
                _showPageNumbers = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Drawing code
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!Initialized)
            {
                return;
            }

            //Deal with invalidate rectangles that have a size of 0
            if (e.ClipRectangle.Width <= 0 || e.ClipRectangle.Height <= 0)
            {
                return;
            }

            //Store the cursor so we can show an hour glass while drawing
            var oldCursor = Cursor;

            e.Graphics.SmoothingMode = SmoothingMode.None;

            DrawControl(e.Graphics, e.ClipRectangle);

            //resets the cursor cuz some times it get jammed
            Cursor = oldCursor;
        }

        /// <summary>
        /// Prevents flicker from any default on paint background operations
        /// </summary>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        /// <summary>
        /// Main rendring routine, uses double buffering.
        /// </summary>
        private void DrawControl(Graphics g, Rectangle clipRectangle)
        {
            //Updates the invalidation rectangle to be a bit bigger to deal with overlaps
            var invalRect = Rectangle.Inflate(clipRectangle, 5, 5);
            if (invalRect.X < 0) invalRect.X = 0;
            if (invalRect.Y < 0) invalRect.Y = 0;

            //We paint to a temporary buffer to avoid flickering
            using (var tempBuffer = new Bitmap(invalRect.Width, invalRect.Height, PixelFormat.Format24bppRgb))
            {
                using (var graph = Graphics.FromImage(tempBuffer))
                {
                    graph.TranslateTransform(-invalRect.X, -invalRect.Y);
                    graph.SmoothingMode = DrawingQuality;

                    graph.FillRectangle(Brushes.DarkGray, invalRect);

                    DrawPages(graph);

                    for (int i = LayoutElements.Count - 1; i >= 0; i--)
                    {
                        DrawElement(graph, LayoutElements[i], invalRect, i);
                    }

                    DrawSelectionRectangles(graph);

                    DrawMainMap(graph);

                    DrawPageNumbers(graph);

                    DrawRubberBand(graph);

                    // draws buffer on the screen
                    g.SmoothingMode = DrawingQuality;
                    g.DrawImage(tempBuffer, invalRect, new RectangleF(0f, 0f, invalRect.Width, invalRect.Height),
                        GraphicsUnit.Pixel);
                }
            }
        }

        /// <summary>
        /// Draws a single element of the layout.
        /// </summary>
        private void DrawElement(Graphics graph, LayoutElement le, Rectangle invalRect, int index)
        {
            bool panning = _mouseMode == MouseMode.PanMap && IsSelected(index) && le is LayoutMap &&
                           _selectedLayoutElements.Count == 1;

            if (!panning && DrawMapResizing(index, graph))
            {
                return;
            }

            float x = panning ? _paperLocation.X + _mouseBox.Width : _paperLocation.X;
            float y = panning ? _paperLocation.Y + _mouseBox.Height : _paperLocation.Y;

            graph.TranslateTransform(x, y);
            graph.ScaleTransform(ScreenHelper.LogicToScreenDpi * _zoom, ScreenHelper.LogicToScreenDpi * _zoom);

            le.DrawElement(graph, false, false);

            graph.ResetTransform();
            graph.TranslateTransform(-invalRect.X, -invalRect.Y);
        }

        /// <summary>
        /// Draws a tag for the main map.
        /// </summary>
        private void DrawMainMap(Graphics g)
        {
            bool multipleMaps = MutipleMaps;
            if (multipleMaps)
            {
                var mainMap = MainMap;
                if (mainMap != null)
                {
                    var leRect = PaperToScreen(mainMap.Rectangle);
                    const string s = "Main map";
                    var size = g.MeasureString(s, Font);
                    var tempR = new RectangleF(leRect.Location, size);
                    g.FillRectangle(Brushes.White, tempR);
                    g.DrawString(s, Font, new SolidBrush(Color.Black), tempR);
                }
            }
        }

        /// <summary>
        /// Draws map element during resizing.
        /// </summary>
        private bool DrawMapResizing(int index, Graphics graph)
        {
            if (IsSelected(index) && _resizeTempBitmap != null)
            {
                var el = _selectedLayoutElements[0];

                var papRect = PaperToScreen(el.Rectangle);
                var clipRect = papRect.FloatRectangleToInt();

                switch (el.ResizeStyle)
                {
                    case ResizeStyle.StretchToFit:
                        graph.DrawImage(_resizeTempBitmap, clipRect);
                        break;
                    case ResizeStyle.NoScaling:
                        graph.DrawImageUnscaled(_resizeTempBitmap, clipRect);
                        break;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Draws the page numbers.
        /// </summary>
        private void DrawPageNumber(Graphics g, RectangleF paperRect, int pageX, int pageY)
        {
            float fontSize = _pages.PageWidth > _pages.PageHeight
                                 ? _pages.PageWidth /* looks suspicios */
                                 : (float)_pages.PageHeight / 10 * _zoom;

            var font = new Font(Font.FontFamily, fontSize);

            var numbersColor = Color.Gray;
            var color = _pages.GetPage(pageX, pageY).Selected ? Color.Orange : numbersColor;

            var brush = new SolidBrush(color);
            var ellipsePen = new Pen(color) { Width = 40 * _zoom };

            int pageId = pageY * _pages.PageCountX + pageX + 1;

            g.DrawString(pageId.ToString(CultureInfo.InvariantCulture), font, brush, paperRect,
                GdiPlusHelper.CenterFormat);

            var size = (int)(fontSize * 3.0);

            var x = (int)(paperRect.X + paperRect.Width / 2f - size / 2.0f);
            var y = (int)(paperRect.Y + paperRect.Height / 2f - size / 2.0f);

            var loc = new Point(x, y);
            var r = new Rectangle(loc, new Size(size, size));

            g.DrawEllipse(ellipsePen, r);
        }

        /// <summary>
        /// Draws page numbers.
        /// </summary>
        private void DrawPageNumbers(Graphics g)
        {
            if (!_showPageNumbers) return;

            for (int i = 0; i < _pages.PageCountX; i++)
            {
                for (int j = 0; j < _pages.PageCountY; j++)
                {
                    float x = _pages.GetPagePositionX(i);
                    float y = _pages.GetPagePositionY(j);

                    var paperRect = PaperToScreen(x, y, _pages.PageWidth, _pages.PageHeight);

                    // page number
                    DrawPageNumber(g, paperRect, i, j);
                }
            }
        }

        /// <summary>
        /// Draws pages of the layout control
        /// </summary>
        private void DrawPages(Graphics g)
        {
            var pen = new Pen(Color.Black) { DashStyle = DashStyle.Dash };

            // TODO: display margins

            // the background of pages
            var rect = PaperToScreen(0, 0, _pages.TotalWidth, _pages.TotalHeight);
            g.FillRectangle(Brushes.White, rect);

            for (int i = 0; i < _pages.PageCountX; i++)
            {
                for (int j = 0; j < _pages.PageCountY; j++)
                {
                    float x = _pages.GetPagePositionX(i);
                    float y = _pages.GetPagePositionY(j);

                    var paperRect = PaperToScreen(x, y, _pages.PageWidth, _pages.PageHeight);

                    g.DrawLine(pen, paperRect.Left, paperRect.Top, paperRect.Left + paperRect.Width, paperRect.Top);
                    g.DrawLine(pen, paperRect.Left, paperRect.Top, paperRect.Left, paperRect.Top + paperRect.Height);

                    // margin
                    if (ShowMargins)
                    {
                        var margins = _printerSettings.DefaultPageSettings.Margins;

                        paperRect = PaperToScreen(x + margins.Left, y + margins.Top,
                            _pages.PageWidth - margins.Left - margins.Right,
                            _pages.PageHeight - margins.Top - margins.Bottom);

                        g.DrawRectangle(Pens.LightGray, paperRect.X, paperRect.Y, paperRect.Width, paperRect.Height);
                    }
                }
            }

            // outside border
            g.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);
        }

        private void DrawRubberBand(Graphics g)
        {
            //If the users is dragging a select box or an insert box we draw it here
            if (_mouseMode == MouseMode.CreateSelection || _mouseMode == MouseMode.InsertNewElement)
            {
                var boxColor = _mouseMode == MouseMode.CreateSelection ? SystemColors.Highlight : Color.Orange;
                var outlinePen = new Pen(boxColor);
                using (var highlightBrush = new SolidBrush(Color.FromArgb(30, boxColor)))
                {
                    g.FillRectangle(highlightBrush, _mouseBox.X, _mouseBox.Y, _mouseBox.Width - 1, _mouseBox.Height - 1);
                    g.DrawRectangle(outlinePen, _mouseBox.X, _mouseBox.Y, _mouseBox.Width - 1, _mouseBox.Height - 1);
                }
            }
        }

        /// <summary>
        /// Draws the selection rectangle around each selected item
        /// </summary>
        private void DrawSelectionRectangles(Graphics g)
        {
            foreach (var layoutEl in _selectedLayoutElements.Where(el => el.Visible))
            {
                var leRect = PaperToScreen(layoutEl.Rectangle);
                var r = leRect.FloatRectangleToInt();
                g.DrawRectangle(_selectionPen, r);
                g.FillRectangle(_selectionBrush, r);
            }
        }
    }
}