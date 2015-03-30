using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.Api.Concrete;

namespace MW5.UI.Controls
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
