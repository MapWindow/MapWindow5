using MapWinGIS;

namespace MW5.Core.Helpers
{
    internal static class GeometryHelper
    {
        public static ShpfileType GeometryType2ShpType(GeometryType type, ZValueType zValue = ZValueType.None)
        {
            switch (type)
            {
                case GeometryType.None:
                    return ShpfileType.SHP_NULLSHAPE;
                case GeometryType.Point:
                    if (zValue == ZValueType.None) return ShpfileType.SHP_POINT;
                    if (zValue == ZValueType.M) return ShpfileType.SHP_POINTM;
                    if (zValue == ZValueType.Z) return ShpfileType.SHP_POINTZ;
                    break;
                case GeometryType.Polyline:
                    if (zValue == ZValueType.None) return ShpfileType.SHP_POLYLINE;
                    if (zValue == ZValueType.M) return ShpfileType.SHP_POLYLINEM;
                    if (zValue == ZValueType.Z) return ShpfileType.SHP_POLYLINEZ;
                    break;
                case GeometryType.Polygon:
                    if (zValue == ZValueType.None) return ShpfileType.SHP_POLYGON;
                    if (zValue == ZValueType.M) return ShpfileType.SHP_POLYGONM;
                    if (zValue == ZValueType.Z) return ShpfileType.SHP_POLYGONZ;
                    break;
                case GeometryType.MultiPoint:
                    if (zValue == ZValueType.None) return ShpfileType.SHP_MULTIPOINT;
                    if (zValue == ZValueType.M) return ShpfileType.SHP_MULTIPOINTM;
                    if (zValue == ZValueType.Z) return ShpfileType.SHP_MULTIPOINTZ;
                    break;
            }
            return ShpfileType.SHP_NULLSHAPE;
        }

        public static GeometryType ShapeType2GeometryType(ShpfileType shpType)
        {
            switch (shpType)
            {
                case ShpfileType.SHP_NULLSHAPE:
                case ShpfileType.SHP_MULTIPATCH:
                    return GeometryType.None;
                case ShpfileType.SHP_POINT:
                case ShpfileType.SHP_POINTZ:
                case ShpfileType.SHP_POINTM:
                    return GeometryType.Point;
                case ShpfileType.SHP_POLYLINE:
                case ShpfileType.SHP_POLYLINEZ:
                case ShpfileType.SHP_POLYLINEM:
                    return GeometryType.Polyline;
                case ShpfileType.SHP_POLYGON:
                case ShpfileType.SHP_POLYGONM:
                case ShpfileType.SHP_POLYGONZ:
                    return GeometryType.Polygon;
                case ShpfileType.SHP_MULTIPOINT:
                case ShpfileType.SHP_MULTIPOINTZ:
                case ShpfileType.SHP_MULTIPOINTM:
                    return GeometryType.MultiPoint;
                default:
                    return GeometryType.None;
            }
        }

        public static ZValueType ShapeType2ZValueType(ShpfileType shpType)
        {
            switch (shpType)
            {
                case ShpfileType.SHP_NULLSHAPE:
                case ShpfileType.SHP_MULTIPATCH:
                case ShpfileType.SHP_POINT:
                case ShpfileType.SHP_POLYLINE:
                case ShpfileType.SHP_POLYGON:
                case ShpfileType.SHP_MULTIPOINT:
                    return ZValueType.None;
                case ShpfileType.SHP_POINTZ:
                case ShpfileType.SHP_POLYLINEZ:
                case ShpfileType.SHP_POLYGONZ:
                case ShpfileType.SHP_MULTIPOINTZ:
                    return ZValueType.Z;
                case ShpfileType.SHP_POINTM:
                case ShpfileType.SHP_POLYLINEM:
                case ShpfileType.SHP_POLYGONM:
                case ShpfileType.SHP_MULTIPOINTM:
                    return ZValueType.M;
            }
            return ZValueType.None;
        }
    }
}