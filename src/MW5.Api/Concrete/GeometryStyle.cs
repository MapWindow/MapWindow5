using System;
using MapWinGIS;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class GeometryStyle: IGeometryStyle
    {
        private readonly ShapeDrawingOptions _style;

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
