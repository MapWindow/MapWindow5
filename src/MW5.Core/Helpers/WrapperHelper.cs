using MapWinGIS;
using MW5.Core.Concrete;
using MW5.Core.Interfaces;

namespace MW5.Core.Helpers
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

        public static LabelCategory GetInternal(this ILabelStyle field)
        {
            return field.InternalObject as LabelCategory;
        }

        public static ShapeDrawingOptions GetInternal(this IGeometryStyle field)
        {
            return field.InternalObject as ShapeDrawingOptions;
        }
    }
}
