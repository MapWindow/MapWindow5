using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Services.Properties;
using MW5.Services.Views;

namespace MW5.Services.Helpers
{
    public static class LayerIconHelper
    {
        public static int GetIcon(ILayer layer)
        {
            if (layer == null)
            {
                return GetIcon();
            }

            var geomType = layer.IsVector ? layer.FeatureSet.GeometryType : GeometryType.None;

            return GetIcon(layer.LayerType, geomType);
        }

        public static int GetIcon(ILayerSource source)
        {
            if (source == null)
            {
                return GetIcon();
            }

            var gt = LayerSourceHelper.GetGeometryType(source);
            
            return GetIcon(source.LayerType, gt);
        }

        private static int GetIcon(LayerType layerType = LayerType.Invalid, GeometryType geometryType = GeometryType.None)
        {
            switch (layerType)
            {
                case LayerType.Shapefile:
                case LayerType.VectorLayer:
                    switch (geometryType)
                    {
                        case GeometryType.Point:
                        case GeometryType.MultiPoint:
                            return 0;
                        case GeometryType.Polyline:
                            return 1;
                        case GeometryType.Polygon:
                            return 2;
                    }
                    return 3;
                case LayerType.Image:
                case LayerType.Grid:
                    return 4;
                
            }

            return -1;
        }

        public static ImageList CreateImageList()
        {
            var list = new ImageList { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new System.Drawing.Size(20, 20) };
            list.Images.Add(Resources.img_point);
            list.Images.Add(Resources.img_line);
            list.Images.Add(Resources.img_polygon);
            list.Images.Add(Resources.img_geometry);
            list.Images.Add(Resources.img_raster);
            return list;
        }
    }
}
