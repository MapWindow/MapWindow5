using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.Plugins.Interfaces;
using MW5.Presenters;
using MW5.Services;
using MW5.Services.Serialization;
using MW5.Services.Services.Abstract;

namespace MW5.Menu
{
    public class MenuListener
    {
        private readonly IAppContext _context;
        private readonly ILayerService _layerService;
        private readonly IMessageService _messageService;
        private readonly IProjectService _projectService;

        public MenuListener(IAppContext context, ILayerService layerService, 
            IMessageService messageService, IProjectService projectService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (layerService == null) throw new ArgumentNullException("layerService");
            if (messageService == null) throw new ArgumentNullException("messageService");
            if (projectService == null) throw new ArgumentNullException("projectService");

            _context = context;
            _layerService = layerService;
            _messageService = messageService;
            _projectService = projectService;

            var appContext = context as AppContext;
            if (appContext != null)
            {
                appContext.PluginManager.MenuItemClicked += MenuItemClicked;
            }
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
                    _projectService.TryClose();
                    break;
                case MenuKeys.SaveProject:
                    _projectService.Save();
                    break;
                case MenuKeys.SaveProjectAs:
                    _projectService.SaveAs();
                    break;
                case MenuKeys.OpenProject:
                    _projectService.Open();
                    break;
                case MenuKeys.AddLayer:
                    _layerService.AddLayer(DataSourceType.All);
                    break;
                case MenuKeys.AddRasterLayer:
                    _layerService.AddLayer(DataSourceType.Raster);
                    break;
                case MenuKeys.AddVectorLayer:
                    _layerService.AddLayer(DataSourceType.Vector);
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
    }
}
