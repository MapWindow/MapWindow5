using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu
{
    internal class StatusBarItem: MenuItemBase, IMenuItem
    {
        private readonly ToolStripItem _item;

        public StatusBarItem(ToolStripItem item)
        {
            if (item == null) throw new ArgumentNullException("item");
            _item = item;
        }

        public string Text
        {
            get { return _item.Text; }
            set { _item.Text = value; }
        }

        public IMenuIcon Icon
        {
            get { return new MenuIcon(_item.Image); }
            set { _item.Image = value.Image; }
        }

        public string Category
        {
            get { return Metadata.Category; }
            set { Metadata.Category = value; }
        }

        public bool Checked
        {
            get
            {
                var item = _item as ToolStripMenuItem;
                if (item != null)
                {
                    return item.Checked;
                }
                return false;
            }
            set
            {
                var item = _item as ToolStripMenuItem;
                if (item != null)
                {
                    item.Checked = value;
                }
            }
        }

        public string Tooltip
        {
            get { return ""; }
            set { ; }
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

        internal protected virtual void DetachItemListeners()
        {
            EventHelper.RemoveEventHandler(_item, "Click");      // so it can be collected by GC
        }

        public object GetInternalObject()
        {
            return _item;
        }

        public event EventHandler ItemSelected;

        public event EventHandler<PropertyChangedEventArgs> ItemChanged;
        
        public event EventHandler<MenuItemEventArgs> ItemClicked
        {
            add
            {
                _item.Click += (sender, args) => value.Invoke(this, new MenuItemEventArgs(Key));
            }
            remove
            {
                
            }
        }
    }
}
