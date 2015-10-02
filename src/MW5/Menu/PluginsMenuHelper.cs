using System;
using System.Collections.Generic;
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
        }

        private static void ClearPlugins()
        {
            var list = new List<IMenuItem>();

            var menuItem = _context.Menu.PluginsMenu;

            foreach (var item in menuItem.SubItems)
            {
                if (!item.Skip && !item.HasKey)
                {
                    list.Add(item);
                }
            }

            foreach (var item in list)
            {
                menuItem.SubItems.Remove(item);
            }
        }

        private static void MenuDropDownOpening(object sender, EventArgs e)
        {
            ClearPlugins();

            var menuItem = _context.Menu.PluginsMenu;
            
            var configureItem = _context.Menu.FindItem(MenuKeys.PluginsConfigure, PluginIdentity.Default);
            menuItem.SubItems.InsertBefore = configureItem;

            foreach (var p in _manager.CustomPlugins)
            {
                var item = menuItem.SubItems.AddButton(p.Identity.Name, PluginIdentity.Default);
                item.Tag = p.Identity;
                item.ItemClicked += OnItemClick;
                item.Checked = _manager.PluginActive(p.Identity);
            }

            menuItem.Update();
        }

        private static void OnItemClick(object sender, MenuItemEventArgs e)
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
