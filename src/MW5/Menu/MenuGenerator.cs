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

        private void InitFileMenu()
        {
            var items = _context.Menu.FileMenu.SubItems;

            items.AddButton(MenuKeys.NewMap);
            items.AddButton(MenuKeys.AddLayer, true);
            items.AddButton(MenuKeys.AddVectorLayer);
            items.AddButton(MenuKeys.AddRasterLayer);
            items.AddButton(MenuKeys.AddDatabaseLayer);
            items.AddButton(MenuKeys.OpenProject, true);
            items.AddButton(MenuKeys.SaveProject, true);
            items.AddButton(MenuKeys.SaveProjectAs);
            items.AddButton(MenuKeys.Quit, true);

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

            items.AddButton(MenuKeys.NewMap);
            items.AddButton(MenuKeys.OpenProject);
            items.AddButton(MenuKeys.SaveProject);
            items.AddButton(MenuKeys.SaveProjectAs);
            items.AddButton(MenuKeys.AddLayer, true);
            items.AddButton(MenuKeys.AddVectorLayer);
            items.AddButton(MenuKeys.AddRasterLayer);
            items.AddButton(MenuKeys.AddDatabaseLayer);
            items.AddButton(MenuKeys.CreateLayer, true);
            items.AddButton(MenuKeys.RemoveLayer);

            bar.Update();
        }

        private void InitMapToolbar(IToolbar bar)
        {
            var items = bar.Items;

            items.AddButton(MenuKeys.ZoomIn);
            items.AddButton(MenuKeys.ZoomOut);
            items.AddButton(MenuKeys.ZoomMax);
            items.AddButton(MenuKeys.ZoomToLayer);
            items.AddButton(MenuKeys.Pan);
            items.AddButton(MenuKeys.SetProjection, true);

            bar.Update();
        }

        #endregion
    }
}
