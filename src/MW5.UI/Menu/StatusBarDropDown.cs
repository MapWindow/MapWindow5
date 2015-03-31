using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu
{
    internal class StatusBarDropDown : StatusBarItem, IDropDownMenuItem
    {
        private readonly ToolStripItem _item;
        private readonly IMenuIndex _menuIndex;

        public StatusBarDropDown(ToolStripItem item, IMenuIndex menuIndex) : base(item)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (menuIndex == null) throw new ArgumentNullException("menuIndex");

            _item = item;
            _menuIndex = menuIndex;
        }

        public IMenuItemCollection SubItems
        {
            get
            {
                var item2 = _item as ToolStripMenuItem;
                if (item2 != null)
                {
                    return new StatusItemCollection(item2.DropDownItems, _menuIndex, false);
                }

                var item = _item as ToolStripDropDownButton;
                if (item != null)
                {
                    return new StatusItemCollection(item.DropDownItems, _menuIndex, false);
                }

                throw new ApplicationException("Invalid menu item: parent menu item expected.");
            }
        }

        private ToolStripDropDownButton AsParent
        {
            get { return _item as ToolStripDropDownButton; }
        }

        public event EventHandler DropDownOpening
        {
            add
            {
                AsParent.DropDownOpening += (s, e) => value.Invoke(this, e);
            }
            remove
            {
                AsParent.DropDownOpening -= value;
            }
        }

        public event EventHandler DropDownClosed
        {
            add
            {
                AsParent.DropDownClosed += (s, e) => value.Invoke(this, e);
            }
            remove
            {
                AsParent.DropDownClosed -= value;
            }
        }

        public void Update()
        {
            var items = AsParent.DropDownItems;
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i] is ToolStripSeparator)
                {
                    items.RemoveAt(i);
                }
            }

            for (int i = SubItems.Count - 1; i >= 0; i--)
            {
                var item = SubItems[i];
                if (item.BeginGroup)
                {
                    items.Insert(i, new ToolStripSeparator());
                }
            }
        }

        internal protected override void DetachItemListeners()
        {
            base.DetachItemListeners();
            EventHelper.RemoveEventHandler(_item, "Popup");
        }
    }
}
