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
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Docking
{
    internal class DockPanelCollection: IDockPanelCollection
    {
        private bool _locked;
        private readonly Form _mainForm;
        private DockingManager _dockingManager;
        private Dictionary<Control, DockPanelInfo> _dict = new Dictionary<Control, DockPanelInfo>();

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

            _dockingManager.DockTabAlignment = DockTabAlignmentStyle.Bottom;
            _dockingManager.ShowCaptionImages = false;
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
                    yield return new DockPanel(_dockingManager, dockItem, _mainForm);
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

            return new DockPanel(_dockingManager, control, _mainForm);
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
                    return new DockPanel(_dockingManager, item.Key, _mainForm);
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
    }
}
