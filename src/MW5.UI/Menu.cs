using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI
{
    public class Menu: IMenu
    {
        private const string PLUGIN_MENU_ITEM = "plugins";
        private const string TILES_MENU_ITEM = "tiles";

        private MainFrameBarManager _menuManager;

        internal static IMenu CreateInstance(object menuManager)
        {
            var menu = new Menu(menuManager);
            return menu;
        }

        private Menu(object menuManager)
        {
            _menuManager = menuManager as MainFrameBarManager;
            if (_menuManager == null)
            {
                throw new ApplicationException("Invalid type of menu manager");
            }
        }

        private Bar MenuBar
        {
            get
            {
                var menu = _menuManager.MainMenuBar;
                if (menu == null)
                {
                    throw new ApplicationException("Failed to find main menu if the application.");
                }
                return menu;
            }
        }

        public string Name
        {
            get { return _menuManager.MainMenuBar.BarName; }
            set { _menuManager.MainMenuBar.BarName = value; }
        }

        public IMenuItemCollection Items
        {
            get
            {
                return new MenuItemCollection(MenuBar.Items);
            }
        }

        private CommandBar CommandBar
        {
            get { return _menuManager.GetBarControl(_menuManager.MainMenuBar); }
        }

        public bool Visible
        {
            get { return CommandBar.Visible; }
            set { CommandBar.Visible = true; }
        }

        public object Tag
        {
            get { return CommandBar.Tag; }
            set { CommandBar.Tag = value; }
        }

        public ToolbarDockState DockState
        {
            get { return ToolbarDockState.Top; }
            set { throw new NotSupportedException("Dock state for the main menu can't be changed."); }
        }

        public void AddSeparator(int beforeItemIndex)
        {
            MenuBar.SeparatorIndices.Add(beforeItemIndex);
        }

        public void ClearSeparators()
        {
            MenuBar.SeparatorIndices.Clear();
        }

        public PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        public IDropDownMenuItem Plugins
        {
            get
            {
                var item = _menuManager.MainMenuBar.Items.FindItem(PLUGIN_MENU_ITEM) as ParentBarItem; 
                return new DropDownMenuItem(item);
            }
        }

        public IDropDownMenuItem Tiles
        {
            get
            {
                var item = _menuManager.MainMenuBar.Items.FindItem(TILES_MENU_ITEM) as ParentBarItem;
                return new DropDownMenuItem(item);
            }
        }

        public IMenuItem FindItem(string key)
        {
            return MenuIndex.GetItem(key);
        }
       
    }
}
