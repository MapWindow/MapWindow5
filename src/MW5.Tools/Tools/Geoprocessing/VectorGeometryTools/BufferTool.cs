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
        [Input("Buffer distance", 1)]
        [DefaultValue(50)]
        public Distance BufferDistance { get; set; }

        [Input("Input layer", 0)]
        public VectorLayerInfo InputLayer { get; set; }

        [Input("Merge results", 3)]
        public bool MergeResults { get; set; }

        [Input("Number of segments", 1, true)]
        [DefaultValue(30)]
        public int NumSegments { get; set; }

        [Output("Save results as", 4, @"d:\buffer.shp")]
        public OutputLayerInfo Output { get; set; }

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
            Output.Result = InputLayer.Datasource.BufferByDistance(BufferDistance.Value, NumSegments, InputLayer.SelectedOnly, MergeResults);
            return true;
        }
    }
}