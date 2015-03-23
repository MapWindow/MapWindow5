using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Forms.Utilities;
using MW5.Plugins.Symbology.Helpers;

namespace MW5.Plugins.Symbology.Menu
{
    public class MenuService
    {
        private readonly IAppContext _context;
        private readonly SymbologyPlugin _plugin;
        private readonly MenuCommands _commands;

        public MenuService(IAppContext context, SymbologyPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            
            _context = context;
            _plugin = plugin;
            _commands = new MenuCommands(plugin.Identity);

            InitToolbar();

            _plugin.ItemClicked += PluginItemClicked;
            _plugin.ViewUpdating += PluginViewUpdating;
        }

        private void PluginViewUpdating(object sender, EventArgs e)
        {
            var fs = _context.Map.SelectedFeatureSet;
            _context.Toolbars.FindItem(MenuKeys.QueryBuilder).Enabled = fs != null;
            _context.Toolbars.FindItem(MenuKeys.Categories).Enabled = fs != null;
        }

        private void PluginItemClicked(object sender, Concrete.MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case MenuKeys.QueryBuilder:
                    FormHelper.ShowQueryBuilder(_context);
                    break;
                case MenuKeys.Categories:
                    FormHelper.ShowCategories(_context);
                    break;
            }
        }

        private void InitToolbar()
        {
            var items = _context.Toolbars.MapToolbar.Items;
            _commands.AddToMenu(items, MenuKeys.QueryBuilder, true);
            _context.Toolbars.MapToolbar.Update();

            items = _context.Toolbars.FileToolbar.Items;
            _commands.AddToMenu(items, MenuKeys.Categories);
            _context.Toolbars.FileToolbar.Update();
        }
    }
}
