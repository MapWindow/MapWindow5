using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
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
        private readonly IAppContext _context;
        public event Action ModeChanged;

        public IdentifierDockPanel(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();

            infoTreeViewBase1.CreateColumns();

            InitModeCombo();

            Resize += IdentifierDockPanel_Resize;
        }

        private void IdentifierDockPanel_Resize(object sender, EventArgs e)
        {
            const int padding = 20;
            int cmnWidth = (Width - padding) / 2;
            
            infoTreeViewBase1.Columns[1].Width = cmnWidth;
            infoTreeViewBase1.Columns[0].Width = cmnWidth;
        }

        private void InitModeCombo()
        {
            _cboIdentifierMode.AddItemsFromEnum<IdentifierPluginMode>();
            _cboIdentifierMode.SetValue(IdentifierPluginMode.CurrentLayer);
            _cboIdentifierMode.SelectedIndexChanged += (s, e) => FireModeChanged();
        }

        public IdentifierPluginMode Mode
        {
            get { return _cboIdentifierMode.GetValue<IdentifierPluginMode>(); }
        }

        public void UpdateView()
        {
            infoTreeViewBase1.Nodes.Clear();

            var root = GetLayerData();

            infoTreeViewBase1.AddSubItems(infoTreeViewBase1.Nodes, root);

            infoTreeViewBase1.ExpandAll();
        }

        private NodeData GetLayerData()
        {
            var root = new NodeData("Layers");

            var layers = _context.Map.IdentifiedShapes.Select(item => item.LayerHandle).Distinct();
            foreach (var layerHandle in layers)
            {
                AddLayerNode(root, layerHandle);
            }

            return root;
        }

        private void AddLayerNode(NodeData root, int layerHandle)
        {
            var layer = _context.Map.Layers.ItemByHandle(layerHandle);
            if (layer == null)
            {
                return;
            }
            
            var fs = layer.FeatureSet;

            if (fs == null)
            {
                return;
            }

            var layerNode = new NodeData(layer.Name);

            AddShapeNodes(layerNode, fs, layerHandle);

            root.AddSubItem(layerNode);
        }

        private void AddShapeNodes(NodeData layerNode, IFeatureSet fs, int layerHandle)
        {
            var shapes = _context.Map.IdentifiedShapes
                            .Where(item => item.LayerHandle == layerHandle)
                            .Select(item => item.ShapeIndex)
                            .ToList();

            foreach (var shapeIndex in shapes)
            {
                var nodeShape = layerNode.AddSubItem("Shape index", shapeIndex.ToString());

                var fields = fs.Table.Fields;
                for (int i = 0; i < fields.Count; i++)
                {
                    var fld = fields[i];
                    var value = fs.Table.CellValue(i, shapeIndex);
                    nodeShape.AddSubItem(fld.Name, value != null ? value.ToString(): "<null>");
                }
            }
        }

        public void Clear()
        {
            infoTreeViewBase1.Nodes.Clear();
        }

        private void FireModeChanged()
        {
            var handler = ModeChanged;
            if (handler != null)
            {
                handler();
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
