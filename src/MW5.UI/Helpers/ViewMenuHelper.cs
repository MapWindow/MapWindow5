using System;
using System.Linq;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Menu;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Helpers
{
    internal static class ViewMenuHelper
    {
        private static MainFrameBarManager _menuManager;
        private static DockingManager _dockingManager;
        private static IMenuBase _menu;
        private static IDockPanelCollection _dockPanels;
        private static PluginIdentity _pluginIdentity;

        public static void Init(object menuManager, object dockingManager, 
                                IMenuBase menuBase, IDockPanelCollection dockPanels, PluginIdentity pluginIdentity)
        {
            _menuManager = menuManager as MainFrameBarManager;
            _dockingManager = dockingManager as DockingManager;
            _menu = menuBase;
            _dockPanels = dockPanels;
            _pluginIdentity = pluginIdentity;

            if (_menuManager == null) throw new ArgumentNullException("menuManager");
            if (_dockingManager == null) throw new ArgumentNullException("dockingManager");
            if (_menu == null) throw new ArgumentNullException("menuBase");
            if (_dockPanels == null) throw new ArgumentNullException("menuBase");
            if (pluginIdentity == null) throw new ArgumentNullException("pluginIdentity");

            InitToolbars();

            InitWindows();

            InitSkins();
        }
        
        #region Skins

        private static void InitSkins()
        {
            var item = _menu.FindItem(MenuKeys.ViewSkins, PluginIdentity.Default) as IDropDownMenuItem;
            if (item != null)
            {
                item.SubItems.AddButton("Default", PluginIdentity.Default);
            }
        }

        #endregion

        #region Windows

        private static void InitWindows()
        {
            var item = _menu.FindItem(MenuKeys.ViewWindows, _pluginIdentity) as IDropDownMenuItem;
            if (item != null)
            {
                item.SubItems.AddButton("-", PluginIdentity.Default);
                    // dummy to make it open and start dynamic population
                item.DropDownOpening += WindowsDropDownOpening;
            }
        }

        private static void WindowsDropDownOpening(object sender, EventArgs e)
        {
            var menu = sender as IDropDownMenuItem;
            if (menu == null) return;

            menu.SubItems.Clear();
            
            var items = menu.SubItems;

            foreach (var panel in _dockPanels.OrderBy(p => p.Caption))
            {
                var btn = items.AddButton(panel.Caption, PluginIdentity.Default);
                btn.ItemClicked += DockWindowsVisibilityClicked;
                btn.Icon = new MenuIcon(panel.GetIcon(), true);
                btn.Checked = panel.Visible;
                btn.Tag = panel;
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
            var item = _menu.FindItem(MenuKeys.ViewToolbars, _pluginIdentity) as IDropDownMenuItem;
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
                    btn.ItemClicked += ToolbarVisibilityClicked;
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
