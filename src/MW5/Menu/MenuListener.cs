// -------------------------------------------------------------------------------------------
// <copyright file="MenuListener.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Static;
using MW5.Data.Views;
using MW5.Helpers;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Model;
using MW5.Plugins.Services;
using MW5.Projections.Helpers;
using MW5.Shared;
using MW5.Tiles.Views;
using MW5.UI.Docking;
using MW5.Views;

namespace MW5.Menu
{
    public class MenuListener
    {
        private readonly IAppContext _context;
        private readonly IGeoDatabaseService _databaseService;
        private readonly ILayerService _layerService;
        private readonly IProjectService _projectService;

        public MenuListener(
            IAppContext context,
            ILayerService layerService,
            IProjectService projectService,
            IGeoDatabaseService databaseService)
        {
            Logger.Current.Trace("In MenuListener");
            if (context == null) throw new ArgumentNullException("context");
            if (layerService == null) throw new ArgumentNullException("layerService");
            if (projectService == null) throw new ArgumentNullException("projectService");
            if (databaseService == null) throw new ArgumentNullException("databaseService");

            _context = context;
            _layerService = layerService;
            _projectService = projectService;
            _databaseService = databaseService;

            var appContext = context as AppContext;
            if (appContext != null)
            {
                appContext.Broadcaster.MenuItemClicked += MenuItemClicked;
            }

            TilesMenuHelper.TileProviderSelected += OnTileProviderSelected;
            TilesMenuHelper.ChooseActiveProvider += OnChooseActiveProvider;
        }

        public void RunCommand(string menuKey)
        {
            if (HandleCursorChanged(menuKey) || HandleProjectCommand(menuKey) || HandleDialogs(menuKey) ||
                HandleHelpMenu(menuKey) || HandleLayerMenu(menuKey) || HandleConfigChanged(menuKey))
            {
                _context.View.Update();
                return;
            }

            switch (menuKey)
            {
                case MenuKeys.ShowRepository:
                    DockPanelHelper.ShowPanel(_context, DockPanelKeys.Repository);
                    return; // make sure that no View.Update is called or we lose the focus
                case MenuKeys.ShowToolbox:
                    DockPanelHelper.ShowPanel(_context, DockPanelKeys.Toolbox);
                    return; // make sure that no View.Update is called or we lose the focus
                case MenuKeys.SetScale:
                    _context.Container.Run<SetScalePresenter>();
                    break;
                case MenuKeys.ZoomToBaseLayer:
                    ZoomToBaseLayer();
                    break;
                case MenuKeys.FindLocation:
                    _context.Container.Run<GeoLocationPresenter>();
                    break;
                case MenuKeys.CustomProviders:
                    {
                        var model = _context.Repository.TmsProviders;
                        _context.Container.Run<TmsListPresenter, TmsProviderList>(model);
                    }
                    break;
                case MenuKeys.BingApiKey:
                    _context.Container.Run<BingApiPresenter>();
                    break;
                case MenuKeys.TilesConfigure:
                    {
                        var model = _context.Container.GetInstance<ConfigViewModel>();
                        model.SelectedPage = ConfigPageType.Tiles;
                        model.UseSelectedPage = true;
                        _context.Container.Run<ConfigPresenter, ConfigViewModel>(model);
                    }
                    break;
                case MenuKeys.PluginsConfigure:
                    {
                        var model = _context.Container.GetInstance<ConfigViewModel>();
                        model.SelectedPage = ConfigPageType.Plugins;
                        model.UseSelectedPage = true;
                        _context.Container.Run<ConfigPresenter, ConfigViewModel>(model);
                    }
                    break;
                case MenuKeys.ZoomPrev:
                    _context.Map.ZoomToPrev();
                    break;
                case MenuKeys.ZoomNext:
                    _context.Map.ZoomToNext();
                    break;
                case MenuKeys.ZoomMax:
                    _context.Map.ZoomToMaxExtents();
                    break;
                case MenuKeys.ZoomToLayer:
                    _context.Map.ZoomToLayer(_context.Legend.SelectedLayerHandle);
                    break;
                case MenuKeys.RemoveLayer:
                    _layerService.RemoveSelectedLayer();
                    break;
                case MenuKeys.ClearSelection:
                    _layerService.ClearSelection();
                    break;
                case MenuKeys.ZoomToSelected:
                    _layerService.ZoomToSelected();
                    break;
                default:
                    MessageService.Current.Info("There is no handler for menu item with key: " + menuKey);
                    break;
            }

            _context.View.Update();
        }

        private bool HandleConfigChanged(string itemKey)
        {
            var config = AppConfig.Instance;

            switch (itemKey)
            {
                case MenuKeys.ShowZoombar:
                    config.ShowZoombar = !AppConfig.Instance.ShowZoombar;
                    _context.Map.ApplyConfig(config);
                    _context.Map.Redraw(RedrawType.SkipAllLayers);
                    return true;
                case MenuKeys.ShowScalebar:
                    AppConfig.Instance.ShowScalebar = !AppConfig.Instance.ShowScalebar;
                    _context.Map.ApplyConfig(config);
                    _context.Map.Redraw(RedrawType.SkipAllLayers);
                    return true;
                case MenuKeys.ShowCoordinates:
                    AppConfig.Instance.ShowCoordinates = !AppConfig.Instance.ShowCoordinates;
                    _context.Map.ApplyConfig(config);
                    _context.Map.Redraw(RedrawType.SkipAllLayers);
                    return true;
                case MenuKeys.ShowRedrawTime:
                    AppConfig.Instance.ShowRedrawTime = !AppConfig.Instance.ShowRedrawTime;
                    _context.Map.ApplyConfig(config);
                    _context.Map.Redraw(RedrawType.SkipAllLayers);
                    return true;
            }

            return false;
        }

        private bool HandleCursorChanged(string itemKey)
        {
            // MapCursorChanged event is raised automatically; no need to update UI manually
            switch (itemKey)
            {
                case MenuKeys.ZoomIn:
                    _context.Map.MapCursor = MapCursor.ZoomIn;
                    return true;
                case MenuKeys.ZoomOut:
                    _context.Map.MapCursor = MapCursor.ZoomOut;
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
                    _context.Map.Measuring.Type = MeasuringType.Area;
                    _context.Map.MapCursor = MapCursor.Measure;
                    return true;
                case MenuKeys.MeasureDistance:
                    _context.Map.Measuring.Type = MeasuringType.Distance;
                    _context.Map.MapCursor = MapCursor.Measure;
                    return true;
                case MenuKeys.AttributesTool:
                    _context.Map.MapCursor = MapCursor.Identify;
                    return true;
            }
            return false;
        }

        private bool HandleDialogs(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.Settings:
                    var model = _context.Container.GetInstance<ConfigViewModel>();
                    _context.Container.Run<ConfigPresenter, ConfigViewModel>(model);
                    return true;
                case MenuKeys.SetProjection:
                    if (_context.Map.Projection.IsEmpty)
                    {
                        _context.ChangeProjection();
                    }
                    else
                    {
                        _context.ShowMapProjectionProperties();
                    }
                    return true;
            }
            return false;
        }

        private bool HandleHelpMenu(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.Welcome:
                    var model = new WelcomeViewModel(AppConfig.Instance.RecentProjects);
                    _context.Container.Run<WelcomePresenter, WelcomeViewModel>(model);
                    return true;
                case MenuKeys.SupportedDrivers:
                    _context.Container.Run<DriversPresenter, DriverManager>(new DriverManager());
                    return true;
                case MenuKeys.ComUsage:
                    GcHelper.Collect();

                    string report = GisUtils.Instance.GetComUsageReport();
                    MessageService.Current.Info(report);

                    return true;
                case MenuKeys.About:
                    _context.Container.Run<AboutPresenter>();
                    return true;
            }

            return false;
        }

        private bool HandleLayerMenu(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.AddWmsLayer:
                    {
                        var model = new WmsCapabilitiesModel(_context.Repository);
                        _context.Container.Run<WmsCapabilitiesPresenter, WmsCapabilitiesModel>(model);
                        return true;
                    }
                case MenuKeys.AddDatabaseLayer:
                    var connection = _databaseService.PromptUserForConnection();
                    if (connection != null)
                    {
                        using (var ds = new VectorDatasource())
                        {
                            var model = new DatabaseLayersModel(ds, connection);
                            _context.Container.Run<DatabaseLayersPresenter, DatabaseLayersModel>(model);
                        }
                    }
                    return true;
                case MenuKeys.AddLayer:
                    _layerService.AddLayer(DataSourceType.All);
                    return true;
                case MenuKeys.AddRasterLayer:
                    _layerService.AddLayer(DataSourceType.Raster);
                    return true;
                case MenuKeys.AddVectorLayer:
                    _layerService.AddLayer(DataSourceType.Vector);
                    return true;
                case MenuKeys.LayerClearSelection:
                    var layer = _context.Legend.SelectedLayer;
                    if (layer != null && layer.FeatureSet != null)
                    {
                        layer.FeatureSet.ClearSelection();
                        _context.Map.Redraw();
                    }
                    return true;
                case MenuKeys.ClearLayers:
                    if (MessageService.Current.Ask("Do you wan't to remove all layers from the map?"))
                    {
                        _context.Legend.Layers.Clear();
                    }
                    return true;
            }

            return false;
        }

        private bool HandleProjectCommand(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.Test:
                    //_context.Projections.UpdateEsriName(_context.Projections.Name);
                    return true;
                case MenuKeys.NewMap:
                    _projectService.TryClose();
                    return true;
                case MenuKeys.SaveProject:
                    if (_projectService.Save())
                    {
                        ShowProjectSaved();
                    }
                    return true;
                case MenuKeys.SaveProjectAs:
                    if (_projectService.SaveAs())
                    {
                        ShowProjectSaved();
                    }
                    return true;
                case MenuKeys.OpenProject:
                    _projectService.Open();
                    return true;
                case Plugins.Menu.MenuKeys.Quit:
                    var appContext = _context as AppContext;
                    if (appContext != null)
                    {
                        appContext.Close();
                    }
                    return true;
            }
            return false;
        }

        private void MenuItemClicked(object sender, MenuItemEventArgs e)
        {
            RunCommand(e.ItemKey);
        }

        private void OnChooseActiveProvider(object sender, TileProviderArgs e)
        {
            e.ProviderId = _context.Map.Tiles.ProviderId;
        }

        private void OnTileProviderSelected(object sender, TileProviderArgs e)
        {
            var manager = _context.Map.Tiles;

            if (e.IsBingProvider)
            {
                if (string.IsNullOrWhiteSpace(MapConfig.BingApiKey))
                {
                    if (!_context.Container.Run<BingApiPresenter>())
                    {
                        return;
                    }
                }
            }

            _context.Map.SetTileProvider(e.ProviderId);
            _context.Map.Redraw(RedrawType.Minimal);
            _context.View.Update(); //to update provider in status bar
        }

        private void ShowProjectSaved()
        {
            MessageService.Current.Info("Project was saved: " + _projectService.Filename);
        }

        private void ZoomToBaseLayer()
        {
            if (_context.Map.Projection.IsEmpty)
            {
                MessageService.Current.Info("Failed to zoom to layer. Map projection is not set.");
            }
            else
            {
                var tiles = _context.Map.Tiles;
                var provider = _context.Map.Tiles.Providers.FirstOrDefault(p => p.Id == tiles.ProviderId);

                if (!tiles.Visible || provider == null)
                {
                    MessageService.Current.Info("Failed to get extents of base layer.");
                }
                else
                {
                    if (!_context.Map.SetGeographicExtents(provider.GeographicBounds))
                    {
                        Logger.Current.Warn("Zoom to base layer: failed to set geographic extents.");
                    }
                }
            }
        }
    }
}