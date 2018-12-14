using System.Drawing;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IGeometryEditor: IComWrapper
    {
        double Area { get; }
        EditorBehavior EditorBehavior { get; set; }
        EditorState EditorState { get; }
        bool HasChanges { get; }
        LayerSelectionMode HighlightVertices { get; set; }
        bool IsDigitizing { get; }
        bool IsEmpty { get; }
        bool IsUsingEllipsoid { get; }
        int LayerHandle { get; }
        double Length { get; }
        int NumPoints { get; }
        IGeometry RawData { get; }
        int SelectedVertex { get; set; }
        int ShapeIndex { get; }
        GeometryType GeometryType { get; set; }
        LayerSelectionMode SnapBehavior { get; set; }
        SnapMode SnapMode { get; set; }
        double SnapTolerance { get; set; }
        IGeometry ValidatedShape { get; }
        EditorValidation ValidationMode { get; set; }
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
        IMeasuringSettings Settings { get; }
        bool ShowArea { get; set; }
    }
}