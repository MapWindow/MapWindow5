using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Plugins.Toolbox
{
    public class ToolboxGenerator
    {
        private readonly IAppContext _context;
        private readonly ToolboxPlugin _plugin;

        public ToolboxGenerator(IAppContext context, ToolboxPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            _context = context;
            _plugin = plugin;

            Init();
        }

        private void Init()
        {
            var toolbox = _context.Toolbox;

            // TODO: create groups and tools in one step (i.e. Add without Create)
            var group = toolbox.CreateGroup("Projections", GroupKeys.Projections, _plugin.Identity);
            toolbox.Groups.Add(group);

            var tool = CreateTool("Identify projection", ToolKeys.IdentitfyProjection);
            tool.Description = "Tries to identify projection string provided by user as on of the known ones";
            group.Tools.Add(tool);

            group = toolbox.CreateGroup("GeoDatabases", GroupKeys.GeoDatabases, _plugin.Identity);
            toolbox.Groups.Add(group);

            tool = CreateTool("Import layer", ToolKeys.ImportLayerInGeodatabase);
            tool.Description = "Imports layer in the geodatabase";
            group.Tools.Add(tool);

            // TODO: Make this easier. Perhaps using reflection. Namespace of tool is MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
            // 1) New tool in new group
            group = toolbox.CreateGroup("Geoprocesssing", GroupKeys.Geoprocessing, _plugin.Identity);
            toolbox.Groups.Add(group);

            // 2) Create subgroup
            var subgroup = toolbox.CreateGroup("VectorGeometryTools", GroupKeys.VectorGeometryTools, _plugin.Identity);
            group.SubGroups.Add(subgroup);

            // 3) Create tool:
            tool = CreateTool("Random points", ToolKeys.RandomPoints);
            tool.Description = "Create a new shapefile with random points";

            // 4) Add tool to subgroup:
            subgroup.Tools.Add(tool);

            // TODO: Let the icons be changed, preferable in the tools class itself.
        }

        private IGisTool CreateTool(string name, string key)
        {
            return _context.Toolbox.CreateTool(name, key, _plugin.Identity);
        }
    }
}
