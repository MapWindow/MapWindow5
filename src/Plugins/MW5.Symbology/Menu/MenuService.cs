using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Forms.Utilities;

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
        }

        private void PluginItemClicked(object sender, Concrete.MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case MenuKeys.QueryBuilder:
                    ShowQueryBuilder();
                    break;
            }
        }

        private void ShowQueryBuilder()
        {
            var fs = _context.Map.SelectedFeatureSet;
            if (fs == null)
            {
                return;
            }

            using (var form = new QueryBuilderForm(_context.Map.Layers.SelectedLayer, string.Empty, false))
            {
                if (_context.View.ShowDialog(form) == DialogResult.OK)
                {
                    
                }
            }
        }

        private void InitToolbar()
        {
            var items = _context.Toolbars.MapToolbar.Items;
            _commands.AddToMenu(items, MenuKeys.QueryBuilder, true);
        }
    }
}
