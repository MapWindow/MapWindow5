
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu
{
    internal class MenuItem : MenuItemBase, IMenuItem
    {
        private const int IconSize = 24;
        protected readonly BarItem _item;

        internal MenuItem(BarItem item)
        {
            _item = item;
            if (item == null)
            {
                throw new NullReferenceException("Bar item reference is null.");
            }

            item.ShowTooltip = false;
            
            Skip = false;
        }
        
        public virtual string Text
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
                if (value == null || value.Image == null) return;

                _item.Image = new ImageExt(value.Image);
                int width = value.UseNativeSize ? value.Image.Width : IconSize;
                int height = value.UseNativeSize ? value.Image.Height : IconSize;

                _item.ImageSize =  new Size(width, height);
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

        public override bool HasKey
        {
            get { return _item.Tag is MenuItemMetadata; }
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

        internal protected virtual void DetachItemListeners()
        {
            EventHelper.RemoveEventHandler(_item, "Click");      // so it can be collected by GC
            EventHelper.RemoveEventHandler(_item, "Selected");
            EventHelper.RemoveEventHandler(this, "ItemChanged");
        }

        public object GetInternalObject()
        {
            return _item;
        }

        public event EventHandler<MenuItemEventArgs> ItemClicked
        {
            add
            {
                _item.Click += (s, e) => value.Invoke(this, new MenuItemEventArgs(Key));
            }
            remove
            {
                // will be unsubscribed in DetachItemListeners
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item should be skipped during processing (e.g. separator).
        /// </summary>
        public bool Skip { get; private set; }

        /// <summary>
        /// Gets or sets the shortcut keys.
        /// </summary>
        public Keys ShortcutKeys { get; set; }
    }
}
