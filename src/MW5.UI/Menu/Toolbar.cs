using System;
using System.Linq;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu
{
    internal class Toolbar: IToolbar
    {
        private MainFrameBarManager _manager;
        private readonly CommandBar _commandBar;
        private readonly Bar _bar;
        private readonly IMenuIndex _menuIndex;

        internal Toolbar(MainFrameBarManager manager, Bar bar, IMenuIndex menuIndex)
        {
            _manager = manager;
            _bar = bar;
            _menuIndex = menuIndex;
            _commandBar = _manager.GetBarControl(_bar);

            if (manager == null)
            {
                throw new ArgumentNullException("manager");
            }
            if (menuIndex == null)
            {
                throw new ArgumentNullException("menuIndex");
            }
            if (bar == null || _commandBar == null)
            {
                throw new NullReferenceException("Internal toolbar reference is null.");
            }
        }

        public string Name
        {
            get { return _bar.BarName; }
            set { _bar.BarName = value; }
        }

        public IMenuItemCollection Items
        {
            get { return new MenuItemCollection(_bar.Items, _menuIndex); }
        }

        public bool Visible
        {
            get { return _commandBar.Visible; }
            set { _commandBar.Visible = value; }
        }

        public object Tag
        {
            get { return Metadata.Tag; }
            set { Metadata.Tag = value; }
        }

        public string Key
        {
            get { return Metadata.Key; }
        }

        public ToolbarDockState DockState
        {
            get { return (ToolbarDockState) _manager.GetBarControl(_bar).DockState; }
            set { _manager.GetBarControl(_bar).DockState = (CommandBarDockState)value; }
        }

        public void Update()
        {
            UpdateSeparators();
        }

        private void UpdateSeparators()
        {
            _bar.SeparatorIndices.Clear();
            for (int i = 0; i < Items.Count(); i++)
            {
                var item = Items[i];
                if (item.BeginGroup)
                {
                    _bar.SeparatorIndices.Add(i);
                }
            }

            // do the same for dropdowns
            foreach (var menu in Items.OfType<IDropDownMenuItem>())
            {
                menu.Update();
            }
        }

        private MenuItemMetadata Metadata
        {
            get
            {
                var metadata = _commandBar.Tag as MenuItemMetadata;
                if (metadata == null)
                {
                    throw new ApplicationException("Tag must have an instance of MenuItemMetadata class.");
                }
                return metadata;
            }
        }

        public PluginIdentity PluginIdentity
        {
            get { return Metadata.PluginIdentity; }
        }
    }
}
