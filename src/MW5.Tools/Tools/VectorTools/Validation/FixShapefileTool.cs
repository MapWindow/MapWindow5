// -------------------------------------------------------------------------------------------
// <copyright file="FixShapefileTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Enums;
using MW5.Api.Static;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.VectorTools.Validation
{
    [GisTool(GroupKeys.Validation, parentGroupKey: GroupKeys.VectorTools)]
    public class FixShapefileTool : AppendModeGisTool
    {
        [Input("Input datasource", 0)]
        public IVectorInput Input { get; set; }

        [Output("Output layer")]
        [OutputLayer("{input}_fix.shp", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name => "Fix shapefile";

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description => "Creates a new shapefile by fixing invalid geometries of the current one.";

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity => PluginIdentity.Default;

        /// <summary>
        /// Is called on the UI thread before execution of the IGisTool.Run method.
        /// </summary>
        protected override bool BeforeRun()
        {
            if (Input.Datasource.HasInvalidShapes()) return true;

            MessageService.Current.Info("Input shapefile doesn't have invalid shapes.");
            return false;
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            bool success;

            if (Output.MemoryLayer)
            {
                Output.Result = Input.Datasource.FixUpShapes(Input.SelectedOnly);
                success = true;
            }
            else
            {
                success = GisUtils.Instance.FixUpShapes(Input.Datasource, Input.SelectedOnly, Output.Filename, Output.Overwrite);
            }

            if (!success)
            {
                Log.Info("Failed to fix shapefile.");
            }

            return success;
        }
    }
}
