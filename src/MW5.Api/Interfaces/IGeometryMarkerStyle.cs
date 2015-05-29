using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IGeometryMarkerStyle
    {
        MarkerType Type { get; set; }
        VectorMarkerType VectorMarker { get; set; }
        char FontCharacter { get; set; }
        double Rotation { get; set; }
        int VectorSideCount { get; set; }
        float VectorMarkerSideRatio { get; set; }
        float Size { get; set; }
        IImageSource Icon { get; set; }
        double IconScaleX { get; set; }
        double IconScaleY { get; set; }
        FrameType FrameType { get; set; }
        bool FrameVisible { get; set; }
        bool AlignByBottom { get; set; }
        void SetVectorMarker(VectorMarker symbol);
        string FontName { get; set; }
        void UpdatePictureScale(bool scaleIcons, int iconSize);
    }
}
