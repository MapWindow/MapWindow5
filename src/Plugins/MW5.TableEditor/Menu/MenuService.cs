using System;
using MapWinGIS;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Forms;
using MW5.Plugins.TableEditor.Helpers;
using MW5.UI.Menu;

namespace MW5.Plugins.TableEditor.Menu
{
    public class MenuService: MenuServiceBase
    {
        private readonly TableEditorPlugin _plugin;
        private readonly TableEditorPresenter _presenter;
        private readonly MenuCommands _commands;

        public MenuService(IAppContext context, TableEditorPlugin plugin, TableEditorPresenter presenter)
            : base(context, plugin.Identity)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (presenter == null) throw new ArgumentNullException("presenter");

            _plugin = plugin;
            _presenter = presenter;
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
                    var layer = _context.Map.Layers.SelectedLayer;
                    if (layer.IsVector)
                    {
                        _presenter.Run(layer, false);
                    }
                    break;
            }
        }
    }
}
