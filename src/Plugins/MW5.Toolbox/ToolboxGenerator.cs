// -------------------------------------------------------------------------------------------
// <copyright file="ToolboxGenerator.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MW5.Gdal.Model;
using MW5.Gdal.Tools;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
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
            GenerateGroups();

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

        private void GenerateGroups()
        {
            var groups = _context.Toolbox.Groups;

            var group = groups.Add("Projections", GroupKeys.Projections, _plugin.Identity);
            group.Description = "Tools to work with coorindate systems and projections.";

            group = groups.Add("GeoDatabases", GroupKeys.GeoDatabases, _plugin.Identity);
            group.Description = "Tools to work with spatial datatabases like PostGIS, SpatialLite, MS SQL Spatial, etc.";

            group = groups.Add("Geoprocessing", GroupKeys.Geoprocessing, _plugin.Identity);
            group.Description = "Various geoprocessing operations for vector and raster datasources.";

            var subGroup = group.SubGroups.Add("Vector Geometry Tools", GroupKeys.VectorGeometryTools, _plugin.Identity);
            subGroup.Description = "Geoprocessing tools for vector datasources.";

            group = groups.Add("Fake", GroupKeys.Fake, _plugin.Identity);
            group.Description = "Fake tools to test the framework itself.";

            group = groups.Add("GDAL / OGR tools", GroupKeys.GdalTools, _plugin.Identity);
            group.Description = "GDAL and OGR tools.";
        }
    }
}