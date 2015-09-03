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
using MW5.Plugins.Enums;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.VectorGeometryTools)]
    public class BufferTool : GisTool
    {
        [Input("Input layer", 0)]
        public VectorLayerInfo Input { get; set; }

        [Input("Buffer distance", 1)]
        public Distance BufferDistance { get; set; }

        [Input("Merge results", 2)]
        public bool MergeResults { get; set; }

        [Input("Number of segments", 0, true)]
        public int NumSegments { get; set; }

        [Output("Save results as", @"buffer", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        protected override void Configure(Services.ToolConfiguration configuration)
        {
            configuration.Get<BufferTool>()
                .SetDefault(t => t.BufferDistance, 50)
                .SetDefault(t => t.NumSegments, 30);
        }

        /// <summary>
        /// BufferDistance doesn't supports cancelling in the ocx
        /// </summary>
        public override bool SupportsCancel
        {
            get { return false; }
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

        protected override bool BeforeRun()
        {
            var units = AppContext.Map.MapUnits;

            double bufferDistance = UnitConversionHelper.Convert(BufferDistance.Units, units, BufferDistance.Value);

            BufferDistance.Value = bufferDistance;

            return true;
        }

        /// <summary>
        /// Provide execution logic for the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            Output.Result = Input.Datasource.BufferByDistance(BufferDistance.Value, NumSegments, Input.SelectedOnly, MergeResults);
            return true;
        }
    }
}