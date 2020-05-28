using System;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Services;
using MW5.UI.Menu;

namespace MW5.Plugins.Symbology.Menu
{
    public class MenuGenerator: MenuServiceBase
    {
        private readonly MenuCommands _commands;

        public MenuGenerator(IAppContext context, SymbologyPlugin plugin):
            base(context, plugin.Identity)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");

            _commands = new MenuCommands(plugin.Identity);

            InitToolbar();

            InitMenu();
        }

        private void InitMenu()
        {
            var menu = _context.Menu.LayerMenu;
            var items = menu.SubItems;

            items.InsertBefore = null;

            items.AddButton(_commands[MenuKeys.Labels], true);
            items.AddButton(_commands[MenuKeys.Charts]);
            items.AddButton(_commands[MenuKeys.Categories]);
            items.AddButton(_commands[MenuKeys.QueryBuilder]);
            items.AddButton(_commands[MenuKeys.LayerProperties], true);

            menu.Update();
        }
        
        private void InitToolbar()
        {
            // file toolbar
            var items = _context.Toolbars.FileToolbar.Items;

            items.AddButton(_commands[MenuKeys.QueryBuilder], true);
            items.AddButton(_commands[MenuKeys.Categories]);
            _context.Toolbars.FileToolbar.Update();

            // map toolbar
            items = _context.Toolbars.MapToolbar.Items;
            items.AddButton(_commands[MenuKeys.LabelMover]);
            items.AddButton(_commands[MenuKeys.SymbolRotator]);
            _context.Toolbars.MapToolbar.Update();
        }
    }
}
