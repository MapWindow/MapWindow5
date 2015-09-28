using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.VectorGeometryTools)]
    public class ConvertTo2DTool: GisTool
    {
        [Input("Input datasource", 0)]
        public IVectorInput Input { get; set; }

        [Output("Output layer", 0)]
        [OutputLayer("{input}_2d.shp", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Convert to 2D"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Removes M, Z components from vector datasource."; }
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
            if (Input.Datasource.ZValueType == ZValueType.None)
            {
                MessageService.Current.Info("The datasource doesn't have M, Z values: " + Input.Name);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            var fs = Input.Datasource;

            var fsNew = fs.Clone(fs.GeometryType);

            int lastPercent = 0;

            var features = Input.Datasource.GetFeatures(Input.SelectedOnly);
            for (int i = 0; i < features.Count; i++)
            {
                task.CheckPauseAndCancel();
                task.Progress.TryUpdate("Calculating...", i, features.Count, ref lastPercent);

                var ft = features[i];

                var gm = ft.Geometry.Clone(fs.GeometryType, ZValueType.None);
                int shapeIndex = fsNew.Features.EditAdd(gm);

                if (shapeIndex != -1)
                {
                    fs.Table.CopyAttributes(ft.Index, fsNew.Table, shapeIndex);
                }
            }

            task.Progress.Clear();

            Output.Result = fsNew;

            return true;
        }
    }
}
