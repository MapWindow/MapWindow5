using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI
{
    public class DropDownMenuItem: MenuItem, IDropDownMenuItem
    {
        internal DropDownMenuItem(ParentBarItem item) 
            : base(item)
        {

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
                return new MenuItemCollection(item.Items);
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
                AsParent.Popup -= value;        // the handler is removed in MenuItemCollection.Remove
            }
        }

        public void SetGroupBegins(int index, bool value)
        {
            if (index < 0 || index > AsParent.Items.Count)
            {
                throw new IndexOutOfRangeException("Item index is out of range.");
            }
            var item = AsParent.Items[index];
            if (value)
            {
                AsParent.BeginGroupAt(item);
            }
            else
            {
                AsParent.RemoveGroupAt(item);
            }
            
        }

        public bool GetGroupBegins(int index)
        {
            if (index < 0 || index > AsParent.Items.Count)
            {
                throw new IndexOutOfRangeException("Item index is out of range.");
            }
            
            var item = AsParent.Items[index];
            return AsParent.IsGroupBeginning(item);
        }
    }
}
