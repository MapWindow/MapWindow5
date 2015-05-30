using System;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu
{
    internal class Menu: IMenu
    {
        private const string MainMenuName = "MainMenu";
        private readonly MenuIndex _menuIndex;

        private MainFrameBarManager _menuManager;

        internal void CreateDefaultItems()
        {
            Items.AddDropDown("File", MainMenuKeys.File, PluginIdentity.Default);
            Items.AddDropDown("Layer", MainMenuKeys.Layer, PluginIdentity.Default);
            Items.AddDropDown("View", MainMenuKeys.View, PluginIdentity.Default);
            Items.AddDropDown("Plugins", MainMenuKeys.Plugins, PluginIdentity.Default);
            Items.AddDropDown("Tiles", MainMenuKeys.Tiles, PluginIdentity.Default);
            Items.AddDropDown("Help", MainMenuKeys.Help, PluginIdentity.Default);
        }

        internal void CreateMenuBar()
        {
            var bar = new Bar(_menuManager, MainMenuName)
            {
                BarStyle = BarStyle.IsMainMenu | BarStyle.UseWholeRow | BarStyle.Visible
            };

            int index = _menuManager.Bars.Add(bar);

            var cbr = _menuManager.GetBarControl(bar);
            cbr.Tag = new MenuItemMetadata(PluginIdentity.Default, MainMenuName);
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

        public string Key
        {
            get { return MainMenuName; }
        }

        public ToolbarDockState DockState
        {
            get { return ToolbarDockState.Top; }
            set { throw new NotSupportedException("Dock state for the main menu can't be changed."); }
        }

        public PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        public void Update()
        {
            // do nothing; no separators are needed here
        }

        public IDropDownMenuItem FileMenu
        {
            get { return GetDropDownItem(MainMenuKeys.File); }
        }

        public IDropDownMenuItem LayerMenu
        {
            get { return GetDropDownItem(MainMenuKeys.Layer); }
        }

        public IDropDownMenuItem ViewMenu
        {
            get { return GetDropDownItem(MainMenuKeys.View); }
        }

        public IDropDownMenuItem PluginsMenu
        {
            get { return GetDropDownItem(MainMenuKeys.Plugins); }
        }

        public IDropDownMenuItem TilesMenu
        {
            get { return GetDropDownItem(MainMenuKeys.Tiles); }
        }

        public IDropDownMenuItem HelpMenu
        {
            get { return GetDropDownItem(MainMenuKeys.Help); }
        }

        private IDropDownMenuItem GetDropDownItem(string key)
        {
            return FindItem(key, PluginIdentity.Default) as IDropDownMenuItem;
        }

        public IMenuItem FindItem(string key, PluginIdentity identity)
        {
            return _menuIndex.GetItem(identity.GetUniqueKey(key));
        }

        public void RemoveItemsForPlugin(PluginIdentity identity)
        {
            _menuIndex.RemoveItemsForPlugin(identity);

            ItemCollectionBase.RemoveItems(Items, identity);
        }
    }
}
