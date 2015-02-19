using System;
using AxMapWinGIS;
using MW5.Core.Events;

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

        void _axMap1_ValidateShape(object sender, _DMapEvents_ValidateShapeEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_UndoListChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_TilesLoaded(object sender, _DMapEvents_TilesLoadedEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_ShapeValidationFailed(object sender, _DMapEvents_ShapeValidationFailedEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_ShapeIdentified(object sender, _DMapEvents_ShapeIdentifiedEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_ShapeHighlighted(object sender, _DMapEvents_ShapeHighlightedEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_SelectionChanged(object sender, _DMapEvents_SelectionChangedEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_SelectBoxFinal(object sender, _DMapEvents_SelectBoxFinalEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_ProjectionMismatch(object sender, _DMapEvents_ProjectionMismatchEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_ProjectionChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_MouseUpEvent(object sender, _DMapEvents_MouseUpEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_MouseMoveEvent(object sender, _DMapEvents_MouseMoveEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_MouseDownEvent(object sender, _DMapEvents_MouseDownEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_MeasuringChanged(object sender, _DMapEvents_MeasuringChangedEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_LayerReprojected(object sender, _DMapEvents_LayerReprojectedEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_LayerRemoved(object sender, _DMapEvents_LayerRemovedEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_LayerProjectionIsEmpty(object sender, _DMapEvents_LayerProjectionIsEmptyEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_LayerAdded(object sender, _DMapEvents_LayerAddedEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_GridOpened(object sender, _DMapEvents_GridOpenedEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_FileDropped(object sender, _DMapEvents_FileDroppedEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_ExtentsChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_DblClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _axMap1_ChooseLayer(object sender, _DMapEvents_ChooseLayerEvent e)
        {
            AssignHandler(sender, ChooseLayer, new ChooseLayerEventArgs(e));
        }

        void _axMap1_BeforeShapeEdit(object sender, _DMapEvents_BeforeShapeEditEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_BeforeDeleteShape(object sender, _DMapEvents_BeforeDeleteShapeEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_BackgroundLoadingStarted(object sender, _DMapEvents_BackgroundLoadingStartedEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_BackgroundLoadingFinished(object sender, _DMapEvents_BackgroundLoadingFinishedEvent e)
        {
            throw new NotImplementedException();
        }

        void _axMap1_AfterShapeEdit(object sender, _DMapEvents_AfterShapeEditEvent e)
        {
            throw new NotImplementedException();
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
