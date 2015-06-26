using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.DebugWindow.Properties;
using MW5.Plugins.DebugWindow.Services;
using MW5.Plugins.Interfaces;
using MW5.Shared;

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

        private string GetKeyForLogLevel(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Warn:
                    return MenuKeys.StatusWarningCount;
                case LogLevel.Error:
                    return MenuKeys.StatusErrorCount;
            }

            return string.Empty;
        }

        private void plugin_ViewUpdating(object sender, EventArgs e)
        {
            bool found = false;

            var list = new[] { LogLevel.Warn, LogLevel.Error };
            foreach (var level in list)
            {
                string key = GetKeyForLogLevel(level);
                
                if (string.IsNullOrWhiteSpace(key))
                {
                    continue;    
                }

                var item = _context.StatusBar.FindItem(key, _plugin.Identity);
                
                int count = Logger.Current.MessageCount(level, true);
                item.Visible = count > 0;
                item.Text = count.ToString(CultureInfo.InvariantCulture);
                item.Description = level.EnumToString() + ": " + item.Text;

                if (item.Visible)
                {
                    found = true;
                }
            }

            // it set ok, but isn't displayed on the statusbar; perhaps style related problems
            var item3 = _context.StatusBar.FindItem(MenuKeys.StatusShowDebug, _plugin.Identity);
            item3.Checked = _context.DockPanels.Find(DockPanelService.DockPanelKey).Visible;
            item3.Visible = !found;
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
                case MenuKeys.StatusErrorCount:
                case MenuKeys.StatusWarningCount:
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

            bar.Items.AddButton("Log", MenuKeys.StatusShowDebug, Resources.img_note16, _plugin.Identity);
            bar.Items.AddButton(string.Empty, MenuKeys.StatusWarningCount, Resources.img_warning16, _plugin.Identity);
            bar.Items.AddButton(string.Empty, MenuKeys.StatusErrorCount, Resources.img_error16, _plugin.Identity);
        }
    }
}
