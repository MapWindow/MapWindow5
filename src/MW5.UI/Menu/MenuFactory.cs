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

        internal static IMenu CreateInstance(object menuManager)
        {
            if (_instance == null)
            {
                if (DebugHelper.SyncfusionMenu)
                {
                    CreateSyncfusionMenu(menuManager);
                }
                else
                {
                    CreateMenuStripMenu(menuManager);
                }
            }

            return _instance;
        }

        private static void CreateMenuStripMenu(object menuManager)
        {
            var manager = menuManager as MainFrameBarManager;
            if (manager == null)
            {
                throw new InvalidCastException("Menu manager must be an instance of MainFrameBarManager.");
            }

            var menuIndex = new MenuIndex(MenuIndexType.MainMenu);

            var menu = new MenuStripMenu(menuManager, menuIndex);

            menu.CreateMenuBar();
            menu.CreateDefaultItems();

            _instance = menu;
        }

        private static void CreateSyncfusionMenu(object menuManager)
        {
            var menuIndex = new MenuIndex(MenuIndexType.MainMenu);
            var menu = new Menu(menuManager, menuIndex);
            menu.CreateMenuBar();
            menu.CreateDefaultItems();
            _instance = menu;
        }

        internal static IStatusBar CreateStatusBar(object bar, PluginIdentity identity)
        {
            var menuIndex = new MenuIndex(MenuIndexType.StatusBar);
            var statusBar = new StatusBar(bar, menuIndex, identity);
            return statusBar;
        }

        internal static IToolbarCollection CreateToolbars(object menuManager)
        {
            var menuIndex = new MenuIndex(MenuIndexType.Toolbar);
            var collection = new ToolbarsCollection(menuManager, menuIndex);
            return collection;
        }
    }
}
