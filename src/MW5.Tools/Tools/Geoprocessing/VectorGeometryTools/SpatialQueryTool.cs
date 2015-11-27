using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.Selection)]
    public class SpatialQueryTool: GisTool
    {
        // TODO: disable the selection of datasources from disk
        [Input("Select features of", 0)]
        public IVectorInput Input { get; set; }

        [Input("Relative to", 2)]
        public IVectorInput Input2 { get; set; }

        [Input("Spatial relation", 1)]
        [ControlHint(ControlHint.Combo)]
        public SpatialRelation Relation { get; set; }

        [Output("How to handle selection", 0)]
        [ControlHint(ControlHint.Combo)]
        public SelectionOperation SelectionOperation { get; set; }

        /// <summary>
        /// Adds tool configuration which can be used for generation of the UI for tool.
        /// </summary>
        protected override void Configure(IAppContext context, Services.ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            configuration.Get<SpatialQueryTool>()
                .AddComboList(t => t.Relation, EnumHelper.GetValues<SpatialRelation>())
                .AddComboList(t => t.SelectionOperation, EnumHelper.GetValues<SelectionOperation>())
                .SetDefault(t => t.Relation, SpatialRelation.Intersects)
                .SetDefault(t => t.SelectionOperation, SelectionOperation.New);
        }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Spatial query"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Selects shapes of the subject vector layer which are in a certain relation to the features of another layer."; }
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        /// <summary>
        /// Gets a value indicating whether the tool supports batch execution.
        /// </summary>
        public override bool SupportsBatchExecution
        {
            get { return false; }
        }

        /// <summary>
        /// Is called on the UI thread before execution of the IGisTool.Run method.
        /// </summary>
        protected override bool BeforeRun()
        {
            int[] result;
            if (Input.Datasource.SelectByShapefile(Input2.Datasource, Relation, Input2.SelectedOnly, out result))
            {
                var layer = _context.Layers.FirstOrDefault(l => l.Handle == Input.LayerHandle);
                if (layer != null)
                {
                    layer.UpdateSelection(result, SelectionOperation);
                    MessageService.Current.Info("Number of features selected: " + result.Length);
                }
            }
            else
            {
                MessageService.Current.Info("No features are found.");
            }

            // we don't want to run in as a task, so return false in all cases
            return false;
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            // implement the run part as well, although it won't be called from UI,
            // to make the core MapWinGIS method testable
            int[] result;
            if (Input.Datasource.SelectByShapefile(Input2.Datasource, Relation, Input2.SelectedOnly, out result))
            {
                Log.Info("Number of features selected: " + result.Length);
            }
            else
            {
                Log.Info("No features are selected.");
            }

            return true;
        }
    }
}
