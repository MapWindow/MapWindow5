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
            double width, height;

            // for geographic coordinate systems distortions are too high
            // to be meaningful in scale calculations
            if (!map.Projection.IsEmpty && !map.Projection.IsGeographic)
            {
                if (map.Projection.HasTransformation)
                {
                    // the projection supports coordinate tranformation to WGS84
                    if (CalculateExtentsWidth(map, extents, out width) &&
                        CalculateExtentsHeight(map, extents, out height))
                    {
                        size = new GeoSize(width, height);
                        return true;
                    }
                }
            }

            // we have nothing better but return width and height of the extents in original
            // coordinate system; only let's convert them to meters (geodesic size is always in meters)
            width = UnitConversionHelper.Convert(map.MapUnits, LengthUnits.Meters, extents.Width);
            height = UnitConversionHelper.Convert(map.MapUnits, LengthUnits.Meters, extents.Height);

            size = new GeoSize(width, height);
            return true;
        }

        public static bool GetGeodesicSizePrecise(this IPrintableMap map, IEnvelope extents, out GeoSize size)
        {
            size = null;
            double width, height;

            if (map.Projection.HasTransformation)
            {
                // the projection supports coordinate tranformation to WGS84
                if (CalculateExtentsWidth(map, extents, out width) &&
                    CalculateExtentsHeight(map, extents, out height))
                {
                    size = new GeoSize(width, height);
                    return true;
                }
            }

            if (map.Projection.IsGeographic)
            {
                // it's WGS84
                var center = extents.Center;

                width = GeodesicDistance(center.Y, extents.MinX, center.Y, extents.MaxX);
                height = GeodesicDistance(extents.MinY, center.X, extents.MaxY, center.X);

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
