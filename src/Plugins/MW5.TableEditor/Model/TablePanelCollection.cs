using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.UI.Docking;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.TableEditor.Model
{
    public class TablePanelCollection: IEnumerable<ITablePanel>
    {
        private readonly DockingManager _dockingManager;
        private readonly Control _parent;

        public event EventHandler<TablePanelCancelEventArgs> BeforePanelClosed;
        public event EventHandler<TablePanelEventArgs> PanelActivated;

        /// <summary>
        /// Initializes a new instance of the <see cref="TablePanelCollection"/> class.
        /// </summary>
        internal TablePanelCollection(object dockingManager, Control parent)
        {
            _parent = parent;
            _dockingManager = dockingManager as DockingManager;

            if (parent == null) throw new ArgumentNullException("parent");
            if (_dockingManager == null) throw new ArgumentNullException("dockingManager");
            
            InitManager();

            _dockingManager.DockVisibilityChanging += OnDockVisibilityChanging;

            _dockingManager.DockControlActivated += OnDockControlActivated;
        }

        private void InitManager()
        {
            _dockingManager.EnableDoubleClickOnCaption = false;
            _dockingManager.ShowCaption = true;
            _dockingManager.DragProviderStyle = DragProviderStyle.VS2012;
            _dockingManager.VisualStyle = VisualStyle.Default;
            _dockingManager.DockToFill = true;
            _dockingManager.DisallowFloating = true;
            _dockingManager.AutoHideEnabled = false;
            _dockingManager.HostFormClientBorder = false;
            _dockingManager.PaintBorders = false;
            _dockingManager.DockTabAlignment = DockTabAlignmentStyle.Bottom;
            _dockingManager.ShowCaptionImages = false;
        }

        public IEnumerator<ITablePanel> GetEnumerator()
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
        }

        public void Unlock()
        {
            _dockingManager.UnlockDockPanelsUpdate();
            _dockingManager.UnlockHostFormUpdate();
        }

        public ITablePanel Add(Control control, string key)
        {
            if (control == null)
            {
                throw new NullReferenceException();
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ApplicationException("Dock panel must have a unique key.");
            }

            control.Name = key;     // to save / restore layout each dock panel must have a key

            _dockingManager.SetEnableDocking(control, true);

            _dockingManager.EnableAutoHideTabContextMenu = false;
            _dockingManager.SetMenuButtonVisibility(control, false);

            _dockingManager.ActivateControl(control);

            return GetDockPanel(control);
        }

        public void ActivatePanel(int layerHandle)
        {
            foreach (var panel in this)
            {
                if (panel.LayerHandle == layerHandle)
                {
                    _dockingManager.ActivateControl(panel.Control);
                }
            }
        }

        public void Remove(IDockPanel panel)
        {
            if (panel == null) throw new ArgumentException("panel");
            _dockingManager.SetEnableDocking(panel.Control, false);
            _parent.Controls.Remove(panel.Control);
        }

        public ITablePanel ActivePanel
        {
            get
            {
                var control = _dockingManager.ActiveControl;

                // active control is stored even after panel was removed
                // so make sure that the panel still exists
                var panel = this.FirstOrDefault(p => p.Control == control);

                return (control != null && panel != null) ? GetDockPanel(control) : null;
            }
        }

        private void OnDockControlActivated(object sender, DockActivationChangedEventArgs arg)
        {
            var handler = PanelActivated;
            if (handler != null)
            {
                var panel = GetDockPanel(arg.Control);

                var e = new TablePanelEventArgs(panel, panel.LayerHandle);
                handler(sender, e);
            }
        }

        private void OnDockVisibilityChanging(object sender, DockVisibilityChangingEventArgs arg)
        {
            if (!arg.Control.Visible) return;

            var handler = BeforePanelClosed;
            if (handler != null)
            {
                var panel = GetDockPanel(arg.Control);

                var e = new TablePanelCancelEventArgs(panel, panel.LayerHandle);
                handler(sender, e);

                if (e.Cancel)
                {
                    arg.Cancel = true;
                }
            }
        }

        private ITablePanel GetDockPanel(Control control)
        {
            return new TablePanel(_dockingManager, control, _parent);
        }
    }
}
