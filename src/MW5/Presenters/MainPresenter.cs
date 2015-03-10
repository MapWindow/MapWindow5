using System;
using System.Diagnostics;
using System.Windows.Forms;
using MW5.Api;
using MW5.Menu;
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
            if (HandleCursorChanged(e.ItemKey))
            {
                return;
            }

            switch (e.ItemKey)
            {
                case MenuKeys.NewMap:
                    TryClose();
                    break;
                case MenuKeys.AddLayer:
                    _layerService.AddLayer(LayerType.All);
                    break;
                case MenuKeys.AddRasterLayer:
                    _layerService.AddLayer(LayerType.Raster);
                    break;
                case MenuKeys.AddVectorLayer:
                    _layerService.AddLayer(LayerType.Vector);
                    break;
                case MenuKeys.ZoomMax:
                    _context.Map.ZoomToMaxExtents();
                    break;
                case MenuKeys.ZoomToLayer:
                    _context.Map.ZoomToLayer(_context.Legend.SelectedLayer);
                    break;
                case MenuKeys.AddDatabaseLayer:
                    // TODO: implement
                    break;
                case MenuKeys.RemoveLayer:
                    _layerService.RemoveSelectedLayer();
                    break;
                case MenuKeys.SetProjection:
                    CompositionRoot.Container.Run<SetProjectionPresenter>();
                    break;
                case MenuKeys.ClearSelection:
                    _layerService.ClearSelection();
                    break;
                case MenuKeys.ZoomToSelected:
                    _layerService.ZoomToSelected();
                    break;
                default:
                    _messageService.Info("There is no handler for menu item with key: " + e.ItemKey);
                    break;
            }
        }

        private bool HandleCursorChanged(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.ZoomIn:
                    _context.Map.MapCursor = MapCursor.ZoomIn;
                    return true;
                case MenuKeys.ZoomOut:
                    _context.Map.MapCursor = MapCursor.ZoomIn;
                    return true;
                case MenuKeys.Pan:
                    _context.Map.MapCursor = MapCursor.Pan;
                    return true;
                case MenuKeys.SelectByPolygon:
                    _context.Map.MapCursor = MapCursor.SelectByPolygon;
                    return true;
                case MenuKeys.SelectByRectangle:
                    _context.Map.MapCursor = MapCursor.Selection;
                    return true;
                case MenuKeys.MeasureArea:
                    _context.Map.Measuring.MeasuringType = MeasuringType.Area;
                    _context.Map.MapCursor = MapCursor.Measure;
                    return true;
                case MenuKeys.MeasureDistance:
                    _context.Map.Measuring.MeasuringType = MeasuringType.Distance;
                    _context.Map.MapCursor = MapCursor.Measure;
                    return true;
                case MenuKeys.Attributes:
                    _context.Map.MapCursor = MapCursor.Identify;
                    return true;
            }
            return false;
        }

        private bool TryClose()
        {
            // TODO: temporary
            //if (!Editor.StopAllEditing())
            //    return false;

            //if (TryCloseProject())
            {
                _context.Map.GeometryEditor.Clear();
                _context.Legend.Groups.Clear();
                _context.Legend.Layers.Clear();
                //_context.Map.SetDefaultExtents();
                return true;
            }
            return false;
        }
    }
}
