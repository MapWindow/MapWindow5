// -------------------------------------------------------------------------------------------
// <copyright file="ImageRegistrationView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Map;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.Toolbox.Helpers;
using MW5.Plugins.Toolbox.Model;
using MW5.Plugins.Toolbox.Views.Abstract;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Plugins.Toolbox.Views
{
    internal partial class ImageRegistrationView : ImageRegistrationViewBase, IImageRegistrationView
    {
        private readonly IAppContext _context;
        private IFeatureSet _fs1;
        private IFeatureSet _fs2;
        private int _resultHandle = -1;
        private int _sourceImageHandle = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageRegistrationView"/> class.
        /// </summary>
        public ImageRegistrationView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();

            AttachEvents();
        }

        private void SetColumnFormats()
        {
            string format = _context.Map.MapUnits == LengthUnits.DecimalDegrees ? "f6" : "f2";
            pointPairGrid1.Adapter.GetColumn(p => p.X1).Appearance.AnyCell.Format = format;
            pointPairGrid1.Adapter.GetColumn(p => p.X2).Appearance.AnyCell.Format = format;
            pointPairGrid1.Adapter.GetColumn(p => p.Y1).Appearance.AnyCell.Format = format;
            pointPairGrid1.Adapter.GetColumn(p => p.Y2).Appearance.AnyCell.Format = format;
            pointPairGrid1.ForceImmediateSaveValue();
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            LoadProject();

            pointPairGrid1.DataSource = Model.Points;

            mapControl1.Redraw();

            UpdateCursor();

            SetColumnFormats();

            UpdateView();
        }

        public override ViewStyle Style
        {
            get { return new ViewStyle(true); }
        }

        public void LoadTransformedImage()
        {
            var resultImage = BitmapSource.Open(Model.ImageFilename, false);
            if (resultImage == null) return;

            resultImage.SetTransparentColor(Color.Black);
            _resultHandle = mapControl1.Layers.Add(resultImage);

            int pos = mapControl1.Layers.ItemByHandle(_resultHandle).Position;
            mapControl1.Layers.MoveTop(pos);
            mapControl1.ZoomToLayer(_resultHandle);

            btnApply.SendToBack();
        }

        public event Action RecalculationNeeded;

        public void RemoveTransformedImage()
        {
            if (_resultHandle != -1)
            {
                mapControl1.Layers.Remove(_resultHandle);
                btnApply.BringToFront();
                UpdateView();
            }
        }

        /// <summary>
        /// Lets user to select and image to register
        /// </summary>
        public void AddSourceImage(IImageSource img)
        {
            ClearPointsCore();
            
            mapControl2.Lock();

            if (_sourceImageHandle != -1)
            {
                mapControl2.Layers.Remove(_sourceImageHandle);
            }

            _sourceImageHandle = mapControl2.Layers.Add(img);

            mapControl2.ZoomToMaxExtents();
            mapControl2.Unlock();

            UpdateView();
        }

        public ButtonBase OkButton
        {
            get { return btnApply; }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield break; }
        }

        public IEnumerable<Control> Buttons
        {
            get
            {
                yield return btnLoadImage;
                yield return btnApply;
                yield return btnCancel;
            }
        }

        /// <summary>
        /// Adds a point to the map
        /// </summary>
        private void AddPoint(MapControl map, IFeatureSet fs, bool source, MouseEventArgs e)
        {
            if (map.MapCursor != MapCursor.None) return;

            if (!Model.ImageLoaded)
            {
                MessageService.Current.Info("Please load an image.");
                return;
            }

            int index = Model.Points.Count - 1;

            if (Model.NeedsNewPoint || !Model.Points[index].Exists(source))
            {
                AddPointCore(map, fs, source, e);
            }
            else
            {
                MessageService.Current.Info("The point is already added to this panel.");
                return;
            }

            if (Model.Points.Last().Complete)
            {
                Model.Points[index].Selected = true;
                Model.Points[index] = Model.Points[index]; // to trigger update of grid

                Invoke(RecalculationNeeded);
            }

            UpdateView();
        }

        private void AddPointCore(MapControl map, IFeatureSet fs, bool source, MouseEventArgs e)
        {
            double x, y;
            map.PixelToProj(e.X, e.Y, out x, out y);

            if (Model.NeedsNewPoint)
            {
                var pnt = new PointPair(_context.Map.MapUnits, Model.Points.Count + 1);
                Model.Points.Add(pnt);

                // we don't detach handler, object will be GCed eventually when form is closed
                pnt.PointSelected += (s, args) => OnPointChecked(); 

                UpdateView();
            }

            var shp = new Geometry(GeometryType.Point);
            shp.Points.Add(new Coordinate(x, y));
            int index = fs.Features.EditAdd(shp);

            fs.Features[index].SetValue(1, Model.Points.Count);

            fs.GenerateLabels(1, LabelPosition.Center);
            fs.Labels.Style.FrameVisible = false;
            map.Redraw();

            int count = Model.Points.Count - 1;
            if (source)
            {
                int imageX, imageY;
                Model.Image.ProjectionToImage(x, y, out imageX, out imageY);
                Model.Points[count].SetSourcePoint(imageX, imageY);
            }
            else
            {
                Model.Points[count].SetTargetPoint(x, y);
            }
        }

        private void AttachEvents()
        {
            pointPairGrid1.Adapter.SelectionChanged += (s, e) => UpdateView();

            mapControl1.MouseDown += (sender, e) => AddPoint(mapControl1, _fs1, false, e);

            mapControl2.MouseDown += (sender, e) => AddPoint(mapControl2, _fs2, true, e);

            FormClosed += OnViewClosed;
        }

        private void OnViewClosed(object sender, FormClosedEventArgs e)
        {
            mapControl1.Layers.ClearWithoutClosing();
        }

        /// <summary>
        /// Recalculates the solution after an item is checked
        /// </summary>
        private void OnPointChecked()
        {
            for (int i = 0; i < Model.Points.Count; i++)
            {
                TogglePointVisibility(_fs1, i, Model.Points[i].Selected);

                TogglePointVisibility(_fs2, i, Model.Points[i].Selected);
            }

            Invoke(RecalculationNeeded);

            RedrawMaps();

            UpdateView();
        }

        private void TogglePointVisibility(IFeatureSet fs, int index, bool visible)
        {
            int val = visible ? -1 : 0;

            fs.Features[index].CategoryIndex = val;
            if (fs.Labels.Items[index, 0] != null)
            {
                fs.Labels.Items[index, 0].CategoryIndex = val;
            }
        }

        /// <summary>
        /// Reloads layers from the main window
        /// </summary>
        private void LoadProject()
        {
            var map = _context.Map;

            bool oldValue = MapConfig.LoadSymbologyOnAddLayer;
            MapConfig.LoadSymbologyOnAddLayer = false;

            foreach (var layer in map.Layers.Where(L => L.Visible))
            {
                var source = layer.LayerSource;
                mapControl1.Layers.Add(source);
            }

            MapConfig.LoadSymbologyOnAddLayer = oldValue;

            mapControl1.SetTileProvider(map.Tiles.ProviderId);
            mapControl1.Projection = map.Projection.Clone();
            mapControl1.ZoomBehavior = ZoomBehavior.UseTileLevels;
            mapControl1.Extents = map.Extents;
            mapControl1.ZoomBehavior = ZoomBehavior.Default;

            _fs1 = PointLayerHelper.CreatePointLayer();
            _fs2 = PointLayerHelper.CreatePointLayer();

            mapControl1.Layers.Add(_fs1);
            mapControl2.Layers.Add(_fs2);
        }

        /// <summary>
        /// Removes a single point from the list
        /// </summary>
        private void OnRemoveClick(object sender, EventArgs e)
        {
            var point = pointPairGrid1.Adapter.SelectedItem;
            if (point == null) return;

            if (MessageService.Current.Ask("Remove selected point?"))
            {
                int index = Model.Points.IndexOf(point);

                _fs1.Features.EditDelete(index);
                _fs2.Features.EditDelete(index);

                Model.Points.RemoveAt(index);

                Invoke(RecalculationNeeded);

                RedrawMaps();

                UpdateView();
            }
        }

        private void MnuSelectCheckedChanged(object sender, EventArgs e)
        {
            UpdateCursor();
        }

        /// <summary>
        /// Zooms to the max extents
        /// </summary>
        private void OnZoomMaxClick(object sender, EventArgs e)
        {
            mapControl1.ZoomToMaxExtents();
            mapControl2.ZoomToMaxExtents();
        }

        public override void UpdateView()
        {
            bool ready = Model.Points.Count(p => p.Selected) >= 3;

            pointPairGrid1.AdjustColumnWidths();

            btnApply.Enabled = ready;
            btnRemovePoint.Enabled = pointPairGrid1.Adapter.SelectedItem != null;
            btnZoomToPoint.Enabled = pointPairGrid1.Adapter.SelectedItem != null;
            btnClearPoints.Enabled = Model.Points.Any();

            statusPointCount.Text = "Number of points: " + Model.Points.Count;

            double value = UnitConversionHelper.Convert(_context.Map.MapUnits, LengthUnits.Meters, Model.StdError);
            statusError.Text = "Error: " +  value.ToString("0.00 m");

            UpdateStatusMessage();
        }

        private void UpdateStatusMessage()
        {
            if (!Model.ImageLoaded)
            {
                status1.Text = "Please load an image to register";
            }
            else if (Model.Registered)
            {
                status1.Text = "The image was registered";
            }
            else if (Model.ActivePoints.Count() < 3)
            {
                status1.Text = "Not enough points for registration";
            }
            else
            {
                status1.Text = "Ready";
            }
        }

        private void UpdateCursor()
        {
            var mode = MapCursor.None;
            if (mnuSelect.Checked)
            {
                mode = MapCursor.None;
            }
            else if (mnuZoomIn.Checked)
            {
                mode = MapCursor.ZoomIn;
            }
            else if (mnuZoomOut.Checked)
            {
                mode = MapCursor.ZoomOut;
            }
            else if (mnuPan.Checked)
            {
                mode = MapCursor.Pan;
            }

            mapControl1.SystemCursor = mode != MapCursor.None ? SystemCursor.MapDefault : SystemCursor.Arrow;
            mapControl2.SystemCursor = mode != MapCursor.None ? SystemCursor.MapDefault : SystemCursor.Arrow;

            mapControl1.MapCursor = mode;
            mapControl2.MapCursor = mode;
        }

        private void ZoomToPoint(IFeatureSet fs, int shapeIndex, double pad, MapControl mapControl)
        {
            double x, y;

            var g1 = fs.GetGeometry(shapeIndex);

            if (g1 == null) return;

            g1.GetPoint(0, out x, out y);

            var ext1 = new Envelope(x - pad, x + pad, y - pad, y + pad);
            mapControl.Extents = ext1;
        }

        private void OnZoomToPointClick(object sender, EventArgs e)
        {
            var point = pointPairGrid1.Adapter.SelectedItem;
            if (point == null) return;

            int index = Model.Points.IndexOf(point);

            ZoomToPoint(_fs1, index, 1000.0, mapControl1);

            ZoomToPoint(_fs2, index, 100.0, mapControl2);
        }

        private void OnClearPointsClick(object sender, EventArgs e)
        {
            if (MessageService.Current.Ask("Do you want to remove all points?"))
            {
                ClearPointsCore();
            }
        }

        private void ClearPointsCore()
        {
            Model.Points.Clear();

            _fs1.Features.EditClear();
            _fs2.Features.EditClear();

            RedrawMaps();

            Invoke(RecalculationNeeded);

            UpdateView();
        }

        private void RedrawMaps()
        {
            mapControl1.Redraw();
            mapControl2.Redraw();
        }
    }

    internal class ImageRegistrationViewBase : MapWindowView<ImageRegistrationModel>
    {
    }
}