
using System;
using MW5.Api;
using MW5.Plugins.Concrete;
using MW5.Plugins.IdentifierTestPlugin.Properties;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.IdentifierTestPlugin.Menu
{
    // it's also a listener and updated in this case (perhaps some other name is needed for such case)
    public class MenuGenerator
    {
        private readonly IAppContext _context;
        private readonly MenuCommands _commands;

        public MenuGenerator(IAppContext context, IdentifierTestPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            _commands = new MenuCommands(plugin.Identity);

            InitToolbar(context, plugin.Identity);
            
            plugin.ItemClicked += plugin_ItemClicked;
            plugin.ViewUpdating += ViewUpdating;
        }

        private void ViewUpdating(object sender, EventArgs e)
        {
            var item = _context.Toolbars.FindItem(MenuKeys.IdentifyTool);
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
