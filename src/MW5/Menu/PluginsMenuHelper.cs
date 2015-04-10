using System;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Menu
{
    internal static class PluginsMenuHelper
    {
        private static IPluginManager _manager;
        private static IAppContext _context;

        internal static void Init(IAppContext context, IPluginManager pluginManager)
        {
            if (context == null || pluginManager == null)
            {
                throw new NullReferenceException("Failed to initialize plugins.");
            }
            _context = context;
            _manager = pluginManager;

            var menuItem = context.Menu.PluginsMenu;
            menuItem.DropDownOpening += MenuDropDownOpening;
            menuItem.DropDownClosed += MenuDropDownClosed;

            AddDummyItem();
        }

        private static void MenuDropDownClosed(object sender, EventArgs e)
        {
            AddDummyItem();
        }

        private static void AddDummyItem()
        {
            // otherwise it won't open, as plugin entries are added dynamically on opening
            var item = _context.Menu.PluginsMenu;
            item.SubItems.AddButton("__empty__", PluginIdentity.Default);
        }

        private static void MenuDropDownOpening(object sender, EventArgs e)
        {
            var menuItem = _context.Menu.PluginsMenu;
            menuItem.SubItems.Clear();

            foreach (var p in _manager.CustomPlugins)
            {
                var item = menuItem.SubItems.AddButton(p.Identity.Name, PluginIdentity.Default);
                item.Tag = p.Identity;
                item.ItemClicked += item_Click;
                item.Checked = _manager.PluginActive(p.Identity);
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
                    _context.View.Update();
                }
            }
        }
    }
}
