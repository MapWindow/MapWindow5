// -------------------------------------------------------------------------------------------
// <copyright file="MenuGenerator.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Printing.Menu
{
    internal class MenuGenerator
    {
        private readonly MenuCommands _commands;
        private readonly IAppContext _context;
        private readonly PrintingPlugin _plugin;

        public MenuGenerator(IAppContext context, PrintingPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");

            _commands = new MenuCommands(plugin.Identity);
            _context = context;
            _plugin = plugin;

            InitMenu();

            InitToolbar();
        }

        private void InitMenu()
        {
            var items = _context.Menu.FileMenu.SubItems;
            items.InsertBefore = _context.Menu.FindItem(Plugins.Menu.MenuKeys.Quit, PluginIdentity.Default);

            items.AddButton(_commands[MenuKeys.Print]).BeginGroup = true;

            _context.Menu.FileMenu.Update();
        }

        private void InitToolbar()
        {
            var items = _context.Toolbars.FileToolbar.Items;

            items.AddButton(_commands[MenuKeys.Print]).BeginGroup = true;
            items.AddButton(_commands[MenuKeys.SelectPrintArea]);

            _context.Toolbars.FileToolbar.Update();
        }
    }
}