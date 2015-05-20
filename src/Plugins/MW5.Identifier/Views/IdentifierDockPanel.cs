using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Plugins.Identifier.Controls;
using MW5.Plugins.Identifier.Enums;
using MW5.Plugins.Interfaces;
using MW5.UI.Controls;
using MW5.UI.Helpers;

namespace MW5.Plugins.Identifier.Views
{
    public partial class IdentifierDockPanel: DockPanelControlBase, IIdentifierView
    {
        public event Action ModeChanged;
        public event Action ItemSelected;

        public IdentifierDockPanel(IAppContext context)
        {
            InitializeComponent();

            _treeView.CreateColumns();

            InitModeCombo();

            _treeView.Initialize(context);

            _treeView.AfterSelect += NodeAfterSelect;

            toolZoomToShape.Tag = 0;
            toolZoomToShape.Click += (s, e) => { toolZoomToShape.Checked = !toolZoomToShape.Checked; };
        }
        
        private void InitModeCombo()
        {
            _cboIdentifierMode.AddItemsFromEnum<IdentifierPluginMode>();
            _cboIdentifierMode.SetValue(IdentifierPluginMode.CurrentLayer);
            _cboIdentifierMode.SelectedIndexChanged += (s, e) => FireModeChanged();
        }

        public void UpdateView()
        {
            _treeView.UpdateView();
        }

        public IEnumerable<IdentifierNodeMetadata> GetLayerItems(int handle)
        {
            return _treeView.GetLayerItems(handle);
        }

        public IdentifierNodeMetadata SelectedItem
        {
            get { return _treeView.SelectedNodeMetadata; }
        }

        public IdentifierPluginMode Mode
        {
            get { return _cboIdentifierMode.GetValue<IdentifierPluginMode>(); }
        }

        public bool ZoomToShape
        {
            get { return toolZoomToShape.Checked; }
        }

        public void Clear()
        {
            _treeView.Nodes.Clear();
        }

        private void FireModeChanged()
        {
            var handler = ModeChanged;
            if (handler != null)
            {
                handler();
            }
        }

        private void FireItemSelected()
        {
            var handler = ItemSelected;
            if (handler != null)
            {
                handler();
            }
        }

        private void NodeAfterSelect(object sender, EventArgs e)
        {
            var data = _treeView.SelectedNodeMetadata;
            if (data != null)
            {
                FireItemSelected();
            }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield return toolStripEx1.Items; }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }
    }
}
