using System;
using System.Drawing;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class GeometryEditor: IGeometryEditor
    {
        private readonly ShapeEditor _editor;

        internal GeometryEditor(ShapeEditor editor)
        {
            _editor = editor;
            if (editor == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public double Area
        {
            get { return _editor.Area; }
        }

        public EditorBehavior EditorBehavior
        {
            get { return (EditorBehavior)_editor.EditorBehavior; }
            set { _editor.EditorBehavior = (tkEditorBehavior)value; }
        }

        public EditorState EditorState
        {
            get { return (EditorState)_editor.EditorState; }
        }

        public bool HasChanges
        {
            get { return _editor.HasChanges; }
        }

        public LayerSelectionMode HighlightVertices
        {
            get { return (LayerSelectionMode)_editor.HighlightVertices; }
            set { _editor.HighlightVertices = (tkLayerSelection)value; }
        }

        public SnapMode SnapMode
        {
            get { return (SnapMode)_editor.SnapMode; }
            set { _editor.SnapMode = (tkSnapMode) value; }
        }

        public bool IsDigitizing
        {
            get { return _editor.IsDigitizing; }
        }
        
        public bool IsEmpty
        {
            get { return _editor.IsEmpty; }
        }
        
        public bool IsUsingEllipsoid
        {
            get { return _editor.IsUsingEllipsoid; }
        }

        public int LayerHandle
        {
            get { return _editor.LayerHandle; }
        }

        public double Length
        {
            get { return _editor.Length; }
        }

        public int NumPoints
        {
            get { return _editor.numPoints; }
        }

        public IGeometry RawData
        {
            get { return new Geometry(_editor.RawData); }
        }
        
        public int SelectedVertex
        {
            get { return _editor.SelectedVertex; }
            set { _editor.SelectedVertex = value; }
        }

        public int ShapeIndex
        {
            get { return _editor.ShapeIndex; }
        }
        
        public GeometryType GeometryType
        {
            get { return GeometryHelper.ShapeType2GeometryType(_editor.ShapeType); }
            set { _editor.ShapeType = GeometryHelper.GeometryType2ShpType(value); }
        }

        public LayerSelectionMode SnapBehavior
        {
            get { return (LayerSelectionMode)_editor.SnapBehavior; }
            set { _editor.SnapBehavior = (tkLayerSelection)value; }
        }
        
        public double SnapTolerance
        {
            get { return _editor.SnapTolerance; }
            set { _editor.SnapTolerance = value; }
        }

        public IGeometry ValidatedShape
        {
            get { return new Geometry(_editor.ValidatedShape); }
        }
        
        public EditorValidation ValidationMode
        {
            get { return (EditorValidation)_editor.ValidationMode; }
            set { _editor.ValidationMode = (tkEditorValidation)value; }
        }
        
        public void Clear()
        {
            _editor.Clear();
        }

        public void CopyStyleFrom(IGeometryStyle style)
        {
            _editor.CopyOptionsFrom(style.GetInternal());
        }

        public ICoordinate GetPoint(int pointIndex)
        {
            double x, y;
            if (_editor.get_PointXY(pointIndex, out x, out y))
            {
                return new Coordinate(x, y);
            }
            return null;
        }

        public double GetSegmentAngle(int segmentIndex)
        {
            return _editor.SegmentAngle[segmentIndex];
        }

        public double GetSegmentLength(int segmentIndex)
        {
            return _editor.SegmentLength[segmentIndex];
        }

        public bool SetPoint(int pointIndex, double x, double y)
        {
            return _editor.put_PointXY(pointIndex, x, y);
        }

        public bool SetPoint(int pointIndex, ICoordinate pnt)
        {
            return _editor.put_PointXY(pointIndex, pnt.X, pnt.Y);
        }

        public bool SaveChanges()
        {
            return _editor.SaveChanges();
        }

        public bool ShowArea
        {
            get { return _editor.ShowArea; }
            set { _editor.ShowArea = value;  }
        }

        public bool StartEdit(int layerHandle, int shapeIndex)
        {
            return _editor.StartEdit(layerHandle, shapeIndex);
        }

        public bool StartOverlay(EditorOverlay overlayType)
        {
            return _editor.StartOverlay((tkEditorOverlay)overlayType);
        }

        public bool StartUnboundShape(GeometryType geomType)
        {
            return _editor.StartUnboundShape(GeometryHelper.GeometryType2ShpType(geomType));
        }

        public bool UndoPoint()
        {
            return _editor.UndoPoint();
        }

        public IMeasuringSettings Settings
        {
            get { return new EditorSettings(_editor); }
        }

        public object InternalObject
        {
            get { return _editor; }
        }

        public string LastError
        {
            get { return _editor.ErrorMsg[_editor.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _editor.Key; }
            set { _editor.Key = value; }
        }
    }
}
