// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntersectionTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the Intersection Tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.VectorGeometryTools, ToolIcon.Hammer)]
    public class IntersectionTool : GisTool
    {
        [Input("First layer", 0)]
        public IVectorLayerInfo InputLayer { get; set; }

        [Input("Second layer", 1)]
        public IVectorLayerInfo InputLayer2 { get; set; }

        [Output("Save results as", "{input}_intersection.shp", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }


        /// <summary>
        /// Gets description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Calculates intersection of 2 vector layers."; }
        }

        /// <summary>
        /// Gets name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Intersection"; }
        }

        /// <summary>
        /// Provide execution logic for the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            var fs = InputLayer.Datasource;
            var fs2 = InputLayer2.Datasource;

            Output.Result = fs.Intersection(InputLayer.SelectedOnly, fs2, InputLayer2.SelectedOnly, GeometryType.None);
            return true;
        }
    }
}