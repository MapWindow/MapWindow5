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

namespace MW5.Plugins.Identifier.Controls
{
    public class IdentifierTreeView: TwoColumnTreeView
    {
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
                Resources.img_raster
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

        private bool AddRasterLayerNode(NodeData root, ILayer layer)
        {
            var img = layer.ImageSource;

            if (img == null)
            {
                return false;
            }

            var layerNode = new NodeData(layer.Name.ToUpper())
            {
                ImageIndex = (int)IdentifierIcon.Raster,
                LargerHeight = true
            };

            AddPixelNodes(layerNode, img, layer.Handle);

            layerNode.Value = layerNode.SubItems.Count() + " pixels";
            layerNode.Metadata = new IdentifierNodeMetadata(layer.Handle);

            root.AddSubItem(layerNode);

            return true;
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
                LargerHeight = true
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
                .Where(item => item.LayerHandle == layerHandle).ToList();

            foreach (var pixel in pixels)
            {
                var nodePixel = layerNode.AddSubItem("Pixel", string.Format("(row = {0}, cmn = {1})", pixel.RasterX, pixel.RasterY));

                var raster = img as IRasterSource;
                if (raster != null)
                {
                    DisplayRasterInfo(raster, nodePixel, pixel);
                }
                else
                {
                    AddColor(nodePixel, img.GetPixel(pixel.RasterX, pixel.RasterY));
                }
            }
        }

        private void DisplayRasterInfo(IRasterSource raster, NodeData nodePixel, SelectionItem pixel)
        {
            int bufferX, bufferY;
            raster.ImageToBuffer(pixel.RasterX, pixel.RasterY, out bufferX, out bufferY);

            if (raster.RenderingType != RasterRendering.Rgb)
            {
                var band = raster.ActiveBand;
                if (band != null)
                {
                    var nodeBand = nodePixel.AddSubItem("Band", raster.ActiveBandIndex);

                    double value;
                    if (band.GetValue(pixel.RasterX, pixel.RasterY, out value))
                    {
                        nodeBand.AddSubItem("Value", value.ToString(CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        nodeBand.AddSubItem("Value", "Failed to retrieve");
                    }

                    nodeBand.AddSubItem("Interpretation", band.ColorInterpretation.EnumToString());
                }
            }
            else
            {
                // TODO: display values for RGB rendering                        
                nodePixel.AddSubItem("RGB values", "Not implemented");
            }

            AddColor(nodePixel, raster.GetPixel(bufferY, bufferX));

            var nodeBuffer = nodePixel.AddSubItem("Buffer", " ");
            nodeBuffer.AddSubItem("BufferX", bufferX);
            nodeBuffer.AddSubItem("BufferY", bufferY);
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

            int iconIndex = (int)GetIconForFeatureSet(fs);

            var geomTypeName = fs.GeometryType.EnumToString();

            bool geodesic = _context.Map.Measuring.IsUsingEllipsoid;

            foreach (var shapeIndex in shapes)
            {
                var nodeShape = layerNode.AddSubItem(geomTypeName, shapeIndex.ToString());
                nodeShape.ImageIndex = iconIndex;
                nodeShape.Expanded = false;
                nodeShape.LargerHeight = true;

                var fields = fs.Table.Fields;

                for (int i = 0; i < fields.Count; i++)
                {
                    var fld = fields[i];
                    var value = fs.Table.CellValue(i, shapeIndex);
                    nodeShape.AddSubItem(fld.Name, value != null ? value.ToString() : "<null>");
                    nodeShape.Metadata = new IdentifierNodeMetadata(layerHandle, shapeIndex);
                }

                var calcNode = nodeShape.AddSubItem("Calculated", string.Empty);
                calcNode.ImageIndex = (int)IdentifierIcon.Calculated;
                calcNode.LargerHeight = true;
                GetCalculatedFields(calcNode, fs.Features[shapeIndex].Geometry, geodesic);
            }

            var firstOrDefault = layerNode.SubItems.FirstOrDefault();
            if (firstOrDefault != null)
            {
                firstOrDefault.Expanded = true;
            }
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
                    root.AddSubItem("Number of parts", geometry.Parts.Count);
                    root.AddSubItem("Number of points", geometry.Points.Count);
                    root.AddSubItem(geodesic ? "Length, m" : "Length", GetLength(geometry, geodesic));
                    break;
                case GeometryType.Polygon:
                    root.AddSubItem("Number of parts", geometry.Parts.Count);
                    root.AddSubItem("Number of points", geometry.Points.Count);
                    root.AddSubItem(geodesic ? "Perimeter, m" : "Perimeter", GetLength(geometry, geodesic));
                    root.AddSubItem(geodesic ? "Area, sq.m" : "Area", GetArea(geometry, geodesic));
                    break;
                case GeometryType.MultiPoint:
                    root.AddSubItem("Number of parts", geometry.Parts.Count);
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
