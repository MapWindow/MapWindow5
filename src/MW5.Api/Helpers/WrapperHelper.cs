using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;

namespace MW5.Api.Helpers
{
    public static class WrapperHelper
    {
        internal static ShapefileCategory GetInternal(this IFeatureCategory category)
        {
            return category.InternalObject as ShapefileCategory;
        }

        public static ColorScheme GetInternal(this ColorRamp ramp)
        {
            return ramp.InternalObject as ColorScheme;
        }

        public static Shape GetInternal(this IGeometry geometry)
        {
            return geometry.InternalObject as Shape;
        }

        public static Point GetInternal(this ICoordinate point)
        {
            return point.InternalObject as Point;
        }

        public static GeoProjection GetInternal(this ISpatialReference spatialReference)
        {
            return spatialReference.InternalObject as GeoProjection;
        }

        public static Extents GetInternal(this IEnvelope envelope)
        {
            return envelope.InternalObject as Extents;
        }

        public static Image GetInternal(this IImageSource image)
        {
            return image.InternalObject as Image;
        }

        public static Field GetInternal(this IFeatureField field)
        {
            return field.InternalObject as Field;
        }

        public static LabelCategory GetInternal(this ILabelStyle style)
        {
            return style.InternalObject as LabelCategory;
        }

        public static ShapeDrawingOptions GetInternal(this IGeometryStyle style)
        {
            return style.InternalObject as ShapeDrawingOptions;
        }

        public static Shapefile GetInternal(this IFeatureSet featureSet)
        {
            return featureSet.InternalObject as Shapefile;
        }

        public static GridHeader GetInternal(this GridSourceHeader header)
        {
            return header.InternalObject as GridHeader;
        }

        public static GridColorScheme GetInternal(this GridColorRamp colorRamp)
        {
            return colorRamp.InternalObject as GridColorScheme;
        }

        public static GridColorBreak GetInternal(this GridColorInterval interval)
        {
            return interval.InternalObject as GridColorBreak;
        }

        public static Vector GetInternal(this Vector3D interval)
        {
            return interval.InternalObject as Vector;
        }
        
        public static ChartField GetInternal(this DiagramField interval)
        {
            return interval.InternalObject as ChartField;
        }

        public static LineSegment GetInternal(this SimpleLine interval)
        {
            return interval.InternalObject as LineSegment;
        }

        public static LinePattern GetInternal(this CompositeLine interval)
        {
            return interval.InternalObject as LinePattern;
        }

        public static FieldStatOperations GetInternal(this FieldOperationList operations)
        {
            return operations.InternalObject as FieldStatOperations;
        }

        public static Grid GetInternal(this GridSource operations)
        {
            return operations.InternalObject as Grid;
        }
    }
}
