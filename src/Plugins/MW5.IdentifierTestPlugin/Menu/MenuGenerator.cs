using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.IdentifierTestPlugin.Menu
{
    public class MenuGenerator
    {
        private readonly IAppContext _context;
        private readonly MenuCommands _commands;

        public MenuGenerator(IAppContext context, IdentifierTestPlugin plugin)
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
