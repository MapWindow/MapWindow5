using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Helpers;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.UI.Menu;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.Menu
{
    internal static class ViewMenuHelper
    {
        private static IAppContext _context;
        private static MainFrameBarManager _menuManager;
        private static DockingManager _dockingManager;

        public static void Init(IAppContext context, object menuManager, object dockingManager)
        {
            _context = context;
            _menuManager = menuManager as MainFrameBarManager;
            _dockingManager = dockingManager as DockingManager;

            if (_context == null) throw new ArgumentNullException("context");
            if (_menuManager == null) throw new ArgumentNullException("menuManager");
            if (_dockingManager == null) throw new ArgumentNullException("dockingManager");

            InitToolbars();

            InitWindows();

            InitSkins();
        }
        
        #region Skins

        private static void InitSkins()
        {
            var item = _context.Menu.FindItem(MenuKeys.ViewSkins, PluginIdentity.Default) as IDropDownMenuItem;
            if (item != null)
            {
                item.SubItems.AddButton("Default", PluginIdentity.Default);
            }
        }

        #endregion

        #region Windows

        private static void InitWindows()
        {
            var item = _context.Menu.FindItem(MenuKeys.ViewWindows, PluginIdentity.Default) as IDropDownMenuItem;
            if (item != null)
            {
                item.SubItems.AddButton("-", PluginIdentity.Default);   // dummy to make it open and start dynamic population
                item.DropDownOpening += WindowsDropDownOpening;
            }
        }

        private static void WindowsDropDownOpening(object sender, EventArgs e)
        {
            var menu = sender as IDropDownMenuItem;
            if (menu != null)
            {
                menu.SubItems.Clear(); // old listeners will be removed here

                foreach (var panel in _context.DockPanels)
                {
                    var btn = menu.SubItems.AddButton(panel.Caption, PluginIdentity.Default);
                    btn.AttachClickEventHandler(DockWindowsVisibilityClicked);
                    btn.Checked = panel.Visible;
                    btn.Tag = panel;
                }
            }
        }

        private static void DockWindowsVisibilityClicked(object sender, MenuItemEventArgs args)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                item.Checked = !item.Checked;
                var panel = item.Tag as IDockPanel;
                if (panel != null)
                {
                    panel.Visible = item.Checked;
                }
            }
        }

        #endregion

        #region Toolbars

        private static void InitToolbars()
        {
            var item = _context.Menu.FindItem(MenuKeys.ViewToolbars, PluginIdentity.Default) as IDropDownMenuItem;
            if (item != null)
            {
                item.SubItems.AddButton("-", PluginIdentity.Default);   // dummy to make it open and start dynamic population
                item.DropDownOpening += ToolbarsDropDownOpening;
            }
        }

        static void ToolbarsDropDownOpening(object sender, EventArgs e)
        {
            var menu = sender as IDropDownMenuItem;
            if (menu != null)
            {
                menu.SubItems.Clear();      // old listeners will be removed here
            
                foreach (Bar bar in _menuManager.Bars)
                {
                    if (CommandBarHelper.FlagIsSet(bar.BarStyle, BarStyle.IsMainMenu))
                    {
                        continue;
                    }

                    var cbr = _menuManager.GetBarControl(bar);

                    var btn = menu.SubItems.AddButton(bar.BarName, PluginIdentity.Default);
                    btn.AttachClickEventHandler(ToolbarVisibilityClicked);
                    btn.Checked = cbr.Visible;
                    btn.Tag = bar.BarName;
                }
            }
        }

        private static void ToolbarVisibilityClicked(object sender, MenuItemEventArgs args)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                item.Checked = !item.Checked;

                var barName = item.Tag as string;
                var bar = _menuManager.GetBarFromBarName(barName);
                var cbr = _menuManager.GetBarControl(bar);
                cbr.Visible = item.Checked;
            }
        }

        #endregion
    }
}
