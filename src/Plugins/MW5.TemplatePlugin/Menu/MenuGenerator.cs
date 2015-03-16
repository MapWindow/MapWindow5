using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.TemplatePlugin.Menu
{
    public class MenuGenerator
    {
        private readonly MenuCommands _commands;

        public MenuGenerator(IAppContext context, TemplatePlugin plugin)
        {
            _commands = new MenuCommands(plugin.Identity);

            InitToolbar(context, plugin.Identity);
        }

        private void InitToolbar(IAppContext context, PluginIdentity identity)
        {
            var bar = context.Toolbars.Add("Template Plugin toolbar", identity);
            bar.DockState = ToolbarDockState.Top;

            var items = bar.Items;

            _commands.AddToMenu(items, MenuKeys.ShowPluginDialog);
        }
    }
}
