using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using MW5.Api;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Helpers;
using MW5.Menu;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Presenters;
using MW5.Services;
using MW5.UI;
using Syncfusion.Windows.Forms;
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

            _legendControl1.Map = _mapControl1;
            _mapControl1.Legend = _legendControl1;

            context.Init(this);

            _dockingManager1.InitDocking(_legendControl1, treeViewAdv2, this);

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

        public void UpdateView()
        {
            // mapControl plays the role of the model here
            _context.Toolbars.FindItem(MenuKeys.ZoomIn).Checked = _mapControl1.MapCursor == MapCursor.ZoomIn;
            _context.Toolbars.FindItem(MenuKeys.ZoomOut).Checked = _mapControl1.MapCursor == MapCursor.ZoomOut;
            _context.Toolbars.FindItem(MenuKeys.Pan).Checked = _mapControl1.MapCursor == MapCursor.Pan;
            _context.Toolbars.FindItem(MenuKeys.Attributes).Checked = _mapControl1.MapCursor == MapCursor.Identify;
            
            _context.Toolbars.FindItem(MenuKeys.MeasureArea).Checked = 
                _mapControl1.MapCursor == MapCursor.Measure && 
                _mapControl1.Measuring.MeasuringType == MeasuringType.Area;

            _context.Toolbars.FindItem(MenuKeys.MeasureDistance).Checked =
                _mapControl1.MapCursor == MapCursor.Measure &&
                _mapControl1.Measuring.MeasuringType == MeasuringType.Distance;
        }

        #endregion

        #region IMainForm implementation

        public object DockingManager
        {
            get { return _dockingManager1; }
        }

        object IMainForm.MenuManager
        {
            get { return _mainFrameBarManager1; }
        }

        IMap IMainForm.Map
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
