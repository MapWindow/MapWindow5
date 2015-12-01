using System;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.ShapeEditor.Operations;

namespace MW5.Plugins.ShapeEditor.Services
{
    public class GeoprocessingService : IGeoprocessingService
    {
        private readonly IAppContext _context;
        private readonly CopyOperation _copyOperation;

        public GeoprocessingService(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            _context = context;
            _copyOperation = new CopyOperation(context.Map);
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
                    //App.RefreshUI();
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

        /// <summary>
        /// Removes selected shapes
        /// </summary>
        public void RemoveShapes()
        {
            var layer = _context.Layers.Current;
            if (layer == null)
            {
                return;
            }

            var fs = layer.FeatureSet;

            if (fs == null || fs.NumSelected <= 1 || !fs.InteractiveEditing)
            {
                return;
            }

            if (MessageService.Current.Ask("Remove selected shapes: " + fs.NumSelected + "?"))
            {
                RemoveOperation.Remove(_context.Map, layer.FeatureSet, layer.Handle);
                _context.Map.Redraw();
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
    }
}
