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
        }

        private IGisTool CreateTool(string name, string key)
        {
            return _context.Toolbox.CreateTool(name, key, _plugin.Identity);
        }
    }
}
