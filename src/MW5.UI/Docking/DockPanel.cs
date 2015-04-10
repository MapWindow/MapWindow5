using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Docking
{
    internal class DockPanel: IDockPanel
    {
        private readonly DockingManager _dockingManager;
        private readonly Control _control;
        private readonly Form _mainForm;

        internal DockPanel(DockingManager dockingManager, Control control, Form mainForm)
        {
            if (dockingManager == null) throw new ArgumentNullException("dockingManager");
            if (control == null) throw new ArgumentNullException("control");
            if (mainForm == null) throw new ArgumentNullException("mainForm");

            _dockingManager = dockingManager;
            _control = control;
            _mainForm = mainForm;
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
            if (parent != null && !parent.Visible)
            {
                return;     // no need to throw exception if it not visible
            }
            var ctrl = parent != null ? parent.Control : _mainForm;
            _dockingManager.DockControl(_control, ctrl, DockHelper.MapWindowToSyncfusion(state), size);
        }

        public void DockTo(DockPanelState state, int size)
        {
            DockTo(null, state, size);
        }

        public string Caption
        {
            get { return _dockingManager.GetDockLabel(_control); }
            set { _dockingManager.SetDockLabel(_control, value); }
        }

        public Size Size
        {
            get { return _dockingManager.GetControlSize(_control); }
            set { _dockingManager.SetControlSize(_control, value); }
        }

        public bool FloatOnly
        {
            get { return _dockingManager.GetFloatOnly(_control); }
            set { _dockingManager.SetFloatOnly(_control, value); }
        }

        public bool AllowFloating
        {
            get { return _dockingManager.GetAllowFloating(_control); }
            set { _dockingManager.SetAllowFloating(_control, value); }
        }

        public void SetIcon(Icon icon)
        {
            _dockingManager.SetDockIcon(_control, icon);
        }

        public int IconIndex
        {
            get { return _dockingManager.GetDockIcon(_control); }
            set { _dockingManager.SetDockIcon(_control, value); }
        }

        public int TabPosition
        {
            get { return _dockingManager.GetTabPosition(_control); }
            set { _dockingManager.SetTabPosition(_control, value); }
        }

        public bool IsFloating
        {
            get { return _dockingManager.IsFloating(_control); }
        }

        public void Float(Rectangle rect, bool tabFloating)
        {
            _dockingManager.FloatControl(_control, rect, tabFloating);
        }
    }
}
