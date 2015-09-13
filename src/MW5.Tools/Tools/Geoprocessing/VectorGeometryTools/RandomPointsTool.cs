// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomPointsTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Generates random points within extents of selected datasource.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Services;
using MW5.Tools.Views.Custom;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    /// <summary>
    /// Generates random points within extents of selected datasource.
    /// </summary>
    [GisTool(GroupKeys.VectorGeometryTools, ToolIcon.Hammer)]   //, typeof(RandomPointsPresenter)
    public class RandomPointsTool : GisTool
    {
        [Input("Layer for bounding box", 0)]
        public IDatasourceInput InputLayer { get; set; }

        [Input("Number of points", 1)]
        public int NumPoints { get; set; }

        [Output("New layer name")]
        [OutputLayer("{input}_random points.shp", LayerType.Shapefile)]
        public OutputLayerInfo OutputLayer { get; set; }

        protected override void Configure(IAppContext context, ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            configuration.Get<RandomPointsTool>()
                .SetDefault(t => t.NumPoints, 500)
                .SetRange(t => t.NumPoints, 1, 1000000);
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        /// <summary>
        /// Gets description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Create a new shapefile with random points."; }
        }

        /// <summary>
        /// Gets name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Random points"; }
        }

        public override bool SupportsBatchExecution
        {
            get { return true; }
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        /// <returns>True on success, which closes the view</returns>
        public override bool Run(ITaskHandle task)
        {
            Log.Debug("Creating {0} random points", NumPoints);

            var ds = InputLayer.Datasource;

            var fs = new FeatureSet(GeometryType.Point);
            fs.Projection.CopyFrom(ds.Projection);

            var envelop = ds.Envelope;
            var random = new Random();
            var lastPercent = 0;

            for (int i = 0; i < NumPoints; i++)
            {
                task.CheckPauseAndCancel();
                var x = envelop.MinX + (envelop.Width * random.NextDouble());
                var y = envelop.MinY + (envelop.Height * random.NextDouble());
                var feature = new Geometry(GeometryType.Point);
                feature.Points.Add(new Coordinate(x, y));
                fs.Features.EditAdd(feature);

                task.Progress.TryUpdate("Running...", i, NumPoints, ref lastPercent);
            }

            task.Progress.Clear();
            Log.Debug("New feature set has {0} features", fs.NumFeatures);
         
            OutputLayer.Result = fs;   

            return true;
        }
    }
}