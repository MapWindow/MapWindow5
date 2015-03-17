
using MW5.Plugins.Concrete;
using MW5.Plugins.IdentifierTestPlugin.Properties;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.IdentifierTestPlugin.Menu
{
    public class MenuGenerator
    {
        private readonly MenuCommands _commands;

        public MenuGenerator(IAppContext context, IdentifierTestPlugin plugin)
        {
            _commands = new MenuCommands(plugin.Identity);

            InitToolbar(context, plugin.Identity);
        }

        private void InitToolbar(IAppContext context, PluginIdentity identity)
        {
            var bar = context.Toolbars.Add("Identifier", identity);
            bar.DockState = ToolbarDockState.Top;

            var items = bar.Items;

            _commands.AddToMenu(items, MenuKeys.IdentifyTool);
        }

    }
}
