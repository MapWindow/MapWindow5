using System;
using MapWinGIS;
using MW5.Plugins.Interfaces;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.Forms;
using MW5.Plugins.TableEditor.Helpers;
using MW5.UI.Menu;

namespace MW5.Plugins.TableEditor.Menu
{
    public class MenuService: MenuServiceBase
    {
        private readonly TableEditorPlugin _plugin;
        private MenuCommands _commands;

        public MenuService(IAppContext context, TableEditorPlugin plugin)
            : base(context, plugin.Identity)
        {
            if (plugin == null) throw new ArgumentNullException("plugin");
            _plugin = plugin;
            _commands = new MenuCommands(plugin);
            
            InitToolbars();

            plugin.ItemClicked += PluginItemClicked;
            plugin.ViewUpdating += ViewUpdating;
        }

        private void ViewUpdating(object sender, EventArgs e)
        {
            FindToolbarItem(MenuKeys.ShowTable).Enabled = _context.Map.SelectedFeatureSet != null;
        }

        private void InitToolbars()
        {
            var items = _context.Toolbars.FileToolbar.Items;
            _commands.AddToMenu(items, MenuKeys.ShowTable);
        }

        private void PluginItemClicked(object sender, Concrete.MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case MenuKeys.ShowTable:
                    _context.ShowEditorForm(_plugin);
                    break;
            }
        }
    }
}
