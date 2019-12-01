// -------------------------------------------------------------------------------------------
// <copyright file="ExportSelectionTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
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

namespace MW5.Tools.Tools.VectorTools.Selection
{
    [GisTool(GroupKeys.Selection, parentGroupKey: GroupKeys.VectorTools)]
    public class ExportSelectionTool: AppendModeGisTool
    {
        // TODO: disable the selected only flag in the UI
        [Input("Input datasource", 0)]
        public IVectorInput Input { get; set; }

        [Output("Output layer", 0)]
        [OutputLayer("{input}_export.shp", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name => "Export selection";

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description => "Exports selected features into a new datasource.";

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity => PluginIdentity.Default;

        /// <summary>
        /// Is called on the UI thread before execution of the IGisTool.Run method.
        /// </summary>
        protected override bool BeforeRun()
        {
            if (Input.Datasource.NumSelected != 0) return true;

            MessageService.Current.Info("No selected features in the input datasource.");
            return false;
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            var success = false;

            if (Output.MemoryLayer)
            {
                var fs = Input.Datasource.ExportSelection();

                if (fs != null)
                {
                    Log.Info("Number of features exported: " + fs.NumFeatures);
                }

                Output.Result = fs;
            }
            else
            {
                success = GisUtils.Instance.ExportSelection(Input.Datasource, Output.Filename, Output.Overwrite);
            }

            return Output.Result != null || success;
        }
    }
}
