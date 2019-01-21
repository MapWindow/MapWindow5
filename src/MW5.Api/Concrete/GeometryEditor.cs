using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
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

        private class CustomGeometryEditorEvents {
            public event EventHandler BeforeClearChangesEvent;
            internal void InvokeBeforeClearChangesEvent(object sender)
                => BeforeClearChangesEvent?.Invoke(sender, new EventArgs());

            public event CancelEventHandler BeforeSaveChangesEvent;
            internal bool InvokeBeforeSaveChangesEvent(object sender)
            {
                if (BeforeSaveChangesEvent != null)
                {
                    var args = new CancelEventArgs();
                    foreach (Delegate handler in BeforeSaveChangesEvent.GetInvocationList())
                    {
                        handler.DynamicInvoke(this, args);
                        if (args.Cancel)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            // The C# GeometryEditor gets re-created on the fly each time it is accesed from the map.
            // This table maps the actual COM object to the correct events we've added.
            private static ConditionalWeakTable<object, object> eventDict = new ConditionalWeakTable<object, object>();
            internal static CustomGeometryEditorEvents Get(object _editor) {
                eventDict.TryGetValue(_editor, out var fetched);
                if (!(fetched is CustomGeometryEditorEvents events))
                {
                    events = new CustomGeometryEditorEvents();
                    eventDict.Remove(_editor);
                    eventDict.Add(_editor, events);
                }
                return events;
            }
        }
        

        #region BeforeClearChangesEvent
        public event EventHandler BeforeClearChangesEvent
        {
            add
            {
                CustomGeometryEditorEvents.Get(_editor).BeforeClearChangesEvent += value;
            }
            remove
            {
                CustomGeometryEditorEvents.Get(_editor).BeforeClearChangesEvent -= value;
            }
        }
        protected virtual void RaiseBeforeClearChangesEvent() => CustomGeometryEditorEvents.Get(_editor).InvokeBeforeClearChangesEvent(this);
        #endregion

        #region BeforeSaveChangesEvent
        public event CancelEventHandler BeforeSaveChangesEvent
        {
            add
            {
                CustomGeometryEditorEvents.Get(_editor).BeforeSaveChangesEvent += value;
            }
            remove
            {
                CustomGeometryEditorEvents.Get(_editor).BeforeSaveChangesEvent -= value;
            }
        }
        protected virtual bool RaiseBeforeSaveChangesEvent() => CustomGeometryEditorEvents.Get(_editor).InvokeBeforeSaveChangesEvent(this);
        #endregion

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

        public bool AddPoint(ICoordinate pnt)
        {
            return _editor.AddPoint((MapWinGIS.Point) pnt.InternalObject);
        }

        public void Clear()
        {
            RaiseBeforeClearChangesEvent();
            _editor.Clear();
        }

        public bool SaveChanges()
        {
            if (RaiseBeforeSaveChangesEvent())
                return _editor.SaveChanges();
            return false;
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
