// -------------------------------------------------------------------------------------------
// <copyright file="LayoutMenuCommands.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using MW5.Plugins.Concrete;
using MW5.Plugins.Printing.Properties;

namespace MW5.Plugins.Printing.Views
{
    public class LayoutMenuCommands : CommandProviderBase
    {
        public LayoutMenuCommands(PluginIdentity identity)
            : base(identity)
        {
        }

        public override IEnumerable<MenuCommand> GetCommands()
        {
            return new List<MenuCommand>
                       {
                           // file
                           new MenuCommand("New Layout", LayoutMenuKeys.NewLayout,
                               Resources.img_create24),
                           new MenuCommand("Save Layout", LayoutMenuKeys.SaveLayout,
                               Resources.img_save24),
                           new MenuCommand("Save Layout As", LayoutMenuKeys.SaveLayoutAs,
                               Resources.img_save_as24),
                           new MenuCommand("Load Layout", LayoutMenuKeys.LoadLayout,
                               Resources.img_open24),
                           new MenuCommand("Print", LayoutMenuKeys.Print, Resources.img_printer24),
                           new MenuCommand("Choose Printer...", LayoutMenuKeys.PrinterSetup, null),
                           new MenuCommand("Page Setup...", LayoutMenuKeys.PageSetup,
                               Resources.img_page_setup24),
                           new MenuCommand("Export to Bitmap", LayoutMenuKeys.ExportToBitmap,
                               Resources.img_export24),
                               new MenuCommand("Export to PDF", LayoutMenuKeys.ExportToPdf,
                               Resources.img_export_pdf24),
                           new MenuCommand("Close", LayoutMenuKeys.Close, Resources.img_close24),
                           new MenuCommand("Adjust Layout", LayoutMenuKeys.AdjustPages, Resources.img_refresh24),

                           // zooming
                           new MenuCommand("Zoom In", LayoutMenuKeys.ZoomIn, Resources.img_zoom_in24),
                           new MenuCommand("Zoom Out", LayoutMenuKeys.ZoomOut,
                               Resources.img_zoom_out24),
                           new MenuCommand("Zoom Max", LayoutMenuKeys.ZoomMax,
                               Resources.img_zoom_max24),
                           new MenuCommand("Show Page Numbers", LayoutMenuKeys.ShowPageNumbers, null),
                           new MenuCommand("Show Margins", LayoutMenuKeys.ShowMargins, null),

                           // selection
                           new MenuCommand("Select All", LayoutMenuKeys.SelectAll, null),
                           new MenuCommand("Select None", LayoutMenuKeys.SelectNone, null),
                           new MenuCommand("Invert Selection", LayoutMenuKeys.InvertSelection, null),
                           new MenuCommand("Convert Bitmap", LayoutMenuKeys.ConvertToBitmap, null),
                           new MenuCommand("Move Up", LayoutMenuKeys.MoveUp, null),
                           new MenuCommand("Move Down", LayoutMenuKeys.MoveDown, null),
                           new MenuCommand("Delete Element", LayoutMenuKeys.DeleteElement, null),

                           // map
                           new MenuCommand("Zoom map in", LayoutMenuKeys.MapZoomIn,
                               Resources.img_map_zoom_in24),
                           new MenuCommand("Zoom map to max extents", LayoutMenuKeys.MapZoomMax,
                               Resources.img_map_zoom_max24),
                           new MenuCommand("Zoom map out", LayoutMenuKeys.MapZoomOut,
                               Resources.img_map_zoom_out24),
                           new MenuCommand("Pan map", LayoutMenuKeys.MapPan, Resources.img_pan24),

                           // insert
                           new MenuCommand("Add Map", LayoutMenuKeys.AddMap,
                               Resources.img_insert_map24),
                           new MenuCommand("Add Legend", LayoutMenuKeys.AddLegend,
                               Resources.img_insert_legend24),
                           new MenuCommand("Add Scale Bar", LayoutMenuKeys.AddScaleBar,
                               Resources.img_scalebar24),
                           new MenuCommand("Add North Arrow", LayoutMenuKeys.AddNorthArrow,
                               Resources.img_insert_compass24),
                           new MenuCommand("Add Table", LayoutMenuKeys.AddTable,
                               Resources.img_insert_table24),
                           new MenuCommand("Add Label", LayoutMenuKeys.AddLabel,
                               Resources.img_insert_text24),
                           new MenuCommand("Add Rectangle", LayoutMenuKeys.AddRectangle,
                               Resources.img_rectangle24),
                           new MenuCommand("Add Bitmap", LayoutMenuKeys.AddBitmap,
                               Resources.img_insert_picture24),
                       };
        }
    }
}