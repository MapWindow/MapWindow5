using System;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Identifier.Menu
{
    public class MenuGenerator
    {
        private readonly IAppContext _context;
        private readonly MenuCommands _commands;

        public MenuGenerator(IAppContext context, IdentifierPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");

            _commands = new MenuCommands(plugin.Identity);
            _context = context;

            InitToolbar(context);
        }

        private void InitToolbar(IAppContext context)
        {
            var items = context.Toolbars.MapToolbar.Items;

            items.AddButton(_commands[MenuKeys.IdentifyTool]);
        }
    }
}
