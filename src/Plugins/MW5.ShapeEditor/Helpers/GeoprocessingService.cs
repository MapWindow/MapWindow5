using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api;
using MW5.Plugins.Interfaces;
using MW5.Plugins.ShapeEditor.Operations;
using MW5.Services.Services.Abstract;
using MWLite.ShapeEditor.Operations;

namespace MW5.Plugins.ShapeEditor.Helpers
{
    public class GeoprocessingService
    {
        private readonly IAppContext _context;
        private readonly IMessageService _messageService;
        //private CopyOperation _copyOperation = new CopyOperation();

        public GeoprocessingService(IAppContext context, IMessageService messageService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (messageService == null) throw new ArgumentNullException("messageService");

            _context = context;
            _messageService = messageService;
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

        ///// <summary>
        ///// Splits selected multipart shapes
        ///// </summary>
        //public void ExplodeShapes()
        //{
        //    var result = ExplodeOperation.Explode();
        //    switch (result)
        //    {
        //        case ExplodeResult.Ok:
        //            App.Map.Redraw2(tkRedrawType.RedrawSkipDataLayers);
        //            App.RefreshUI();
        //            MessageHelper.Info("Shapes were split successfully.");
        //            break;
        //        case ExplodeResult.NoMultiPart:
        //            MessageHelper.Info("No multipart shapes were found within selection.");
        //            break;
        //        case ExplodeResult.Failed:
        //            MessageHelper.Info("Failed to merge.");
        //            break;
        //        case ExplodeResult.NoInput:
        //            MessageHelper.Info("No input for operation was found.");
        //            break;
        //    }
        //}

        ///// <summary>
        ///// Removes selected shapes
        ///// </summary>
        //public void RemoveShapes()
        //{
        //    var sf = App.SelectedShapefile;
        //    if (sf == null || !sf.InteractiveEditing || sf.NumSelected == 0) return;
        //    if (MessageHelper.Ask("Remove selected shapes: " + sf.NumSelected + "?") == DialogResult.Yes)
        //    {
        //        int layerHandle = App.Legend.SelectedLayer;
        //        RemoveOperation.Remove(sf, layerHandle);
        //        App.Map.Redraw();
        //    }
        //}

        //public bool BufferIsEmpty
        //{
        //    get { return _copyOperation.IsEmpty; }
        //}

        //public void CopyShapes()
        //{
        //    int layerHandle = App.Legend.SelectedLayer;
        //    var sf = App.SelectedShapefile;
        //    _copyOperation.Copy(layerHandle, sf);
        //}

        //public void PasteShapes()
        //{
        //    var result = _copyOperation.Paste(App.Legend.SelectedLayer, App.SelectedShapefile);
        //    switch (result)
        //    {
        //        case PasteResult.Ok:
        //            App.Map.Redraw();
        //            App.RefreshUI();
        //            MessageHelper.Info("Shapes were copied.");
        //            break;
        //        case PasteResult.NoInput:
        //            MessageHelper.Info("No input was found.");
        //            break;
        //        case PasteResult.ShapeTypeMismatch:
        //            MessageHelper.Info("Shape type of source and target shapefiles doesn't match.");
        //            break;
        //    }
        //}

        //public void CutShapes()
        //{
        //    _copyOperation.Cut(App.Legend.SelectedLayer, App.SelectedShapefile);
        //    App.Map.Redraw();
        //}
    }
}
