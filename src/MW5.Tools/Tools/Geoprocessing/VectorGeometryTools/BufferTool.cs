using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.VectorGeometryTools)]
    public class BufferTool : GisTool
    {
        [Input("Input layer", 0)]
        public VectorLayerParameter InputLayer { get; set; }

        [Input("Buffer distance", 1)]
        public DistanceParameter BufferDistance { get; set; }

        [OptionalInput("Number of segments", 2), DefaultValue(30)]
        public IntegerParameter NumSegments { get; set; }

        [Input("Merge results", 3)]
        public BooleanParameter MergeResults { get; set; }

        [Input("Save results as", 4), DefaultValue(@"d:\buffer.shp")]
        public OutputLayerParameter Output { get; set; }

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
            LengthUnits units = LengthUnits.Kilometers;
            LengthUnits mapUnits=  LengthUnits.Meters;
            IFeatureSet input = null;
            bool mergeResults = false;
            double bufferDistance = 0.0;
            int numSegments = 30;
            OutputLayerInfo outputInfo = null;

            SendOrPostCallback action = p =>
                {
                    units = BufferDistance.Units;
                    mapUnits = AppContext.Map.MapUnits;
                    bufferDistance = BufferDistance.Value;
                    mergeResults = MergeResults.Value;
                    numSegments = NumSegments.Value;
                    outputInfo = Output.Value;
                    input = InputLayer.Value;
                };

            UiThread.Send(action, null);

            bufferDistance = UnitConversionHelper.Convert(units, mapUnits, bufferDistance);

            input.ErrorCallback = task.ErrorCallback;
            
            var fs = input.BufferByDistance(bufferDistance, numSegments, false, mergeResults);

            input.ErrorCallback = null;

            if (fs != null)
            {
                SendOrPostCallback action2 = p => HandleOutput(fs, outputInfo);
                UiThread.Send(action2, null);

                return true;
            }

            return false;
        }


    }
}
