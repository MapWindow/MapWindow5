using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Docking
{
    internal class DockPanel: IDockPanel
    {
        private readonly DockingManager _dockingManager;
        private readonly Control _control;

        internal DockPanel(DockingManager dockingManager, Control control)
        {
            if (dockingManager == null) throw new ArgumentNullException("dockingManager");
            if (control == null) throw new ArgumentNullException("control");

            _dockingManager = dockingManager;
            _control = control;

            _dockingManager.DockTabAlignment = DockTabAlignmentStyle.Bottom;
        }

        public Control Control
        {
            get { return _control; }
        }

        public DockPanelState DockState
        {
            get
            {
                var style = _dockingManager.GetDockStyle(_control);
                return DockHelper.SyncfusionToMapWindow(style);
            }
        }

        public bool Visible
        {
            get { return _dockingManager.GetDockVisibility(_control); }
            set { _dockingManager.SetDockVisibility(_control, value); }
        }

        public void DockTo(IDockPanel parent, DockPanelState state, int size)
        {
            var ctrl = parent != null ? parent.Control : null;
            _dockingManager.DockControl(_control, ctrl, DockHelper.MapWindowToSyncfusion(state), size);
        }

        public string Caption
        {
            get { return _dockingManager.GetDockLabel(_control); }
            set { _dockingManager.SetDockLabel(_control, value); }
        }
    }
}
