// -------------------------------------------------------------------------------------------
// <copyright file="SortShapefileTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.VectorTools.Basic
{
    [GisTool(GroupKeys.Basic, parentGroupKey: GroupKeys.VectorTools)]
    public class SortShapefileTool: GisTool
    {
        [Input("Input datasource", 0)]
        public IVectorInput Input { get; set; }

        [Input("Field index", 1)]
        [ControlHint(ControlHint.Field)]
        public int FieldIndex { get; set; }

        [Input("Ascending", 2)]
        public bool Ascending { get; set; }

        [Output("Output layer", 0)]
        [OutputLayer("{input}_sort.shp", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// Adds tool configuration which can be used for generation of the UI for tool.
        /// </summary>
        protected override void Configure(IAppContext context, Services.ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            configuration.Get<SortShapefileTool>()
                .AddField(t => t.Input, t => t.FieldIndex)
                .SetDefault(t => t.Ascending, true);
        }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name => "Sort shapefile";

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description => "Sorts shapefile by the given attribute, physically changing the order of records.";

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity => PluginIdentity.Default;

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            Output.Result = Input.Datasource.Sort(FieldIndex, Ascending);
            return true;
        }
    }
}
