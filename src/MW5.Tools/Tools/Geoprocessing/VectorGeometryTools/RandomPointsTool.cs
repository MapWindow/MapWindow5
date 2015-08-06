// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomPointsTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    /// <summary>
    /// Generates random points within extents of selected datasource.
    /// </summary>
    [GisTool(GroupKeys.VectorGeometryTools)]
    public class RandomPointsTool : GisTool
    {
        [Input("Layer for bounding box", 0)]
        public LayerParameter InputLayer { get; set; }

        [Input("Number of points", 1), DefaultValue(500), Range(1, 1000000)]
        public IntegerParameter NumPoints { get; set; }

        [Input("New layer name", 2), DefaultValue("random points")]
        public OutputLayerParameter OutputLayer { get; set; }

        /// <summary>
        /// Gets name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Random points"; }
        }

        /// <summary>
        /// Gets description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Create a new shapefile with random points."; }
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        /// <returns>True on success, which closes the view</returns>
        public override bool Run(ITaskHandle task)
        {
            // TODO: log the name of the tool and start time

            // let it be synchronous until progress reporting is implemented in a thread safe way
            //var result = Task.Factory.StartNew(() => RunCore(layerSource, NewLayerName.Value, numPoints, Overwrite.Value)).Result;
            var fs = RunCore(InputLayer.Value, NumPoints.Value);
            if (fs == null)
            {
                return false;
            }

            UiThread.Post(p => HandleOutput(fs, OutputLayer.Value), null);

            return true;
        }

        /// <summary>
        /// Core processing.
        /// </summary>
        private IFeatureSet RunCore(ILayerSource inputLayer, int numPoints)
        {
            // TODO: Open log tab of view; log to the log tab
            Logger.Current.Debug("Creating {0} random points", numPoints);

            var fs = new FeatureSet(GeometryType.Point);
            fs.Projection.CopyFrom(inputLayer.Projection);

            var envelop = inputLayer.Envelope;
            var random = new Random();

            for (int i = 0; i < numPoints; i++)
            {
                var x = envelop.MinX + envelop.Width * random.NextDouble();
                var y = envelop.MinY + envelop.Height * random.NextDouble();
                var feature = new Geometry(GeometryType.Point);
                feature.Points.Add(new Coordinate(x, y));
                fs.Features.EditAdd(feature);
            }

            Logger.Current.Debug("New feature set has {0} features", fs.NumFeatures);

            return fs;
        }
    }
}