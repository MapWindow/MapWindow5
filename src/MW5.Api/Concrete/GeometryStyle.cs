using System;
using System.Drawing;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class GeometryStyle: IGeometryStyle
    {
        private readonly ShapeDrawingOptions _style;

        public GeometryStyle()
        {
            _style = new ShapeDrawingOptions();
        }

        internal GeometryStyle(ShapeDrawingOptions style)
        {
            if (style == null)
            {
                throw new NullReferenceException("Internal style reference is null.");
            }
            _style = style;
        }

        public IGeometryFillStyle Fill
        {
            get { return new GeometryFillStyle(_style); }
        }

        public IGeometryLineStyle Line
        {
            get { return new GeometryLineStyle(_style); }
        }

        public IGeometryMarkerStyle Marker
        {
            get { return new GeometryMarkerStyle(_style); }
        }

        public IGeometryVertexStyle Vertices
        {
            get { return new GeometryVertexStyle(_style); }
        }

        public bool DynamicVisibility
        {
            get { return _style.DynamicVisibility; }
            set { _style.DynamicVisibility = value; }
        }

        public double MaxVisibleScale
        {
            get { return _style.MaxVisibleScale; }
            set { _style.MaxVisibleScale = value; }
        }

        public double MinVisibleScale
        {
            get { return _style.MinVisibleScale; }
            set { _style.MinVisibleScale = value; }
        }

        public bool Visible
        {
            get { return _style.Visible; }
            set { _style.Visible = value; }
        }

        public IGeometryStyle Clone()
        {
            return new GeometryStyle(_style);
        }

        public void Deserialize(string newVal)
        {
            _style.Deserialize(newVal);
        }

        public string Serialize()
        {
            return _style.Serialize();
        }

        public bool DrawLine(IntPtr hdc, float x, float y, int width, int height, bool drawVertices, int clipWidth, int clipHeight,
            Color? backColor = null)
        {
            return _style.DrawLine(hdc, x, y, width, height, drawVertices, clipWidth, clipHeight, backColor.ToUInt());
        }

        public bool DrawPoint(IntPtr hdc, float x, float y, int clipWidth = 0, int clipHeight = 0, Color? backColor = null)
        {
            return _style.DrawPoint(hdc, x, y, clipWidth, clipHeight, backColor.ToUInt());
        }

        public bool DrawRectangle(IntPtr hdc, float x, float y, int width, int height, bool drawVertices, int clipWidth = 0,
            int clipHeight = 0, Color? backColor = null)
        {
            return _style.DrawRectangle(hdc, x, y, width, height, drawVertices, clipWidth, clipHeight,
                backColor.ToUInt());
        }

        public bool DrawShape(IntPtr hdc, float x, float y, IGeometry geometry, bool drawVertices, int clipWidth, int clipHeight,
            Color? backColor = null)
        {
            return _style.DrawShape(hdc, x, y, geometry.GetInternal(), drawVertices, clipWidth, clipHeight, backColor.ToUInt());
        }

        public bool DrawLine(Graphics g, float x, float y, int width, int height, bool drawVertices, int clipWidth, int clipHeight,
            Color? backColor = null)
        {
            IntPtr hdc = g.GetHdc();
            bool result = DrawLine(hdc, x, y, width, height, drawVertices, clipWidth, clipHeight, backColor);
            g.ReleaseHdc(hdc);
            return result;
        }

        public bool DrawPoint(Graphics g, float x, float y, int clipWidth = 0, int clipHeight = 0, Color? backColor = null)
        {
            IntPtr hdc = g.GetHdc();
            bool result = _style.DrawPoint(hdc, x, y, clipWidth, clipHeight, backColor.ToUInt());
            g.ReleaseHdc(hdc);
            return result;
        }

        public bool DrawRectangle(Graphics g, float x, float y, int width, int height, bool drawVertices, int clipWidth = 0,
            int clipHeight = 0, Color? backColor = null)
        {
            IntPtr hdc = g.GetHdc();
            bool result = _style.DrawRectangle(hdc, x, y, width, height, drawVertices, clipWidth, clipHeight, backColor.ToUInt());
            g.ReleaseHdc(hdc);
            return result;
        }

        public bool DrawShape(Graphics g, float x, float y, IGeometry geometry, bool drawVertices, int clipWidth, int clipHeight,
            Color? backColor = null)
        {
            IntPtr hdc = g.GetHdc();
            bool result = _style.DrawShape(hdc, x, y, geometry.GetInternal(), drawVertices, clipWidth, clipHeight, backColor.ToUInt());
            g.ReleaseHdc(hdc);
            return result;
        }

        public object InternalObject
        {
            get { return _style; }
        }

        public string LastError
        {
            get { return _style.ErrorMsg[_style.LastErrorCode]; }
        }

        public string Tag
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }
    }
}
