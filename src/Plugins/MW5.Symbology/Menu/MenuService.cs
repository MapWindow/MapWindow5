using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Services;
using MW5.UI.Menu;

namespace MW5.Plugins.Symbology.Menu
{
    public class MenuService: MenuServiceBase
    {
        private readonly SymbologyPlugin _plugin;
        private readonly MenuCommands _commands;

        public MenuService(IAppContext context, SymbologyPlugin plugin):
            base(context, plugin.Identity)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");

            _plugin = plugin;
            _commands = new MenuCommands(plugin.Identity);

            InitToolbar();

            _plugin.ItemClicked += PluginItemClicked;
            _plugin.ViewUpdating += PluginViewUpdating;
        }

        private void PluginViewUpdating(object sender, EventArgs e)
        {
            var fs = _context.Map.SelectedFeatureSet;
            FindToolbarItem(MenuKeys.QueryBuilder).Enabled = fs != null;
            FindToolbarItem(MenuKeys.Categories).Enabled = fs != null;
            
            FindToolbarItem(MenuKeys.LabelMover).Checked = _context.Map.CustomCursor == LabelMoverCursor.Instance;
        }

        private void PluginItemClicked(object sender, MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case MenuKeys.QueryBuilder:
                    FormHelper.ShowQueryBuilder(_context);
                    break;
                case MenuKeys.Categories:
                    FormHelper.ShowCategories(_context);
                    break;
                case MenuKeys.LabelMover:
                    _context.Map.CustomCursor = LabelMoverCursor.Instance;
                    break;
            }
        }

        private void InitToolbar()
        {
            // file toolbar
            var items = _context.Toolbars.FileToolbar.Items;

            items.AddButton(_commands[MenuKeys.Categories], true);
            items.AddButton(_commands[MenuKeys.QueryBuilder]);
            _context.Toolbars.FileToolbar.Update();

            // map toolbar
            items = _context.Toolbars.MapToolbar.Items;
            items.AddButton(_commands[MenuKeys.LabelMover]);
            _context.Toolbars.FileToolbar.Update();
        }
    }
}
