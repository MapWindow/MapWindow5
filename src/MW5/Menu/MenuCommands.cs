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

        public override List<MenuCommand> GetCommands()
        {
            return new List<MenuCommand>()
            {
                // file menu
                new MenuCommand("New map", MenuKeys.NewMap, Resources.new_map),
                new MenuCommand("Add layer", MenuKeys.AddLayer, Resources.layer_add),
                new MenuCommand("Add vector layer", MenuKeys.AddVectorLayer, Resources.layer_vector_add),
                new MenuCommand("Add raster layer", MenuKeys.AddRasterLayer, Resources.layer_raster_add),
                new MenuCommand("Add database layer", MenuKeys.AddDatabaseLayer, Resources.layer_database_add),
                new MenuCommand("Open project", MenuKeys.OpenProject, Resources.folder),
                new MenuCommand("Save project", MenuKeys.SaveProject, Resources.save),
                new MenuCommand("Save project as", MenuKeys.SaveProjectAs, Resources.save_as),
                new MenuCommand("Quit", MenuKeys.Quit, Resources.quit),
                
                // file toolbar
                new MenuCommand("Create layer", MenuKeys.CreateLayer, Resources.layer_create),
                new MenuCommand("Remove layer", MenuKeys.RemoveLayer, Resources.layer_remove),
                
                // map toolbar
                new MenuCommand("Zoom in", MenuKeys.ZoomIn, Resources.zoom_in),
                new MenuCommand("Zoom out", MenuKeys.ZoomOut, Resources.zoom_out),
                new MenuCommand("Zoom to maximum extents", MenuKeys.ZoomMax, Resources.zoom_max_extents),
                new MenuCommand("Zoom to layer", MenuKeys.ZoomToLayer, Resources.zoom_to_layer),
                new MenuCommand("Pan", MenuKeys.Pan, Resources.pan),
                new MenuCommand("Set coordinate system and projection", MenuKeys.SetProjection, Resources.crs_change),
                new MenuCommand("Measure distance", MenuKeys.MeasureDistance, Resources.measure_distance),
                new MenuCommand("Measure area", MenuKeys.MeasureArea, Resources.measure_area),
                new MenuCommand("By rectangle", MenuKeys.SelectByRectangle, null),
                new MenuCommand("By polygon", MenuKeys.SelectByPolygon, null),
                new MenuCommand("Attributes", MenuKeys.Attributes, Resources.attribute_show),
                new MenuCommand("Zoom to selected", MenuKeys.ZoomToSelected, Resources.zoom_to_selection),
                
                // TODO: correct icon name
                new MenuCommand("Clear Selection", MenuKeys.ClearSelection, Resources.delete_selected), 
            };
        }
    }
}
