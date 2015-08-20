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
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    /// <summary>
    /// Generates random points within extents of selected datasource.
    /// </summary>
    [GisTool(GroupKeys.VectorGeometryTools)]
    public class RandomPointsTool : GisTool
    {
        [Input("Layer for bounding box", 0)]
        public ILayerSource InputLayer { get; set; }

        [Input("Number of points", 1)]
        [DefaultValue(500)]
        [Range(1, 1000000)]
        public int NumPoints { get; set; }

        [Input("New layer name", 2)]
        [DefaultValue("random points")]
        public OutputLayerInfo OutputLayer { get; set; }

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

        /// <summary>
        /// Runs the tool.
        /// </summary>
        /// <returns>True on success, which closes the view</returns>
        public override bool Run(ITaskHandle task)
        {
            Log.Debug("Creating {0} random points", NumPoints);

            var fs = new FeatureSet(GeometryType.Point);
            fs.Projection.CopyFrom(InputLayer.Projection);

            var envelop = InputLayer.Envelope;
            var random = new Random();
            var progressValue = 0;
            var progressStep = NumPoints / 100;

            for (int i = 0; i < NumPoints; i++)
            {
                task.CheckPauseAndCancel();
                var x = envelop.MinX + (envelop.Width * random.NextDouble());
                var y = envelop.MinY + (envelop.Height * random.NextDouble());
                var feature = new Geometry(GeometryType.Point);
                feature.Points.Add(new Coordinate(x, y));
                fs.Features.EditAdd(feature);

                if (i % progressStep == 0)
                {
                    progressValue++;
                    task.Progress.Update("Running...", progressValue);
                }
            }

            task.Progress.Clear();
            Log.Debug("New feature set has {0} features", fs.NumFeatures);
            HandleOutput(fs, OutputLayer);

            return true;
        }
    }
}