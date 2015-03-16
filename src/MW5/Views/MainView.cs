using System;
using System.ComponentModel;
using System.Linq;
//using System.Linq;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Helpers;
using MW5.Menu;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI;
using MW5.UI.Helpers;

namespace MW5.Views
{
    /// <summary>
    /// Represents the main view of the application with the map, docking windows, toolbars and menu.
    /// </summary>
    public partial class MainView : MapWindowForm, IMainView
    {
        private const string WINDOW_TITLE = "MapWindow";
        private readonly IAppContext _context;
        private bool _rendered = false;

        public MainView(IAppContext context)
            : base(context)
        {
            _context = context;

            InitializeComponent();

            _legendControl1.Map = _mapControl1;
            _mapControl1.Legend = _legendControl1;

            //_dockingManager1.InitDocking(_legendControl1, treeViewAdv2, this);

            FormClosed += (s, e) => _dockingManager1.SaveLayout();

            FormClosing += MainView_FormClosing;

            // setting bar item text before form is shown results in creation of duplicated bar item;
            // it seems it's a bug in Syncfusion's XpMenus
            Shown += (s, e) =>
            {
                _rendered = true;
                UpdateView();
            };
        }

        void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!FireViewClosing())
            {
                e.Cancel = true;
            }
        }

        public event EventHandler<CancelEventArgs> ViewClosing;
        public event EventHandler<EventArgs> ViewUpdating;

        private void FireViewUpdating()
        {
            var handler = ViewUpdating;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private bool FireViewClosing()
        {
            
            var handler = ViewClosing;
            if (handler != null)
            {
                var args = new CancelEventArgs();
                handler(this, args);
                if (args.Cancel)
                {
                    return false;
                }
            }
            return true;
        }

        private void InitDocking()
        {
            var panels = _context.DockPanels;
            panels.Lock();
            try
            {
                _legendControl1.BorderStyle = BorderStyle.None;
                treeViewAdv2.BorderStyle = BorderStyle.None;
                const int size = 300;

                var legend = panels.Add(_legendControl1, DockPanelState.Left, true, size, PluginIdentity.Default);
                legend.Caption = "Legend";

                var preview = panels.Add(treeViewAdv2, DockPanelState.Left, true, size, PluginIdentity.Default);
                preview.Caption = "Preview";

                preview.DockTo(legend, DockPanelState.Bottom, size);
            }
            catch (Exception ex)
            {
                panels.Unlock();
            }
        }

        #region IView implementation

        public new void ShowView()
        {
            InitDocking();
            
            Application.Run(this);
        }

        public void UpdateView()
        {
            Text = WINDOW_TITLE;
            if (!_context.Project.IsEmpty)
            {
                Text += @" - " + _context.Project.Filename;
            }
            
            var bars = _context.Toolbars;

            // mapControl plays the role of the model here
            bars.FindItem(MenuKeys.ZoomIn).Checked = _mapControl1.MapCursor == MapCursor.ZoomIn;
            bars.FindItem(MenuKeys.ZoomOut).Checked = _mapControl1.MapCursor == MapCursor.ZoomOut;
            bars.FindItem(MenuKeys.Pan).Checked = _mapControl1.MapCursor == MapCursor.Pan;
            bars.FindItem(MenuKeys.Attributes).Checked = _mapControl1.MapCursor == MapCursor.Identify;
            
            bars.FindItem(MenuKeys.SelectByRectangle).Checked = _mapControl1.MapCursor == MapCursor.Selection;
            bars.FindItem(MenuKeys.SelectByPolygon).Checked = _mapControl1.MapCursor == MapCursor.SelectByPolygon;

            bool selectionCursor = _mapControl1.MapCursor == MapCursor.Selection ||
                                   _mapControl1.MapCursor == MapCursor.SelectByPolygon;
            bars.FindItem(MenuKeys.SelectDropDown).Checked = selectionCursor;

            bool distance = _mapControl1.Measuring.Type == MeasuringType.Distance;
            bars.FindItem(MenuKeys.MeasureArea).Checked = _mapControl1.MapCursor == MapCursor.Measure && !distance;
            bars.FindItem(MenuKeys.MeasureDistance).Checked = _mapControl1.MapCursor == MapCursor.Measure && distance;

            var item = bars.FindItem(MenuKeys.SetProjection);
            item.Enabled = !_context.Map.Layers.Any();
            if (_rendered)
            {
                item.Text = item.Enabled
                    ? "Set coordinate system and projection"
                    : "It's not allowed to change projection when layers are already added to the map.";
            }

            bool hasFeatureSet = false;
            
            bool hasLayer = _context.Legend.SelectedLayer != -1;
            if (hasLayer)
            {
                var fs = _context.Map.Layers.SelectedLayer.FeatureSet;
                if (fs != null)
                {
                    //statusSelectedCount.Text = string.Format("Shapes: {0}; selected: {1}", sf.NumShapes, sf.NumSelected);
                    bars.FindItem(MenuKeys.ClearSelection).Enabled = fs.NumSelected > 0;
                    bars.FindItem(MenuKeys.ZoomToSelected).Enabled = fs.NumSelected > 0;
                    hasFeatureSet = true;
                }
            }

            if (!hasFeatureSet)
            {
                //statusSelectedCount.Text = "";
                bars.FindItem(MenuKeys.ClearSelection).Enabled = false;
                bars.FindItem(MenuKeys.ZoomToSelected).Enabled = false;
            }

            bars.FindItem(MenuKeys.RemoveLayer).Enabled = hasLayer;

            //toolSearch.Enabled = true;
            //toolSearch.Text = "Find location";
            //if (App.Map.NumLayers > 0 && !App.Map.Measuring.IsUsingEllipsoid)
            //{
            //    toolSearch.Enabled = false;
            //    toolSearch.Text = "Unsupported projection. Search isn't allowed.";
            //}

            //if (Map.CursorMode != tkCursorMode.cmIdentify)
            //{
            //    MapForm.HideTooltip();
            //}

            UpdateStatusBar();

            // broadcast to plugins
            FireViewUpdating();

            _mapControl1.Focus();
        }

        private void UpdateStatusBar()
        {
            statusTileProvider.Text = EnumHelper.EnumToString(_context.Map.TileProvider);

            if (_context.Map.Layers.SelectedLayer == null)
            {
                statusSelected.Text = "No selected layer";
                return;
            }

            var fs = _context.Map.SelectedFeatureSet;
            if (fs != null)
            {
                statusSelected.Text = string.Format("Selected: {0} / {1}", fs.NumSelected, fs.Features.Count);
                return;
            }
            
            var img = _context.Map.SelectedImage;
            if (img != null)
            {
                statusSelected.Text = "Selected layer is raster";
            }
        }

        #endregion

        #region IMainView implementation

        public object DockingManager
        {
            get { return _dockingManager1; }
        }

        public object MenuManager
        {
            get { return _mainFrameBarManager1; }
        }

        public object StatusBar
        {
            get { return statusStripEx1; }
        }

        public IMap Map
        {
            get { return _mapControl1; }
        }

        public IMuteLegend Legend
        {
            get { return _legendControl1; }
        }

        public IView View
        {
            get { return this; }
        }

        #endregion
    }
}
