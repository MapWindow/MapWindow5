using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Map;
using MW5.Api.Static;

namespace MW5.Api.Helpers
{
    public static class GeodesicUtils
    {
        public static double GeodesicDistance(double lat1, double lng1, double lat2, double lng2)
        {
            return GisUtils.Instance.GetInternal().GeodesicDistance(lat1, lng1, lat2, lng2);
        }

        public static bool ConvertDistance(LengthUnits sourceUnit, LengthUnits targetUnit, ref double value)
        {
            return GisUtils.Instance.GetInternal().ConvertDistance((tkUnitsOfMeasure)sourceUnit, (tkUnitsOfMeasure)targetUnit, ref value);
        }

        public static double GeodesicArea(IGeometry polygonWgs84)
        {
            return GisUtils.Instance.GetInternal().GeodesicArea(polygonWgs84.InternalObject as Shape);
        }

        /// <summary>
        /// Calculates the size of currently selected map extents in meters
        /// </summary>
        public static bool GetGeodesicSize(this IPrintableMap map, out GeoSize size)
        {
            return GetGeodesicSize(map, map.Extents, out size);
        }

        /// <summary>
        /// Calculates the size of specified map extents in meters.
        /// </summary>
        public static bool GetGeodesicSize(this IPrintableMap map, IEnvelope extents, out GeoSize size)
        {
            size = null;

            if (!map.Projection.HasTransformation)
            {
                return false;
            }

            double width, height;
            if (CalculateExtentsWidth(map, extents, out width) && CalculateExtentsHeight(map, extents, out height))
            {
                size = new GeoSize(width, height);
                return true;
            }

            return false;
        }

        private static bool CalculateExtentsWidth(this IPrintableMap map, IEnvelope extents, out double width)
        {
            var center = extents.Center;
            double lng = extents.MinX;
            double lat = center.Y;
            double lng2 = extents.MaxX;
            double lat2 = center.Y;

            width = 0.0;

            if (map.Projection.Transform(ref lng, ref lat) && map.Projection.Transform(ref lng2, ref lat2))
            {
                width = GeodesicDistance(lat, lng, lat2, lng2);
                return true;
            }

            return false;
        }

        private static bool CalculateExtentsHeight(this IPrintableMap map, IEnvelope extents, out double height)
        {
            var center = extents.Center;

            double lng = center.X;
            double lat = extents.MinY;
            double lng2 = center.X;
            double lat2 = extents.MaxY;

            height = 0.0;

            if (map.Projection.Transform(ref lng, ref lat) && map.Projection.Transform(ref lng2, ref lat2))
            {
                height = GeodesicDistance(lat, lng, lat2, lng2);
                return true;
            }

            return false;
        }

    }
}
