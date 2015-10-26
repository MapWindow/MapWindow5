using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Static;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.VectorGeometryTools)]
    public class ExplodeShapesTool: AppendModeGisTool
    {
        [Input("Input datasource", 0)]
        public IVectorInput Input { get; set; }

        [Output("Output layer", 0)]
        [OutputLayer("{input}_explode.shp", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }
        
        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Explode shapes"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Splits multi-part shapes in single part shapes."; }
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
            bool success = false;

            if (Output.MemoryLayer)
            {
                var fs = Input.Datasource.ExplodeShapes(Input.SelectedOnly);

                if (fs != null)
                {
                    Log.Info("Initial number of features: " + Input.Datasource.NumFeatures);
                    Log.Info("After exploding: " + fs.NumFeatures);
                }

                Output.Result = fs;
            }
            else
            {
                success = GisUtils.Instance.ExplodeShapes(Input.Datasource, Input.SelectedOnly, Output.Filename, Output.Overwrite);
            }

            return Output.Result != null || success;
        }
    }
}
