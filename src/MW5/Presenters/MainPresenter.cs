using System;
using System.Diagnostics;
using System.Windows.Forms;
using MW5.Api;
using MW5.Mvp;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Services.Services.Abstract;

namespace MW5.Presenters
{
    public enum MainCommand
    {
        Open = 0,
        ZoomIn = 1,
        ZoomOut = 2,
        ZoomMax = 3,
        Pan = 4,
        OpenVector = 5,
        OpenRaster = 6,
        SetProjection = 7,
        ZoomToLayer = 8,
        RemoveLayer = 9,
    }

    public interface IMainView : IComplexView
    {
        
    }

    public class MainPresenter : BasePresenter<IMainView, MainCommand>
    {
        private readonly IAppContext _context;
        private readonly IMainView _view;
        private readonly ILayerService _layerService;
        private readonly IMessageService _messageService;

        public MainPresenter(IAppContext context, IMainView view, ILayerService layerService, IMessageService messageService)
            : base(view)
        {
            _context = context;
            _view = view;
            _layerService = layerService;
            _messageService = messageService;
        }

        public override void RunCommand(MainCommand command)
        {
            switch( command)
            {
                case MainCommand.Open:
                    _layerService.AddLayer(LayerType.All);
                    break;
                case MainCommand.OpenVector:
                    _layerService.AddLayer(LayerType.Vector);
                    break;
                case MainCommand.OpenRaster:
                    _layerService.AddLayer(LayerType.Raster);
                    break;
                case MainCommand.ZoomIn:
                    SetMapCursor(MapCursor.ZoomIn);
                    break;
                case MainCommand.ZoomOut:
                    SetMapCursor(MapCursor.ZoomOut);
                    break;
                case MainCommand.ZoomMax:
                    _context.Map.ZoomToMaxExtents();
                    break;
                case MainCommand.Pan:
                    SetMapCursor(MapCursor.Pan);
                    break;
                case MainCommand.SetProjection:
                    CompositionRoot.Container.Run<SetProjectionPresenter>();
                    break;
                case MainCommand.RemoveLayer:
                    _layerService.RemoveSelectedLayer();
                    break;
                case MainCommand.ZoomToLayer:
                    _context.Map.ZoomToLayer(_context.Legend.SelectedLayer);
                    break;
            }
        }

        private void SetMapCursor(MapCursor cursor)
        {
            _context.Map.MapCursor = cursor;
            //_view.UpdateView();           // it's will be called from MapCursorChanged event
        }

        protected override void CommandNotFound(string itemName)
        {
            _messageService.Warn("Command not found: " + itemName);
        }
    }
}
