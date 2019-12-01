// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DissolveTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015-2019
// </copyright>
// <summary>
//   Defines the DissolveTool tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Services;

namespace MW5.Tools.Tools.VectorTools.Attributes
{
    [CustomLayout]
    [GisTool(GroupKeys.Attributes, parentGroupKey: GroupKeys.VectorTools)]
    public class DissolveTool: GisTool
    {
        [Input("Input datasource", 0)]
        public IVectorInput Input { get; set; }

        [Input("Field index", 1)]
        [ControlHint(ControlHint.Field)]
        public int FieldIndex { get; set; }

        [Input("Group operations", 2, true)]
        public FieldOperationList GroupOperations { get; set; }

        [Output("Save results as")]
        [OutputLayer(@"{input}_dissolve.shp", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// Adds tool configuration which can be used for generation of the UI for tool.
        /// </summary>
        protected override void Configure(IAppContext context, ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            configuration.Get<DissolveTool>()
                .AddField(t => t.Input, t => t.FieldIndex)
                .AddField(t => t.Input, t => t.GroupOperations);
        }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name => "Dissolve by attribute";

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description => "Merges together vector features which have the same value of a given field.";

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
        /// <returns></returns>
        protected override bool BeforeRun()
        {
            return GroupOperations.ValidateWithMessage(Input.Datasource);
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            Log.Info("Number of group operations specified: " + GroupOperations.Count);

            Output.Result = Input.Datasource.DissolveWithStats(FieldIndex, Input.SelectedOnly, GroupOperations);
            return true;
        }
    }
}
