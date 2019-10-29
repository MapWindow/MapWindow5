using System.Drawing;
using MW5.Api.Interfaces;

namespace MW5.Plugins.AdvancedSnapping.Services
{
    public interface IDrawingService
    {
        Color FillColor { get; set; }
        Color StrokeColor { get; set; }

        Color HighlightColor { get; set; }

        void DrawCircle(string context, ICoordinate poi, double radius, short strokeWidth, bool fill = false);
        void DrawLine(string context, ICoordinate from, ICoordinate to, short strokeWidth);
        void DrawPoint(string context, ICoordinate poi, int size, short strokeWidth);

        void Remove(string context);
    }
}