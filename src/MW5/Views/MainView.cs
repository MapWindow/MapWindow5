using System;
using System.ComponentModel;
using System.Drawing;
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
using MW5.Properties;
using MW5.UI;
using MW5.UI.Docking;
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
        private MenuUpdater _menuUpdater;

        public MainView(IAppContext context)
            : base(context)
        {
            _context = context;
            
            InitializeComponent();

            _legendControl1.Map = _mapControl1;
            _mapControl1.Legend = _legendControl1;

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

        #region IView implementation

        public new void ShowView(bool dialog)
        {
            _menuUpdater = new MenuUpdater(_context, _mapControl1, PluginIdentity.Default);

            Application.Run(this);
        }

        public void UpdateView()
        {
            Text = WINDOW_TITLE;
            if (!_context.Project.IsEmpty)
            {
                Text += @" - " + _context.Project.Filename;
            }

            if (_menuUpdater != null)
            {
                _menuUpdater.Update(_rendered);
            }

            UpdateStatusBar();

            // broadcast to plugins
            FireViewUpdating();

            if (Form.ActiveForm == _mapControl1.ParentForm)
            {
                _mapControl1.Focus();
            }
        }

        private void UpdateStatusBar()
        {
            statusTileProvider.Text = _context.Map.TileProvider.EnumToString();

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

        public void InitDocking()
        {
            var panels = _context.DockPanels;
            panels.Lock();
            try
            {
                _legendControl1.BorderStyle = BorderStyle.None;
                treeViewAdv2.BorderStyle = BorderStyle.None;
                const int size = 300;

                var legend = panels.Add(_legendControl1, DockPanelKeys.Legend, PluginIdentity.Default);
                legend.Caption = "Legend";
                legend.DockTo(null, DockPanelState.Left, size);
                legend.SetIcon(Resources.ico_legend);

                var preview = panels.Add(treeViewAdv2, DockPanelKeys.Preview, PluginIdentity.Default);
                preview.Caption = "Preview";
                preview.SetIcon(Resources.ico_zoom_to_layer);

                preview.DockTo(legend, DockPanelState.Bottom, size);
            }
            finally
            {
                panels.Unlock();
            }
        }

        #endregion
    }
}
