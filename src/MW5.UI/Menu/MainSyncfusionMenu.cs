using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.UI.Menu
{
    internal class MainSyncfusionMenu: SyncfusionMenu, IMenu
    {
        internal MainSyncfusionMenu(object menuManager, MenuIndex menuIndex)
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

        public IDropDownMenuItem HelpMenu
        {
            get { return GetDropDownItem(MainMenuKeys.Help); }
        }
    }
}
