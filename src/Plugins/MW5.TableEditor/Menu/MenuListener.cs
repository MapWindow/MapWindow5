using System;
using MapWinGIS;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Forms;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Views;
using MW5.UI.Menu;

namespace MW5.Plugins.TableEditor.Menu
{
    public class MenuListener: MenuServiceBase
    {
        private readonly TableEditorPresenter _presenter;

        public MenuListener(IAppContext context, TableEditorPlugin plugin, TableEditorPresenter presenter)
            : base(context, plugin.Identity)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (presenter == null) throw new ArgumentNullException("presenter");

            _presenter = presenter;

            plugin.ItemClicked += PluginItemClicked;
            plugin.ViewUpdating += ViewUpdating;
        }

        private void ViewUpdating(object sender, EventArgs e)
        {
            FindToolbarItem(MenuKeys.ShowTable).Enabled = _context.Map.SelectedFeatureSet != null;
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
