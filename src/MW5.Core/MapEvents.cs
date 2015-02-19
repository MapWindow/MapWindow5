using System;
using System.Windows.Forms;
using AxMapWinGIS;
using MW5.Core.Events;
using MW5.Core.Helpers;

namespace MW5.Core
{
    public partial class MapControl
    {
        public void AttachHandlers()
        {
            _axMap1.ChooseLayer += _axMap1_ChooseLayer;
            _axMap1.AfterShapeEdit += _axMap1_AfterShapeEdit;
            _axMap1.BackgroundLoadingFinished += _axMap1_BackgroundLoadingFinished;
            _axMap1.BackgroundLoadingStarted += _axMap1_BackgroundLoadingStarted;
            _axMap1.BeforeDeleteShape += _axMap1_BeforeDeleteShape;
            _axMap1.BeforeShapeEdit += _axMap1_BeforeShapeEdit;
            _axMap1.DblClick += _axMap1_DblClick;
            _axMap1.ExtentsChanged += _axMap1_ExtentsChanged;
            _axMap1.FileDropped += _axMap1_FileDropped;
            _axMap1.GridOpened += _axMap1_GridOpened;
            _axMap1.LayerAdded += _axMap1_LayerAdded;
            _axMap1.LayerProjectionIsEmpty += _axMap1_LayerProjectionIsEmpty;
            _axMap1.LayerRemoved += _axMap1_LayerRemoved;
            _axMap1.LayerReprojected += _axMap1_LayerReprojected;
            _axMap1.MeasuringChanged += _axMap1_MeasuringChanged;
            _axMap1.MouseDownEvent += _axMap1_MouseDownEvent;
            _axMap1.MouseMoveEvent += _axMap1_MouseMoveEvent;
            _axMap1.MouseUpEvent += _axMap1_MouseUpEvent;
            _axMap1.ProjectionChanged += _axMap1_ProjectionChanged;
            _axMap1.ProjectionMismatch += _axMap1_ProjectionMismatch;
            _axMap1.SelectBoxFinal += _axMap1_SelectBoxFinal;
            _axMap1.SelectionChanged += _axMap1_SelectionChanged;
            _axMap1.ShapeHighlighted += _axMap1_ShapeHighlighted;
            _axMap1.ShapeIdentified += _axMap1_ShapeIdentified;
            _axMap1.ShapeValidationFailed += _axMap1_ShapeValidationFailed;
            _axMap1.TilesLoaded += _axMap1_TilesLoaded;
            _axMap1.UndoListChanged += _axMap1_UndoListChanged;
            _axMap1.ValidateShape += _axMap1_ValidateShape;
        }

        public void DetachHandlers()
        {
            _axMap1.ChooseLayer -= _axMap1_ChooseLayer;
            _axMap1.AfterShapeEdit -= _axMap1_AfterShapeEdit;
            _axMap1.BackgroundLoadingFinished -= _axMap1_BackgroundLoadingFinished;
            _axMap1.BackgroundLoadingStarted -= _axMap1_BackgroundLoadingStarted;
            _axMap1.BeforeDeleteShape -= _axMap1_BeforeDeleteShape;
            _axMap1.BeforeShapeEdit -= _axMap1_BeforeShapeEdit;
            _axMap1.DblClick -= _axMap1_DblClick;
            _axMap1.ExtentsChanged -= _axMap1_ExtentsChanged;
            _axMap1.FileDropped -= _axMap1_FileDropped;
            _axMap1.GridOpened -= _axMap1_GridOpened;
            _axMap1.LayerAdded -= _axMap1_LayerAdded;
            _axMap1.LayerProjectionIsEmpty -= _axMap1_LayerProjectionIsEmpty;
            _axMap1.LayerRemoved -= _axMap1_LayerRemoved;
            _axMap1.LayerReprojected -= _axMap1_LayerReprojected;
            _axMap1.MeasuringChanged -= _axMap1_MeasuringChanged;
            _axMap1.MouseDownEvent -= _axMap1_MouseDownEvent;
            _axMap1.MouseMoveEvent -= _axMap1_MouseMoveEvent;
            _axMap1.MouseUpEvent -= _axMap1_MouseUpEvent;
            _axMap1.ProjectionChanged -= _axMap1_ProjectionChanged;
            _axMap1.ProjectionMismatch -= _axMap1_ProjectionMismatch;
            _axMap1.SelectBoxFinal -= _axMap1_SelectBoxFinal;
            _axMap1.SelectionChanged -= _axMap1_SelectionChanged;
            _axMap1.ShapeHighlighted -= _axMap1_ShapeHighlighted;
            _axMap1.ShapeIdentified -= _axMap1_ShapeIdentified;
            _axMap1.ShapeValidationFailed -= _axMap1_ShapeValidationFailed;
            _axMap1.TilesLoaded -= _axMap1_TilesLoaded;
            _axMap1.UndoListChanged -= _axMap1_UndoListChanged;
            _axMap1.ValidateShape -= _axMap1_ValidateShape;
        }

        #region Handlers

        private void _axMap1_ValidateShape(object sender, _DMapEvents_ValidateShapeEvent e)
        {
            AssignHandler(sender, ValidateShape, new ValidateShapeEventArgs(e));
        }

        private void _axMap1_UndoListChanged(object sender, EventArgs e)
        {
            AssignHandler(sender, UndoListChanged, e);
        }

        private void _axMap1_TilesLoaded(object sender, _DMapEvents_TilesLoadedEvent e)
        {
            AssignHandler(sender, TilesLoaded, new TilesLoadedEventArgs(e));
        }

        private void _axMap1_ShapeValidationFailed(object sender, _DMapEvents_ShapeValidationFailedEvent e)
        {
            AssignHandler(sender, ShapeValidationFailed, new ShapeValidationFailedEventArgs(e));
        }

        private void _axMap1_ShapeIdentified(object sender, _DMapEvents_ShapeIdentifiedEvent e)
        {
            AssignHandler(sender, ShapeIdentified, new ShapeIdentifiedEventArgs(e));
        }

        private void _axMap1_ShapeHighlighted(object sender, _DMapEvents_ShapeHighlightedEvent e)
        {
            AssignHandler(sender, ShapeHighlighted, new ShapeHightlightedEventArgs(e));
        }

        private void _axMap1_SelectionChanged(object sender, _DMapEvents_SelectionChangedEvent e)
        {
            AssignHandler(sender, SelectionChanged, new SelectionChangedEventArgs(e));
        }

        private void _axMap1_SelectBoxFinal(object sender, _DMapEvents_SelectBoxFinalEvent e)
        {
            AssignHandler(sender, SelectBoxFinal, new SelectBoxFinalEventArgs(e));
        }

        private void _axMap1_ProjectionMismatch(object sender, _DMapEvents_ProjectionMismatchEvent e)
        {
            AssignHandler(sender, ProjectionMismatch, new ProjectionMismatchEventArgs(e));
        }

        private void _axMap1_ProjectionChanged(object sender, EventArgs e)
        {
            AssignHandler(sender, ProjectionChanged, e);
        }

        private void _axMap1_MouseUpEvent(object sender, _DMapEvents_MouseUpEvent e)
        {
            var button = MouseEventHelper.ParseMouseButton(e.button);
            var args = new MouseEventArgs(button, 1, e.x, e.y, 0);
            AssignHandler(sender, MouseUp, args);
        }

        private void _axMap1_MouseMoveEvent(object sender, _DMapEvents_MouseMoveEvent e)
        {
            var button = MouseEventHelper.ParseMouseButton(e.button);
            var args = new MouseEventArgs(button, 1, e.x, e.y, 0);
            AssignHandler(sender, MouseMove, args);
        }

        private void _axMap1_MouseDownEvent(object sender, _DMapEvents_MouseDownEvent e)
        {
            var button = MouseEventHelper.ParseMouseButton(e.button);
            var args = new MouseEventArgs(button, 1, e.x, e.y, 0);
            AssignHandler(sender, MouseDown, args);
        }

        private void _axMap1_MeasuringChanged(object sender, _DMapEvents_MeasuringChangedEvent e)
        {
            AssignHandler(sender, MeasuringChanged, new MeasuringChangedEventArgs(e));
        }

        private void _axMap1_LayerReprojected(object sender, _DMapEvents_LayerReprojectedEvent e)
        {
            AssignHandler(sender, LayerReprojected, new LayerReprojectedEventArgs(e));
        }

        private void _axMap1_LayerRemoved(object sender, _DMapEvents_LayerRemovedEvent e)
        {
            AssignHandler(sender, LayerRemoved, new LayerRemovedEventArgs(e));
        }

        private void _axMap1_LayerProjectionIsEmpty(object sender, _DMapEvents_LayerProjectionIsEmptyEvent e)
        {
            AssignHandler(sender, LayerProjectionIsEmpty, new LayerProjectionIsEmptyEventArgs(e));
        }

        private void _axMap1_LayerAdded(object sender, _DMapEvents_LayerAddedEvent e)
        {
            AssignHandler(sender, LayerAdded, new LayerAddedEventArgs(e));
        }

        private void _axMap1_GridOpened(object sender, _DMapEvents_GridOpenedEvent e)
        {
            AssignHandler(sender, GridOpened, new GridOpenedEventArgs(e));
        }

        private void _axMap1_FileDropped(object sender, _DMapEvents_FileDroppedEvent e)
        {
            AssignHandler(sender, FileDropped, new FileDroppedEventArgs(e));
        }

        private void _axMap1_ExtentsChanged(object sender, EventArgs e)
        {
            AssignHandler(sender, ExtentsChanged, e);
        }
        
        private void _axMap1_DblClick(object sender, EventArgs e)
        {
            // TODO: investigate how to hide / override events of UserControl
            throw new NotImplementedException();
        }

        private void _axMap1_ChooseLayer(object sender, _DMapEvents_ChooseLayerEvent e)
        {
            AssignHandler(sender, ChooseLayer, new ChooseLayerEventArgs(e));
        }

        private void _axMap1_BeforeShapeEdit(object sender, _DMapEvents_BeforeShapeEditEvent e)
        {
            AssignHandler(sender, BeforeShapeEdit, new BeforeShapeEditEventArgs(e));
        }

        private void _axMap1_BeforeDeleteShape(object sender, _DMapEvents_BeforeDeleteShapeEvent e)
        {
            AssignHandler(sender, BeforeDeleteShape, new BeforeDeleteShapeEventArgs(e));
        }

        private void _axMap1_BackgroundLoadingStarted(object sender, _DMapEvents_BackgroundLoadingStartedEvent e)
        {
            AssignHandler(sender, BackgroundLoadingStarted, new BackgroundLoadingStartedEventArgs(e));
        }

        private void _axMap1_BackgroundLoadingFinished(object sender, _DMapEvents_BackgroundLoadingFinishedEvent e)
        {
            AssignHandler(sender, BackgroundLoadingFinished, new BackgroundLoadingFinishedEventArgs(e));
        }

        private void _axMap1_AfterShapeEdit(object sender, _DMapEvents_AfterShapeEditEvent e)
        {
            AssignHandler(sender, AfterShapeEdit, new AfterShapeEditEventArgs(e));
        }

        #endregion

        private void AssignHandler<T>(object sender, EventHandler<T> d, T args) where T : EventArgs
        {
            var handler = d;
            if (handler != null)
            {
                handler.Invoke(sender, args);
            }
        }
    }
}
