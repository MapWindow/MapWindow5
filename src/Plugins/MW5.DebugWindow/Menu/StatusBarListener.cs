using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.DebugWindow.Properties;
using MW5.Plugins.DebugWindow.Services;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.DebugWindow.Menu
{
    public class StatusBarListener
    {
        private readonly IAppContext _context;
        private readonly DebugWindowPlugin _plugin;

        public StatusBarListener(IAppContext context, DebugWindowPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            _context = context;
            _plugin = plugin;

            InitStatusBar();

            plugin.ItemClicked += plugin_ItemClicked;
            plugin.ViewUpdating += plugin_ViewUpdating;
        }

        private void plugin_ViewUpdating(object sender, EventArgs e)
        {
            // it set ok, but isn't displayed on the statusbar; perhaps style related problems
            var item = _context.StatusBar.FindItem(MenuKeys.StatusShowDebug, _plugin.Identity);
            item.Checked = _context.DockPanels.Find(DockPanelService.DockPanelKey).Visible;
        }

        private void plugin_ItemClicked(object sender, Events.MenuItemEventArgs e)
        {
            if (!e.StatusBar)
            {
                return;
            }

            switch (e.ItemKey)
            {
                case MenuKeys.StatusShowDebug:
                    var panel = _context.DockPanels.Find(DockPanelService.DockPanelKey);
                    panel.Visible = !panel.Visible;
                    _context.View.Update();
                    break;
            }
        }

        private void InitStatusBar()
        {
            var bar = _context.StatusBar;
            bar.AlignNewItemsRight = true;

            bar.Items.AddButton("Debug", MenuKeys.StatusShowDebug, Resources.img_bug_24, _plugin.Identity);
        }
    }
}
