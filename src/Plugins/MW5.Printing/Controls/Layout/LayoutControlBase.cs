// -------------------------------------------------------------------------------------------
// <copyright file="LayoutControlBase.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model;
using MW5.Shared;

namespace MW5.Plugins.Printing.Controls.Layout
{
    public partial class LayoutControlBase : UserControl
    {
        private const int OFFSET = 50;
        protected readonly LayoutPages _pages;
        private HScrollBar _hScrollBar;
        private Panel _hScrollBarPanel;
        protected bool _initialized = false;
        protected PointF _paperLocation; //The location of the paper within the screen coordinates
        protected PrinterSettings _printerSettings;
        protected bool _suppressScrollbarUpdate = false;
        private VScrollBar _vScrollBar;
        protected float _zoom; //The zoom of the paper

        public LayoutControlBase()
        {
            _pages = new LayoutPages();

            InitPrinterSettings();

            InitializeComponent();

            Resize += LayoutControlResize;

            _zoom = 1;
        }

        public event EventHandler PageSettingsChanged;

        public LayoutPages Pages
        {
            get { return _pages; }
        }

        public PrinterSettings PrinterSettings
        {
            get { return _printerSettings; }
            set
            {
                _printerSettings = value;
                _pages.MarkPageSizeDirty();
                DelegateHelper.FireEvent(this, PageSettingsChanged);
            }
        }

        protected bool Initialized
        {
            get { return _initialized || DesignMode; }
        }

        /// <summary>
        /// Gets height of paper page in pixels
        /// </summary>
        protected int PaperHeightPixels
        {
            get { return Convert.ToInt32(_pages.TotalHeight * _zoom * ScreenHelper.LogicToScreenDpi); }
        }

        /// <summary>
        /// Gets width of a paper page in pixels
        /// </summary>
        protected int PaperWidthPixels
        {
            get { return Convert.ToInt32(_pages.TotalWidth * _zoom * ScreenHelper.LogicToScreenDpi); }
        }

        /// <summary>
        /// Height of the control with scrollbars
        /// </summary>
        protected int UsableHeight
        {
            get { return Height - (_hScrollBar.Visible ? _hScrollBar.Height : 0) - 4; }
        }

        /// <summary>
        /// Width of control without scrollbars
        /// </summary>
        protected int UsableWidth
        {
            get { return Width - (_vScrollBar.Visible ? _vScrollBar.Width : 0) - 4; }
        }

        /// <summary>
        /// Converts between a point in paper coordinats in 1/100th of an inch to screen coordinats
        /// </summary>
        /// <returns></returns>
        protected PointF PaperToScreen(PointF paper)
        {
            return PaperToScreen(paper.X, paper.Y);
        }

        /// <summary>
        /// Converts between a point in paper coordinats in 1/100th of an inch to screen coordinats
        /// </summary>
        /// <returns></returns>
        protected PointF PaperToScreen(float paperX, float paperY)
        {
            float screenX = (paperX * _zoom * ScreenHelper.LogicToScreenDpi) + _paperLocation.X;
            float screenY = (paperY * _zoom * ScreenHelper.LogicToScreenDpi) + _paperLocation.Y;
            return (new PointF(screenX, screenY));
        }

        /// <summary>
        /// Converts between a rectangle in paper coordinats in 1/100th of an inch to screen coordinats
        /// </summary>
        /// <returns></returns>
        protected RectangleF PaperToScreen(RectangleF paper)
        {
            return PaperToScreen(paper.X, paper.Y, paper.Width, paper.Height);
        }

        /// <summary>
        /// Converts a rectangle in screen coordinats to paper coordiants in 1/100 of an inch
        /// </summary>
        /// <returns></returns>
        protected RectangleF PaperToScreen(float paperX, float paperY, float paperW, float paperH)
        {
            var screenTL = PaperToScreen(paperX, paperY);
            var screenBR = PaperToScreen(paperX + paperW, paperY + paperH);
            return new RectangleF(screenTL.X, screenTL.Y, screenBR.X - screenTL.X, screenBR.Y - screenTL.Y);
        }

        /// <summary>
        /// Updates the scroll bars so the look and act right
        /// </summary>
        internal void UpdateScrollBars()
        {
            //if (Math.Abs(_zoom) < 1e-10)
            //{
            //    // zoom can be zero on older printer drivers don't divide by 0
            //    Logger.Current.Warn("Invalid zoom in ZoomableLayoutControl.UpdateScrollBars.");
            //    _zoom = 100;
            //}

            if (!Initialized || _suppressScrollbarUpdate)
            {
                return;
            }

            UpdateScrollbarScale();

            UpdateScrollbarPosition();
        }

        private void HScrollBarScroll(object sender, ScrollEventArgs e)
        {
            _paperLocation.X = _paperLocation.X + (e.OldValue - e.NewValue);
            Invalidate();
        }

        private void InitPrinterSettings()
        {
            var printerSettings = PrinterManager.PrinterSettings;
            printerSettings.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);

            // TODO: use service / helper for the conversion
            const double centimetersPerInch = 2.54;
            int width = Convert.ToInt32(1.0 / centimetersPerInch * 100 + 0.5);
            int height = Convert.ToInt32(0.5 / centimetersPerInch * 100 + 0.5);

            printerSettings.DefaultPageSettings.Margins = new Margins(width, width, height, height);

            PrinterSettings = printerSettings;
        }

        /// <summary>
        /// Fires whenever the ZoomableLayoutControl is resized
        /// </summary>
        private void LayoutControlResize(object sender, EventArgs e)
        {
            if (!Initialized)
            {
                return;
            }

            var rect = PaperToScreen(0F, 0F, _pages.TotalWidth, _pages.TotalHeight);

            // sets up the vertical scroll bars
            int controlWidth = UsableWidth;
            _paperLocation.X = rect.Width <= controlWidth ? (controlWidth - rect.Width) / 2F : 0;

            // sets up the horizontal scroll bar
            int controlHeight = UsableHeight;
            _paperLocation.Y = rect.Height <= controlHeight ? (controlHeight - rect.Height) / 2F : 0;

            UpdateScrollBars();

            //Invalidate the whole thing since we are moving this around
            // Invalidate();
        }

        private void UpdateScrollbarPosition()
        {
            var paper = PaperToScreen(0f, 0f, _pages.TotalWidth, _pages.TotalHeight);
            int left = OFFSET - (int)paper.Left;
            int top = OFFSET - (int)paper.Top;

            if (left < 0) left = 0;
            if (top < 0) top = 0;

            if (left > _hScrollBar.Maximum - _hScrollBar.LargeChange)
            {
                _hScrollBar.Value = _hScrollBar.Maximum - _hScrollBar.LargeChange;
            }
            else
            {
                _hScrollBar.Value = left;
            }

            if (top > _vScrollBar.Maximum - _vScrollBar.LargeChange)
            {
                _vScrollBar.Value = _vScrollBar.Maximum - _vScrollBar.LargeChange;
            }
            else
            {
                _vScrollBar.Value = top;
            }
        }

        private void UpdateScrollbarScale()
        {
            int xChange = _hScrollBar.Width * UsableWidth / (PaperWidthPixels + OFFSET * 2);
            int yChange = _vScrollBar.Height * UsableHeight / (PaperHeightPixels + OFFSET * 2);

            int width = PaperWidthPixels + OFFSET * 2 - UsableWidth + xChange;
            int height = PaperHeightPixels + OFFSET * 2 - UsableHeight + yChange;

            _hScrollBarPanel.Visible = xChange < width;
            _vScrollBar.Visible = yChange < height;

            if (width < 0) width = 0;
            if (height < 0) height = 0;

            _hScrollBar.Minimum = 0;
            _hScrollBar.Maximum = width;
            _hScrollBar.LargeChange = xChange < 0 ? 0 : xChange > _hScrollBar.Maximum ? _hScrollBar.Maximum : xChange;

            _vScrollBar.Minimum = 0;
            _vScrollBar.Maximum = height;
            _vScrollBar.LargeChange = yChange < 0 ? 0 : yChange > _vScrollBar.Maximum ? _vScrollBar.Maximum : yChange;
        }

        private void VScrollBarScroll(object sender, ScrollEventArgs e)
        {
            _paperLocation.Y = _paperLocation.Y + (e.OldValue - e.NewValue);
            Invalidate();
        }
    }
}