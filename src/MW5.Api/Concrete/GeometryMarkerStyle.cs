using System;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class GeometryMarkerStyle: IGeometryMarkerStyle
    {
        private readonly ShapeDrawingOptions _style;

        public GeometryMarkerStyle(ShapeDrawingOptions style)
        {
            if (style == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
            _style = style;
        }

        public MarkerType Type
        {
            get { return (MarkerType)_style.PointType; }
            set { _style.PointType = (tkPointSymbolType)value; }
        }

        public VectorMarkerType VectorMarker
        {
            get { return (VectorMarkerType)_style.PointShape; }
            set { _style.PointShape = (tkPointShapeType)value; }
        }

        public char FontCharacter
        {
            get { return (char)_style.PointCharacter; }
            set { _style.PointCharacter = (short)value; }
        }

        public double Rotation
        {
            get { return _style.PointRotation; }
            set { _style.PointRotation = value; }
        }

        public int VectorSideCount
        {
            get { return _style.PointSidesCount; }
            set { _style.PointSidesCount = value; }
        }

        public float VectorMarkerSideRatio
        {
            get { return _style.PointSidesRatio; }
            set { _style.PointSidesRatio = value; }
        }

        public float Size
        {
            get { return _style.PointSize; }
            set { _style.PointSize = value; }
        }

        public IImageSource Icon
        {
            get
            {
                var img = _style.Picture;
                return img != null ? BitmapSource.Wrap(img) : null;
            }
            set { _style.Picture = value.GetInternal(); }
        }

        public double IconScaleX
        {
            get { return _style.PictureScaleX; }
            set { _style.PictureScaleX = value; }
        }

        public double IconScaleY
        {
            get { return _style.PictureScaleY; }
            set { _style.PictureScaleY = value; }
        }

        public FrameType FrameType
        {
            get { return (FrameType)_style.FrameType; }
            set { _style.FrameType = (tkLabelFrameType)value; }
        }

        public bool FrameVisible
        {
            get { return _style.FrameVisible; }
            set { _style.FrameVisible = value; }
        }

        public bool AlignByBottom
        {
            get { return _style.AlignPictureByBottom; }
            set { _style.AlignPictureByBottom = value; }
        }

        public void SetVectorMarker(VectorMarker symbol)
        {
            _style.SetDefaultPointSymbol((tkDefaultPointSymbol)symbol);
        }

        public string FontName
        {
            get { return _style.FontName; }
            set { _style.FontName = value; }
        }
    }
}
