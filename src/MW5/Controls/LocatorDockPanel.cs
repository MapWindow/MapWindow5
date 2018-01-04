// -------------------------------------------------------------------------------------------
// <copyright file="LocatorDockPanel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015 - 2017
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Shared;
using MW5.UI.Controls;

namespace MW5.Controls
{
    public partial class LocatorDockPanel : DockPanelControlBase
    {
        // private readonly Color _locatorColor = Color.Red;

        private bool _dragging;
        private IEnvelope _extents; // extents of the main map
        private int _initX;
        private int _initY;

        public LocatorDockPanel()
        {
            InitializeComponent();

            InitLocatorMap();

            AttachHandlers();
        }

        private void AttachHandlers()
        {
            btnUpdateCurrent.Click += (s, e) => Invoke(UpdateWithCurrentExtents);
            btnUpdateFull.Click += (s, e) => Invoke(UpdateFullExtents);
            btnClear.Click += (s, e) => Clear();
            btnDisplayBackground.Click += (s, e) =>
            {
                AppConfig.Instance.OverviewBackgroundVisible = !btnDisplayBackground.Checked;
            };

            contextMenuStripEx1.Opening += (s, e) => btnDisplayBackground.Checked = AppConfig.Instance.OverviewBackgroundVisible;

            mapControl1.MouseDown += MapMouseDown;
            mapControl1.MouseMove += MapMouseMove;
            mapControl1.MouseUp += MapMouseUp;

            Paint += (s, e) => UpdateLocatorBox(_extents);
            Resize += (s, e) => UpdateLocatorBox(_extents);
        }

        public event EventHandler<ExtentsEventArgs> LocatorExtentsChanged;

        public event Action UpdateFullExtents;

        public event Action UpdateWithCurrentExtents;

        internal bool BackgroundVisible
        {
            get { return AppConfig.Instance.OverviewBackgroundVisible; }
        }

        internal bool Empty
        {
            get { return !mapControl1.Layers.Any(); }
        }

        internal IImageSource Image
        {
            get
            {
                var layer = mapControl1.Layers[0];
                return layer != null ? layer.ImageSource : null;
            }
        }

        internal void Clear()
        {
            mapControl1.FocusRectangle.Visible = false;
            mapControl1.Layers.Clear();
        }

        internal void UpdateImage(IImageSource imageSource)
        {
            mapControl1.Layers.Clear();
            mapControl1.Layers.Add(imageSource);
            mapControl1.ExtentPad = 0;
            mapControl1.ZoomToMaxExtents();
        }

        internal void UpdateLocatorBox(IEnvelope exts)
        {
            if (DebugHelper.HideAdditionalMapControls)
            {
                return;
            }

            if (exts == null || Empty)
            {
                return;
            }

            double newLeft, newRight, newTop, newBottom;
            mapControl1.ProjToPixel(exts.MinX, exts.MaxY, out newLeft, out newTop);
            mapControl1.ProjToPixel(exts.MaxX, exts.MinY, out newRight, out newBottom);

            var fr = mapControl1.FocusRectangle;
            fr.X = newLeft;
            fr.Y = Math.Min(newBottom, newTop);
            fr.Width = newRight - newLeft;
            fr.Height = Math.Abs(newTop - newBottom);
            mapControl1.FocusRectangle.Visible = true;
            mapControl1.Redraw(RedrawType.Minimal);

            _extents = exts;
        }

        private void FireExtentsChanged(IEnvelope ext)
        {
            var handler = LocatorExtentsChanged;
            if (handler != null)
            {
                handler(this, new ExtentsEventArgs(ext));
            }
        }

        private IEnvelope GetNewExtents(int xScreen, int yScreen)
        {
            double x1, x2, y1, y2;
            mapControl1.PixelToProj(_initX, _initY, out x1, out y1);
            mapControl1.PixelToProj(xScreen, yScreen, out x2, out y2);
            _initX = xScreen;
            _initY = yScreen;
            return _extents.Move(x2 - x1, y2 - y1);
        }

        private void InitLocatorMap()
        {
            mapControl1.ScalebarVisible = false;
            mapControl1.ShowCoordinates = CoordinatesDisplay.None;
            mapControl1.ZoomBar.Visible = false;
            mapControl1.ZoomBehavior = ZoomBehavior.Default;
            mapControl1.TileProvider = TileProvider.None;
            mapControl1.MapCursor = MapCursor.None;
            mapControl1.MouseWheelSpeed = 1.0;
            mapControl1.FocusRectangle.FillTransparency = 64;
            mapControl1.FocusRectangle.Color = Color.Red;
            mapControl1.FocusRectangle.LineWidth = 1.0f;
            mapControl1.ResizeBehavior = ResizeBehavior.Intuitive;
        }

        private void Invoke(Action action)
        {
            var handler = action;
            if (action != null)
            {
                handler();
            }
        }

        private void MapMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }

            if (Empty || !WithinBounds(e.X, e.Y))
            {
                _dragging = false;
                return;
            }

            _initX = e.X;
            _initY = e.Y;
            _dragging = true;
        }

        private void MapMouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging && !Empty)
            {
                var ext = GetNewExtents(e.X, e.Y);
                UpdateLocatorBox(ext);
                return;
            }

            mapControl1.SystemCursor = WithinBounds(e.X, e.Y) ? SystemCursor.SizeAll : SystemCursor.MapDefault;
        }

        private void MapMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }

            if (_dragging)
            {
                var ext = GetNewExtents(e.X, e.Y);
                FireExtentsChanged(ext);
            }

            _dragging = false;
        }

        private bool WithinBounds(int xScreen, int yScreen)
        {
            double projX, projY;
            mapControl1.PixelToProj(xScreen, yScreen, out projX, out projY);
            return WithinBounds(projX, projY);
        }

        private bool WithinBounds(double xProj, double yProj)
        {
            if (Empty || _extents == null)
            {
                return false;
            }

            return _extents.PointWithin(xProj, yProj);
        }
    }
}