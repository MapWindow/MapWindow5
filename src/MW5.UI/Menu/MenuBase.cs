using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;

namespace MW5.UI.Menu
{
    internal abstract class MenuBase : IMenuBase
    {
        protected const string MainMenuName = "MainMenuStripMenu";
        protected MenuIndex _menuIndex;

        public abstract string Name { get; set; }

        public abstract IMenuItemCollection Items { get;  }

        public abstract bool Visible { get; set; }

        public abstract object Tag { get; set; }

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

        public virtual void Update()
        {
            // do nothing; no separators are needed here
        }

        protected IDropDownMenuItem GetDropDownItem(string key)
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
