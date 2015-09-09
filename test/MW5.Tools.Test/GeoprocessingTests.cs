// -------------------------------------------------------------------------------------------
// <copyright file="GeoprocessingTests.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using Moq;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Test.Properties;
using MW5.Tools.Tools.Geoprocessing.VectorGeometryTools;
using NUnit.Framework;

namespace MW5.Tools.Test
{
    [TestFixture]
    public class GeoProcessingTests
    {
        private Mock<ITaskHandle> _taskHandle;
        private Mock<ITaskProgress> _taskProgress;

        private string ShapefilePath
        {
            get { return Settings.Default.GisDataPath + @"MapWindow-Projects\UnitedStates\Shapefiles\"; }
        }

        [SetUp]
        public void Setup()
        {
            _taskHandle = new Mock<ITaskHandle>();
            _taskProgress = new Mock<ITaskProgress>();
            _taskHandle.SetupGet(t => t.Progress).Returns(_taskProgress.Object);
        }

        [Test]
        public void TestBuffer()
        {
            var fs = OpenFeatureSet(ShapefilePath + "rivers.shp");

            var tool = new BufferTool
                           {
                               BufferDistance = new Distance(100, LengthUnits.Kilometers),
                               Input = new VectorInput(fs),
                               MergeResults = true,
                               Output = new OutputLayerInfo { MemoryLayer = true }
                           };

            RunTool(tool);

            tool.Output.Result.Dispose(); // this will generate exception if there is no result
        }

        [Test]
        public void TestRandomPoints()
        {
            var fs = OpenFeatureSet(ShapefilePath + "cities.shp");

            const int numPoints = 500;

            var tool = new RandomPointsTool
                           {
                               NumPoints = numPoints,
                               InputLayer = new DatasourceInput(fs),
                               OutputLayer = new OutputLayerInfo { MemoryLayer = true }
                           };

            RunTool(tool);

            var result = tool.OutputLayer.Result as IFeatureSet;

            Assert.AreEqual(result.NumFeatures, numPoints);

            result.Dispose();
        }

        [Test]
        public void TestIntersection()
        {
            var rivers = OpenFeatureSet(ShapefilePath + "rivers.shp");
            var roads = OpenFeatureSet(ShapefilePath + "roads.shp");

            var tool = new IntersectionTool()
                           {
                               InputLayer = new VectorInput(rivers),
                               InputLayer2 = new VectorInput(roads),
                               Output = new OutputLayerInfo() {  MemoryLayer = true }
                           };

            RunTool(tool);

            var result = tool.Output.Result as IFeatureSet;

            Assert.IsTrue(result.NumFeatures > 0);

            result.Dispose();
        }

        private IFeatureSet OpenFeatureSet(string filename)
        {
            return new FeatureSet(filename);
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