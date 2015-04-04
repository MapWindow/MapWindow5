using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
//using System.Linq;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Controls;
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
    public partial class MainView : MapWindowView, IMainView
    {
        private const string WINDOW_TITLE = "MapWindow";
        private readonly IAppContext _context;
        private bool _rendered = false;

        public MainView(IAppContext context)
        {
            _context = context;
            
            InitializeComponent();

            statusStripEx1.Items.Clear();
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
        public event EventHandler<RenderedEventArgs> ViewUpdating;

        private void FireViewUpdating(bool rendered)
        {
            var handler = ViewUpdating;
            if (handler != null)
            {
                handler(this, new RenderedEventArgs() { Rendered = rendered });
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

        public override void ShowView(IWin32Window parent = null)
        {
            Application.Run(this);
        }

        public void UpdateView()
        {
            Text = WINDOW_TITLE;
            if (!_context.Project.IsEmpty)
            {
                Text += @" - " + _context.Project.Filename;
            }
            
            // broadcast to plugins
            if (_rendered)
            {
                FireViewUpdating(_rendered);
            }

            if (ActiveForm == _mapControl1.ParentForm)
            {
                _mapControl1.Focus();
            }
        }

        public ButtonBase OkButton
        {
            get { return null; }
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
