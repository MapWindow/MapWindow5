using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Docking
{
    internal class DockPanelCollection: IDockPanelCollection
    {
        private bool _locked;
        private readonly Form _mainForm;
        private readonly IBroadcasterService _broadcaster;
        private readonly DockingManager _dockingManager;
        private readonly Dictionary<Control, DockPanelInfo> _dict = new Dictionary<Control, DockPanelInfo>();

        internal DockPanelCollection(object dockingManager, Form mainForm, IBroadcasterService broadcaster)
        {
            if (mainForm == null) throw new ArgumentNullException("mainForm");
            if (broadcaster == null) throw new ArgumentNullException("broadcaster");

            _mainForm = mainForm;
            _broadcaster = broadcaster;
            _dockingManager = dockingManager as DockingManager;

            if (_dockingManager == null)
            {
                throw new ApplicationException(
                    "Failed to initialize DockPanelCollection. No docking manager is provided.");
            }

            _dockingManager.DragProviderStyle = DragProviderStyle.VS2012;
#if STYLE2010
            _dockingManager.VisualStyle = VisualStyle.Office2010;
#else
            _dockingManager.VisualStyle = VisualStyle.Metro;
#endif

            _dockingManager.DockTabAlignment = DockTabAlignmentStyle.Bottom;
            _dockingManager.ShowCaptionImages = false;

            _dockingManager.DockVisibilityChanged += DockVisibilityChanged;
            _dockingManager.DockVisibilityChanging += DockVisibilityChanging;
        }

        private void DockVisibilityChanging(object sender, DockVisibilityChangingEventArgs arg)
        {
            if (!_dict.ContainsKey(arg.Control))
            {
                throw new ApplicationException("Invalid docking panel control");
            }
            
            var panel = GetDockPanel(arg.Control);
            var info = _dict[arg.Control];
            var args = new DockPanelCancelEventArgs(panel, info.Key);

            if (panel.Visible)
            {
                _broadcaster.BroadcastEvent(p => p.DockPanelClosing_, panel, args, info.Identity);
            }
            else
            {
                _broadcaster.BroadcastEvent(p => p.DockPanelOpening_, panel, args, info.Identity);
            }

            if (args.Cancel)
            {
                arg.Cancel = true;
            }
        }

        private void DockVisibilityChanged(object sender, DockVisibilityChangedEventArgs arg)
        {
            if (!_dict.ContainsKey(arg.Control))
            {
                throw new ApplicationException("Invalid docking panel control");
            }

            var panel = GetDockPanel(arg.Control);
            var info = _dict[arg.Control];
            var args = new DockPanelEventArgs(panel, info.Key);

            if (panel.Visible)
            {
                _broadcaster.BroadcastEvent(p => p.DockPanelOpened_, panel, args, info.Identity);    
            }
            else
            {
                _broadcaster.BroadcastEvent(p => p.DockPanelClosed_, panel, args, info.Identity);
            }
        }
        
        public IEnumerator<IDockPanel> GetEnumerator()
        {
            var enumerator = _dockingManager.Controls;
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                var dockItem = enumerator.Current as Control;
                if (dockItem != null)
                {
                    yield return GetDockPanel(dockItem);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Lock()
        {
            _dockingManager.LockDockPanelsUpdate();
            _dockingManager.LockHostFormUpdate();
            _locked = true;
        }

        public void Unlock()
        {
            _dockingManager.UnlockDockPanelsUpdate();
            _dockingManager.UnlockHostFormUpdate();
            _locked = false;
        }

        public bool Locked
        {
            get { return _locked; }
        }

        public IDockPanel Add(Control control, string key, PluginIdentity identity)
        {
            if (control == null)
            {
                throw new NullReferenceException();
            }

            _dockingManager.SetEnableDocking(control, true);
            if (_dict.ContainsKey(control))
            {
                throw new ApplicationException("This control has been already added as a docking window");
            }

            _dict.Add(control, new DockPanelInfo(identity, key));

            return GetDockPanel(control);
        }

        public void Remove(IDockPanel panel, PluginIdentity identity)
        {
            if (panel == null)
            {
                throw new ArgumentException("panel");
            }
            
            if (!_dict.ContainsKey(panel.Control))
            {
                throw new ApplicationException("Dock panel isn't registed in the collection");
            }

            if (_dict[panel.Control].Identity == identity)
            {
                throw new ApplicationException(
                    "Invalid plugin identity. The panel can be removed only from the same plugin.");
            }

            _dockingManager.SetEnableDocking(panel.Control, false);
            _dict.Remove(panel.Control);
            _mainForm.Controls.Remove(panel.Control);
            
        }

        public void RemoveItemsForPlugin(PluginIdentity identity)
        {
            List<Control> controls = new List<Control>();
            foreach (var p in this)
            {
                if (_dict[p.Control].Identity == identity)
                {
                    controls.Add(p.Control);
                }
            }
            foreach (var ctrl in controls)
            {
                _dockingManager.SetEnableDocking(ctrl, false);
                _dict.Remove(ctrl);
                _mainForm.Controls.Remove(ctrl);
            }
        }

        public IDockPanel Find(string key)
        {
            foreach (var item in _dict)
            {
                if (item.Value.Key.EqualsIgnoreCase(key))
                {
                    return GetDockPanel(item.Key);
                }
            }
            return null;
        }

        public IDockPanel Legend
        {
            get { return Find(DockPanelKeys.Legend); }
        }

        public IDockPanel Preview
        {
            get { return Find(DockPanelKeys.Preview); }
        }

        public IDockPanel Toolbox
        {
            get { return Find(DockPanelKeys.Toolbox); }
        }

        private IDockPanel GetDockPanel(Control control)
        {
            return new DockPanel(_dockingManager, control, _mainForm);
        }
    }
}
