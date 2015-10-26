using System;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.UI.Enums;
using MW5.UI.Menu.Classic;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu
{
    public class MenuFactory
    {
        private static IMenu _instance;

        internal static IMenu CreateMainMenu(object menuManager)
        {
            if (_instance == null)
            {
                var menuIndex = new MenuIndex(MenuIndexType.MainMenu);

                if (DebugHelper.SyncfusionMenu)
                {
                    _instance = new MainSyncfusionMenu(menuManager, menuIndex);
                }
                else
                {
                    _instance = new MainMenuStripMenu(menuManager, menuIndex);
                }

                CreateDefaultMenuItems(_instance);
            }

            return _instance;
        }

        internal static IMenuEx CreateMenu(object menuManager)
        {
            var menuIndex = new MenuIndex(MenuIndexType.MainMenu, false);

            return new MenuStripMenu(menuManager, menuIndex);
        }

        internal static IStatusBar CreateStatusBar(object bar, PluginIdentity identity)
        {
            var menuIndex = new MenuIndex(MenuIndexType.StatusBar);
            var statusBar = new StatusBar(bar, menuIndex, identity);
            return statusBar;
        }

        internal static IToolbarCollection CreateMainToolbars(object menuManager)
        {
            var menuIndex = new MenuIndex(MenuIndexType.Toolbar);
            return new ToolbarCollectionMain(menuManager, menuIndex);
        }

        internal static IToolbarCollectionEx CreateToolbars(object menuManager)
        {
            var menuIndex = new MenuIndex(MenuIndexType.Toolbar, false);
            return new ToolbarCollection(menuManager, menuIndex);
        }

        private static void CreateDefaultMenuItems(IMenuBase menu)
        {
            var items = menu.Items;

            items.AddDropDown("File", MainMenuKeys.File, PluginIdentity.Default);
            items.AddDropDown("View", MainMenuKeys.View, PluginIdentity.Default);
            items.AddDropDown("Map", MainMenuKeys.Map, PluginIdentity.Default);
            items.AddDropDown("Layer", MainMenuKeys.Layer, PluginIdentity.Default);
            items.AddDropDown("Plugins", MainMenuKeys.Plugins, PluginIdentity.Default);
            items.AddDropDown("Tiles", MainMenuKeys.Tiles, PluginIdentity.Default);
            items.AddDropDown("Help", MainMenuKeys.Help, PluginIdentity.Default);

            menu.Update();
        }
    }
}
