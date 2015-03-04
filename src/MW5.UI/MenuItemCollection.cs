using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI
{
    public class MenuItemCollection: IMenuItemCollection
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

        public IMenuItem AddButton(string text)
        {
            var item = new BarItem(text);
            return AddButtonCore(item);
        }

        public IMenuItem AddButton(string text, string name)
        {
            var item = new BarItem(text) {ID = name};
            return AddButtonCore(item);
        }

        private IMenuItem AddButtonCore(BarItem item)
        {
            item.Padding = new System.Drawing.Point(TOOLBAR_ITEM_PADDING_X, TOOLBAR_ITEM_PADDING_Y);
            _items.Add(item);
            return new MenuItem(item);
        }

        public IDropDownMenuItem AddDropDown(string text)
        {
            var item = new ParentBarItem(text);
            _items.Add(item);
            return new DropDownMenuItem(item);
        }

        public void Add(IDropDownMenuItem dropDownItem)
        {
            _items.Add(dropDownItem);
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
            _items.RemoveAt(index);
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}
