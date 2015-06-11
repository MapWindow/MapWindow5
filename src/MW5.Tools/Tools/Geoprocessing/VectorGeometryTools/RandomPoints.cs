// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomPoints.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The random points.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    #region

    using System;
    using System.Threading;

    using MW5.Api.Concrete;
    using MW5.Api.Enums;
    using MW5.Api.Interfaces;
    using MW5.Plugins.Interfaces;
    using MW5.Plugins.Services;
    using MW5.Shared;
    using MW5.Tools.Model;
    using MW5.Tools.Model.Parameters;
    using MW5.Tools.Properties;

    #endregion

    /// <summary>
    /// The random points.
    /// </summary>
    [GisTool("Random points", typeof(Resources))]
    public class RandomPoints : GisToolBase
    {
        #region Public Properties

        /// <summary>Gets or sets the input layer.</summary>
        [RequiredParameter("Layer for bounding box", 0)]
        public LayerParameter InputLayer { get; set; }

        /// <summary>Gets or sets the new layer name.</summary>
        [RequiredParameter("New layer name", 1)]
        public StringParameter NewLayerName { get; set; }

        /// <summary>Gets or sets the overwrite.</summary>
        [RequiredParameter("Overwrite output file", 2)]
        public BooleanParameter Overwrite { get; set; }

        /// <summary>Gets or sets the number of random points.</summary>
        [RequiredParameter("Number of points", 3)]
        public StringParameter NumPoints { get; set; }

        /// <summary>As demo an optional value</summary>
        [OptionalParameter("Some optional value", 4)]
        public StringParameter OptionalValue { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Initializes lists of options.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(IAppContext context)
        {
            // TODO: Set default value for NumPoints
            // TODO: Set title of View
            // TODO: Make new parameter to select a new file location for NewLayerName
            // TODO: Set manual, local html file or remote local html file.
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        /// <returns>True on success</returns>
        public override bool Run()
        {
            Logger.Current.Debug("Optional value: " + this.OptionalValue.Value);
            Logger.Current.Info("Run create random points tool");
            var fs = this.InputLayer.Value.FeatureSet;

            ulong numPoints;
            if (ulong.TryParse(this.NumPoints.Value, out numPoints))
            {
                return RunCore(fs, this.NewLayerName.Value, numPoints, this.Overwrite.Value);
            }

            Logger.Current.Error("Number points is invalid");
            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Core processing.
        /// </summary>
        /// <param name="inputLayer">The input Layer.</param>
        /// <param name="newLayerName">The new Layer Name.</param>
        /// <param name="numPoints">The number points that needs to be created.</param>
        /// <param name="overwrite">Overwrite the output file or not</param>
        /// <returns>True on success.</returns>
        private static bool RunCore(ILayerSource inputLayer, string newLayerName, ulong numPoints, bool overwrite)
        {
            // TODO: Open log tab of view
            
            // TODO: Log to log tab
            Logger.Current.Debug("Creating {0} random points", numPoints);

            // Needed to create a random value between a range of doubles:
            const int Multiplier = 10000000;

            // Load shapefile to get bounds:
            var envelop = inputLayer.Envelope;

            // Create a new shapefile:
            var featureSet = new FeatureSet(GeometryType.Point);
            featureSet.Projection.CopyFrom(inputLayer.Projection);

            // Init randomizers:
            var randomX = new Random();

            // Wait to allow the timer to advance.
            Thread.Sleep(1);
            var randomY = new Random();

            for (ulong i = 0; i < numPoints; i++)
            {
                var x = randomX.Next(
                    (int)Math.Round(envelop.MinX * Multiplier),
                    (int)Math.Round(envelop.MaxX * Multiplier)) / Multiplier;
                var y = randomY.Next(
                    (int)Math.Round(envelop.MinY * Multiplier),
                    (int)Math.Round(envelop.MaxY * Multiplier)) / Multiplier;
                var feature = new Geometry(GeometryType.Point);
                feature.Points.Add(new Coordinate(x, y));
                featureSet.Features.EditAdd(feature);
            }

            Logger.Current.Debug("New feature set has {0} features", featureSet.NumFeatures);

            // Create new shapefile:
            featureSet.SaveAsShapefile(newLayerName);
            featureSet.Dispose();
            Logger.Current.Info("Layer ({0}) with random points is created: ", newLayerName);

            return true;
        }

        #endregion
    }
}