// -------------------------------------------------------------------------------------------
// <copyright file="ToolboxGenerator.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Tools.Enums;
using MW5.Tools.Tools.Database;
using MW5.Tools.Tools.Geoprocessing.VectorGeometryTools;
using MW5.Tools.Tools.Projections;

namespace MW5.Plugins.Toolbox
{
    public class ToolboxGenerator
    {
        private readonly IAppContext _context;

        private readonly ToolboxPlugin _plugin;
        private readonly ILayerService _layerService;

        public ToolboxGenerator(IAppContext context, ToolboxPlugin plugin, ILayerService layerService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (layerService == null) throw new ArgumentNullException("layerService");

            _context = context;
            _plugin = plugin;
            _layerService = layerService;

            Init();
        }

        private void Init()
        {
            var groups = _context.Toolbox.Groups;

            var group = groups.Add("Projections", GroupKeys.Projections, _plugin.Identity);
            group.Tools.Add(new IdentifyProjectionTool());

            group = groups.Add("GeoDatabases", GroupKeys.GeoDatabases, _plugin.Identity);
            group.Tools.Add(new ImportLayerTool());

            group = groups.Add("Geoprocessing", GroupKeys.Geoprocessing, _plugin.Identity);                
            var subGroup = group.SubGroups.Add("VectorGeometryTools", GroupKeys.VectorGeometryTools, _plugin.Identity);

            subGroup.Tools.Add(new RandomPointsTool(_layerService));
        }
    }
}