// -------------------------------------------------------------------------------------------
// <copyright file="ScreenAwareLayoutControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
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
        private Bitmap _screenBuffer;
        private Bitmap _tempBuffer;
        protected Point _mousePosition;
        private const int _rulerWidth = 18;
        private bool _showRulers;

        protected ScreenAwareLayoutControl()
        {
            _selectionBrush = new SolidBrush(Color.Transparent);
            _selectionPen = new Pen(Color.Orange, 2f);
            _selectionPen.DashStyle = DashStyle.Dash;

            _showMargins = true;
            _showRulers = true;
            DrawingQuality = SmoothingMode.HighQuality;
        }

        /// <summary>
        /// Gets or sets the smoothing mode to use to draw the map
        /// </summary>
        public SmoothingMode DrawingQuality { get; set; }

        public bool ShowRulers
        {
            get { return _showRulers; }
            set
            {
                _showRulers = value;
                DoInvalidate();
            }
        }

        public Color SelectionColor
        {
            get { return _selectionPen.Color; }
            set
            {
                _selectionPen.Color = value;
                DoInvalidate();
            }
        }

        /// <summary>
        /// Sets a boolean flag indicating if margins should be shown.
        /// </summary>
        public bool ShowMargins
        {
            get { return _showMargins; }
            set
            {
                _showMargins = value;
                DoInvalidate();
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
                DoInvalidate();
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

            // running full redraw
            if (_fullRedraw || _screenBuffer == null)
            {
                _fullRedraw = false;
                DrawControl(e.ClipRectangle);

                e.Graphics.SmoothingMode = DrawingQuality;
            }

            if (_screenBuffer != null)
            {
                if (_showRulers)
                {
                    if (_tempBuffer == null || _tempBuffer.Width != _screenBuffer.Width ||
                        _tempBuffer.Height != _screenBuffer.Height)
                    {
                        _tempBuffer = new Bitmap(_screenBuffer.Width, _screenBuffer.Height, _screenBuffer.PixelFormat);
                    }

                    // adding guides
                    using (var g = Graphics.FromImage(_tempBuffer))
                    {
                        g.DrawImage(_screenBuffer, 0, 0);
                        DrawGuides(g);
                    }

                    // drawing buffer on the screen
                    e.Graphics.DrawImage(_tempBuffer, 0, 0);
                }
                else
                {
                    RecycleTempBuffer();
                    e.Graphics.DrawImage(_screenBuffer, 0, 0);
                }
            }

            Cursor = oldCursor;
        }

        private void RecycleTempBuffer()
        {
            if (_tempBuffer != null)
            {
                _tempBuffer.Dispose();
                _tempBuffer = null;
            }
        }

        private void DrawGuides(Graphics g)
        {
            g.DrawLine(Pens.Red, _mousePosition.X, 0, _mousePosition.X, _rulerWidth);
            g.DrawLine(Pens.Red, 0, _mousePosition.Y, _rulerWidth, _mousePosition.Y);
        }

        /// <summary>
        /// Prevents flicker from any default on paint background operations
        /// </summary>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        private void RecycleScreenBuffer()
        {
            if (_screenBuffer != null)
            {
                _screenBuffer.Dispose();
                _screenBuffer = null;
            }
        }

        /// <summary>
        /// Main rendring routine, uses double buffering.
        /// </summary>
        private void DrawControl(Rectangle clipRectangle)
        {
            //Updates the invalidation rectangle to be a bit bigger to deal with overlaps
            var invalRect = Rectangle.Inflate(clipRectangle, 5, 5);

            if (invalRect.X < 0) invalRect.X = 0;
            if (invalRect.Y < 0) invalRect.Y = 0;

            RecycleScreenBuffer();

            //We paint to a temporary buffer to avoid flickering
            _screenBuffer = new Bitmap(invalRect.Width, invalRect.Height, PixelFormat.Format24bppRgb);

            using (var graph = Graphics.FromImage(_screenBuffer))
            {
                graph.TranslateTransform(-invalRect.X, -invalRect.Y);
                graph.SmoothingMode = DrawingQuality;

                graph.FillRectangle(Brushes.DarkGray, invalRect);

                DrawPages(graph);

                for (int i = _layoutElements.Count - 1; i >= 0; i--)
                {
                    DrawElement(graph, _layoutElements[i], invalRect, i);
                }

                DrawSelectionRectangles(graph);

                DrawMainMapLabel(graph);

                DrawPageNumbers(graph);

                DrawRubberBand(graph);

                if (_showRulers)
                {
                    DrawRulers(graph);
                }
            }
        }

        private void DrawRulersFrame(Graphics g, Pen pen, int rulerWidth)
        {
            var brush = new SolidBrush(Color.WhiteSmoke);
            g.FillRectangle(brush, 0, 0, Width, rulerWidth);
            g.FillRectangle(brush, 0, 0, rulerWidth, Height);

            g.DrawLine(pen, 0, 0, 0, Height);
            g.DrawLine(pen, 0, 0, Width, 0);
            g.DrawLine(pen, rulerWidth, rulerWidth, rulerWidth, Height);
            g.DrawLine(pen, rulerWidth, rulerWidth, Width, rulerWidth);
        }

        /// <summary>
        /// Draws horizontal and verical rulers with paper size.
        /// </summary>
        private void DrawRulers(Graphics g)
        {
            var pen = Pens.Gray;

            DrawRulersFrame(g, pen, _rulerWidth );

            int step = ChooseRulerStep();

            var origin = ScreenToPaper(_rulerWidth, _rulerWidth);
            
            double ratio = ConfigHelper.GetUnitsConversionRatio(false);
            double x = origin.X * ratio;
            double y = origin.Y * ratio;

            origin = new PointF((float)(Math.Floor(x / step) * step), (float)(Math.Floor(y / step) * step));

            var originPaper = new PointF((float)(origin.X / ratio), (float)(origin.Y / ratio));

            var start = PaperToScreen(originPaper);

            DrawRuler(g, pen, Convert.ToInt32(origin.X), start.X, Width, _rulerWidth, step, false);
            
            // let's reuse the same rendering code for vertical ruler
            g.RotateTransform(90f);
            g.TranslateTransform(_rulerWidth, 0f, MatrixOrder.Append);

            DrawRuler(g, pen, Convert.ToInt32(origin.Y), start.Y, Height, _rulerWidth, step, true);

            g.ResetTransform();
        }

        /// <summary>
        /// Returns ruler step in 1/100 of an inch
        /// </summary>
        private int ChooseRulerStep()
        {
            float ratio = PixelsPerDot();
            double step = 1;

            int byTwo = 0;
            while (ratio * step < 60f)
            {
                step = byTwo < 2 ? step * 2 : step * 2.5;
                byTwo++;
                if (byTwo == 3) byTwo = 0;
            }

            return Convert.ToInt32(step);
        }

        /// <summary>
        /// Draws the ruler, eithe horizontal or vertical.
        /// </summary>
        private void DrawRuler(Graphics g, Pen pen, int paperStart, float screenStart, float screenEnd, float rulerWidth, int step, bool vertical)
        {
            float ratio = PixelsPerDot();
            float screenStep = step * ratio / 10f;

            var textBrush = Brushes.Black;

          
            float val = screenStart;
            while (val < screenEnd)
            {
                if (val > rulerWidth)
                {
                    g.DrawLine(pen, Convert.ToInt32(val), 0, Convert.ToInt32(val), rulerWidth);
                    g.DrawString(paperStart.ToString(CultureInfo.InvariantCulture), Font, textBrush, val + 1, vertical ? rulerWidth * 0.25f : 0);
                }

                for (int i = 0; i < 10; i++)
                {
                    int valTemp = Convert.ToInt32(val + screenStep * i);

                    if (valTemp < rulerWidth)
                    {
                        continue;
                    }

                    float size = Convert.ToInt32((i == 5) ? rulerWidth / 2f : rulerWidth * 0.75f);

                    if (vertical)
                    {
                        size = rulerWidth - size;
                    }

                    g.DrawLine(pen, valTemp, size, valTemp, (vertical ? 0f : rulerWidth));
                }

                val += screenStep * 10;
                paperStart += step;
            }
        }

        /// <summary>
        /// Draws a single element of the layout.
        /// </summary>
        private void DrawElement(Graphics g, LayoutElement le, Rectangle invalRect, int index)
        {
            bool panning = _mouseMode == MouseMode.PanMap && IsSelected(index) && le is LayoutMap &&
                           _selectedLayoutElements.Count == 1;

            if (!panning && DrawMapResizing(index, g))
            {
                return;
            }

            if (le is LayoutMap)
            {
                var pnt = PaperToScreen(le.LocationF);

                g.TranslateTransform(Convert.ToInt32(pnt.X), Convert.ToInt32(pnt.Y));
                
                if (panning)
                {
                    // setting clip to the original rectangle
                    var r = PaperToScreen(le.Rectangle);
                    g.SetClip(new RectangleF(0f, 0f, r.Width, r.Height));

                    pnt.X += _mouseBox.Width;
                    pnt.Y += _mouseBox.Height;

                    // translating to new origin of buffer
                    g.ResetTransform();
                    g.TranslateTransform(Convert.ToInt32(pnt.X), Convert.ToInt32(pnt.Y));    
                }

                g.ScaleTransform(_zoom, _zoom);
            }
            else
            {
                g.TranslateTransform(_paperLocation.X, _paperLocation.Y);

                g.ScaleTransform(ScreenHelper.LogicToScreenDpi * _zoom, ScreenHelper.LogicToScreenDpi * _zoom);    
            }
            
            le.DrawElement(g, false, false);

            g.ResetClip();
            g.ResetTransform();
            g.TranslateTransform(-invalRect.X, -invalRect.Y);
        }

        /// <summary>
        /// Draws a tag for the main map.
        /// </summary>
        private void DrawMainMapLabel(Graphics g)
        {
            if (_layoutElements.OfType<LayoutMap>().Count() > 1)
            {
                var mainMap = _layoutElements.OfType<LayoutMap>().FirstOrDefault(map => map.IsMain);
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

                graph.SetClip(clipRect);

                switch (el.ResizeStyle)
                {
                    case ResizeStyle.StretchToFit:
                        graph.DrawImage(_resizeTempBitmap, clipRect);
                        break;
                    case ResizeStyle.NoScaling:
                        graph.DrawImageUnscaled(_resizeTempBitmap, clipRect);
                        break;
                }

                graph.ResetClip();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Draws the page numbers.
        /// </summary>
        private void DrawPageNumber(Graphics g, RectangleF paperRect, int pageX, int pageY)
        {
            float fontSize = Math.Max(_pages.PageWidth, _pages.PageHeight);
            fontSize = fontSize / 10 * _zoom;

            var font = new Font(Font.FontFamily, fontSize);

            var color = _pages.GetPage(pageX, pageY).Selected ? Color.Orange : Color.Gray;

            var brush = new SolidBrush(color);
            var ellipsePen = new Pen(color) { Width = 40 * Math.Min(_zoom, 0.7f) };

            int pageId = pageY * _pages.PageCountX + pageX + 1;

            g.DrawString(pageId.ToString(CultureInfo.InvariantCulture), font, brush, paperRect, GdiPlusHelper.CenterFormat);

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

        private RectangleF GetPaperBoundsWithMargins()
        {
            var page = PrinterSettings.DefaultPageSettings;

            float width = _pages.TotalWidth + page.Margins.Left + page.Margins.Right;
            float height = _pages.TotalHeight + page.Margins.Top + page.Margins.Bottom;

            return PaperToScreen(-page.Margins.Left, -page.Margins.Top, width, height);
        }

        /// <summary>
        /// Draws pages of the layout control
        /// </summary>
        private void DrawPages(Graphics g)
        {
            var pen = new Pen(Color.Gray) { DashStyle = DashStyle.Dash };

            var rect = PaperToScreen(0, 0, _pages.TotalWidth, _pages.TotalHeight);
            var bounds = GetPaperBoundsWithMargins();

            g.FillRectangle(Brushes.White, ShowMargins ? bounds : rect);

            for (int i = 0; i < _pages.PageCountX; i++)
            {
                for (int j = 0; j < _pages.PageCountY; j++)
                {
                    float x = _pages.GetPagePositionX(i);
                    float y = _pages.GetPagePositionY(j);

                    var paperRect = PaperToScreen(x, y, _pages.PageWidth, _pages.PageHeight).ConvertToInt();

                    g.DrawLine(pen, paperRect.Left, paperRect.Top, paperRect.Left + paperRect.Width, paperRect.Top);
                    g.DrawLine(pen, paperRect.Left, paperRect.Top, paperRect.Left, paperRect.Top + paperRect.Height);
                }
            }

            // outside border
            var r = _showMargins ? bounds: rect;
            g.DrawRectangle(Pens.Black, r.X, r.Y, r.Width, r.Height);

            if (ShowMargins)
            {
                var rint = rect.ConvertToInt();
                g.DrawLine(pen, rint.Right, rint.Top, rint.Right, rint.Bottom);
                g.DrawLine(pen, rint.Left, rint.Bottom, rint.Right, rint.Bottom);
            }
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