using System;
using MW5.Plugins.Interfaces;
using MW5.Shared;
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

            // TODO: add handlers only when external handlers are attached,
            // otherwise it will preven GC of this wrapper
            item.Popup += (s, e) => FireDropDownOpening();
            item.PopupClosed += (s, e) => FireDropDownClosed();
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

        private void FireDropDownOpening()
        {
            var handler = DropDownOpening;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private void FireDropDownClosed()
        {
            var handler = DropDownClosed;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        public event EventHandler DropDownOpening;

        public event EventHandler DropDownClosed;

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
            EventHelper.RemoveEventHandler(_item, "PopupClosed");
        }
    }
}
