using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI
{
    public class Menu: IMenu
    {
        private MainFrameBarManager _menuManager;

        public static IMenu CreateInstance(object menuManager)
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

        public IDropDownMenuItem Plugins
        {
            get
            {
                // TODO: make constant
                var item = _menuManager.MainMenuBar.Items.FindItem("plugins") as ParentBarItem; 
                return new DropDownMenuItem(item);
            }
        }

        public IDropDownMenuItem Tiles
        {
            get
            {
                // TODO: make constant
                var item = _menuManager.MainMenuBar.Items.FindItem("tiles") as ParentBarItem;
                return new DropDownMenuItem(item);
            }
        }
    }
}
