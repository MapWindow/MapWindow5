using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Shared;

namespace MW5.UI.Menu.Classic
{
    /// <summary>
    /// Represents ToolStripMenuItem implementation of IMenuItem interface.
    /// </summary>
    internal class MenuStripItem : MenuItemBase, IMenuItem
    {
        protected readonly ToolStripMenuItem _item;

        public MenuStripItem(ToolStripMenuItem item)
        {
            if (item == null) throw new ArgumentNullException("item");
            _item = item;
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

        /// <summary>
        /// Gets/Sets the icon for the menu item
        /// </summary>
        public IMenuIcon Icon
        {
            get { return new MenuIcon(_item.Image); }
            set
            {
                if (value == null || value.Image == null) return;
                _item.Image = value.Image;
                _item.ImageScaling = ToolStripItemImageScaling.SizeToFit;
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
            set
            {
                _item.Checked = value;
                _item.ImageScaling = Icon.Image == null
                                         ? ToolStripItemImageScaling.None
                                         : ToolStripItemImageScaling.SizeToFit;
            }
        }

        public bool Enabled
        {
            get { return _item.Enabled; }
            set { _item.Enabled = value; }
        }

        public override bool HasKey
        {
            get
            {
                var meta = _item.Tag as MenuItemMetadata;
                if (meta != null)
                {
                    return !string.IsNullOrWhiteSpace(meta.Key);
                }

                return false;
            }
        }

        public bool Visible
        {
            get { return _item.Visible; }
            set { _item.Visible = value; }
        }

        /// <summary>
        /// Gets the internal object.
        /// </summary>
        public object GetInternalObject()
        {
            return _item;
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

        internal protected virtual void DetachItemListeners()
        {
            EventHelper.RemoveEventHandler(_item, "Click");      // so it can be collected by GC
            EventHelper.RemoveEventHandler(this, "ItemChanged");
        }

        public event EventHandler<MenuItemEventArgs> ItemClicked
        {
            add
            {
                _item.Click += (s, e) =>
                    {
                        if (!Metadata.DropDown)
                        {
                            value.Invoke(this, new MenuItemEventArgs(Key));
                        }
                    };
            }
            remove
            {
                // will be unsubscribed in DetachItemListeners
            }
        }

        /// <summary>
        /// Gets a value indicating whether the item should be skipped during processing (e.g. separator).
        /// </summary>
        public bool Skip
        {
            get { return false; }
        }

        /// <summary>
        /// Gets or sets the shortcut keys.
        /// </summary>
        public Keys ShortcutKeys 
        {
            get { return _item.ShortcutKeys; }
            set  { _item.ShortcutKeys = value; } 
        }
    }
}






