using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapWinGIS;

namespace MW5.Api.Legend
{
    public static class LegendHelper
    {
        internal static System.Drawing.Image GetIcon(this ImageList imageList, LegendIcon icon)
        {
            return imageList.Images[(int) icon];
        }
        
        public static bool IsSupportedPicture(object picture)
        {
            if (picture == null)
                return true;

            Type picType = picture.GetType();
            if (typeof(Icon) == picType)
                return true;
            if (typeof(MapWinGIS.Image) == picType)
                return true;
            if (typeof(Bitmap) == picType)
                return true;

            return false;
        }

        public static LegendLayerType GetLayerType(object newLayer)
        {
            if (newLayer == null) return LegendLayerType.Invalid;

            if (newLayer is MapWinGIS.Image)
                return LegendLayerType.Image;

            var sf = newLayer as Shapefile;
            if (newLayer is IOgrLayer)
                sf = (newLayer as IOgrLayer).GetBuffer();
            else if (newLayer is Shapefile)
                sf = newLayer as Shapefile;

            if (sf != null)
            {
                var shpType = sf.ShapefileType2D;
                if (shpType == ShpfileType.SHP_POINT || shpType == ShpfileType.SHP_MULTIPOINT)
                    return LegendLayerType.PointShapefile;
                if (shpType == ShpfileType.SHP_POLYLINE)
                    return LegendLayerType.LineShapefile;
                if (shpType == ShpfileType.SHP_POLYGON)
                    return LegendLayerType.PolygonShapefile;
            }
            return LegendLayerType.Invalid;
        }

        // temporary
        public static string LastError = "";
    }
}
