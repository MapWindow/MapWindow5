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
using MW5.Shared;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.VectorGeometryTools)]
    public class BufferTool : GisTool
    {
        [Input("Input layer", 0)]
        public VectorLayerInfo InputLayer { get; set; }

        [Input("Buffer distance", 1), DefaultValue(50)]
        public Distance BufferDistance { get; set; }

        [OptionalInput("Number of segments", 2), DefaultValue(30)]
        public int NumSegments { get; set; }

        [Input("Merge results", 3)]
        public bool MergeResults { get; set; }

        [Input("Save results as", 4), DefaultValue(@"d:\buffer.shp")]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// Gets name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Buffer by distance"; }
        }

        public override bool SupportsCancel
        {
            get { return false; }
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
            
            var fs = InputLayer.Datasource.BufferByDistance(bufferDistance, NumSegments, false, MergeResults);

            if (fs != null)
            {
                HandleOutput(fs, Output);

                return true;
            }

            return false;
        }
    }
}
