using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Menu
{
    internal class StatusItemCollection : ItemCollectionBase, IStatusItemCollection
    {
        private const int ITEM_PADDING = 7;

        private readonly ToolStripItemCollection _items;
        private readonly IMenuIndex _menuIndex;
        private readonly bool _topLevel;

        public StatusItemCollection(ToolStripItemCollection items, IMenuIndex menuIndex, bool topLevel):
            base(items, menuIndex)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (menuIndex == null) throw new ArgumentNullException("menuIndex");

            _items = items;
            _menuIndex = menuIndex;
            _topLevel = topLevel;
        }

        public override IMenuItem this[int index]
        {
            get
            {
                if (index < 0 || index >= _items.Count)
                {
                    return null;
                }

                var item = _items[index];
                if (item is ToolStripMenuItem || item is StatusStripDropDownButton)
                {
                    return new StatusBarDropDown(item, _menuIndex);
                }

                return new StatusBarItem(item);
            }
        }

        public override IMenuItem AddLabel(string text, string key, PluginIdentity identity)
        {
            ToolStripItem item = null;
            if (AlignRight)
            {
                item = new ToolStripStatusLabel() { Text = text, Padding = new Padding(ITEM_PADDING) };
            }
            else
            {
                item = new StatusStripLabel { Text = text, Padding = new Padding(ITEM_PADDING) };
            }

            var menuItem = AddItem(item, identity, key, true);
            return menuItem;
        }

        public IMenuItem AddProgressBar(string key, PluginIdentity identity)
        {
            var item = new ToolStripProgressBar();
            var menuItem = AddItem(item, identity, key, true);
            return menuItem;
        }

        public override IMenuItem AddButton(string text, string key, Bitmap icon, PluginIdentity identity)
        {
            var item = new ToolStripMenuItem { Text = text};
            var menuItem = AddItem(item, identity, key, false);
            MenuIcon.AssignIcon(menuItem, icon);
            return menuItem;
        }

        protected override IDropDownMenuItem AddDropDown(string text, string key, Bitmap icon, PluginIdentity identity)
        {
            if (!_topLevel)
            {
                return AddButton(text, key, icon, identity) as IDropDownMenuItem;
            }

            var item = new StatusStripDropDownButton()
            {
                Text = text, 
                Padding = new Padding(ITEM_PADDING),
                ImageScaling = ToolStripItemImageScaling.SizeToFit
            };
            var menuItem = AddItem(item, identity, key, true) as IDropDownMenuItem;
            MenuIcon.AssignIcon(menuItem, icon);
            return menuItem;
        }

        protected IMenuItem AddItem(ToolStripItem item, PluginIdentity identity, string key, bool label)
        {
            item.Tag = new MenuItemMetadata(identity, key);
            return AddItemCore(item, key, label, true);
        }

        public bool AlignRight
        {
            get
            {
                var data = MenuIndex.LoadMetadata(_items);
                if (data != null)
                {
                    return data.AlignRight;
                }
                return false;
            }
            set
            {
                var data = MenuIndex.LoadMetadata(_items) ?? new MenuItemCollectionMetadata();
                data.AlignRight = value;
                MenuIndex.SaveMetadata(_items, data);
            }
        }
    }
}
