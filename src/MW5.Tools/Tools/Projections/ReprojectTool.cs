using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.Projections
{
    [GisTool(GroupKeys.Projections, Enums.ToolIcon.ToolDefault)]
    public class ReprojectTool: GisTool
    {
        [Input("Input datasource", 0)]
        public IVectorInput Input { get; set; }

        [Output("New projection", 0)]
        public ISpatialReference NewProjection { get; set; }

        [Output("Output filename", 1)]
        [OutputLayer("{input}_reprojected.shp", Api.Enums.LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Reproject shapefile"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Reproject vector datasources."; }
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
            var fs = Input.Datasource;
            
            if (fs.Projection.IsSame(NewProjection))
            {
                Log.Info("Source and target projections are the same. Continuing anyway.", null);
            }

            int count;
            var newFs = fs.Reproject(NewProjection, out count);

            if (newFs == null || count == 0)
            {
                Log.Warn("No features were reprojected.", null);
                return false;
            }

            if (count != fs.NumFeatures)
            {
                Log.Warn("Some features were not reprojected: {0} from {1}", null, count, fs.NumFeatures);
            }

            Output.Result = newFs;
            return true;
        }
    }
}
