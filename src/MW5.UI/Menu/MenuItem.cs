using System;
using System.Drawing;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu
{
    internal class MenuItem: IMenuItem
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
        }
        
        public string Text
        {
            get { return _item.Text; }
            set { _item.Text = value; }
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

        public string Tooltip
        {
            get { return _item.Tooltip; }
            set { _item.Tooltip = value; }
        }

        public string Description
        {
            get { return Metadata.Description; }
            set { Metadata.Description = value; }
        }

        public bool Enabled
        {
            get { return _item.Enabled; }
            set { _item.Enabled = value; }
        }

        public string Key
        {
            get { return Metadata.Key; }
        }

        public bool Visible
        {
            get { return _item.Visible; }
            set { _item.Visible = value; }
        }

        public object Tag
        {
            get { return Metadata.Tag; }
            set { Metadata.Tag = value; }
        }

        public void AttachClickEventHandler(EventHandler<MenuItemEventArgs> handler)
        {
            _item.Click += (sender, args) => handler.Invoke(this, new MenuItemEventArgs(this.Key));
        }

        internal protected virtual void DetachItemListeners()
        {
            EventHelper.RemoveEventHandler(_item, "Click");      // so it can be collected by GC
        }

        public object GetInternalObject()
        {
            return _item;
        }

        public PluginIdentity PluginIdentity
        {
            get
            {
                return Metadata.PluginIdentity;
            }
        }

        public bool BeginGroup
        {
            get { return Metadata.BeginGroup; }
            set { Metadata.BeginGroup = value; }
        }

        private MenuItemMetadata Metadata
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
    }
}
