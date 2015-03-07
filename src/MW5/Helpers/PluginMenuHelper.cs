using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.UI;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.Helpers
{
    public static class PluginMenuHelper
    {
        private static PluginManager _manager;
        private static IAppContext _context;

        internal static void InitPlugins(IAppContext context, PluginManager pluginManager)
        {
            if (context == null || pluginManager == null)
            {
                throw new NullReferenceException("Failed to initialize plugins.");
            }
            _context = context;
            _manager = pluginManager;

            var menuItem = context.Menu.Plugins;

            foreach (var p in _manager.AllPlugins)
            {
                var item = menuItem.SubItems.AddButton(p.Identity.Name, PluginIdentity.Default);
                item.Tag = p.Identity;                    
                item.AttachClickEventHandler(item_Click);
            }

            menuItem.DropDownOpening += MenuDropDownOpening;
        }

        private static void MenuDropDownOpening(object sender, EventArgs e)
        {
            var menu = _context.Menu.Plugins;

            foreach (var item in menu.SubItems)
            {
                var identity = item.Tag as PluginIdentity;
                if (identity != null)
                {
                    item.Checked = _manager.PluginActive(identity);
                }
            }
        }

        private static void item_Click(object sender, MenuItemEventArgs e)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                var identity = item.Tag as PluginIdentity;
                if (identity != null)
                {
                    if (item.Checked)
                    {
                        _manager.UnloadPlugin(identity, _context);
                    }
                    else
                    {
                        _manager.LoadPlugin(identity, _context);
                    }
                    item.Checked = !item.Checked;
                }
            }
        }
    }
}
