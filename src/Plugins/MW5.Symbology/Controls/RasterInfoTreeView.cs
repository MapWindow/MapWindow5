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
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Shared;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class RasterInfoTreeView : TwoColumnTreeView
    {
        public RasterInfoTreeView()
        {
            InitializeComponent();

        }

        public void Initialize(IRasterSource raster)
        {
            if (raster == null) return;

            Nodes.Clear();

            var root = PopulateTree(raster);

            var node = AddSubItems(Nodes, root);

            node.ExpandAll();
        }

        private NodeData PopulateTree(IRasterSource raster)
        {
            var root = new NodeData(" ");

            var general = new NodeData("General");
            general.AddSubItem("Size", string.Format("{0}×{1}", raster.Width, raster.Height));
            general.AddSubItem("Palette", raster.PaletteInterpretation.ToString());
            general.AddSubItem("Bands", raster.NumBands);
            general.AddSubItem("Driver", raster.Driver.Name);

            root.AddSubItem(general);

            var bandsData = GetBandsInfo(raster);
            root.AddSubItem(bandsData);

            AddBounds(root, raster);

            return root;
        }

        private void AddBounds(NodeData root, IRasterSource raster)
        {
            var bounds = new NodeData("Bounds");
            bounds.AddSubItem("Cell size", string.Format("{0}×{1}", raster.Dx, raster.Dy));
            bounds.AddSubItem("Lower left corner", string.Format("{0};{1}", raster.XllCenter, raster.YllCenter));
            root.AddSubItem(bounds);

            var buffer = new NodeData("Buffer");
            buffer.AddSubItem("Width", raster.BufferWidth);
            buffer.AddSubItem("Height", raster.BufferHeight);
            buffer.AddSubItem("Cell size", string.Format("{0}×{1}", raster.BufferDx, raster.BufferDy));
            buffer.AddSubItem("Lower left corner", string.Format("{0};{1}", raster.BufferXllCenter, raster.BufferYllCenter));
            
            root.AddSubItem(buffer);
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
                
                // TODO: restore; temporarily commented
                //bandNode.AddSubItem("Minimum", band.Minimum);
                //bandNode.AddSubItem("Maximum", band.Maximum);

                bandNode.AddSubItem("No data value", band.NoDataValue.ToString(CultureInfo.InvariantCulture));
                bandNode.AddSubItem("Color interpretation", band.ColorInterpretation.ToString());
                bandNode.AddSubItem("Overview count", band.Overviews.Count);

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
