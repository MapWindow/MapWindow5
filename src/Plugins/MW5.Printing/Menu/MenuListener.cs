// -------------------------------------------------------------------------------------------
// <copyright file="MenuListener.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Linq;
using MW5.Api.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Services;
using MW5.Plugins.Printing.Views;
using MW5.UI.Menu;

namespace MW5.Plugins.Printing.Menu
{
    internal class MenuListener : MenuServiceBase
    {
        private readonly PrintingPlugin _plugin;

        public MenuListener(IAppContext context, PrintingPlugin plugin)
            : base(context, plugin.Identity)
        {
            if (plugin == null) throw new ArgumentNullException("plugin");
            _plugin = plugin;

            plugin.ItemClicked += OnItemClicked;
            plugin.ViewUpdating += ViewUpdating;
        }
        
        private void ViewUpdating(object sender, EventArgs e)
        {
            var item = _context.Toolbars.FindItem(MenuKeys.SelectPrintArea, _plugin.Identity);
            if (item != null)
            {
                item.Checked = _context.Map.GetIsCustomSelectionMode(_plugin.Identity.Guid);
            }
        }

        private void OnItemClicked(object sender, MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case MenuKeys.Print:
                    var model = new TemplateModel(PrintArea.CurrentScreen, _plugin.PrinterSettings);

                    if (_context.Container.Run<TemplatePresenter, TemplateModel>(model))
                    {
                        _context.Container.Run<LayoutPresenter, TemplateModel>(model);
                    }
                    break;
                case MenuKeys.SelectPrintArea:
                    _context.Map.MapCursor = MapCursor.Selection;
                    _context.Map.StartCustomSelectionMode(_plugin.Identity.Guid);
                    break;
            }
        }
    }
}