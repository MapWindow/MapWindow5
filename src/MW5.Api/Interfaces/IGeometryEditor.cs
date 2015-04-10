using System.Drawing;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IGeometryEditor: IComWrapper
    {
        AngleDisplay AngleDisplayMode { get; set; }
        double Area { get; }
        AreaDisplay AreaDisplay { get; set; }
        EditorBehavior EditorBehavior { get; set; }
        EditorState EditorState { get; }
        Color FillColor { get; set; }
        byte AlpaFillTransparency { get; set; }
        bool HasChanges { get; }
        LayerSelectionMode HighlightVertices { get; set; }
        bool IndicesVisible { get; set; }
        bool IsDigitizing { get; }
        bool IsEmpty { get; }
        bool IsUsingEllipsoid { get; }
        int LayerHandle { get; }
        double Length { get; }
        LengthDisplay LengthDisplayMode { get; set; }
        Color LineColor { get; set; }
        float LineWidth { get; set; }
        int NumPoints { get; }
        IGeometry RawData { get; }
        int SelectedVertex { get; set; }
        int ShapeIndex { get; }
        GeometryType GeometryType { get; set; }
        LayerSelectionMode SnapBehavior { get; set; }
        double SnapTolerance { get; set; }
        IGeometry ValidatedShape { get; }
        EditorValidation ValidationMode { get; set; }
        bool VerticesVisible { get; set; }
        void Clear();
        void CopyStyleFrom(IGeometryStyle style);
        ICoordinate GetPoint(int pointIndex);
        double GetSegmentAngle(int segmentIndex);
        double GetSegmentLength(int segmentIndex);
        bool SetPoint(int pointIndex, double x, double y);
        bool SetPoint(int pointIndex, ICoordinate pnt);
        bool SaveChanges();
        bool StartEdit(int layerHandle, int shapeIndex);
        bool StartOverlay(EditorOverlay overlayType);
        bool StartUnboundShape(GeometryType geomType);
        bool UndoPoint();
    }
}