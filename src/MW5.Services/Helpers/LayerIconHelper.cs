using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Services.Properties;
using MW5.Services.Views;

namespace MW5.Services.Helpers
{
    public static class LayerIconHelper
    {
        public static int GetIcon(ILayer layer)
        {
            if (layer != null)
            {
                if (layer.IsVector)
                {
                    switch (layer.FeatureSet.GeometryType)
                    {
                        case GeometryType.Point:
                        case GeometryType.MultiPoint:
                            return 0;
                        case GeometryType.Polyline:
                            return 1;
                        case GeometryType.Polygon:
                            return 2;
                    }
                }
                else
                {
                    return 4;
                }
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
