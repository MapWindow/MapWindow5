// -------------------------------------------------------------------------------------------
// <copyright file="MergeShapefilesTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.VectorTools.Basic
{
    [GisTool(GroupKeys.Basic, parentGroupKey: GroupKeys.VectorTools)]
    public class MergeShapefilesTool: GisTool
    {
        [Input("First datasource", 0)]
        public IVectorInput Input { get; set; }

        [Input("Second datasource", 1)]
        public IVectorInput Input2 { get; set; }

        [Output("Save results as")]
        [OutputLayer("{input}_merge.shp", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name => "Merge shapefiles";

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description =>
            "Merges 2 shapefiles into one copying all the shapes and fields from both intputs." + 
            "Input shapefiles must have the same geometry type.";

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity => PluginIdentity.Default;

        /// <summary>
        /// Gets a value indicating whether the tool supports batch execution.
        /// </summary>
        public override bool SupportsBatchExecution => false;

        /// <summary>
        /// Is called on the UI thread before execution of the IGisTool.Run method.
        /// </summary>
        protected override bool BeforeRun()
        {
            if (InputHelper.InputsAreEqual(Input, Input2))
            {
                MessageService.Current.Info("The same datasource is used for both input parameters.");
                return false;
            }

            if (Input.Datasource.GeometryType == Input2.Datasource.GeometryType) return true;

            MessageService.Current.Info("Geometry type for both inputs must be the same.");
            return false;
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            var result = Input.Datasource.Merge(Input.SelectedOnly, Input2.Datasource, Input2.SelectedOnly);

            Log.Info("Number of features in the first input: " + Input.Datasource.NumFeatures);
            Log.Info("Number of features in the second input: " + Input2.Datasource.NumFeatures);
            Log.Info("Number of features in output: " + result);

            Output.Result = result;
            return true;
        }
    }
}
