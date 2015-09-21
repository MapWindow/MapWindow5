using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
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
    [CustomLayout]
    [GisTool(GroupKeys.VectorGeometryTools)]
    public class CentroidTool: GisTool
    {
        [Input("Input datasource", 0)]
        public IVectorInput Input { get; set; }

        [Input("Calculation method", 1)]
        [ControlHint(ControlHint.Combo)]
        public PolygonCenter Method { get; set; }

        [Input("Calcuate for each part (for multi part shapes)", 2)]
        public bool AllParts { get; set; }

        [Output("Output layer", 0)]
        [OutputLayer("{input}_center", LayerType.Shapefile)]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// Adds tool configuration which can be used for generation of the UI for tool.
        /// </summary>
        protected override void Configure(IAppContext context, Services.ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            var methods = EnumHelper.GetValues<PolygonCenter>();

            configuration.Get<CentroidTool>()
                .AddComboList(t => t.Method, methods)
                .SetDefault(t => t.Method, PolygonCenter.Centroid);
        }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Calculate centroids"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Calculate centroids for polugon features."; }
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
            get { return true; }
        }

        /// <summary>
        /// Is called on the UI thread before execution of the IGisTool.Run method.
        /// </summary>
        protected override bool BeforeRun()
        {
            if (Input.Datasource.GeometryType == GeometryType.Point)
            {
                MessageService.Current.Info("Operations is not supported for point layers");
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
            var fsNew = fs.Clone(GeometryType.Point);

            int lastPercent = 0;

            var features = Input.Datasource.GetFeatures(Input.SelectedOnly);
            for (int i = 0; i < features.Count; i++)
            {
                task.CheckPauseAndCancel();
                task.Progress.TryUpdate("Calculating...", i, features.Count, ref lastPercent);

                var gm = features[i].Geometry;

                if (AllParts)
                {
                    var list = gm.Explode();
                    foreach (var gmPart in list)
                    {
                        ProcessGeometry(gmPart, fs, i, fsNew);
                    }
                }
                else
                {
                    ProcessGeometry(gm, fs, i, fsNew);
                }
            }

            task.Progress.Clear();

            Output.Result = fsNew; 
            return true;
        }

        /// <summary>
        /// Processes single input geometry geometry.
        /// </summary>
        private bool ProcessGeometry(IGeometry g, IFeatureSet source, int sourceIndex, IFeatureSet target)
        {
            var pnt = CalculateCenter(g);

            var gmNew = new Geometry(GeometryType.Point);
            gmNew.Points.Add(pnt);

            var index = target.Features.EditAdd(gmNew);
            if (index == -1)
            {
                Log.Warn("Failed to insert geometry: {0}", null, sourceIndex);
            }
            else
            {
                source.Table.CopyAttributes(sourceIndex, target.Table, index);
            }

            return true;
        }

        /// <summary>
        /// Calculates the center using specified method.
        /// </summary>
        private ICoordinate CalculateCenter(IGeometry g)
        {
            switch (Method)
            {
                case PolygonCenter.Center:
                    return g.Center;
                case PolygonCenter.Centroid:
                    return g.Centroid;
                case PolygonCenter.InteriorPoint:
                    return g.InteriorPoint;
                default:
                    throw new ArgumentOutOfRangeException("method");
            }
        }
    }
}
