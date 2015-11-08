// -------------------------------------------------------------------------------------------
// <copyright file="MenuGenerator.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Printing.Menu
{
    internal class MenuGenerator
    {
        private readonly MenuCommands _commands;
        private readonly IAppContext _context;

        public MenuGenerator(IAppContext context, PrintingPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");

            _commands = new MenuCommands(plugin.Identity);
            _context = context;

            InitToolbar(context);
        }

        private void InitToolbar(IAppContext context)
        {
            var items = context.Toolbars.FileToolbar.Items;

            items.AddButton(_commands[MenuKeys.Print]).BeginGroup = true;
            items.AddButton(_commands[MenuKeys.SelectPrintArea]);

            context.Toolbars.FileToolbar.Update();
        }
    }
}