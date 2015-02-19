using System.Drawing;
using System.Drawing.Drawing2D;

namespace MW5.Core.Interfaces
{
    public interface IGeometryLineStyle
    {
        byte AlphaTransparency { get; set; }
        bool Visible { get; set; }
        float Width { get; set; }
        Color Color { get; set; }
        DashStyle DashStyle { get; set; }
        /*
        bool UseLinePattern { get; set; }
        LinePattern LinePattern { get; set; }
         */
    }
}
