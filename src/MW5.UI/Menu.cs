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
    internal class Menu: IMenu
    {
        private const string MAIN_MENU_NAME = "MainMenu";
        private readonly MenuIndex _menuIndex;

        private MainFrameBarManager _menuManager;

        internal void CreateDefaultItems()
        {
            Items.AddDropDown("File", MainMenuKeys.File, PluginIdentity.Default);
            Items.AddDropDown("Plugins", MainMenuKeys.Plugins, PluginIdentity.Default);
            Items.AddDropDown("Tiles", MainMenuKeys.Tiles, PluginIdentity.Default);
            Items.AddDropDown("Help", MainMenuKeys.Help, PluginIdentity.Default);
        }

        internal void CreateMenuBar()
        {
            var bar = new Bar(_menuManager, MAIN_MENU_NAME)
            {
                BarStyle = BarStyle.IsMainMenu | BarStyle.UseWholeRow | BarStyle.Visible
            };

            int index = _menuManager.Bars.Add(bar);

            var cbr = _menuManager.GetBarControl(bar);
            cbr.Tag = new MenuItemMetadata(PluginIdentity.Default, MAIN_MENU_NAME);
            cbr.AlwaysLeadingEdge = true;
        }

        internal Menu(object menuManager, MenuIndex menuIndex)
        {
            _menuIndex = menuIndex;
            _menuManager = menuManager as MainFrameBarManager;
            if (menuIndex == null)
            {
                throw new ArgumentNullException("menuIndex");
            }
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
                return new MenuItemCollection(MenuBar.Items, _menuIndex);
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
            get { return GetDropDownItem(MainMenuKeys.Plugins); }
        }

        public IDropDownMenuItem Tiles
        {
            get { return GetDropDownItem(MainMenuKeys.Tiles); }
        }

        private IDropDownMenuItem GetDropDownItem(string key)
        {
            return FindItem(key) as IDropDownMenuItem;
        }

        public IMenuItem FindItem(string key)
        {
            return _menuIndex.GetItem(key);
        }

        public void RemoveItemsForPlugin(PluginIdentity identity)
        {
            _menuIndex.RemoveItemsForPlugin(identity);

            MenuItemCollection.RemoveItems(Items, identity);
        }
    }
}
