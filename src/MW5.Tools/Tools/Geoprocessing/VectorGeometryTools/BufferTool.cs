// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BufferTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the BufferTool type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Properties;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.VectorGeometryTools, Enums.ToolIcon.Hammer)]
    public class BufferTool : GisTool
    {
        private LengthUnits _mapUnits;

        [Input("Input layer", 0)]
        public IVectorInput Input { get; set; }

        [Input("Buffer distance", 1)]
        public Distance BufferDistance { get; set; }

        [Input("Merge results", 2)]
        public bool MergeResults { get; set; }

        [Input("Number of segments", 0, true)]
        public int NumSegments { get; set; }

        [Output("Save results as", "{input}_buffer.shp", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        protected override void Configure(IAppContext context, Services.ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            configuration.Get<BufferTool>()
                .SetDefault(t => t.BufferDistance, 50)
                .SetDefault(t => t.NumSegments, 30);
        }

        public override void Initialize(IAppContext context)
        {
            base.Initialize(context);

            _mapUnits = context.Map.MapUnits;
        }

        /// <summary>
        /// BufferDistance doesn't supports cancelling in the ocx
        /// </summary>
        public override bool SupportsCancel
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        /// <summary>
        /// Gets name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Buffer by distance"; }
        }

        /// <summary>
        /// Gets description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Builds a buffer around features of input vector layer."; }
        }

        public override bool SupportsBatchExecution
        {
            get { return true; }
        }

        /// <summary>
        /// Provide execution logic for the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            double bufferDistance = UnitConversionHelper.Convert(BufferDistance.Units, _mapUnits, BufferDistance.Value);

            Output.Result = Input.Datasource.BufferByDistance(bufferDistance, NumSegments, Input.SelectedOnly, MergeResults);

            return true;
        }
    }
}