using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Docking
{
    internal class DockPanelCollection: IDockPanelCollection
    {
        private bool _locked;
        private readonly Form _mainForm;
        private DockingManager _dockingManager;
        private Dictionary<Control, PluginIdentity> _dict = new Dictionary<Control, PluginIdentity>();

        internal DockPanelCollection(object dockingManager, Form mainForm)
        {
            if (mainForm == null) throw new ArgumentNullException("mainForm");
            _mainForm = mainForm;
            _dockingManager = dockingManager as DockingManager;
            if (_dockingManager == null)
            {
                throw new ApplicationException(
                    "Failed to initialize DockPanelCollection. No docking manager is provided.");
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
                    yield return new DockPanel(_dockingManager, dockItem);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Lock()
        {
            _dockingManager.LockHostFormUpdate();
            _locked = true;
        }

        public void Unlock()
        {
            _dockingManager.UnlockHostFormUpdate();
            _locked = false;
        }

        public bool Locked
        {
            get { return _locked; }
        }

        public IDockPanel Add(Control control, DockPanelState state, bool visible, int size, PluginIdentity identity)
        {
            if (control == null)
            {
                throw new NullReferenceException();
            }

            bool locked = _locked;
            if (!locked)
            {
                Lock();
            }
            
            _dockingManager.SetEnableDocking(control, true);
            _dockingManager.SetDockVisibility(control, visible);
            _dockingManager.DockControl(control, _mainForm, DockHelper.MapWindowToSyncfusion(state), size);
            _dockingManager.UnlockHostFormUpdate();

            if (!locked)
            {
                Unlock();
            }

            if (_dict.ContainsKey(control))
            {
                throw new ApplicationException("This control has been already added as a docking window");
            }
            _dict.Add(control, identity);

            return new DockPanel(_dockingManager, control);
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

            if (_dict[panel.Control] == identity)
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
                if (_dict[p.Control] == identity)
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
    }
}
