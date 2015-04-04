using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Helpers;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.UI;
using stdole;

namespace MW5.Controls
{
    public partial class LocatorDockPanel : UserControl
    {
        private IEnvelope _extents;      // extents of the main map
        private readonly Color _locatorColor = Color.Red;
        private bool _backgroundVisible = true;

        public event Action UpdateFullExtents;
        public event Action UpdateWithCurrentExtents;
        public event EventHandler<ExtentsEventArgs> PreviewExtentsChanged;

        private int _drawHandle = -1;
        private bool _dragging;
        private int _initX;
        private int _initY;

        public LocatorDockPanel()
        {
            InitializeComponent();

            InitLocatorMap();

            btnUpdateCurrent.Click += (s, e) => Invoke(UpdateWithCurrentExtents);
            btnUpdateFull.Click += (s, e) => Invoke(UpdateFullExtents);
            btnClear.Click += (s, e) => Clear();
            btnDisplayBackground.Click += (s, e) => _backgroundVisible = !btnDisplayBackground.Checked;
            contextMenuStripEx1.Opening += (s, e) => btnDisplayBackground.Checked = _backgroundVisible;

            mapControl1.MouseDown += MapMouseDown;
            mapControl1.MouseMove += MapMouseMove;
            mapControl1.MouseUp += MapMouseUp;

            Resize += (s, e) => UpdateLocatorBox(_extents);
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
        }

        internal bool BackgroundVisible
        {
            get { return _backgroundVisible; }
        }

        internal IImageSource Image
        {
            get
            {
                var layer = mapControl1.Layers[0];
                return layer != null ? layer.ImageSource : null;
            }
        }

        internal bool Empty
        {
            get { return !mapControl1.Layers.Any(); }
        }

        internal void Clear()
        {
            mapControl1.Layers.Clear();
            mapControl1.Drawing.Clear();
        }

        #region Drawing

        internal void UpdateImage(IImageSource imageSource)
        {
            mapControl1.Layers.Clear();
            mapControl1.Layers.Add(imageSource);
            mapControl1.ExtentPad = 0;
            mapControl1.ZoomToMaxExtents();
        }
        
        internal void UpdateLocatorBox(IEnvelope exts)
        {
            if (exts == null)
            {
                return;
            }

            if (!mapControl1.Layers.Any())
            {
                return;
            }

            double newLeft, newRight, newTop, newBottom;
            mapControl1.ProjToPixel(exts.MinX, exts.MaxY, out newLeft, out newTop);
            mapControl1.ProjToPixel(exts.MaxX, exts.MinY, out newRight, out newBottom);

            var rect = new Rectangle(Convert.ToInt32(newLeft), Convert.ToInt32(newTop), Convert.ToInt32(newRight - newLeft), Convert.ToInt32(newBottom - newTop));
            DrawBox(rect);

            _extents = exts;
        }

        private void DrawBox(Rectangle rect)
        {
            var drawing = mapControl1.Drawing;

            if (_drawHandle >= 0)
            {
                drawing.RemoveLayer(_drawHandle);
            }

            _drawHandle = drawing.AddLayer(DrawReferenceList.ScreenReferencedList);

            drawing.DrawLine(rect.Left, rect.Top, rect.Right, rect.Top, 2, _locatorColor);
            drawing.DrawLine(rect.Right, rect.Top, rect.Right, rect.Bottom, 2, _locatorColor);
            drawing.DrawLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom, 2, _locatorColor);
            drawing.DrawLine(rect.Left, rect.Bottom, rect.Left, rect.Top, 2, _locatorColor);
        }

        #endregion

        #region Dragging

        private void MapMouseDown(object sender, MouseEventArgs e)
        {
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
            if (_dragging) 
            {
                var ext = GetNewExtents(e.X, e.Y);
                FireExtentsChanged(ext);
            }

            _dragging = false;
        }

        private IEnvelope GetNewExtents(int xScreen, int yScreen)
        {
            double x1, x2, y1, y2;
            mapControl1.PixelToProj(_initX, _initY, out x1, out y1);
            mapControl1.PixelToProj( xScreen, yScreen, out x2, out y2);
            _initX = xScreen;
            _initY = yScreen;
            return _extents.Move(x2 - x1, y2 - y1);
        }

        private bool WithinBounds(int xScreen, int yScreen)
        {
            double projX, projY;
            mapControl1.PixelToProj(xScreen, yScreen, out projX, out projY);
            return WithinBounds(projX, projY);
        }

        private bool WithinBounds(double xProj, double yProj)
        {
            if (Empty)
            {
                return false;
            }

            return _extents.PointWithin(xProj, yProj);
        }

        private void FireExtentsChanged(IEnvelope ext)
        {
            var handler = PreviewExtentsChanged;
            if (handler != null)
            {
                handler(this, new ExtentsEventArgs(ext));
            }
        }

        #endregion

        private void Invoke(Action action)
        {
            var handler = action;
            if (action != null)
            {
                handler();
            }
        }
    }
}
