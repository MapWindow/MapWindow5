using System;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.UI;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.Helpers
{
    public static class PluginHelper
    {
        private static PluginManager _manager;
        private static IAppContext _context;

        internal static void InitPlugins(IAppContext context, PluginManager pluginManager)
        {
            if (context == null || pluginManager == null)
            {
                throw new ArgumentNullException("Failed to initialize plugins.");
            }
            _context = context;
            _manager = pluginManager;

            _manager.AssemblePlugins();
            _manager.Initialize(context);

            var menuItem = context.Menu.Plugins;

            foreach (var p in _manager.Plugins)
            {
                var item = menuItem.SubItems.AddButton(p.Name);
                item.Tag = p;
                item.Click += item_Click;
            }

            menuItem.DropDownOpening += MenuDropDownOpening;
        }

        private static void MenuDropDownOpening(object sender, EventArgs e)
        {
            var menu = _context.Menu.Plugins;

            foreach (var item in menu.SubItems)
            {
                var plugin = item.Tag as Lazy<IPlugin, IPluginMetadata>;
                if (plugin != null)
                {
                    item.Checked = _manager.PluginActive(plugin.Metadata.Name);
                }
            }
        }

        private static void item_Click(object sender, EventArgs e)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                var plugin = item.Tag as Lazy<IPlugin, IPluginMetadata>;
                if (plugin != null)
                {
                    if (item.Checked)
                    {
                        _manager.UnloadPlugin(plugin.Metadata.Name);
                    }
                    else
                    {
                        _manager.LoadPlugin(plugin.Metadata.Name, _context);
                    }
                    item.Checked = !item.Checked;
                }
            }
        }
    }
}
