using System;
using System.Drawing;

namespace MW5.Api.Interfaces
{
    public interface IGeometryStyle: IComWrapper
    {
        IGeometryFillStyle Fill { get; }
        IGeometryLineStyle Line { get; }
        IGeometryMarkerStyle Marker { get; }
        IGeometryVertexStyle Vertices { get; }

        bool DynamicVisibility { get; set; }
        double MaxVisibleScale { get; set; }
        double MinVisibleScale { get; set; }
        bool Visible { get; set; }

        IGeometryStyle Clone();
        void Deserialize(string newVal);
        string Serialize();

        bool DrawLine(IntPtr hdc, float x, float y, int width, int height, bool drawVertices, int clipWidth, int clipHeight, Color? backColor = null);
        bool DrawPoint(IntPtr hdc, float x, float y, int clipWidth = 0, int clipHeight = 0, Color? backColor = null);
        bool DrawRectangle(IntPtr hdc, float x, float y, int width, int height, bool drawVertices, int clipWidth = 0, int clipHeight = 0, Color? backColor = null);
        bool DrawShape(IntPtr hdc, float x, float y, IGeometry geometry, bool drawVertices, int clipWidth, int clipHeight, Color? backColor = null);

        bool DrawLine(Graphics g, float x, float y, int width, int height, bool drawVertices, int clipWidth, int clipHeight, Color? backColor = null);
        bool DrawPoint(Graphics g, float x, float y, int clipWidth = 0, int clipHeight = 0, Color? backColor = null);
        bool DrawRectangle(Graphics g, float x, float y, int width, int height, bool drawVertices, int clipWidth = 0, int clipHeight = 0, Color? backColor = null);
        bool DrawShape(Graphics g, float x, float y, IGeometry geometry, bool drawVertices, int clipWidth, int clipHeight, Color? backColor = null);
    }
}