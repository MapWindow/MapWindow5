using MW5.Api.Concrete;
using MW5.Api.Enums;

namespace MW5.UI.Legacy
{
    /// <summary>
    /// Utility structure to hold drawing options with type
    /// </summary>
    public class GeometryRowStyle
    {
        internal GeometryStyle Style;
        internal GeometryType Type;

        public GeometryRowStyle(GeometryStyle style, GeometryType type)
        {
            Style = style;
            Type = type;
        }
    }
}
