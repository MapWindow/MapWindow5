// -------------------------------------------------------------------------------------------
// <copyright file="BufferTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Static;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Services;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [CustomLayout]
    [GisTool(GroupKeys.Geoprocessing, ToolIcon.Hammer)]
    public class BufferTool : AppendModeGisTool
    {
        [Input("Input layer", 0)]
        public IVectorInput Input { get; set; }

        [Input("Buffer distance", 1)]
        public Distance BufferDistance { get; set; }

        [Input("Merge results", 2)]
        public bool MergeResults { get; set; }

        [Input("Number of segments", 0, true)]
        public int NumSegments { get; set; }

        [Output("Save results as")]
        [OutputLayer("{input}_buffer.shp", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        protected override void Configure(IAppContext context, ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            configuration.Get<BufferTool>().SetDefault(t => t.BufferDistance, 50).SetDefault(t => t.NumSegments, 30);
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

        /// <summary>
        /// Provide execution logic for the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            var units = Input.Datasource.GetLengthUnits();

            double bufferDistance = UnitConversionHelper.Convert(BufferDistance.Units, units, BufferDistance.Value);

            bool success = false;

            if (Output.MemoryLayer)
            {
                Output.Result = Input.Datasource.BufferByDistance(bufferDistance, NumSegments, Input.SelectedOnly, MergeResults);
            }
            else
            {
                success = GisUtils.Instance.BufferByDistance(Input.Datasource, Input.SelectedOnly, bufferDistance, 
                                                            NumSegments, MergeResults, Output.Filename, Output.Overwrite);
            }

            return Output.Result != null || success;
        }
    }
}