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

    using MW5.Api.Interfaces;
    using MW5.Plugins.Interfaces;
    using MW5.Plugins.Services;
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

        /// <summary>
        /// Gets or sets the input layer.
        /// </summary>
        [RequiredParameter("Layer for bounding box", 0)]
        public LayerParameter InputLayer { get; set; }

        /// <summary>
        /// Gets or sets the new layer name.
        /// </summary>
        [RequiredParameter("New layer name", 1)]
        public StringParameter NewLayerName { get; set; }

        /// <summary>
        /// Gets or sets the num points.
        /// </summary>
        [RequiredParameter("Number of points", 3)]
        public StringParameter NumPoints { get; set; }

        /// <summary>
        /// Gets or sets the overwrite.
        /// </summary>
        [RequiredParameter("Overwrite", 4)]
        public BooleanParameter Overwrite { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Initializes lists of options.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void Initialize(IAppContext context)
        {
            // TODO: Set default value for NumPoints
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Run()
        {
            var fs = this.InputLayer.Value.FeatureSet;
            var newLayerName = this.NewLayerName.Value;
            int numPoints;
            if (int.TryParse(this.NumPoints.Value, out numPoints))
            {
                return RunCore(fs, newLayerName, numPoints);
            }

            MessageService.Current.Warn("Number points is invalid");
            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Core processing.
        /// </summary>
        /// <param name="inputLayer">
        /// The input Layer.
        /// </param>
        /// <param name="newLayerName">
        /// The new Layer Name.
        /// </param>
        /// <param name="numPoints">
        /// The num Points.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool RunCore(ILayerSource inputLayer, string newLayerName, int numPoints)
        {
            // Needed to create a random value between a range of doubles:
            const int Multiplier = 10000000;

            // Load shapefile to get bounds:
            var envelop = inputLayer.Envelope;
            MessageService.Current.Info("envelop.minX: " + envelop.MinX);
            MessageService.Current.Info("envelop.maxX: " + envelop.MaxX);

            // Init randomizers:
            var randomX = new Random();

            // Wait to allow the timer to advance.
            Thread.Sleep(1);
            var randomY = new Random();

            var x = randomX.Next((int)Math.Round(envelop.MinX * Multiplier), (int)Math.Round(envelop.MaxX * Multiplier))
                    / Multiplier;
            var y = randomY.Next((int)Math.Round(envelop.MinY * Multiplier), (int)Math.Round(envelop.MaxY * Multiplier))
                    / Multiplier;
            MessageService.Current.Info("x: " + x);
            MessageService.Current.Info("y: " + y);

            // Create new shapefile:
            MessageService.Current.Warn("Warning");
            MessageService.Current.Info("Layer was imported: " + newLayerName);

            return false;
        }

        #endregion
    }
}