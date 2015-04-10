using System.Drawing;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IGeometryVertexStyle
    {
        Color Color { get; set; }
        bool FillVisible { get; set; }
        int Size { get; set; }
        VertexType VertexType { get; set; }
        bool Visible { get; set; }
    }
}
