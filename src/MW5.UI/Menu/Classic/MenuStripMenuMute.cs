using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu.Classic
{
    /// <summary>
    /// Represents MenuStrip implementation of IMenuBase interface.
    /// </summary>
    internal class MenuStripMenuMute: MenuBase
    {
        private readonly MainFrameBarManager _menuManager;
        private MenuStrip _menuStrip;

        internal MenuStripMenuMute(object menuManager, MenuIndex menuIndex)
        {
            _menuIndex = menuIndex;
            _menuManager = menuManager as MainFrameBarManager;

            if (menuIndex == null) throw new ArgumentNullException("menuIndex");
            if (_menuManager == null) throw new ApplicationException("Invalid type of menu manager");

            CreateMenuBar();
        }

        internal void CreateMenuBar()
        {
            _menuStrip = new MenuStrip
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                ImageScalingSize = new Size(20, 20),
                RenderMode = ToolStripRenderMode.Professional,
            };
            
            var bar = new CommandBar()
            {
                AlwaysLeadingEdge = true,
                BackColor = Color.White,
                DisableFloating = true,
                DockState = CommandBarDockState.Top,
                HideGripper = true,
                OccupyFullRow = true,
                Tag = new MenuItemMetadata(PluginIdentity.Default, MainMenuName),
                Name = "mainCommandBar"
            };
            
            _menuManager.DetachedCommandBars.Add(bar);
            bar.Controls.Add(_menuStrip);
        }

        public override string Name
        {
            get { return "Main menu"; }
            set { throw new NotSupportedException("Set accessor isn't supported: Menu.Name"); }
        }

        public override IMenuItemCollection Items
        {
            get { return new MenuStripItemCollection(_menuStrip.Items, _menuIndex); }
        }

        public override bool Visible
        {
            get { return _menuStrip.Visible; }
            set { _menuStrip.Visible = value; }
        }

        public override object Tag
        {
            get { return _menuStrip.Tag; }
            set { _menuStrip.Tag = value; }
        }

        // don't do anything
        public override bool Enabled { get; set; }

        public override void Update()
        {
            base.Update();

            foreach (var item in Items)
            {
                var toolItem = item.GetInternalObject() as ToolStripItem;
                if (toolItem != null)
                {
                    toolItem.Padding = new Padding(8, 2, 8, 2);
                }
            }
        }
    }
}
