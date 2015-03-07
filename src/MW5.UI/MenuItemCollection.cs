using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Helpers;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI
{
    public class MenuItemCollection : IMenuItemCollection
    {
        private const int TOOLBAR_ITEM_PADDING_X = 10;
        private const int TOOLBAR_ITEM_PADDING_Y = 5;
        private readonly BarItems _items;

        internal MenuItemCollection(BarItems items)
        {
            _items = items;
            if (items == null)
            {
                throw new NullReferenceException("Bar items reference is null.");
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
                    return new DropDownMenuItem(item as ParentBarItem);
                }
                return new MenuItem(item);
            }
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
            var item = new BarItem(text);
            item.Padding = new Point(TOOLBAR_ITEM_PADDING_X, TOOLBAR_ITEM_PADDING_Y);
            AddItem(item, pluginIdentity, key);
            
            var result = new MenuItem(item);
            if (icon != null)
            {
                result.Icon = new MenuIcon(icon);
            }
            RegisterItem(result);
            return result;
        }

        public IDropDownMenuItem AddDropDown(string text, string key, PluginIdentity identity)
        {
            var item = new ParentBarItem(text);
            AddItem(item, identity, key);
            var result = new DropDownMenuItem(item);
            RegisterItem(result);
            return result;
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
            
            var item = _items[index];
            EventHelper.RemoveEventHandler(item, "Click");      // so it can be collected by GC

            if (item is ParentBarItem)
            {
                EventHelper.RemoveEventHandler(item, "Popup");      // so it can be collected by GC
            }

            _items.RemoveAt(index);
        }

        public void Clear()
        {
            _items.Clear();
        }

        private void AddItem(BarItem item, PluginIdentity identity, string key)
        {
            item.Tag = new MenuItemMetadata(identity, key);
            _items.Add(item);
        }

        private void RegisterItem(IMenuItem item)
        {
            if (!string.IsNullOrWhiteSpace(item.Key))
            {
                item.AttachClickEventHandler(PluginManager.Instance.FireItemClicked);
                MenuIndex.AddItem(item.Key, item);
            }
        }
    }
}
