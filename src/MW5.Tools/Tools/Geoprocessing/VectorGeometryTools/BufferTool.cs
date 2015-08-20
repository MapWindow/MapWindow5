// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BufferTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the BufferTool type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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

        [Input("Save results as", 4)]
        [DefaultValue(@"d:\buffer.shp")]
        public OutputLayerInfo Output { get; set; }
        
        [OptionalInput("Number of segments", 1)]
        [DefaultValue(30)]
        public int NumSegments { get; set; }
        
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

        /// <summary>
        /// Provide execution logic for the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            // TODO: find more general way to read values from UI thread
            var mapUnits = LengthUnits.Meters;
            UiThread.Send(p => mapUnits = AppContext.Map.MapUnits, null);

            double bufferDistance = UnitConversionHelper.Convert(BufferDistance.Units, mapUnits, BufferDistance.Value);

            var fs = InputLayer.Datasource.BufferByDistance(bufferDistance, NumSegments, InputLayer.SelectedOnly, MergeResults);

            if (fs != null)
            {
                HandleOutput(fs, Output);

                return true;
            }

            return false;
        }
    }
}