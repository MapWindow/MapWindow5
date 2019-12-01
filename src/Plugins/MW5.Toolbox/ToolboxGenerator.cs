// -------------------------------------------------------------------------------------------
// <copyright file="ToolboxGenerator.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Gdal.Model;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tools.Helpers;
using MW5.Tools.Model;

namespace MW5.Plugins.Toolbox
{
    public class ToolboxGenerator
    {
        private readonly IAppContext _context;

        private readonly ToolboxPlugin _plugin;
        private readonly ILayerService _layerService;

        public ToolboxGenerator(IAppContext context, ToolboxPlugin plugin, ILayerService layerService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _plugin = plugin ?? throw new ArgumentNullException(nameof(plugin));
            _layerService = layerService ?? throw new ArgumentNullException(nameof(layerService));

            Init();
        }

        private void Init()
        {
            // GenerateVectorGroups();

            CreateTools();
        }

        private void CreateTools()
        {
            var types = new[] { typeof(GisTool), typeof(GdalTool) };

            foreach (var type in types)
            {
                try
                {
                    var tools = type.Assembly.GetTools();
                    _context.Toolbox.AddTools(tools);
                }
                catch (Exception ex)
                {
                    Logger.Current.Error("Failed to add tools from assembly.", ex);
                }
            }
        }

        private void GenerateVectorGroups()
        {
            var groups = _context.Toolbox.Groups;

            var group = groups.Add("Vector Tools", GroupKeys.VectorTools, _plugin.Identity);
            group.Description = "Geoprocessing tools for vector datasources.";

            var subGroup = group.SubGroups.Add("Attributes", GroupKeys.Attributes, _plugin.Identity);
            subGroup.Description = "Tools to work with attributes of vector layers.";

            subGroup = group.SubGroups.Add("Basic", GroupKeys.Basic, _plugin.Identity);
            subGroup.Description = "Basic operations on vector layers.";

            subGroup = group.SubGroups.Add("Geoprocessing", GroupKeys.Geoprocessing, _plugin.Identity);
            subGroup.Description = "Various geoprocessing operations for vector and raster datasources.";

            subGroup = group.SubGroups.Add("Selection", GroupKeys.Selection, _plugin.Identity);
            subGroup.Description = "Tools to select and work with selected features.";

            subGroup = group.SubGroups.Add("Validation", GroupKeys.Validation, _plugin.Identity);
            subGroup.Description = "Validation of vector layers and fixing the errors.";
        }
    }
}