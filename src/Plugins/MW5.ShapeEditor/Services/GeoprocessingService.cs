using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Api.Events;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Events;
using MW5.Api.Map;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.ShapeEditor.Operations;

namespace MW5.Plugins.ShapeEditor.Services
{
    public class GeoprocessingService : IGeoprocessingService
    {
        private readonly IAppContext _context;
        private readonly IBroadcasterService _broadcaster;
        private readonly CopyOperation _copyOperation;

        public GeoprocessingService(IAppContext context, IBroadcasterService broadcaster)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (broadcaster == null) throw new ArgumentNullException("broadcaster");

            _context = context;
            _broadcaster = broadcaster;
            _copyOperation = new CopyOperation(context.Map, this);
        }

        /// <summary>
        /// Merges selected shapes
        /// </summary>
        public void MergeShapes()
        {
            var result = MergeOperation.Run(_context);
            switch (result)
            {
                case MergeResult.Ok:
                    _context.Map.Redraw(RedrawType.SkipDataLayers);
                    MessageService.Current.Info("Shapes were merged successfully.");
                    //App.RefreshUI();
                    break;
                case MergeResult.TooManyShapes:
                    MessageService.Current.Info("Too many shapes. The number of shapes for operation is limited to 50.");
                    break;
                case MergeResult.Failed:
                    MessageService.Current.Info("Failed to merge.");
                    break;
                case MergeResult.NoInput:
                    MessageService.Current.Info("No input for operation was found.");
                    break;
            }
        }

        /// <summary>
        /// Splits selected multipart shapes
        /// </summary>
        public void ExplodeShapes()
        {
            var result = ExplodeOperation.Run(_context);
            switch (result)
            {
                case ExplodeResult.Ok:
                    _context.Map.Redraw(RedrawType.SkipDataLayers);
                    MessageService.Current.Info("Shapes were split successfully.");
                    break;
                case ExplodeResult.NoMultiPart:
                    MessageService.Current.Info("No multipart shapes were found within selection.");
                    break;
                case ExplodeResult.Failed:
                    MessageService.Current.Info("Failed to merge.");
                    break;
                case ExplodeResult.NoInput:
                    MessageService.Current.Info("No input for operation was found.");
                    break;
            }
        }

        public bool BufferIsEmpty
        {
            get { return _copyOperation.IsEmpty; }
        }

        public void CopyShapes()
        {
            var layer = _context.Map.Layers.Current;
            if (layer != null && layer.IsVector)
            {
                _copyOperation.Copy(layer.Handle, layer.FeatureSet);
            }
        }

        public void PasteShapes()
        {
            var layer = _context.Legend.SelectedLayer;
            if (layer != null && layer.IsVector && layer.FeatureSet.InteractiveEditing)
            {
                var result = _copyOperation.Paste(layer.Handle, layer.FeatureSet);
                switch (result)
                {
                    case PasteResult.Ok:
                        _context.Map.Redraw();
                        MessageService.Current.Info("Shapes were copied.");
                        //App.RefreshUI();
                        break;
                    case PasteResult.NoInput:
                        MessageService.Current.Info("No input was found.");
                        break;
                    case PasteResult.ShapeTypeMismatch:
                        MessageService.Current.Info("Shape type of source and target shapefiles doesn't match.");
                        break;
                }
            }
        }

        public void CutShapes()
        {
            var layer = _context.Legend.SelectedLayer;
            if (layer != null && layer.IsVector && layer.FeatureSet.InteractiveEditing)
            {
                _copyOperation.Cut(layer.Handle, layer.FeatureSet);
                _context.Map.Redraw();
            }
        }

        public void ReplaceShape(int layerHandle, int shapeIndex, IGeometry newGeometry)
        {
            var layer = _context.Layers.GetVectorLayer(layerHandle);
            if (layer == null)
            {
                MessageService.Current.Info("Layer with specified handle not found.");
                return;
            }

            BeforeShapeEditEventArgs beforeargs = new BeforeShapeEditEventArgs(layerHandle, shapeIndex, false);
            _broadcaster.BroadcastEvent(p => p.BeforeShapeEdit_, _context.Map, beforeargs);

            if (beforeargs.Cancel == true)
                return;

            _context.Map.History.Add(UndoOperation.EditShape, layerHandle, shapeIndex);
            layer.Data.Features.EditUpdate(shapeIndex, newGeometry);

            AfterShapeEditEventArgs afterargs = new AfterShapeEditEventArgs(UndoOperation.EditShape, layerHandle, shapeIndex);
            _broadcaster.BroadcastEvent(p => p.AfterShapeEdit_, _context.Map, afterargs);
        }

        /// <summary>
        /// Removes selected shapes
        /// </summary>
        public void RemoveSelectedShapes(bool prompt)
        {
            var layer = _context.Layers.Current;

            RemoveSelectedShapesCore(layer, prompt);
        }

        public void RemoveSelectedShapes(int layerHandle, bool prompt)
        {
            var layer = _context.Layers.ItemByHandle(layerHandle);

            RemoveSelectedShapesCore(layer, prompt);
        }

        private void RemoveSelectedShapesCore(ILayer layer, bool prompt)
        {
            if (prompt)
            {
                RemoveSelectedShapesWithPrompt(layer);
            }
            else
            {
                RemoveSelectedShapesWithPrompt(layer);
                _context.Map.Redraw();
            }
        }

        private void RemoveSelectedShapesWithPrompt(ILayer layer)
        {
            if (layer == null || layer.FeatureSet == null) return;

            var fs = layer.FeatureSet;

            if (!fs.InteractiveEditing)
            {
                MessageService.Current.Info("Please start edit mode for the layer (Shape Editor plug-in's toolbar).");
                return;
            }

            if (fs.NumSelected == 0)
            {
                MessageService.Current.Info("No selected shapes on the layer.");
                return;
            }

            if (MessageService.Current.Ask("Remove selected shapes: " + fs.NumSelected + "?"))
            {
                RemoveSelectedShapesNoPrompt(_context.Map, layer.FeatureSet, layer.Handle);
                _context.Map.Redraw();
            }
        }

        private void RemoveSelectedShapesNoPrompt(IMuteMap map, IFeatureSet fs, int layerHandle)
        {

            // First try to delete each feature - some may get cancelled
            var features = fs.Features;
            var actualDeletes = new List<int>();

            try
            {
                for (int i = features.Count - 1; i >= 0; i--)
                {
                    if (!features[i].Selected) continue;

                    var args = new BeforeDeleteShapeEventArgs(DeleteTarget.Shape, false, true);
                    _broadcaster.BroadcastEvent(p => p.BeforeDeleteShape_, _context.Map, args);
                    if (!args.Cancel && features.EditDelete(i))
                    {
                        actualDeletes.Add(i);
                    }
                }
            }
            finally
            {
                // Then add this to the undo history
                var list = map.History;
                list.BeginBatch();
                foreach (var i in actualDeletes)
                {
                    list.Add(UndoOperation.RemoveShape, layerHandle, i);
                }
                list.EndBatch();
            }

            _broadcaster.BroadcastEvent(p => p.LayerFeatureCountChanged_, fs, new LayerEventArgs(layerHandle));
        }

    }
}
