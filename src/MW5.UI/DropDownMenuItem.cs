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
                AsParent.Popup += value;
            }
            remove
            {
                AsParent.Popup -= value;
            }
        }
    }
}
