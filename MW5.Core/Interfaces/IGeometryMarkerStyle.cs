namespace MW5.Core.Interfaces
{
    public interface IGeometryMarkerStyle
    {
        MarkerType MarkerType { get; set; }
        VectorMarkerType VectorMarker { get; set; }
        char FontCharacter { get; set; }
        double Rotation { get; set; }
        int VectorMarkerSideCount { get; set; }
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
    }
}
