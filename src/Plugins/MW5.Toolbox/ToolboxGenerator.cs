// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolboxGenerator.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the ToolboxGenerator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Plugins.Toolbox
{
    using System;

    using MW5.Plugins.Interfaces;

    public class ToolboxGenerator
    {
        #region Fields

        private readonly IAppContext _context;

        private readonly ToolboxPlugin _plugin;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolboxGenerator"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="plugin">The plugin.</param>
        public ToolboxGenerator(IAppContext context, ToolboxPlugin plugin)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (plugin == null)
            {
                throw new ArgumentNullException("plugin");
            }

            _context = context;
            _plugin = plugin;

            Init();
        }

        #endregion

        #region Methods

        private IGisTool CreateTool(string name, string key)
        {
            return _context.Toolbox.CreateTool(name, key, _plugin.Identity);
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

        #endregion
    }
}