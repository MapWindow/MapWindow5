using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Static;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.Selection)]
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
        public override string Name
        {
            get { return "Export selection"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Exports selected features into a new datasource."; }
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        /// <summary>
        /// Is called on the UI thread before execution of the IGisTool.Run method.
        /// </summary>
        protected override bool BeforeRun()
        {
            if (Input.Datasource.NumSelected == 0)
            {
                MessageService.Current.Info("No selected features in the input datasource.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            bool success = false;

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
