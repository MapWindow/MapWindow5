using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Properties;

namespace MW5.Menu
{
    /// <summary>
    /// Holds list of commands for the core app. 
    /// </summary>
    internal class MenuCommands : CommandProviderBase
    {
        public MenuCommands(PluginIdentity identity)
            : base(identity)
        {
        }

        public override IEnumerable<MenuCommand> GetCommands()
        {
            return new List<MenuCommand>()
            {
                // file menu
                new MenuCommand("New map", MenuKeys.NewMap, Resources.icon_new_map),
                new MenuCommand("Add layer", MenuKeys.AddLayer, Resources.icon_layer_add),
                new MenuCommand("Add vector layer", MenuKeys.AddVectorLayer, Resources.icon_layer_vector_add),
                new MenuCommand("Add raster layer", MenuKeys.AddRasterLayer, Resources.icon_layer_raster_add),
                new MenuCommand("Add database layer", MenuKeys.AddDatabaseLayer, Resources.icon_layer_database_add),
                new MenuCommand("Open project", MenuKeys.OpenProject, Resources.icon_folder),
                new MenuCommand("Save project", MenuKeys.SaveProject, Resources.icon_save),
                new MenuCommand("Save project as", MenuKeys.SaveProjectAs, Resources.icon_save_as),
                new MenuCommand("Quit", MenuKeys.Quit, Resources.icon_quit),
                
                // file toolbar
                new MenuCommand("Create layer", MenuKeys.CreateLayer, Resources.icon_layer_create),
                new MenuCommand("Remove layer", MenuKeys.RemoveLayer, Resources.icon_layer_remove),
                new MenuCommand("Settings", MenuKeys.Settings, Resources.icon_settings),

                // map toolbar
                new MenuCommand("Zoom in", MenuKeys.ZoomIn, Resources.icon_zoom_in),
                new MenuCommand("Zoom out", MenuKeys.ZoomOut, Resources.icon_zoom_out),
                new MenuCommand("Zoom to maximum extents", MenuKeys.ZoomMax, Resources.icon_zoom_max_extents),
                new MenuCommand("Zoom to layer", MenuKeys.ZoomToLayer, Resources.icon_zoom_to_layer),
                new MenuCommand("Pan", MenuKeys.Pan, Resources.icon_pan),
                new MenuCommand("Set coordinate system and projection", MenuKeys.SetProjection, Resources.icon_crs_change),
                new MenuCommand("Measure distance", MenuKeys.MeasureDistance, Resources.icon_measure_distance),
                new MenuCommand("Measure area", MenuKeys.MeasureArea, Resources.icon_measure_area),
                new MenuCommand("By rectangle", MenuKeys.SelectByRectangle, null),
                new MenuCommand("By polygon", MenuKeys.SelectByPolygon, null),
                new MenuCommand("Attributes", MenuKeys.Attributes, Resources.icon_identify),
                new MenuCommand("Zoom to selected", MenuKeys.ZoomToSelected, Resources.icon_zoom_to_selection),
                new MenuCommand("Clear Selection", MenuKeys.ClearSelection, Resources.icon_clear_selection), 
            };
        }
    }
}
