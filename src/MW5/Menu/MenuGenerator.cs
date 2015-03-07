using System;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Properties;
using MW5.Services;
//using System.Linq;

namespace MW5.Menu
{
    internal class MenuGenerator
    {
        private const string FILE_TOOLBAR = "File";
        private const string TOOLS_TOOLBAR = "Map tools";
        
        private readonly IAppContext _context;

        public MenuGenerator(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public void Init()
        {
            InitToolbars();
            InitMenus();
        }

        private void InitToolbars()
        {
            var bar = _context.Toolbars.Add(FILE_TOOLBAR, PluginIdentity.Default);
            InitFileToolbar(bar);
            bar.DockState = Plugins.ToolbarDockState.Left;

            bar = _context.Toolbars.Add(TOOLS_TOOLBAR, PluginIdentity.Default);
            InitToolsToolbar(bar);
            bar.DockState = Plugins.ToolbarDockState.Top;
        }

        private void InitFileToolbar(IToolbar bar)
        {
            bar.Items.AddButton("Open project", MenuKeys.OpenProject, Resources.folder, PluginIdentity.Default);
            bar.Items.AddButton("Save project", MenuKeys.SaveProject, Resources.save, PluginIdentity.Default);
            bar.Items.AddButton("Save project as", MenuKeys.SaveProjectAs, Resources.save_as, PluginIdentity.Default);

            bar.Items.AddButton("Add layer", MenuKeys.AddLayer, Resources.layer_add, PluginIdentity.Default);
            bar.Items.AddButton("Add vector layer", MenuKeys.AddVectorLayer, Resources.layer_vector_add, PluginIdentity.Default);
            bar.Items.AddButton("Add raster layer", MenuKeys.AddRasterLayer, Resources.layer_raster_add, PluginIdentity.Default);
            bar.Items.AddButton("Add database layer", MenuKeys.AddDatabaseLayer, Resources.layer_database_add, PluginIdentity.Default);

            bar.Items.AddButton("Create layer", MenuKeys.FileBarCreateLayer, Resources.layer_create, PluginIdentity.Default);
            bar.Items.AddButton("Remove layer", MenuKeys.RemoveLayer, Resources.layer_remove, PluginIdentity.Default);

            bar.AddSeparator(3);
            bar.AddSeparator(7);
        }

        private void InitToolsToolbar(IToolbar bar)
        {
            bar.Items.AddButton("Zoom in", MenuKeys.ZoomIn, Resources.zoom_in, PluginIdentity.Default);
            bar.Items.AddButton("Zoom out", MenuKeys.ZoomOut, Resources.zoom_out, PluginIdentity.Default);
            bar.Items.AddButton("Zoom to maximum extents", MenuKeys.ZoomMax, Resources.zoom_max_extents, PluginIdentity.Default);
            bar.Items.AddButton("Zoom to layer", MenuKeys.ZoomToLayer, Resources.zoom_to_layer, PluginIdentity.Default);
            bar.Items.AddButton("Pan", MenuKeys.Pan, Resources.pan, PluginIdentity.Default);
            bar.Items.AddButton("Set coordinate system & projection", MenuKeys.SetProjection, Resources.crs_change, PluginIdentity.Default);
            bar.AddSeparator(5);
        }

        private void InitMenus()
        {
             
        }
    }
}
