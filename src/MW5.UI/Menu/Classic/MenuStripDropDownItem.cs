using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Shared;

namespace MW5.UI.Menu.Classic
{
    /// <summary>
    /// Represents ToolStripMenuItem implementation of IDropDownMenuItem interface.
    /// </summary>
    internal class MenuStripDropDownItem : MenuStripItem, IDropDownMenuItem
    {
        private readonly IMenuIndex _menuIndex;

        public MenuStripDropDownItem(ToolStripMenuItem item, IMenuIndex menuIndex)
            : base(item)
        {
            if (menuIndex == null) throw new ArgumentNullException("menuIndex");
            _menuIndex = menuIndex;

            // TODO: add handlers only when external handlers are attached,
            // otherwise it will preven GC of this wrapper
            item.DropDownOpening += (s, e) => FireDropDownOpening();
            item.DropDownClosed += (s, e) => FireDropDownClosed();
        }

        /// <summary>
        /// Gets the collection item in submenu for this item.
        /// </summary>
        public IMenuItemCollection SubItems 
        {
            get
            {
                return new MenuStripItemCollection(_item.DropDownItems, _menuIndex);
            } 
        }

        public event EventHandler DropDownOpening;

        public event EventHandler DropDownClosed;

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

        internal protected override void DetachItemListeners()
        {
            base.DetachItemListeners();

            EventHelper.RemoveEventHandler(_item, "DropDownOpening");
            EventHelper.RemoveEventHandler(_item, "DropDownClosed");
        }

        public void Update()
        {
            UpdateSeparators();
        }

        private void UpdateSeparators()
        {
            for (int i = _item.DropDownItems.Count - 1; i >= 0 ; i--)
            {
                if (_item.DropDownItems[i] is ToolStripSeparator)
                {
                    _item.DropDownItems.RemoveAt(i);
                }
            }

            foreach(var item in SubItems.ToList())
            {
                if (item.BeginGroup)
                {
                    var menuItem = item.GetInternalObject() as ToolStripMenuItem;
                    if (menuItem != null)
                    {
                        int index = _item.DropDownItems.IndexOf(menuItem);
                        if (index != -1)
                        {
                            _item.DropDownItems.Insert(index, new ToolStripSeparator());
                        }
                    }
                }
            }
        }
    }
}
