using System;
using System.ComponentModel;
using System.Drawing;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu
{
    internal class MenuItem: MenuItemBase, IMenuItem
    {
        private const int ICON_SIZE = 24;
        protected BarItem _item;

        internal MenuItem(BarItem item)
        {
            _item = item;
            if (item == null)
            {
                throw new NullReferenceException("Bar item reference is null.");
            }

            item.ShowTooltip = false;
        }
        
        public string Text
        {
            get { return _item.Text; }
            set
            {
                _item.Text = value;
                FireItemChanged("Text");
            }
        }

        public IMenuIcon Icon
        {
            get { return new MenuIcon(_item.Image.GetImage()); }
            set
            {
                _item.Image = new ImageExt(value.Image);
                _item.ImageSize = new Size(ICON_SIZE, ICON_SIZE);
            }
        }

        public string Category
        {
            get { return Metadata.Category; }
            set { Metadata.Category = value; }
        }

        public bool Checked
        {
            get { return _item.Checked; }
            set { _item.Checked = value; }
        }

        public bool Enabled
        {
            get { return _item.Enabled; }
            set { _item.Enabled = value; }
        }

        protected override MenuItemMetadata Metadata
        {
            get
            {
                var data = _item.Tag as MenuItemMetadata;
                if (data == null)
                {
                    throw new ApplicationException("Tag property of menu items must store an instance of MenuItemMetadata class.");
                }
                return data;
            }
        }

        public bool Visible
        {
            get { return _item.Visible; }
            set { _item.Visible = value; }
        }

        public void AttachClickEventHandler(EventHandler<MenuItemEventArgs> handler)
        {
            _item.Click += (sender, args) => handler.Invoke(this, new MenuItemEventArgs(Key));
        }

        internal protected virtual void DetachItemListeners()
        {
            EventHelper.RemoveEventHandler(_item, "Click");      // so it can be collected by GC
            EventHelper.RemoveEventHandler(_item, "Selected");
            EventHelper.RemoveEventHandler(_item, "ItemChanged");
        }

        public object GetInternalObject()
        {
            return _item;
        }

        public event EventHandler ItemSelected
        {
            add
            {
                _item.Selected += (s, e) => value.Invoke(this, e);
            }
            remove
            {
                // will be unsubscribed in DetachItemListeners
            }
        }
    }
}
