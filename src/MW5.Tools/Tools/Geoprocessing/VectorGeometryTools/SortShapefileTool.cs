using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.VectorGeometryTools)]
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
        [OutputLayer("{input}_sort", LayerType.Shapefile)]
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
        public override string Name
        {
            get { return "Sort shapefile"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Sorts shapefile by the given attribute, physically changing the order of records."; }
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

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
