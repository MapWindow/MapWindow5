using System;
using System.Diagnostics;
using System.Windows.Forms;
using MW5.Api;
using MW5.Mvp;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Services;
using MW5.Services.Services.Abstract;

namespace MW5.Presenters
{
    public interface IMainView : IView
    {
        
    }

    public class MainPresenter : BasePresenter<IMainView>
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

            PluginManager.Instance.MenuItemClicked += MenuItemClicked;
        }

        private void MenuItemClicked(object sender, Plugins.Concrete.MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case MenuKeys.AddLayer:
                    _layerService.AddLayer(LayerType.All);
                    break;
                case MenuKeys.AddRasterLayer:
                    _layerService.AddLayer(LayerType.Raster);
                    break;
                case MenuKeys.AddVectorLayer:
                    _layerService.AddLayer(LayerType.Vector);
                    break;
                case MenuKeys.ZoomIn:
                    _context.Map.MapCursor = MapCursor.ZoomIn;
                    break;
                case MenuKeys.ZoomMax:
                    _context.Map.ZoomToMaxExtents();
                    break;
                case MenuKeys.ZoomOut:
                    _context.Map.MapCursor = MapCursor.ZoomIn;
                    break;
                case MenuKeys.ZoomToLayer:
                    _context.Map.ZoomToLayer(_context.Legend.SelectedLayer);
                    break;
                case MenuKeys.AddDatabaseLayer:
                    // TODO: implement
                    break;
                case MenuKeys.Pan:
                    _context.Map.MapCursor = MapCursor.Pan;
                    break;
                case MenuKeys.RemoveLayer:
                    _layerService.RemoveSelectedLayer();
                    break;
                case MenuKeys.SetProjection:
                    CompositionRoot.Container.Run<SetProjectionPresenter>();
                    break;
            }
        }
    }
}
