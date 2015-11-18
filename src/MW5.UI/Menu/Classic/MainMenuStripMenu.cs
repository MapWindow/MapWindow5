using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.UI.Menu.Classic
{
    internal class MainMenuStripMenu: MenuStripMenuMute, IMenu
    {
        internal MainMenuStripMenu(object menuManager, MenuIndex menuIndex)
            : base(menuManager, menuIndex)
        {
            
        }

        public IDropDownMenuItem FileMenu
        {
            get { return GetDropDownItem(MainMenuKeys.File); }
        }

        public IDropDownMenuItem LayerMenu
        {
            get { return GetDropDownItem(MainMenuKeys.Layer); }
        }

        public IDropDownMenuItem MapMenu
        {
            get { return GetDropDownItem(MainMenuKeys.Map); }
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

        public IDropDownMenuItem ToolsMenu
        {
            get { return GetDropDownItem(MainMenuKeys.Tools); }
        }

        public IDropDownMenuItem HelpMenu
        {
            get { return GetDropDownItem(MainMenuKeys.Help); }
        }
    }
}
