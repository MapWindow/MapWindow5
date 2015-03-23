
using System;
using MW5.Api;
using MW5.Plugins.Concrete;
using MW5.Plugins.IdentifierTestPlugin.Properties;
using MW5.Plugins.Interfaces;
using MW5.UI.Menu;

namespace MW5.Plugins.IdentifierTestPlugin.Menu
{
    public class MenuService: MenuServiceBase
    {
        private readonly IdentifierTestPlugin _plugin;
        private readonly MenuCommands _commands;

        public MenuService(IAppContext context, IdentifierTestPlugin plugin):
            base(context, plugin.Identity)
        {
            if (plugin == null) throw new ArgumentNullException("plugin");
            _plugin = plugin;

            _commands = new MenuCommands(plugin.Identity);

            InitToolbar(context, plugin.Identity);
            
            plugin.ItemClicked += plugin_ItemClicked;
            plugin.ViewUpdating += ViewUpdating;
        }

        private void ViewUpdating(object sender, EventArgs e)
        {
            var item = _context.Toolbars.FindItem(MenuKeys.IdentifyTool, _plugin.Identity);
            if (item != null)
            {
                item.Checked = _context.Map.MapCursor == MapCursor.Identify;
            }
        }

        private void InitToolbar(IAppContext context, PluginIdentity identity)
        {
            var bar = context.Toolbars.Add("Identifier", identity);
            bar.DockState = ToolbarDockState.Top;

            var items = bar.Items;

            _commands.AddToMenu(items, MenuKeys.IdentifyTool);
        }

        void plugin_ItemClicked(object sender, MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case MenuKeys.IdentifyTool:
                    _context.Map.MapCursor = MapCursor.Identify;
                    break;
            }
        }
    }
}
