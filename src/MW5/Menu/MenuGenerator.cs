using System;
using System.Collections.Generic;
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
        private readonly CommandProvider _commands;
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
            _commands = new CommandProvider(PluginIdentity.Default);
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

        private void InitFileMenu()
        {
            var items = _context.Menu.FileMenu.SubItems;

            _commands.AddToMenu(items, MenuKeys.NewMap);
            _commands.AddToMenu(items, MenuKeys.AddLayer, true);
            _commands.AddToMenu(items, MenuKeys.AddVectorLayer);
            _commands.AddToMenu(items, MenuKeys.AddRasterLayer);
            _commands.AddToMenu(items, MenuKeys.AddDatabaseLayer);
            _commands.AddToMenu(items, MenuKeys.OpenProject, true);
            _commands.AddToMenu(items, MenuKeys.SaveProject, true);
            _commands.AddToMenu(items, MenuKeys.SaveProjectAs);
            _commands.AddToMenu(items, MenuKeys.Quit, true);

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

            _commands.AddToMenu(items, MenuKeys.NewMap);
            _commands.AddToMenu(items, MenuKeys.OpenProject);
            _commands.AddToMenu(items, MenuKeys.SaveProject);
            _commands.AddToMenu(items, MenuKeys.SaveProjectAs);
            _commands.AddToMenu(items, MenuKeys.AddLayer, true);
            _commands.AddToMenu(items, MenuKeys.AddVectorLayer);
            _commands.AddToMenu(items, MenuKeys.AddRasterLayer);
            _commands.AddToMenu(items, MenuKeys.AddDatabaseLayer);
            _commands.AddToMenu(items, MenuKeys.CreateLayer, true);
            _commands.AddToMenu(items, MenuKeys.RemoveLayer);

            bar.Update();
        }

        private void InitMapToolbar(IToolbar bar)
        {
            var items = bar.Items;

            _commands.AddToMenu(items, MenuKeys.ZoomIn);
            _commands.AddToMenu(items, MenuKeys.ZoomOut);
            _commands.AddToMenu(items, MenuKeys.ZoomMax);
            _commands.AddToMenu(items, MenuKeys.ZoomToLayer);
            _commands.AddToMenu(items, MenuKeys.Pan);
            _commands.AddToMenu(items, MenuKeys.SetProjection, true);

            _commands.AddToMenu(items, MenuKeys.MeasureDistance, true);
            _commands.AddToMenu(items, MenuKeys.MeasureArea);
            _commands.AddToMenu(items, MenuKeys.Attributes);

            // select drop down
            var dropDown = items.AddDropDown("Select", Resources.select, PluginIdentity.Default);
            dropDown.BeginGroup = true;
            _commands.AddToMenu(dropDown.SubItems, MenuKeys.SelectByRectangle);
            _commands.AddToMenu(dropDown.SubItems, MenuKeys.SelectByPolygon);

            _commands.AddToMenu(items, MenuKeys.ZoomToSelected);
            _commands.AddToMenu(items, MenuKeys.ClearSelection);

            bar.Update();
        }

        #endregion
    }
}
