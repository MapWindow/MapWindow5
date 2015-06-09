using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Helpers;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared;
using MW5.UI;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Views
{
    /// <summary>
    /// Represents the main view of the application with the map, docking windows, toolbars and menu.
    /// </summary>
    public partial class MainView : MapWindowView, IMainView
    {
        private const string WindowTitle = "MapWindow";
        private readonly IAppContext _context;
        private bool _rendered = false;

        public MainView(IAppContext context)
        {
            _context = context;
            
            InitializeComponent();

            statusStripEx1.Items.Clear();
            statusStripEx1.Refresh();

            ToolTipHelper.Init(superToolTip1);

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
            // if there are hidden child forms which override FormClosing
            // the initial value is set to true: https ://msdn.microsoft.com/en-us/library/system.windows.forms.form.formclosing%28v=vs.110%29.aspx
            // currently it may be the case with non-modal Find / Replace form in the table editor
            e.Cancel = false;   

            if (!FireViewClosing())
            {
                e.Cancel = true;
            }
            else
            {
                _dockingManager1.SaveLayout(false);
                _mainFrameBarManager1.SaveLayout(false);
            }
        }

        public event EventHandler<CancelEventArgs> ViewClosing;
        public event EventHandler<RenderedEventArgs> ViewUpdating;
        public event Action BeforeShow;

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
            if (AppConfig.Instance.FirstRun)
            {
                _dockingManager1.SaveLayout(true);
                _mainFrameBarManager1.SaveLayout(true);
                AppConfig.Instance.FirstRun = false;
            }
            else
            {
                _dockingManager1.RestoreLayout(false);
                _mainFrameBarManager1.RestoreLayout(false);
            }

            Program.Timer.Stop();
            Logger.Current.Info("Loading time: " + Program.Timer.Elapsed);

            SplashView.Instance.Close();

            ShowInTaskbar = true;
            _context.DockPanels.Unlock();

            // don't set it initially or it will cause a lot of resizing
            // with reallocation of buffer when panels / toolbars are loaded
            _mapControl1.Dock = DockStyle.Fill;

            Invoke(BeforeShow);

            Application.Run(this);
        }

        public override void UpdateView()
        {
            Text = WindowTitle;
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

        public IView View
        {
            get { return this; }
        }

        #endregion

    }
}
