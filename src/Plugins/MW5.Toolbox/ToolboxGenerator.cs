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
            group.Tools.Add(tool);

            group = toolbox.CreateGroup("GeoDatabases", GroupKeys.GeoDatabases, _plugin.Identity);
            toolbox.Groups.Add(group);

            tool = CreateTool("Import layer in geodatabase", ToolKeys.ImportLayerInGeodatabase);
            group.Tools.Add(tool);
        }

        private IGisTool CreateTool(string name, string key)
        {
            return _context.Toolbox.CreateTool(name, key, _plugin.Identity);
        }
    }
}
