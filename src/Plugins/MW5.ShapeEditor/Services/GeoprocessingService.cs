using System;
using MW5.Api;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.ShapeEditor.Operations;

namespace MW5.Plugins.ShapeEditor.Services
{
    public class GeoprocessingService : IGeoprocessingService
    {
        private readonly IAppContext _context;
        private readonly IMessageService _messageService;
        private readonly CopyOperation _copyOperation;

        public GeoprocessingService(IAppContext context, IMessageService messageService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (messageService == null) throw new ArgumentNullException("messageService");

            _context = context;
            _messageService = messageService;
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
                    _messageService.Info("Shapes were merged successfully.");
                    //App.RefreshUI();
                    break;
                case MergeResult.TooManyShapes:
                    _messageService.Info("Too many shapes. The number of shapes for operation is limited to 50.");
                    break;
                case MergeResult.Failed:
                    _messageService.Info("Failed to merge.");
                    break;
                case MergeResult.NoInput:
                    _messageService.Info("No input for operation was found.");
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
                    _messageService.Info("Shapes were split successfully.");
                    //App.RefreshUI();
                    break;
                case ExplodeResult.NoMultiPart:
                    _messageService.Info("No multipart shapes were found within selection.");
                    break;
                case ExplodeResult.Failed:
                    _messageService.Info("Failed to merge.");
                    break;
                case ExplodeResult.NoInput:
                    _messageService.Info("No input for operation was found.");
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
            
            if (_messageService.Ask("Remove selected shapes: " + fs.NumSelected + "?"))
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
            if (layer != null && layer.IsVector)
            {
                var result = _copyOperation.Paste(layer.Handle, layer.FeatureSet);
                switch (result)
                {
                    case PasteResult.Ok:
                        _context.Map.Redraw();
                        _messageService.Info("Shapes were copied.");
                        //App.RefreshUI();
                        break;
                    case PasteResult.NoInput:
                        _messageService.Info("No input was found.");
                        break;
                    case PasteResult.ShapeTypeMismatch:
                        _messageService.Info("Shape type of source and target shapefiles doesn't match.");
                        break;
                }
            }
        }

        public void CutShapes()
        {
            var layer = _context.Legend.SelectedLayer;
            if (layer != null && layer.IsVector)
            {
                _copyOperation.Cut(layer.Handle, layer.FeatureSet);
                _context.Map.Redraw();
            }
        }
    }
}
