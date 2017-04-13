using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Identifier.Enums;
using MW5.Plugins.Identifier.Properties;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;

namespace MW5.Plugins.Identifier.Controls
{
    /// <summary>
    /// Tree view with identified items, vector geometries or raster pixels.
    /// </summary>
    public class IdentifierTreeView: TwoColumnTreeView
    {
        private const int LocalStatsRange = 2;
        private IAppContext _context;

        public IdentifierTreeView()
        {
            Resize += OnResize;
            HideSelection = false;
        }

        public IdentifierNodeMetadata SelectedNodeMetadata
        {
            get
            {
                if (SelectedNode != null)
                {
                    return SelectedNode.Tag as IdentifierNodeMetadata;
                }

                return null;
            }
        }

        protected override IEnumerable<Bitmap> OnCreateImageList()
        {
            return new []
            {
                Resources.img_point,
                Resources.img_line,
                Resources.img_polygon,
                Resources.img_calculator16,
                Resources.img_raster,
                Resources.img_field16
            };
        }

        public void Initialize(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public void UpdateView()
        {
            Nodes.Clear();

            var root = GetLayerData();

            foreach (var item in root.SubItems)
            {
                AddSubItems(Nodes, item);    
            }
        }

        public IEnumerable<IdentifierNodeMetadata> GetLayerItems(int handle)
        {
            foreach (TreeNodeAdv node in Nodes)
            {
                var data = node.Tag as IdentifierNodeMetadata;
                if (data != null && data.LayerHandle == handle)
                {
                    foreach (TreeNodeAdv item in node.Nodes)
                    {
                        yield return item.Tag as IdentifierNodeMetadata;
                    }

                    break;
                }
            }
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

            if (AddVectorLayerNode(root, layer))
            {
                return;
            }

            AddRasterLayerNode(root, layer);
        }

        private void AddRasterLayerNode(NodeData root, ILayer layer)
        {
            var img = layer.ImageSource;

            if (img == null)
            {
                return;
            }

            var layerNode = new NodeData(layer.Name.ToUpper())
            {
                ImageIndex = (int)IdentifierIcon.Raster,
            };

            AddPixelNodes(layerNode, img, layer.Handle);

            layerNode.Value = layerNode.SubItems.Count() + " pixels";
            layerNode.Metadata = new IdentifierNodeMetadata(layer.Handle);

            root.AddSubItem(layerNode);
        }

        private bool AddVectorLayerNode(NodeData root, ILayer layer)
        {
            var fs = layer.FeatureSet;

            if (fs == null)
            {
                return false;
            }

            var layerNode = new NodeData(layer.Name.ToUpper())
            {
                ImageIndex = (int)GetIconForFeatureSet(fs),
            };

            AddShapeNodes(layerNode, fs, layer.Handle);

            layerNode.Value = layerNode.SubItems.Count() + " geometries";
            layerNode.Metadata = new IdentifierNodeMetadata(layer.Handle);

            root.AddSubItem(layerNode);

            return true;
        }

        private void AddPixelNodes(NodeData layerNode, IImageSource img, int layerHandle)
        {
            var pixels = _context.Map.IdentifiedShapes
                .Where(item => item.LayerHandle == layerHandle).Reverse().ToList();
                
            foreach (SelectionItem pixel in pixels)
            {
                var nodePixel = layerNode.AddSubItem("Pixel", string.Format("(row = {0}, column = {1})", pixel.Row, pixel.Column));
                nodePixel.Metadata = new IdentifierNodeMetadata(layerHandle, pixel.Row, pixel.Column);
                nodePixel.Expanded = false;

                var raster = img as IRasterSource;
                if (raster != null)
                {
                    DisplayPixelInfo(raster, nodePixel, pixel);
                }
                else
                {
                    AddColor(nodePixel, img.GetPixel(pixel.Row, pixel.Column));
                }
            }

            if (layerNode.SubItems.Any())
            {
                layerNode.SubItems.First().Expanded = true;
            }
        }

        private void DisplayPixelInfo(IRasterSource raster, NodeData nodePixel, SelectionItem pixel)
        {
            int bufferX, bufferY;
            raster.ImageToBuffer(pixel.Column, pixel.Row, out bufferX, out bufferY);

            if (raster.RenderingType != RasterRendering.Rgb)
            {
                var band = raster.ActiveBand;
                if (band != null)
                {
                    var nodeBand = nodePixel.AddSubItem("Band", raster.ActiveBandIndex);

                    double value;
                    nodeBand.AddSubItem("Value",
                        band.GetValue(pixel.Column, pixel.Row, out value)
                            ? value.ToString(CultureInfo.InvariantCulture)
                            : "Failed to retrieve");

                    ShowRasterCellInfo(nodeBand, raster);

                    nodeBand.AddSubItem("Interpretation", band.ColorInterpretation.EnumToString());

                    ShowLocalStatistics(nodePixel, band, pixel);
                }
            }
            else
            {
                var nodeInfo = nodePixel.AddSubItem("Info", " ");
                ShowRasterCellInfo(nodeInfo, raster);
            }

            AddColor(nodePixel, raster.GetPixel(bufferY, bufferX));

            if (raster.RenderingType == RasterRendering.Rgb)
            {
                if (raster.UseRgbBandMapping)
                {
                    NodeData nodeRgb = nodePixel.AddSubItem("RGB mapping", " ");

                    DisplayRgbMapping(nodeRgb, raster, pixel);
                }
            }

            DisplayPixelPosition(nodePixel, pixel, raster);
        }

        private void ShowLocalStatistics(NodeData parent, RasterBand band, SelectionItem pixel)
        {
            double min, max, mean, stdDev;
            int count;

            if (!band.ComputeLocalStatistics(pixel.Column, pixel.Row, LocalStatsRange, out min, out max, out mean, out stdDev,
                out count))
            {
                parent.AddSubItem("Local stats", "<failed to compute>");
            }
            else
            {
                var nodeStats = parent.AddSubItem("Local stats", LocalStatsRange + " pixel range");
                nodeStats.AddSubItem("Minimum", min);
                nodeStats.AddSubItem("Maximum", max);
                nodeStats.AddSubItem("Mean", mean);
                nodeStats.AddSubItem("Std. deviation", stdDev);
                nodeStats.AddSubItem("Count", count);
            }
        }

        private void ShowRasterCellInfo(NodeData node, IRasterSource raster)
        {
            node.AddSubItem("Data type", raster.DataType.EnumToString());

            node.AddSubItem("Cell size", string.Format("{0:g5} × {1:g5}", raster.BufferDx, raster.BufferDy));
        }

        private void DisplayRgbMapping(NodeData nodeRgb, IRasterSource raster, SelectionItem pixel)
        {
            var indices = new List<int>();
            if (!raster.UseRgbBandMapping)
            {
                for (int i = 1; i <= Math.Max(4, raster.NumBands); i++)
                {
                    indices.Add(i);
                }
            }
            else
            {
                indices.Add(raster.RedBandIndex);
                indices.Add(raster.GreenBandIndex);
                indices.Add(raster.BlueBandIndex);
                indices.Add(raster.AlphaBandIndex);
            }

            for (int i = 0; i < indices.Count; i++)
            {
                if (indices[i] <= 0 || indices[i] > raster.NumBands)
                {
                    continue;
                }

                string channel = ((RgbChannel) i).EnumToString();
                var nodeBand = nodeRgb.AddSubItem("Band " + (i + 1), channel);

                var band = raster.Bands[indices[i]];
                if (band != null)
                {
                    double value;
                    nodeBand.AddSubItem("Value",
                         band.GetValue(pixel.Column, pixel.Row, out value)
                             ? value.ToString(CultureInfo.InvariantCulture)
                             : "Failed to retrieve");

                    if (raster.UseRgbBandMapping)
                    {
                        nodeBand.AddSubItem("Original index", indices[i]);
                    }
                }
            }
        }

        private void DisplayPixelPosition(NodeData nodePixel, SelectionItem pixel, IRasterSource raster)
        {
            var nodeBuffer = nodePixel.AddSubItem("Position", " ");

            double projX, projY;
            raster.ImageToProjection(pixel.Column, pixel.Row, out projX, out projY);

            double degX, degY;
            if (_context.Map.ProjToDegrees(projX, projY, out degX, out degY))
            {
                nodeBuffer.AddSubItem("Latitude", GeoAngle.FromDouble(degY).ToString());
                nodeBuffer.AddSubItem("Longitude", GeoAngle.FromDouble(degX).ToString());
            }
            
            nodeBuffer.AddSubItem("Projected X", projX.ToString("0.0"));
            nodeBuffer.AddSubItem("Projected Y", projY.ToString("0.0"));
        }

        private void AddColor(NodeData parent, Color color)
        {
            NodeData data = parent.AddSubItem("Color", "");
            data.AddSubItem("R", color.R);
            data.AddSubItem("G", color.G);
            data.AddSubItem("B", color.B);
            data.AddSubItem("A", color.A);
        }

        private void AddShapeNodes(NodeData layerNode, IFeatureSet fs, int layerHandle)
        {
            var shapes = _context.Map.IdentifiedShapes
                            .Where(item => item.LayerHandle == layerHandle)
                            .Select(item => item.ShapeIndex)
                            .ToList();

            var geomTypeName = fs.GeometryType.EnumToString();

            bool geodesic = _context.Map.Measuring.IsUsingEllipsoid;

            foreach (var shapeIndex in shapes)
            {
                var nodeShape = layerNode.AddSubItem(geomTypeName, "Shape id = " + shapeIndex);

                DisplayAttributes(fs, nodeShape, shapeIndex, layerHandle, geodesic);
            }

            var firstOrDefault = layerNode.SubItems.FirstOrDefault();
            if (firstOrDefault != null)
            {
                firstOrDefault.Expanded = true;
            }
        }

        private void DisplayAttributes(IFeatureSet fs, NodeData nodeShape, int shapeIndex, int layerHandle, bool geodesic)
        {
            var fields = fs.Table.Fields;

            var fieldsNode = nodeShape.AddSubItem("Fields", string.Empty);
            //fieldsNode.ImageIndex = (int)IdentifierIcon.Field;

            for (int i = 0; i < fields.Count; i++)
            {
                var fld = fields[i];
                if (!fld.Visible)
                {
                    continue;
                }

                var value = fs.Table.CellValue(i, shapeIndex);
                fieldsNode.AddSubItem(fld.DisplayName, value != null ? value.ToString() : "<null>");
                nodeShape.Metadata = new IdentifierNodeMetadata(layerHandle, shapeIndex);
            }

            var calcNode = nodeShape.AddSubItem("Calculated", string.Empty);
            //calcNode.ImageIndex = (int)IdentifierIcon.Calculated;
            GetCalculatedFields(calcNode, fs.Features[shapeIndex].Geometry, geodesic);
        }

        private void GetCalculatedFields(NodeData root, IGeometry geometry, bool geodesic)
        {
            if (geometry == null) return;
            

            switch (geometry.GeometryType)
            {
                case GeometryType.Point:
                    if (geometry.Points.Count > 0)
                    {
                        var pnt = geometry.Points[0];
                        root.AddSubItem("X", pnt.X);
                        root.AddSubItem("Y", pnt.Y);
                    }
                    break;
                case GeometryType.Polyline:
                    root.AddSubItem("Parts", geometry.Parts.Count);
                    root.AddSubItem("Points", geometry.Points.Count);
                    root.AddSubItem(geodesic ? "Length, m" : "Length", GetLength(geometry, geodesic));
                    break;
                case GeometryType.Polygon:
                    root.AddSubItem("Parts", geometry.Parts.Count);
                    root.AddSubItem("Points", geometry.Points.Count);
                    root.AddSubItem(geodesic ? "Perimeter, m" : "Perimeter", GetLength(geometry, geodesic));
                    root.AddSubItem(geodesic ? "Area, sq.m" : "Area", GetArea(geometry, geodesic));
                    break;
                case GeometryType.MultiPoint:
                    root.AddSubItem("Parts", geometry.Parts.Count);
                    break;
            }
        }

        private double GetArea(IGeometry g, bool geodesic)
        {
            return geodesic ? _context.Map.GeodesicArea(g) : g.Area;
        }

        private double GetLength(IGeometry g, bool geodesic)
        {
            return geodesic ? _context.Map.GeodesicLength(g) : g.Length;
        }

        private IdentifierIcon GetIconForFeatureSet(IFeatureSet featureSet)
        {
            // ReSharper disable once RedundantCaseLabel
            switch (featureSet.GeometryType)
            {
                case GeometryType.Point:
                case GeometryType.MultiPoint:
                    return IdentifierIcon.Point;
                case GeometryType.Polyline:
                    return IdentifierIcon.Line;
                case GeometryType.Polygon:
                    return IdentifierIcon.Polygon;
                case GeometryType.None:
                default:
                    return IdentifierIcon.None;
            }
        }

        private void OnResize(object sender, EventArgs e)
        {
            if (Columns.Count != 2) return;
            
            const int padding = 20;
            int cmnWidth = (Width - padding)/2;

            Columns[1].Width = cmnWidth;
            Columns[0].Width = cmnWidth;
        }
    }
}
