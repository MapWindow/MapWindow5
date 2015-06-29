using System;
using System.Linq;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Services;
using MW5.Plugins.TableEditor.Views;
using MW5.UI.Docking;
using MW5.UI.Menu;

namespace MW5.Plugins.TableEditor.Menu
{
    internal class MenuListener: MenuServiceBase
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
            bool visible = _context.Map.SelectedFeatureSet != null;
            FindToolbarItem(MenuKeys.ShowTable).Enabled = visible;
            FindMenuItem(MenuKeys.ShowTable).Enabled = visible;
        }

        private void PluginItemClicked(object sender, MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case MenuKeys.ShowTable:
                    var layer = _context.Legend.SelectedLayer;
                    if (layer.IsVector)
                    {
                        _presenter.OpenTable(layer);
                    }

                    var panel = _context.DockPanels.Find(DockPanelKeys.TableEditor);
                    if (panel != null && !panel.Visible)
                    {
                        panel.Visible = true;
                    }
                    break;
            }
        }
    }
}
