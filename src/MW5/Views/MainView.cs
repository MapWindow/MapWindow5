using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Interfaces;
using MW5.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Presenters;
using MW5.UI;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Views
{
    // IMainView - for communication with the presenter
    // IMainForm - for initialization of application context
    public partial class MainView : Form, IMainView, IMainForm
    {
        private readonly IAppContext _context;

        public MainView(IAppContext context)
        {
            _context = context;

            InitializeComponent();

            context.Init(this);

            _dockingManager1.InitDocking(treeViewAdv1, treeViewAdv2, this);

            _mainFrameBarManager1.InitMenus(_mainMenu);

            _mainFrameBarManager1.DockToolbar(_toolbarProject, CommandBarDockState.Left);
            _mainFrameBarManager1.DockToolbar(_toolbarMap, CommandBarDockState.Top);

            FormClosed += MainView_FormClosed;
        }

        void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            _dockingManager1.SaveLayout();
        }

        #region IView implementation

        public void ShowView()
        {
            UpdateView();
            Application.Run(this);
        }

        public IEnumerable<IToolbar> Toolbars
        {
            get
            {
                // TODO: it's already included in toolbars, but better to expose it separately
                // yield return _context.Menu;
                return _context.Toolbars;
            }
        }

        public void UpdateView()
        {
            // mapControls plays the role of the model here
            toolZoomIn.Checked = _mapControl1.MapCursor == MapCursor.ZoomIn;
            toolZoomOut.Checked = _mapControl1.MapCursor == MapCursor.ZoomOut;
            toolPan.Checked = _mapControl1.MapCursor == MapCursor.Pan;
        }

        #endregion

        #region IMainForm implementation

        object IMainForm.MenuManager
        {
            get { return _mainFrameBarManager1; }
        }

        IMapControl IMainForm.Map
        {
            get { return _mapControl1; }
        }

        #endregion
    }
}
