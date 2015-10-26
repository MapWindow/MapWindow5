// -------------------------------------------------------------------------------------------
// <copyright file="MenuListener.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Linq;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
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

            plugin.ItemClicked += plugin_ItemClicked;
            plugin.ViewUpdating += ViewUpdating;
        }

        private void InitPaperSize()
        {
            var ps = PrinterManager.PrinterSettings;
            PaperSizes.AddPaperSizes(ps);

            // TODO: improve conversion from PaperFormat to PaperSize
            var paperSizes = PaperSizes.GetPaperSizes(ps);
            var paperSize = paperSizes.FirstOrDefault(p => p.PaperName == PaperFormat.A4.ToString());

            var pgs = PrinterManager.PageSettings;
            pgs.PaperSize = paperSize;
        }

        private void ViewUpdating(object sender, EventArgs e)
        {
            //var item = _context.Toolbars.FindItem(MenuKeys.Print, _plugin.Identity);
            //if (item != null)
            //{
            //    item.Checked = _context.Map.MapCursor == MapCursor.Identify;
            //}
        }

        private void plugin_ItemClicked(object sender, MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case MenuKeys.Print:
                    var model = new TemplateModel(PrintArea.CurrentScreen);

                    if (_context.Container.Run<TemplatePresenter, TemplateModel>(model))
                    {
                        InitPaperSize();

                        _context.Container.Run<LayoutPresenter, TemplateModel>(model);
                    }
                    break;
            }
        }
    }
}