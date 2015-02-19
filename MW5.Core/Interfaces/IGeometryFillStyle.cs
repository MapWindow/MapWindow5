using System.Drawing;
using System.Drawing.Drawing2D;

namespace MW5.Core.Interfaces
{
    public interface IGeometryFillStyle
    {
        GradientBounds GradientBounds { get; set; }
        GradientType GradientType { get; set; }
        FillType FillType { get; set; }
        double Rotation { get; set; }
        byte AlphaTransparency { get; set; }
        Color Color { get; set; }
        Color Color2 { get; set; }
        Color BackgroundHatchColor { get; set; }
        bool BackgroundHatchTransparent { get; set; }
        bool Visible { get; set; }
        HatchStyle HatchStyle { get; set; }
        void SetGradient(Color color, byte range);
    }
}
