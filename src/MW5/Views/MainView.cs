using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Presenters;
using MW5.UI;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Views
{
    public partial class MainView : Form, IMainView, IMainForm
    {
        public MainView()
        {
            InitializeComponent();

            AppContext.Init(this);

            

            _dockingManager1.InitDocking(treeViewAdv1, treeViewAdv2, this);

            _mainFrameBarManager1.InitMenus(_mainMenu);

            _mainFrameBarManager1.DockToolbar(_toolbarProject, CommandBarDockState.Left);
            _mainFrameBarManager1.DockToolbar(_toolbarMap, CommandBarDockState.Top);

            TilesHelper.Init(mnuTiles);

            FormClosed += MainView_FormClosed;
        }

        void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            _dockingManager1.SaveLayout();
        }

        public void ShowView()
        {
            Application.Run(this);
        }

        public ToolStripItemCollection[] Menus
        {
            get { return null; }
        }

        public void UpdateView(MainViewModel model)
        {
            //throw new NotImplementedException();
        }

        public object MenuManager
        {
            get { return _mainFrameBarManager1; }
        }

        public IMapControl Map
        {
            get { return _mapControl1; }
        }

        public object Form
        {
            get { return this; }
        }
    }
}
