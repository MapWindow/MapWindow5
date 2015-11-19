using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Identifier.Controls;
using MW5.Plugins.Identifier.Enums;
using MW5.Plugins.Interfaces;
using MW5.UI.Controls;
using MW5.UI.Helpers;

namespace MW5.Plugins.Identifier.Views
{
    /// <summary>
    /// Represents dock panel with identifier tree view.
    /// </summary>
    public partial class IdentifierDockPanel: DockPanelControlBase, IIdentifierView
    {
        private readonly IAppContext _context;

        public event Action ModeChanged;
        public event Action ItemSelected;

        public IdentifierDockPanel(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();

            InitTreeView();

            InitModeCombo();

            toolZoomToShape.Tag = 0;
            toolZoomToShape.Click += (s, e) => { toolZoomToShape.Checked = !toolZoomToShape.Checked; };
        }

        private void InitTreeView()
        {
            _treeView.CreateColumns();

            _treeView.Initialize(_context);

            _treeView.AfterSelect += NodeAfterSelect;
        }
        
        private void InitModeCombo()
        {
            _cboIdentifierMode.AddItemsFromEnum<IdentifierMode>();
            _cboIdentifierMode.SetValue(AppConfig.Instance.IdentifierMode);

            _cboIdentifierMode.SelectedIndexChanged += (s, e) =>
                {
                    AppConfig.Instance.IdentifierMode = Mode;
                    FireModeChanged();
                };
        }

        public void UpdateView()
        {
            lblEmpty.Visible = _context.Map.IdentifiedShapes.Count == 0;
            _treeView.Visible = !lblEmpty.Visible;
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

        public IdentifierMode Mode
        {
            get { return _cboIdentifierMode.GetValue<IdentifierMode>(); }
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
