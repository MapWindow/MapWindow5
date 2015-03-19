using System;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu
{
    internal class DropDownMenuItem: MenuItem, IDropDownMenuItem
    {
        private readonly IMenuIndex _menuIndex;

        internal DropDownMenuItem(ParentBarItem item, IMenuIndex menuIndex) 
            : base(item)
        {
            if (menuIndex == null)
            {
                throw new ArgumentNullException("menuIndex");
            }
            _menuIndex = menuIndex;
        }

        public IMenuItemCollection SubItems
        {
            get
            {
                var item = _item as ParentBarItem;
                if (item == null)
                {
                    throw new ApplicationException("Invalid menu item: parent menu item expected.");
                }
                return new MenuItemCollection(item.Items, _menuIndex);
            }
        }

        private ParentBarItem AsParent
        {
            get { return _item as ParentBarItem; }
        }

        public event EventHandler DropDownOpening
        {
            add
            {
                AsParent.Popup += (s, e) => value.Invoke(this, e);
            }
            remove
            {
                //AsParent.Popup -= value;        // the handler is removed in MenuItemCollection.Remove
            }
        }

        public event EventHandler DropDownClosed
        {
            add
            {
                AsParent.PopupClosed += (s, e) => value.Invoke(this, e);
            }
            remove
            {
                AsParent.PopupClosed -= value;
            }
        }

        public void Update()
        {
            UpdateSeparators();
        }

        private void UpdateSeparators()
        {
            foreach (var item in SubItems)
            {
                var barItem = item.GetInternalObject() as BarItem;
                AsParent.RemoveGroupAt(barItem);
                if (item.BeginGroup)
                {
                    AsParent.BeginGroupAt(barItem);
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
