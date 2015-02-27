using System;
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
        private static PluginManager _manager = new PluginManager();
        
        internal static void InitPlugins(IAppContext context)
        {
            _manager.AssemblePlugins();
            _manager.Initialize(context);

            var menuItem = context.Menu.Plugins;

            foreach (var p in _manager.Plugins)
            {
                var item = menuItem.SubItems.AddButton(p.Value.Name);
                item.Tag = p;
                item.Click += item_Click;
            }

            menuItem.DropDownOpening += MenuDropDownOpening;
        }

        private static void MenuDropDownOpening(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            if (menu != null)
            {
                foreach (ToolStripMenuItem item in menu.DropDownItems)
                {
                    var plugin = item.Tag as Lazy<IPlugin, IPluginMetadata>;
                    if (plugin != null)
                    {
                        item.Checked = _manager.PluginActive(plugin.Metadata.Name);
                    }
                }
            }
        }

        private static void item_Click(object sender, EventArgs e)
        {
            // TODO: implement

            //var item = sender as ToolStripMenuItem;
            //if (item != null)
            //{
            //    var plugin = item.Tag as Lazy<IPlugin, IPluginMetadata>;
            //    if (plugin != null)
            //    {
            //        if (item.Checked)
            //        {
            //            _manager.UnloadPlugin(plugin.Metadata.Name);
            //        }
            //        else
            //        {
            //            _manager.LoadPlugin(plugin.Metadata.Name, AppContext.Instance);
            //        }
            //        item.Checked = !item.Checked;
            //    }
            //}
        }
    }
}
