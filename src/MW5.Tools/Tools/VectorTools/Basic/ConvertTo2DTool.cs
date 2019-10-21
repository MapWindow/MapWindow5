// -------------------------------------------------------------------------------------------
// <copyright file="ConvertTo2DTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.VectorTools.Basic
{
    [GisTool(GroupKeys.Basic, parentGroupKey: GroupKeys.VectorTools)]
    public class ConvertTo2DTool: AppendModeGisTool
    {
        [Input("Input datasource", 0)]
        public IVectorInput Input { get; set; }

        [Output("Output layer", 0)]
        [OutputLayer("{input}_2d.shp", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name => "Convert to 2D";

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description => "Removes M, Z components from vector datasource.";

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity => PluginIdentity.Default;

        public override bool SupportsBatchExecution => true;

        /// <summary>
        /// Is called on the UI thread before execution of the IGisTool.Run method.
        /// </summary>
        protected override bool BeforeRun()
        {
            if (Input.Datasource.ZValueType != ZValueType.None) return true;

            MessageService.Current.Info("The datasource doesn't have M, Z values: " + Input.Name);
            return false;
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            var fs = Input.Datasource;

            var fsNew = fs.Clone(fs.GeometryType);

            if (!TrySaveForAppendMode(Output, fsNew))
            {
                return false;
            }

            var lastPercent = 0;

            var features = Input.Datasource.GetFeatures(Input.SelectedOnly);
            for (var i = 0; i < features.Count; i++)
            {
                task.CheckPauseAndCancel();
                task.Progress.TryUpdate("Calculating...", i, features.Count, ref lastPercent);

                var ft = features[i];

                var gm = ft.Geometry.Clone(fs.GeometryType);
                var shapeIndex = fsNew.Features.EditAdd(gm);

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
