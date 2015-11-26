using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Printing.Menu
{
    internal class MenuUpdater
    {
        private readonly IAppContext _context;
        private readonly PrintingPlugin _plugin;

        public MenuUpdater(IAppContext context, PrintingPlugin plugin)
        {
            _context = context;
            _plugin = plugin;

            _plugin.ViewUpdating += OnViewUpdating;
        }

        void OnViewUpdating(object sender, EventArgs e)
        {
            bool mapIsEmpty = _context.Map.IsEmpty;
            _context.Toolbars.FindItem(MenuKeys.Print, _plugin.Identity).Enabled = !mapIsEmpty;
            _context.Toolbars.FindItem(MenuKeys.SelectPrintArea, _plugin.Identity).Enabled = !mapIsEmpty;
            _context.Menu.FindItem(MenuKeys.Print, _plugin.Identity).Enabled = !mapIsEmpty;
        }
    }
}
