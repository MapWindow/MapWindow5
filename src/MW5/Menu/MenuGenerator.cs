using System;
using System.Collections.Generic;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Properties;
using MW5.Services;
using System.Linq;
using MW5.Plugins.Services;

namespace MW5.Menu
{
    internal class MenuGenerator
    {
        private const string FILE_TOOLBAR = "File";
        private const string MAP_TOOLBAR = "Map";
        
        private readonly IAppContext _context;
        private readonly IPluginManager _pluginManager;
        private readonly IMainView _mainView;
        private readonly MenuCommands _commands;
        private readonly object _menuManager;
        private readonly object _dockingManager;

        public MenuGenerator(IAppContext context, IPluginManager pluginManager, IMainView mainView)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (pluginManager == null) throw new ArgumentNullException("pluginManager");
            if (mainView == null) throw new ArgumentNullException("mainView");

            _context = context;
            _pluginManager = pluginManager;
            _mainView = mainView;
            _menuManager = _mainView.MenuManager;
            _dockingManager = _mainView.DockingManager;
            _commands = new MenuCommands(PluginIdentity.Default);

            InitToolbars();
            InitMenus();
        }

        private void InitMenus()
        {
            InitFileMenu();

            InitViewMenu();

            PluginsMenuHelper.Init(_context, _pluginManager);

            TilesMenuHelper.Init(_context.Map, _context.Menu.TilesMenu);

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

            ViewMenuHelper.Init(_context, _menuManager, _dockingManager);
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
            _commands.AddToMenu(items, MenuKeys.Settings, true);
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
            //_commands.AddToMenu(items, MenuKeys.Attributes);

            // select drop down
            var dropDown = items.AddDropDown("Select", MenuKeys.SelectDropDown, PluginIdentity.Default);
            dropDown.BeginGroup = true;
            dropDown.Icon = new MenuIcon(Resources.icon_select);
            _commands.AddToMenu(dropDown.SubItems, MenuKeys.SelectByRectangle);
            _commands.AddToMenu(dropDown.SubItems, MenuKeys.SelectByPolygon);

            _commands.AddToMenu(items, MenuKeys.ZoomToSelected);
            _commands.AddToMenu(items, MenuKeys.ClearSelection);

            bar.Update();
        }

        #endregion
    }
}
