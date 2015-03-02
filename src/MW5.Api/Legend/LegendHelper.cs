using System.Drawing;
using System.Windows.Forms;
using MapWinGIS;
using Image = System.Drawing.Image;

namespace MW5.Api.Legend
{
    public static class LegendHelper
    {
        // temporary
        public static string LastError { get; set; }

        internal static bool IsSupportedPicture(object picture)
        {
            if (picture == null)
            {
                return true;
            }

            var picType = picture.GetType();
            if (typeof (Icon) == picType)
            {
                return true;
            }

            if (typeof (MapWinGIS.Image) == picType)
            {
                return true;
            }

            if (typeof (Bitmap) == picType)
            {
                return true;
            }

            return false;
        }

        internal static LegendLayerType GetLayerType(object newLayer)
        {
            if (newLayer == null)
            {
                return LegendLayerType.Invalid;
            }

            if (newLayer is MapWinGIS.Image)
            {
                return LegendLayerType.Image;
            }

            var sf = newLayer as Shapefile;
            if (newLayer is IOgrLayer)
            {
                sf = (newLayer as IOgrLayer).GetBuffer();
            }
            else if (newLayer is Shapefile)
            {
                sf = newLayer as Shapefile;
            }

            if (sf != null)
            {
                var shpType = sf.ShapefileType2D;
                if (shpType == ShpfileType.SHP_POINT || shpType == ShpfileType.SHP_MULTIPOINT)
                {
                    return LegendLayerType.PointShapefile;
                }

                if (shpType == ShpfileType.SHP_POLYLINE)
                {
                    return LegendLayerType.LineShapefile;
                }

                if (shpType == ShpfileType.SHP_POLYGON)
                {
                    return LegendLayerType.PolygonShapefile;
                }
            }

            return LegendLayerType.Invalid;
        }

        internal static Image GetIcon(this ImageList imageList, LegendIcon icon)
        {
            return imageList.Images[(int) icon];
        }
    }
}