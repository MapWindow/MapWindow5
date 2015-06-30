// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomPointsTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The random points.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Properties;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    /// <summary>
    /// The random points.
    /// </summary>
    [GisTool(ToolboxGroupType.VectorTools, typeof(Resources))]
    public class RandomPointsTool : GisToolBase
    {
        private readonly ILayerService _layerService;

        private IAppContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomPointsTool"/> class.
        /// </summary>
        /// <param name="layerService">The layer service.</param>
        public RandomPointsTool(ILayerService layerService)
        {
            _layerService = layerService;
        }

        /// <summary>Gets or sets the add to map.</summary>
        [OptionalParameter("Add to map", 1)]
        public BooleanParameter AddToMap { get; set; }

        /// <summary>Gets or sets the input layer.</summary>
        [RequiredParameter("Layer for bounding box", 0)]
        public LayerParameter InputLayer { get; set; }

        /// <summary>Gets or sets the new layer name.</summary>
        [RequiredParameter("New layer name", 1)]
        public StringParameter NewLayerName { get; set; }

        /// <summary>Gets or sets the number of random points.</summary>
        [RequiredParameter("Number of points", 3)]
        public StringParameter NumPoints { get; set; }

        /// <summary>Gets or sets the overwrite.</summary>
        [RequiredParameter("Overwrite output file", 2)]
        public BooleanParameter Overwrite { get; set; }

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
        /// Initializes lists of options.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(IAppContext context)
        {
            InitializeBase(context);

            // TODO: Set default value for NumPoints
            // TODO: Set title of View
            // TODO: Make new parameter to select a new file location for NewLayerName
            // TODO: Set manual, local html file or remote local html file.
            _context = context;
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        /// <returns>True on success, which closes the view</returns>
        public override bool Run()
        {
            Logger.Current.Info("Run create random points tool");
            var fs = InputLayer.Value.FeatureSet;

            Logger.Current.Debug("Input feature set: " + fs.Filename);
            Logger.Current.Debug("New layer name: " + NewLayerName.Value);
            Logger.Current.Debug("Overwrite: ", Overwrite.Value);
            Logger.Current.Debug("Number of points: " + NumPoints.Value);

            ulong numPoints;
            if (ulong.TryParse(NumPoints.Value, out numPoints))
            {
                var result = Task.Factory.StartNew(() => RunCore(fs, NewLayerName.Value, numPoints, Overwrite.Value)).Result;

                if (!result)
                {
                    return false;
                }

                // Add to map:
                if (AddToMap.Value)
                {
                    return _layerService.AddLayersFromFilename(NewLayerName.Value);
                }

                return true;
            }

            Logger.Current.Error("Number points is invalid");

            return false;
        }

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
            // Check if file not already exists:
            if (!overwrite && File.Exists(newLayerName))
            {
                Logger.Current.Error("The file already exists. The process has stopped!");
                return false;
            }

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
            GeoSource.Remove(newLayerName);
            if (featureSet.SaveAsShapefile(newLayerName))
            {
                Logger.Current.Info("Layer ({0}) with random points is created.", newLayerName);
            }
            else
            {
                Logger.Current.Error("Could not save shapefile: " + featureSet.LastError);
            }

            featureSet.Dispose();

            return true;
        }
    }
}