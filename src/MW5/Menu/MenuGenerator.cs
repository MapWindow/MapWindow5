using System;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Properties;
using MW5.Services;
using System.Linq;

namespace MW5.Menu
{
    internal class MenuGenerator
    {
        private const string FILE_TOOLBAR = "File";
        private const string MAP_TOOLBAR = "Map";
        
        private readonly IAppContext _context;
        private readonly PluginManager _pluginManager;
        private readonly object _menuManager;
        private readonly object _dockingManager;
        
        // perhaps can be injected 
        private ViewMainMenuService _viewMenuService = new ViewMainMenuService();

        public MenuGenerator(IAppContext context, PluginManager pluginManager, object menuManager, object dockingManager)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (pluginManager == null) throw new ArgumentNullException("pluginManager");
            _context = context;
            _pluginManager = pluginManager;
            _menuManager = menuManager;
            _dockingManager = dockingManager;
        }

        public void Init()
        {
            InitToolbars();
            InitMenus();
        }

        private void InitMenus()
        {
            InitFileMenu();

            InitViewMenu();

            PluginsMainMenuHelper.InitPlugins(_context, _pluginManager);

            TilesMainMenuHelper.Init(_context.Map, _context.Menu.TilesMenu);

            InitHelpMenu();

            _context.Menu.Update();
        }

        #region Menus

        // TODO: perhaps extract text to function to avoid duplicating it for menus and toolbars
        private void InitFileMenu()
        {
            var items = _context.Menu.FileMenu.SubItems;

            items.AddButton("New map", MenuKeys.NewMap, Resources.new_map, PluginIdentity.Default);

            items.AddButton("Add layer", MenuKeys.AddLayer, Resources.layer_add, PluginIdentity.Default).BeginGroup = true;
            items.AddButton("Add vector layer", MenuKeys.AddVectorLayer, Resources.layer_vector_add, PluginIdentity.Default);
            items.AddButton("Add raster layer", MenuKeys.AddRasterLayer, Resources.layer_raster_add, PluginIdentity.Default);
            items.AddButton("Add database layer", MenuKeys.AddDatabaseLayer, Resources.layer_database_add, PluginIdentity.Default);

            items.AddButton("Open project", MenuKeys.OpenProject, Resources.folder, PluginIdentity.Default).BeginGroup = true;

            items.AddButton("Save project", MenuKeys.SaveProject, Resources.save, PluginIdentity.Default).BeginGroup = true;
            items.AddButton("Save project as", MenuKeys.SaveProjectAs, Resources.save_as, PluginIdentity.Default);

            items.AddButton("Quit", MenuKeys.Quit, Resources.quit, PluginIdentity.Default).BeginGroup = true;

            _context.Menu.FileMenu.Update();
        }

        private void InitViewMenu()
        {
            var items = _context.Menu.ViewMenu.SubItems;

            items.AddDropDown("Toolbars", MenuKeys.ViewToolbars, PluginIdentity.Default);
            items.AddDropDown("Windows", MenuKeys.ViewWindows, PluginIdentity.Default);
            items.AddDropDown("Skins", MenuKeys.ViewSkins, PluginIdentity.Default);

            _viewMenuService.Init(_context, _menuManager, _dockingManager);
        }

        private void InitHelpMenu()
        {
            var items = _context.Menu.HelpMenu.SubItems;
            items.AddButton("About", MenuKeys.About, PluginIdentity.Default);
        }

        #endregion

        #region Toolbars

        private void InitToolbars()
        {
            var bar = _context.Toolbars.Add(FILE_TOOLBAR, PluginIdentity.Default);
            InitFileToolbar(bar);
            bar.DockState = ToolbarDockState.Left;

            bar = _context.Toolbars.Add(MAP_TOOLBAR, PluginIdentity.Default);
            InitMapToolbar(bar);
            bar.DockState = ToolbarDockState.Top;
        }

        private void InitFileToolbar(IToolbar bar)
        {
            var items = bar.Items;
            items.AddButton("New map", MenuKeys.NewMap, Resources.new_map, PluginIdentity.Default);
            items.AddButton("Open project", MenuKeys.OpenProject, Resources.folder, PluginIdentity.Default);
            items.AddButton("Save project", MenuKeys.SaveProject, Resources.save, PluginIdentity.Default);
            items.AddButton("Save project as", MenuKeys.SaveProjectAs, Resources.save_as, PluginIdentity.Default);

            items.AddButton("Add layer", MenuKeys.AddLayer, Resources.layer_add, PluginIdentity.Default).BeginGroup = true;
            items.AddButton("Add vector layer", MenuKeys.AddVectorLayer, Resources.layer_vector_add, PluginIdentity.Default);
            items.AddButton("Add raster layer", MenuKeys.AddRasterLayer, Resources.layer_raster_add, PluginIdentity.Default);
            items.AddButton("Add database layer", MenuKeys.AddDatabaseLayer, Resources.layer_database_add, PluginIdentity.Default);

            items.AddButton("Create layer", MenuKeys.FileBarCreateLayer, Resources.layer_create, PluginIdentity.Default).BeginGroup = true;
            items.AddButton("Remove layer", MenuKeys.RemoveLayer, Resources.layer_remove, PluginIdentity.Default);

            bar.Update();
        }

        private void InitMapToolbar(IToolbar bar)
        {
            var items = bar.Items;

            items.AddButton("Zoom in", MenuKeys.ZoomIn, Resources.zoom_in, PluginIdentity.Default);
            items.AddButton("Zoom out", MenuKeys.ZoomOut, Resources.zoom_out, PluginIdentity.Default);
            items.AddButton("Zoom to maximum extents", MenuKeys.ZoomMax, Resources.zoom_max_extents, PluginIdentity.Default);
            items.AddButton("Zoom to layer", MenuKeys.ZoomToLayer, Resources.zoom_to_layer, PluginIdentity.Default);
            items.AddButton("Pan", MenuKeys.Pan, Resources.pan, PluginIdentity.Default);

            items.AddButton("Set coordinate system & projection", MenuKeys.SetProjection, Resources.crs_change, PluginIdentity.Default).BeginGroup = true;

            bar.Update();
        }

        #endregion
    }
}
