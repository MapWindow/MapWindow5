using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.TableEditor.Menu
{
    public class MenuGenerator
    {
        private readonly IAppContext _context;
        private MenuCommands _commands;

        public MenuGenerator(IAppContext context, TableEditorPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
            _commands = new MenuCommands(plugin);

            InitToolbars();
        }

        private void InitToolbars()
        {
            var items = _context.Toolbars.FileToolbar.Items;
            _commands.AddToMenu(items, MenuKeys.ShowTable);
        }
    }
}
