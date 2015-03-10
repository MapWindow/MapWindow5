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
    internal static class MenuCommands
    {
        private static Dictionary<string, MenuCommand> _commands = new Dictionary<string,MenuCommand>();

        public static void Init()
        {
            var list = new List<MenuCommand>()
            {
                // file menu
                new MenuCommand("New map", MenuKeys.NewMap, Resources.new_map, PluginIdentity.Default),
                new MenuCommand("Add layer", MenuKeys.AddLayer, Resources.layer_add, PluginIdentity.Default),
                new MenuCommand("Add vector layer", MenuKeys.AddVectorLayer, Resources.layer_vector_add, PluginIdentity.Default),
                new MenuCommand("Add raster layer", MenuKeys.AddRasterLayer, Resources.layer_raster_add, PluginIdentity.Default),
                new MenuCommand("Add database layer", MenuKeys.AddDatabaseLayer, Resources.layer_database_add, PluginIdentity.Default),
                new MenuCommand("Open project", MenuKeys.OpenProject, Resources.folder, PluginIdentity.Default),
                new MenuCommand("Save project", MenuKeys.SaveProject, Resources.save, PluginIdentity.Default),
                new MenuCommand("Save project as", MenuKeys.SaveProjectAs, Resources.save_as, PluginIdentity.Default),
                new MenuCommand("Quit", MenuKeys.Quit, Resources.quit, PluginIdentity.Default),
                
                // file toolbar
                new MenuCommand("Create layer", MenuKeys.CreateLayer, Resources.layer_create, PluginIdentity.Default),
                new MenuCommand("Remove layer", MenuKeys.RemoveLayer, Resources.layer_remove, PluginIdentity.Default),
                
                // map toolbar
                new MenuCommand("Zoom in", MenuKeys.ZoomIn, Resources.zoom_in, PluginIdentity.Default),
                new MenuCommand("Zoom out", MenuKeys.ZoomOut, Resources.zoom_out, PluginIdentity.Default),
                new MenuCommand("Zoom to maximum extents", MenuKeys.ZoomMax, Resources.zoom_max_extents, PluginIdentity.Default),
                new MenuCommand("Zoom to layer", MenuKeys.ZoomToLayer, Resources.zoom_to_layer, PluginIdentity.Default),
                new MenuCommand("Pan", MenuKeys.Pan, Resources.pan, PluginIdentity.Default),
                new MenuCommand("Set coordinate system & projection", MenuKeys.SetProjection, Resources.crs_change, PluginIdentity.Default),
            };

            foreach (var cmd in list)
            {
                _commands.Add(cmd.Key, cmd);
            }
        }

        public static MenuCommand Get(string key)
        {
            return _commands[key];      // don't catch it, if there is a mistake we want to know at once
        }

        public static void AddButton(this IMenuItemCollection items, string key, bool beginGroup = false)
        {
            var btn = items.AddButton(Get(key));
            if (beginGroup)
            {
                btn.BeginGroup = true;
            }
        }
    }
}
