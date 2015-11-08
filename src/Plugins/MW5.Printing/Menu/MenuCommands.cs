// -------------------------------------------------------------------------------------------
// <copyright file="MenuCommands.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using MW5.Plugins.Concrete;
using MW5.Plugins.Printing.Properties;

namespace MW5.Plugins.Printing.Menu
{
    public class MenuCommands : CommandProviderBase
    {
        public MenuCommands(PluginIdentity identity)
            : base(identity)
        {
        }

        public override IEnumerable<MenuCommand> GetCommands()
        {
            return new List<MenuCommand>
                       {
                           new MenuCommand("Print", MenuKeys.Print, Resources.img_printer24),
                           new MenuCommand("Select Print Area", MenuKeys.SelectPrintArea, Resources.img_select_print_area24)
                       };
        }
    }
}