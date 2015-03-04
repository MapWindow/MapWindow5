using System;
using System.Windows.Forms;
using AxMapWinGIS;
using MW5.Api.Events;
using MW5.Api.Helpers;

namespace MW5.Api
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
            _map.DblClick += MapDblClick;
            _map.ExtentsChanged += MapExtentsChanged;
            _map.FileDropped += MapFileDropped;
            _map.GridOpened += MapGridOpened;
            _map.LayerAdded += MapLayerAdded;
            _map.LayerProjectionIsEmpty += MapLayerProjectionIsEmpty;
            _map.LayerRemoved += MapLayerRemoved;
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
            _map.DblClick -= MapDblClick;
            _map.ExtentsChanged -= MapExtentsChanged;
            _map.FileDropped -= MapFileDropped;
            _map.GridOpened -= MapGridOpened;
            _map.LayerAdded -= MapLayerAdded;
            _map.LayerProjectionIsEmpty -= MapLayerProjectionIsEmpty;
            _map.LayerRemoved -= MapLayerRemoved;
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
            AssignHandler(sender, ValidateShape, new ValidateShapeEventArgs(e));
        }

        private void MapUndoListChanged(object sender, EventArgs e)
        {
            AssignHandler(sender, UndoListChanged, e);
        }

        private void MapTilesLoaded(object sender, _DMapEvents_TilesLoadedEvent e)
        {
            AssignHandler(sender, TilesLoaded, new TilesLoadedEventArgs(e));
        }

        private void MapShapeValidationFailed(object sender, _DMapEvents_ShapeValidationFailedEvent e)
        {
            AssignHandler(sender, ShapeValidationFailed, new ShapeValidationFailedEventArgs(e));
        }

        private void MapShapeIdentified(object sender, _DMapEvents_ShapeIdentifiedEvent e)
        {
            AssignHandler(sender, ShapeIdentified, new ShapeIdentifiedEventArgs(e));
        }

        private void MapShapeHighlighted(object sender, _DMapEvents_ShapeHighlightedEvent e)
        {
            AssignHandler(sender, ShapeHighlighted, new ShapeHightlightedEventArgs(e));
        }

        private void MapSelectionChanged(object sender, _DMapEvents_SelectionChangedEvent e)
        {
            AssignHandler(sender, SelectionChanged, new SelectionChangedEventArgs(e));
        }

        private void MapSelectBoxFinal(object sender, _DMapEvents_SelectBoxFinalEvent e)
        {
            AssignHandler(sender, SelectBoxFinal, new SelectBoxFinalEventArgs(e));
        }

        private void MapProjectionMismatch(object sender, _DMapEvents_ProjectionMismatchEvent e)
        {
            AssignHandler(sender, ProjectionMismatch, new ProjectionMismatchEventArgs(e));
        }

        private void MapProjectionChanged(object sender, EventArgs e)
        {
            AssignHandler(sender, ProjectionChanged, e);
        }

        private void MapMouseUpEvent(object sender, _DMapEvents_MouseUpEvent e)
        {
            var button = MouseEventHelper.ParseMouseButton(e.button);
            var args = new MouseEventArgs(button, 1, e.x, e.y, 0);
            AssignHandler(sender, MouseUp, args);
        }

        private void MapMouseMoveEvent(object sender, _DMapEvents_MouseMoveEvent e)
        {
            var button = MouseEventHelper.ParseMouseButton(e.button);
            var args = new MouseEventArgs(button, 1, e.x, e.y, 0);
            AssignHandler(sender, MouseMove, args);
        }

        private void MapMouseDownEvent(object sender, _DMapEvents_MouseDownEvent e)
        {
            var button = MouseEventHelper.ParseMouseButton(e.button);
            var args = new MouseEventArgs(button, 1, e.x, e.y, 0);
            AssignHandler(sender, MouseDown, args);
        }

        private void MapMeasuringChanged(object sender, _DMapEvents_MeasuringChangedEvent e)
        {
            AssignHandler(sender, MeasuringChanged, new MeasuringChangedEventArgs(e));
        }

        private void MapLayerReprojected(object sender, _DMapEvents_LayerReprojectedEvent e)
        {
            AssignHandler(sender, LayerReprojected, new LayerReprojectedEventArgs(e));
        }

        private void MapLayerRemoved(object sender, _DMapEvents_LayerRemovedEvent e)
        {
            AssignHandler(sender, LayerRemoved, new LayerRemovedEventArgs(e));
        }

        private void MapLayerProjectionIsEmpty(object sender, _DMapEvents_LayerProjectionIsEmptyEvent e)
        {
            AssignHandler(sender, LayerProjectionIsEmpty, new LayerProjectionIsEmptyEventArgs(e));
        }

        private void MapLayerAdded(object sender, _DMapEvents_LayerAddedEvent e)
        {
            AssignHandler(sender, LayerAdded, new LayerAddedEventArgs(e));
        }

        private void MapGridOpened(object sender, _DMapEvents_GridOpenedEvent e)
        {
            AssignHandler(sender, GridOpened, new GridOpenedEventArgs(e));
        }

        private void MapFileDropped(object sender, _DMapEvents_FileDroppedEvent e)
        {
            AssignHandler(sender, FileDropped, new FileDroppedEventArgs(e));
        }

        private void MapExtentsChanged(object sender, EventArgs e)
        {
            AssignHandler(sender, ExtentsChanged, e);
        }
        
        private void MapDblClick(object sender, EventArgs e)
        {
            // TODO: investigate how to hide / override events of UserControl
            throw new NotImplementedException();
        }

        private void MapChooseLayer(object sender, _DMapEvents_ChooseLayerEvent e)
        {
            AssignHandler(sender, ChooseLayer, new ChooseLayerEventArgs(e));
        }

        private void MapBeforeShapeEdit(object sender, _DMapEvents_BeforeShapeEditEvent e)
        {
            AssignHandler(sender, BeforeShapeEdit, new BeforeShapeEditEventArgs(e));
        }

        private void MapBeforeDeleteShape(object sender, _DMapEvents_BeforeDeleteShapeEvent e)
        {
            AssignHandler(sender, BeforeDeleteShape, new BeforeDeleteShapeEventArgs(e));
        }

        private void MapBackgroundLoadingStarted(object sender, _DMapEvents_BackgroundLoadingStartedEvent e)
        {
            AssignHandler(sender, BackgroundLoadingStarted, new BackgroundLoadingStartedEventArgs(e));
        }

        private void MapBackgroundLoadingFinished(object sender, _DMapEvents_BackgroundLoadingFinishedEvent e)
        {
            AssignHandler(sender, BackgroundLoadingFinished, new BackgroundLoadingFinishedEventArgs(e));
        }

        private void MapAfterShapeEdit(object sender, _DMapEvents_AfterShapeEditEvent e)
        {
            AssignHandler(sender, AfterShapeEdit, new AfterShapeEditEventArgs(e));
        }

        #endregion

        private void AssignHandler<T>(object sender, EventHandler<T> d, T args) where T : EventArgs
        {
            var handler = d;
            if (handler != null)
            {
                handler.Invoke(this, args);
            }
        }
    }
}
