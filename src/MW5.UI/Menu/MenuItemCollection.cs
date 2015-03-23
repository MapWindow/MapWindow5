using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu
{
    internal class MenuItemCollection : IMenuItemCollection
    {
        private const int TOOLBAR_ITEM_PADDING_X = 10;
        private const int TOOLBAR_ITEM_PADDING_Y = 5;
        private readonly BarItems _items;
        private readonly IMenuIndex _menuIndex;

        internal MenuItemCollection(BarItems items, IMenuIndex menuIndex)
        {
            _items = items;
            _menuIndex = menuIndex;
            if (items == null)
            {
                throw new NullReferenceException("Bar items reference is null.");
            }
            if (menuIndex == null)
            {
                throw new ArgumentNullException("menuIndex");
            }
        }

        public static void RemoveItems(IMenuItemCollection items, PluginIdentity identity)
        {
            for (int j = items.Count() - 1; j >= 0; j--)
            {
                var dropDownMenuItem = items[j] as IDropDownMenuItem;
                if (dropDownMenuItem != null)
                {
                    RemoveItems(dropDownMenuItem.SubItems, identity);
                }

                if (items[j].PluginIdentity == identity)
                {
                    items.Remove(j);
                }
            }
        }

        public IEnumerator<IMenuItem> GetEnumerator()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

       

        public IMenuItem this[int index]
        {
            get
            {
                if (index < 0 || index >= _items.Count)
                {
                    return null;
                }

                var item = _items[index];
                if (item is ParentBarItem)
                {
                    return new DropDownMenuItem(item as ParentBarItem, _menuIndex);
                }

                return new MenuItem(item);
            }
        }

        public IMenuItem AddLabel(string text, string key, PluginIdentity identity)
        {
            var item = new StaticBarItem(text) { Padding = new Point(TOOLBAR_ITEM_PADDING_X, TOOLBAR_ITEM_PADDING_Y) };
            var menuItem = AddItem(item, identity, key);
            return menuItem;
        }

        public IMenuItem AddButton(MenuCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            // TODO: command can have further use, e.g. to control Enabled state of the item
            // then it should be stored in the tag
            return AddButton(command.Text, command.Key, command.Icon, command.PluginIdentity);
        }

        public IMenuItem AddButton(string text, PluginIdentity identity)
        {
            return AddButton(text, string.Empty, identity);
        }

        public IMenuItem AddButton(string text, string key, PluginIdentity identity)
        {
            return AddButton(text, key, null, identity);
        }

        public IMenuItem AddButton(string text, string key, Bitmap icon, PluginIdentity pluginIdentity)
        {
            var item = new BarItem(text) {Padding = new Point(TOOLBAR_ITEM_PADDING_X, TOOLBAR_ITEM_PADDING_Y)};
            var menuItem = AddItem(item, pluginIdentity, key);
            if (icon != null)
            {
                menuItem.Icon = new MenuIcon(icon);
            }
            return menuItem;
        }

        public IDropDownMenuItem AddDropDown(string text, string key, PluginIdentity identity)
        {
            return AddDropDown(text, key, null, identity);
        }

        public IDropDownMenuItem AddDropDown(string text, Bitmap icon, PluginIdentity identity)
        {
            return AddDropDown(text, string.Empty, icon, identity);
        }

        private IDropDownMenuItem AddDropDown(string text, string key, Bitmap icon, PluginIdentity identity)
        {
            var item = new ParentBarItem(text) { Padding = new Point(TOOLBAR_ITEM_PADDING_X, TOOLBAR_ITEM_PADDING_Y) }; ;
            var menuItem = AddItem(item, identity, key) as IDropDownMenuItem;
            if (menuItem != null && icon != null)
            {
                menuItem.Icon = new MenuIcon(icon);
            }
            return menuItem;
        }

        public void Insert(IMenuItem item, int index)
        {
            if (index < 0 || index >= _items.Count)
            {
                throw new IndexOutOfRangeException("Menu items index is out of range.");
            }
            _items.Insert(index, item);
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= _items.Count)
            {
                throw new IndexOutOfRangeException("Menu items index is out of range.");
            }

            var menuItem = this[index] as MenuItem;
            if (menuItem != null)
            {
                menuItem.DetachItemListeners();
                _menuIndex.Remove(menuItem.UniqueKey);
            }

            _items.RemoveAt(index);
        }

        public void Clear()
        {
            // clear the nested menus recursively
            var subMenus = this.OfType<IDropDownMenuItem>().Select(item => item.SubItems);
            {
                foreach (var menu in subMenus)
                {
                    menu.Clear();
                }
            }

            // clear the index
            var keys = this.Select(item => item.UniqueKey).ToList();
            foreach (var uniqueKey in keys)
            {
                _menuIndex.Remove(uniqueKey);
            }

            _items.Clear();
        }

        private IMenuItem AddItem(BarItem item, PluginIdentity identity, string key)
        {
            item.Tag = new MenuItemMetadata(identity, key);
            int index = _items.Add(item);

            var menuItem = this[index];

            if (!string.IsNullOrWhiteSpace(key))
            {
                menuItem.AttachClickEventHandler(PluginManager.Instance.FireItemClicked);
                _menuIndex.AddItem(menuItem.UniqueKey, menuItem);
            }

            return menuItem;
        }
        
    }
}
