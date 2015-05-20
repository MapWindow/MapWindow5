using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Events;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Events;
using MW5.Plugins.Identifier.Controls;
using MW5.Plugins.Identifier.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI.Controls;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools;
using Action = System.Action;

namespace MW5.Plugins.Identifier.Views
{
    public partial class IdentifierDockPanel: DockPanelControlBase, IIdentifierView
    {
        public event Action ModeChanged;
        public event EventHandler<ShapeEventArgs> ShapeSelected;
        public event EventHandler<RasterEventArgs> PixelSelected;

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

        private void NodeAfterSelect(object sender, EventArgs e)
        {
            var data = _treeView.SelectedNodeMetadata;
            if (data != null)
            {
                switch (data.NodeType)
                {
                    case IdentifierNodeType.Geometry:
                        FireShapeSelected(data.LayerHandle, data.ShapeIndex);
                        break;
                    case IdentifierNodeType.Pixel:
                        FirePixelSelected(data.LayerHandle, data.RasterX, data.RasterY);
                        break;
                }
            }
        }

        private void FirePixelSelected(int layerHandle, int rasterX, int rasterY)
        {
            var handler = PixelSelected;
            if (handler != null)
            {
                handler(this, new RasterEventArgs(layerHandle, rasterX, rasterY));
            }
        }

        private void FireShapeSelected(int layerHandle, int shapeIndex)
        {
            var handler = ShapeSelected;
            if (handler != null)
            {
                handler(this, new ShapeEventArgs(layerHandle, shapeIndex));
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
