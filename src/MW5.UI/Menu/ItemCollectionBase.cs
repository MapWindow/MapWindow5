using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu
{
    internal abstract class ItemCollectionBase: IMenuItemCollection
    {
        private readonly IList _items;
        protected readonly IMenuIndex MenuIndex;

        internal ItemCollectionBase(IList items, IMenuIndex menuIndex)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (menuIndex == null) throw new ArgumentNullException("menuIndex");

            _items = items;
            MenuIndex = menuIndex;
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

        public abstract IMenuItem this[int menuItemIndex] { get; }

        protected abstract IDropDownMenuItem AddDropDown(string text, string key, Bitmap icon, PluginIdentity identity);

        public abstract IMenuItem AddLabel(string text, string key, PluginIdentity identity);

        public abstract IMenuItem AddButton(string text, string key, Bitmap icon, PluginIdentity identity);

        public IMenuItem AddButton(MenuCommand command, bool beginGroup = false)
        {
            if (command == null) throw new ArgumentNullException("command");

            var item = AddButton(command.Text, command.Key, command.Icon, command.PluginIdentity);

            item.Description = command.Description;

            if (beginGroup)
            {
                item.BeginGroup = true;
            }

            return item;
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

        public IMenuItem AddButton(string text, PluginIdentity identity)
        {
            return AddButton(text, string.Empty, identity);
        }

        public IMenuItem AddButton(string text, string key, PluginIdentity identity)
        {
            return AddButton(text, key, null, identity);
        }

        public IDropDownMenuItem AddDropDown(string text, string key, PluginIdentity identity)
        {
            return AddDropDown(text, key, null, identity);
        }

        public IDropDownMenuItem AddDropDown(string text, Bitmap icon, PluginIdentity identity)
        {
            return AddDropDown(text, string.Empty, icon, identity);
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
                MenuIndex.Remove(menuItem.UniqueKey);
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
                MenuIndex.Remove(uniqueKey);
            }

            _items.Clear();
        }

        public int IndexOf(IMenuItem item)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                var it = this[i];
                if (it.UniqueKey == item.UniqueKey)
                {
                    return i;
                }
            }
            return -1;
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public IMenuItem InsertBefore
        {
            get
            {
                var data = MenuIndex.LoadMetadata(_items);
                if (data != null)
                {
                    return data.InsertBefore;
                }
                return null;
            }
            set
            {
                var data = MenuIndex.LoadMetadata(_items) ?? new MenuItemCollectionMetadata();
                data.InsertBefore = value;
                MenuIndex.SaveMetadata(_items, data);
            }
        }

        protected IMenuItem AddItemCore(object item,  string key, bool label, bool statusBar)
        {
            int index = -1;
            if (InsertBefore != null)
            {
                index = IndexOf(InsertBefore);
            }

            if (index != -1)
            {
                _items.Insert(index, item);
            }
            else
            {
                index = _items.Add(item);
            }

            var menuItem = this[index];

            if (!string.IsNullOrWhiteSpace(key))
            {
                if (!label)
                {
                    if (statusBar)
                    {
                        menuItem.ItemClicked += PluginBroadcaster.Instance.FireStatusItemClicked;    
                    }
                    else
                    {
                        menuItem.ItemClicked += PluginBroadcaster.Instance.FireItemClicked;    
                    }
                }

                MenuIndex.AddItem(menuItem.UniqueKey, menuItem);
            }

            return menuItem;
        }
    }
}
