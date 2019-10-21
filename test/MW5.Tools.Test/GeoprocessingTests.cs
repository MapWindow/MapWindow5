// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeoprocessingTests.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the GeoProcessingTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using Moq;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Test.Properties;
using MW5.Tools.Tools.VectorTools.Geoprocessing;
using MW5.Tools.Tools.VectorTools.Validation;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace MW5.Tools.Test
{
    [TestFixture]
    public class GeoProcessingTests
    {
        private readonly Stopwatch _timer = new Stopwatch();
        private Mock<ITaskHandle> _taskHandle;
        private Mock<ITaskProgress> _taskProgress;

        private static string NlShapefilesPath
        {
            get { return Path.Combine(Settings.Default.GisDataPath, @"MapWindow-Projects\TheNetherlands\"); }
        }

        private static string UsaShapefilesPath
        {
            get { return Path.Combine(Settings.Default.GisDataPath, @"MapWindow-Projects\UnitedStates\Shapefiles\"); }
        }

        private static string WorldProjectPath
        {
            get { return Path.Combine(Settings.Default.GisDataPath, @"MapWindow-Projects\World\"); }
        }

        [SetUp]
        public void Setup()
        {
            // To get English error messages:
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");

            _taskHandle = new Mock<ITaskHandle>();
            _taskProgress = new Mock<ITaskProgress>();
            _taskHandle.SetupGet(t => t.Progress).Returns(_taskProgress.Object);
        }

        /// <summary>
        /// Tests the buffer tool
        /// </summary>
        [Test]
        public void TestBuffer()
        {
            var testFiles = new List<string> { "cities.shp", "rivers.shp", "states.shp" };
            foreach (var testFile in testFiles)
            {
                _timer.Restart();
                var fs = OpenFeatureSet(Path.Combine(UsaShapefilesPath, testFile));
                Debug.Write("Buffering " + testFile);
                var tool = new BufferTool
                               {
                                   BufferDistance = new Distance(100, LengthUnits.Kilometers), 
                                   Input = new VectorInput(fs), 
                                   MergeResults = true, 
                                   Output = new OutputLayerInfo { MemoryLayer = true }
                               };

                RunTool(tool);
                Debug.Write(" ... ");
                var result = tool.Output.Result as IFeatureSet;
                Assert.IsNotNull(result);

                // The envelop should be larger:
                Assert.IsFalse(fs.Envelope.EqualsTo(result.Envelope, 1), "The resulting envelop is equal to the input envelop, this is unexpected");

                // Check number of features:
                Assert.IsTrue(result.NumFeatures > 0);

                result.Dispose(); // this will generate exception if there is no result
                Debug.WriteLine(" Done!");
                Debug.WriteLine("Elapsed time " + GetDateString(_timer.ElapsedMilliseconds));
            }
        }

        [Test]
        public void TestFixShapefile()
        {
            _timer.Restart();
            var fs = OpenFeatureSet(Path.Combine(NlShapefilesPath, "Buurtkaart.shp"));
            var outputFilename = Path.ChangeExtension(fs.Filename, ".fixed.shp");
            FeatureSet.DeleteShapefile(outputFilename);

            Debug.Write("Fix shapefile");
            var tool = new FixShapefileTool { Input = new DatasourceInput(fs), Output = new OutputLayerInfo { Filename = outputFilename, MemoryLayer = false, Overwrite = true } };

            RunTool(tool);

            Debug.Write(" ... ");
            var result = OpenFeatureSet(outputFilename);
            Assert.IsNotNull(result);

            // Check number of features:
            Assert.IsTrue(result.NumFeatures > 0);

            // Check envelop:
            Assert.IsTrue(fs.Envelope.EqualsTo(result.Envelope, 1), "The resulting envelop is not equal to the input envelop");
            Debug.Write(" ..the resulting envelope is OK.. ");

            Debug.WriteLine(" Done!");
            Debug.WriteLine("NumFeatures: " + result.NumFeatures);

            result.Close();
            result.Dispose();

            Debug.WriteLine("Elapsed time " + GetDateString(_timer.ElapsedMilliseconds));
        }

        [Test]
        public void TestIntersection()
        {
            _timer.Restart();

            // TODO: Test other shapefile type combinations as well:
            var rivers = OpenFeatureSet(Path.Combine(UsaShapefilesPath, "rivers.shp"));
            var roads = OpenFeatureSet(Path.Combine(UsaShapefilesPath, "roads.shp"));

            Debug.Write("Intersecting rivers with roads");
            var tool = new OverlayTool
                           {
                               Operation = ClipOperation.Intersection, 
                               InputLayer = new VectorInput(rivers), 
                               InputLayer2 = new VectorInput(roads), 
                               Output = new OutputLayerInfo { MemoryLayer = true }
                           };

            RunTool(tool);
            Debug.Write(" ... ");
            var result = tool.Output.Result as IFeatureSet;
            Assert.IsNotNull(result);

            Assert.IsTrue(result.NumFeatures > 0);

            result.Dispose();
            Debug.WriteLine(" Done!");
            Debug.WriteLine("Elapsed time " + GetDateString(_timer.ElapsedMilliseconds));
        }

#region RandomPointsTool
        [Test]
        public void TestRandomPointsVector()
        {
            _timer.Restart();
            var fs = OpenFeatureSet(Path.Combine(UsaShapefilesPath, "cities.shp"));

            const int NumPoints = 5000;
            Debug.Write(string.Format("Creating {0} random points", NumPoints));
            var tool = new RandomPointsTool { NumPoints = NumPoints, InputLayer = new DatasourceInput(fs), OutputLayer = new OutputLayerInfo { MemoryLayer = true } };

            RunTool(tool);

            Debug.Write(" ... ");
            var result = tool.OutputLayer.Result as IFeatureSet;
            Assert.IsNotNull(result);

            // Check number of features:
            Assert.AreEqual(result.NumFeatures, NumPoints);

            // Check envelop:
            Assert.IsTrue(fs.Envelope.EqualsTo(result.Envelope, 1), "The resulting envelop is not equal to the input envelop");
            Debug.Write(" ..the resulting envelope is OK.. ");

            result.Dispose();
            Debug.WriteLine(" Done!");
            Debug.WriteLine("Elapsed time " + GetDateString(_timer.ElapsedMilliseconds));
        }

        [Test]
        public void TestRandomPointsVectorSelected()
        {
            _timer.Restart();
            var fs = OpenFeatureSet(Path.Combine(UsaShapefilesPath, "cities.shp"));
            // Create Vector layer:
            var vector = new DatasourceInput(fs) as IVectorInput;
            vector.SelectedOnly = true;
            // Select first feature:
            vector.Datasource.Features[0].Selected = true;

            const int NumPoints = 5000;
            Debug.Write(string.Format("Creating {0} random points", NumPoints));
            var tool = new RandomPointsTool { NumPoints = NumPoints, InputLayer = vector, OutputLayer = new OutputLayerInfo { MemoryLayer = true } };

            RunTool(tool);

            Debug.Write(" ... ");
            var result = tool.OutputLayer.Result as IFeatureSet;
            Assert.IsNotNull(result);

            // Check number of features:
            Assert.AreEqual(result.NumFeatures, NumPoints);

            // Check envelop:
            Assert.IsTrue(vector.Datasource.GetSelectedExtents().EqualsTo(result.Envelope, 1), "The resulting envelop is not equal to the input envelop");
            Debug.Write(" ..the resulting envelope is OK.. ");

            result.Dispose();
            Debug.WriteLine(" Done!");
            Debug.WriteLine("Elapsed time " + GetDateString(_timer.ElapsedMilliseconds));
        }

        [Test]
        public void TestRandomPointsRaster()
        {
            _timer.Restart();

            var ds = OpenDatasource(Path.Combine(WorldProjectPath, "Raster", "NE2_50M_SR.jpg"));

            const int NumPoints = 5000;
            Debug.Write(string.Format("Creating {0} random points", NumPoints));
            var tool = new RandomPointsTool { NumPoints = NumPoints, InputLayer = ds, OutputLayer = new OutputLayerInfo { MemoryLayer = true } };

            RunTool(tool);

            Debug.Write(" ... ");
            var result = tool.OutputLayer.Result as IFeatureSet;
            Assert.IsNotNull(result);

            // Check number of features:
            Assert.AreEqual(result.NumFeatures, NumPoints);

            // Check envelop:
            Assert.IsTrue(ds.Datasource.Envelope.EqualsTo(result.Envelope, 1), "The resulting envelop is not equal to the input envelop");
            Debug.Write(" ..the resulting envelope is OK.. ");

            result.Dispose();
            Debug.WriteLine(" Done!");
            Debug.WriteLine("Elapsed time " + GetDateString(_timer.ElapsedMilliseconds));
        }

#endregion

        private static string GetDateString(long milliseconds)
        {
            var ts = TimeSpan.FromMilliseconds(milliseconds);
            return string.Format("{0}h {1}m {2}s {3}ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        private static IFeatureSet OpenFeatureSet(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("Dataset file doesn't exists.", filename);
            }

            return new FeatureSet(filename);
        }

        private static IDatasourceInput OpenDatasource(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("Datasource file doesn't exists.", filename);
            }

            return new DatasourceInput(filename);
        }



        private void RunTool(IGisTool tool)
        {
            // it can be called without ITaskHandle as well, as GisTool class provide a mock for it internally
            if (!tool.Run(_taskHandle.Object))
            {
                Assert.Fail("GisTool.Run returned false.");
            }
        }
    }
}