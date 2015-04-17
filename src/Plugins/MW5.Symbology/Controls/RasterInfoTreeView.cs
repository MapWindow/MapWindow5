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
using MW5.Api.Concrete;
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

            var root = GetRasterInfo(raster);

            var bandsData = GetBandsInfo(raster);
            root.AddSubItem(bandsData);

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

        private NodeData GetRasterInfo(IRasterSource raster)
        {
            var root = new NodeData("Raster Info");

            var general = new NodeData("General");
            general.AddSubItem("Width", raster.Width);
            general.AddSubItem("Height", raster.Height);
            general.AddSubItem("Palette", raster.PaletteInterpretation.ToString());
            root.AddSubItem(general);

            var bounds = new NodeData("Bounds");
            bounds.AddSubItem("Dx", raster.Dx);
            bounds.AddSubItem("Dy", raster.Dy);
            bounds.AddSubItem("XllCenter", raster.XllCenter);
            bounds.AddSubItem("YllCenter", raster.YllCenter);
            root.AddSubItem(bounds);

            var buffer = new NodeData("Buffer");
            buffer.AddSubItem("Width", raster.BufferWidth);
            buffer.AddSubItem("Height", raster.BufferHeight);
            buffer.AddSubItem("Dx", raster.BufferDx);
            buffer.AddSubItem("Dy", raster.BufferDy);
            buffer.AddSubItem("XllCenter", raster.BufferXllCenter);
            buffer.AddSubItem("YllCenter", raster.BufferYllCenter);
            root.AddSubItem(buffer);

            return root;
        }

        private NodeData GetBandsInfo(IRasterSource raster)
        {
            var root = new NodeData("Bands");

            var bands = raster.Bands;
            for (int i = 1; i <= bands.Count; i++)
            {
                var band = bands[i];

                var bandNode = new NodeData("Band " + i);
                bandNode.AddSubItem("Data type", band.DataType.ToString());
                bandNode.AddSubItem("Unit type", band.UnitType);
                bandNode.AddSubItem("Minimum", band.Minimum);
                bandNode.AddSubItem("Maximum", band.Maximum);
                bandNode.AddSubItem("No data value", band.NoDataValue);
                bandNode.AddSubItem("Color interpretation", band.ColorInterpretation.ToString());
                bandNode.AddSubItem("Overview count", band.OverviewCount);

                var metadata = GetMetadata(band);
                if (metadata != null)
                {
                    bandNode.AddSubItem(metadata);
                }

                root.AddSubItem(bandNode);
            }

            return root;
        }

        private NodeData GetMetadata(RasterBand band)
        {
            if (band.MetadataCount > 0)
            {
                var metadata = new NodeData("Metadata");
                for (int j = 0; j < band.MetadataCount; j++)
                {
                    string s = band.get_MetadataItem(j);
                    var parts = s.Split('=');
                    if (parts.Length == 2)
                    {
                        metadata.AddSubItem(parts[0], parts[1]);
                    }
                }

                return metadata;
            }

            return null;
        }
    }
}
