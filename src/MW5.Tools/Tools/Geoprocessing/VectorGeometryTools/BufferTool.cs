// -------------------------------------------------------------------------------------------
// <copyright file="BufferTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Enums;
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
    [GisTool(GroupKeys.VectorGeometryTools, ToolIcon.Hammer)]
    public class BufferTool : GisTool
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

        private LengthUnits GetSourceUnits()
        {
            // TODO: this is a fast and dirty solution; units may also be stored in WKT string explicitly,
            // while ultimatily it may be needed to choose source units explicitly in the UI
            return Input.Datasource.Projection.IsGeographic ? LengthUnits.DecimalDegrees : LengthUnits.Meters;
        }

        /// <summary>
        /// Provide execution logic for the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            double bufferDistance = UnitConversionHelper.Convert(BufferDistance.Units, GetSourceUnits(),
                BufferDistance.Value);

            Output.Result = Input.Datasource.BufferByDistance(bufferDistance, NumSegments, Input.SelectedOnly,
                MergeResults);

            return true;
        }
    }
}