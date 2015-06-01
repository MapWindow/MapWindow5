using System;
using System.Windows.Forms;
using AxMapWinGIS;
using MW5.Api.Events;
using MW5.Shared;

namespace MW5.Api.Map
{
    public partial class MapControl
    {
        public void AttachHandlers()
        {
            _map.ChooseLayer += MapChooseLayer;
            _map.AfterShapeEdit += MapAfterShapeEdit;
            _map.BackgroundLoadingFinished += MapBackgroundLoadingFinished;
            _map.BackgroundLoadingStarted += MapBackgroundLoadingStarted;
            _map.BeforeDeleteShape += MapBeforeDeleteShape;
            _map.BeforeShapeEdit += MapBeforeShapeEdit;
            _map.DblClick += MapDoubleClick;
            _map.ExtentsChanged += MapExtentsChanged;
            _map.FileDropped += MapFileDropped;
            _map.GridOpened += MapGridOpened;
            _map.LayerProjectionIsEmpty += MapLayerProjectionIsEmpty;
            _map.LayerReprojected += MapLayerReprojected;
            _map.MeasuringChanged += MapMeasuringChanged;
            _map.MouseDownEvent += MapMouseDownEvent;
            _map.MouseMoveEvent += MapMouseMoveEvent;
            _map.MouseUpEvent += MapMouseUpEvent;
            _map.ProjectionChanged += MapProjectionChanged;
            _map.ProjectionMismatch += MapProjectionMismatch;
            _map.SelectBoxFinal += MapSelectBoxFinal;
            _map.SelectionChanged += MapSelectionChanged;
            _map.ShapeHighlighted += MapShapeHighlighted;
            _map.ShapeIdentified += MapShapeIdentified;
            _map.ShapeValidationFailed += MapShapeValidationFailed;
            _map.TilesLoaded += MapTilesLoaded;
            _map.UndoListChanged += MapUndoListChanged;
            _map.ValidateShape += MapValidateShape;
        }

        public void DetachHandlers()
        {
            _map.ChooseLayer -= MapChooseLayer;
            _map.AfterShapeEdit -= MapAfterShapeEdit;
            _map.BackgroundLoadingFinished -= MapBackgroundLoadingFinished;
            _map.BackgroundLoadingStarted -= MapBackgroundLoadingStarted;
            _map.BeforeDeleteShape -= MapBeforeDeleteShape;
            _map.BeforeShapeEdit -= MapBeforeShapeEdit;
            _map.DblClick -= MapDoubleClick;
            _map.ExtentsChanged -= MapExtentsChanged;
            _map.FileDropped -= MapFileDropped;
            _map.GridOpened -= MapGridOpened;
            _map.LayerProjectionIsEmpty -= MapLayerProjectionIsEmpty;
            _map.LayerReprojected -= MapLayerReprojected;
            _map.MeasuringChanged -= MapMeasuringChanged;
            _map.MouseDownEvent -= MapMouseDownEvent;
            _map.MouseMoveEvent -= MapMouseMoveEvent;
            _map.MouseUpEvent -= MapMouseUpEvent;
            _map.ProjectionChanged -= MapProjectionChanged;
            _map.ProjectionMismatch -= MapProjectionMismatch;
            _map.SelectBoxFinal -= MapSelectBoxFinal;
            _map.SelectionChanged -= MapSelectionChanged;
            _map.ShapeHighlighted -= MapShapeHighlighted;
            _map.ShapeIdentified -= MapShapeIdentified;
            _map.ShapeValidationFailed -= MapShapeValidationFailed;
            _map.TilesLoaded -= MapTilesLoaded;
            _map.UndoListChanged -= MapUndoListChanged;
            _map.ValidateShape -= MapValidateShape;
        }

        #region Handlers

        private void MapValidateShape(object sender, _DMapEvents_ValidateShapeEvent e)
        {
            Invoke(sender, ValidateShape, new ValidateShapeEventArgs(e));
        }

        private void MapUndoListChanged(object sender, EventArgs e)
        {
            Invoke(sender, HistoryChanged, e);
        }

        private void MapTilesLoaded(object sender, _DMapEvents_TilesLoadedEvent e)
        {
            Invoke(sender, TilesLoaded, new TilesLoadedEventArgs(e));
        }

        private void MapShapeValidationFailed(object sender, _DMapEvents_ShapeValidationFailedEvent e)
        {
            Invoke(sender, ShapeValidationFailed, new ShapeValidationFailedEventArgs(e));
        }

        private void MapShapeIdentified(object sender, _DMapEvents_ShapeIdentifiedEvent e)
        {
            Invoke(sender, ShapeIdentified, new ShapeIdentifiedEventArgs(e));
        }

        private void MapShapeHighlighted(object sender, _DMapEvents_ShapeHighlightedEvent e)
        {
            Invoke(sender, ShapeHighlighted, new ShapeHightlightedEventArgs(e));
        }

        private void MapSelectionChanged(object sender, _DMapEvents_SelectionChangedEvent e)
        {
            Invoke(sender, SelectionChanged, new SelectionChangedEventArgs(e));
        }

        private void MapSelectBoxFinal(object sender, _DMapEvents_SelectBoxFinalEvent e)
        {
            Invoke(sender, SelectBoxFinal, new SelectBoxFinalEventArgs(e));
        }

        private void MapProjectionMismatch(object sender, _DMapEvents_ProjectionMismatchEvent e)
        {
            Invoke(sender, ProjectionMismatch, new ProjectionMismatchEventArgs(e));
        }

        private void MapProjectionChanged(object sender, EventArgs e)
        {
            Invoke(sender, ProjectionChanged, e);
        }

        private void MapMouseUpEvent(object sender, _DMapEvents_MouseUpEvent e)
        {
            var button = MouseEventHelper.ParseMouseButton(e.button);
            var args = new MouseEventArgs(button, 1, e.x, e.y, 0);
            Invoke(sender, MouseUp, args);
        }

        private void MapMouseMoveEvent(object sender, _DMapEvents_MouseMoveEvent e)
        {
            var button = MouseEventHelper.ParseMouseButton(e.button);
            var args = new MouseEventArgs(button, 1, e.x, e.y, 0);
            Invoke(sender, MouseMove, args);
        }

        private void MapMouseDownEvent(object sender, _DMapEvents_MouseDownEvent e)
        {
            var button = MouseEventHelper.ParseMouseButton(e.button);
            var args = new MouseEventArgs(button, 1, e.x, e.y, 0);
            Invoke(sender, MouseDown, args);
        }

        private void MapMeasuringChanged(object sender, _DMapEvents_MeasuringChangedEvent e)
        {
            Invoke(sender, MeasuringChanged, new MeasuringChangedEventArgs(e));
        }

        private void MapLayerReprojected(object sender, _DMapEvents_LayerReprojectedEvent e)
        {
            Invoke(sender, LayerReprojected, new LayerReprojectedEventArgs(e));
        }

        private void MapLayerProjectionIsEmpty(object sender, _DMapEvents_LayerProjectionIsEmptyEvent e)
        {
            Invoke(sender, LayerProjectionIsEmpty, new LayerProjectionIsEmptyEventArgs(e));
        }

        private void MapGridOpened(object sender, _DMapEvents_GridOpenedEvent e)
        {
            Invoke(sender, GridOpened, new GridOpenedEventArgs(e));
        }

        private void MapFileDropped(object sender, _DMapEvents_FileDroppedEvent e)
        {
            Invoke(sender, FileDropped, new FileDroppedEventArgs(e.filename));
        }

        private void MapExtentsChanged(object sender, EventArgs e)
        {
            Invoke(sender, ExtentsChanged, e);
        }
        
        private void MapDoubleClick(object sender, EventArgs e)
        {
            Invoke(sender, MouseDoubleClick, e);
        }

        private void MapChooseLayer(object sender, _DMapEvents_ChooseLayerEvent e)
        {
            Invoke(sender, ChooseLayer, new ChooseLayerEventArgs(e));
        }

        private void MapBeforeShapeEdit(object sender, _DMapEvents_BeforeShapeEditEvent e)
        {
            Invoke(sender, BeforeShapeEdit, new BeforeShapeEditEventArgs(e));
        }

        private void MapBeforeDeleteShape(object sender, _DMapEvents_BeforeDeleteShapeEvent e)
        {
            Invoke(sender, BeforeDeleteShape, new BeforeDeleteShapeEventArgs(e));
        }

        private void MapBackgroundLoadingStarted(object sender, _DMapEvents_BackgroundLoadingStartedEvent e)
        {
            Invoke(sender, BackgroundLoadingStarted, new BackgroundLoadingStartedEventArgs(e));
        }

        private void MapBackgroundLoadingFinished(object sender, _DMapEvents_BackgroundLoadingFinishedEvent e)
        {
            Invoke(sender, BackgroundLoadingFinished, new BackgroundLoadingFinishedEventArgs(e));
        }

        private void MapAfterShapeEdit(object sender, _DMapEvents_AfterShapeEditEvent e)
        {
            Invoke(sender, AfterShapeEdit, new AfterShapeEditEventArgs(e));
        }

        #endregion

        private void Invoke<T>(object sender, EventHandler<T> d, T args) where T : EventArgs
        {
            var handler = d;
            if (handler != null)
            {
                handler.Invoke(this, args);
            }
        }

        protected void FireMapCursorChanged(object sender, EventArgs args)
        {
            Invoke(sender, MapCursorChanged, args);
        }

        internal void FireSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            Invoke(sender, SelectionChanged, args);
        }

        protected void FireMapLocked(object sender, LockedEventArgs args)
        {
            Invoke(sender, MapLocked, args);
        }
    }
}
