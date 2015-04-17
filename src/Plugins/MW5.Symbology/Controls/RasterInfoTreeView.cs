using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class RasterInfoTreeView : MultiColumnTreeView
    {
        public RasterInfoTreeView()
        {
            InitializeComponent();
        }

        public void Initialize(IRasterSource raster)
        {
            if (raster == null) return;

            Nodes.Clear();

            var root = GetRasterBandInfo(raster);

            var node = AddSubItems(Nodes, root);

            node.ExpandAll();
        }

        private TreeNodeAdv AddSubItems(TreeNodeAdvCollection nodes, NodeData data)
        {
            var node = GetNode(data);
            nodes.Add(node);

            foreach (var item in data.SubItems)
            {
                AddSubItems(node.Nodes, item);
            }

            return node;
        }

        private TreeNodeAdv GetNode(NodeData data)
        {
            var node = new TreeNodeAdv(data.Name);
            node.SubItems.Add(new TreeNodeAdvSubItem(data.Value));
            return node;
        }

        private NodeData GetRasterBandInfo(IRasterSource raster)
        {
            var root = new NodeData("Raster bands");

            var bands = raster.Bands;
            for (int i = 1; i <= bands.Count; i++)
            {
                var band = bands[i];

                var bandNode = new NodeData("Band " + i);
                bandNode.AddSubItem("Minimum", band.Minimum);
                bandNode.AddSubItem("Maximum", band.Maximum);
                bandNode.AddSubItem("No data value", band.NoDataValue);
                bandNode.AddSubItem("Color interpretation", band.ColorInterpretation.ToString());
                bandNode.AddSubItem("Overview count", band.OverviewCount);

                root.AddSubItem(bandNode);
            }

            return root;
        }
    }
}
