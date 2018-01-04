using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using NUnit.Framework;

namespace MW5.API.Test
{
    [TestFixture]
    public class TestSpatialReference
    {
        /// <summary>
        /// Make sure that:
        /// a) Amersfoort projection can be imported from EPSG;
        /// b) ExportToEsri method doesn't change inner state of projection object;
        /// c) results of ExportToEsri is different from regular WKT; 
        /// </summary>
        [Test]
        public void TestExportToEsri()
        {
            var sr = new SpatialReference();
            if (!sr.ImportFromEpsg(28992))
            {
                Assert.Fail("Failed to import projection: 28992");
            }

            string wkt = sr.ExportToWkt();

            string esri = sr.ExportToEsri();

            Assert.IsFalse(string.IsNullOrWhiteSpace(esri));

            string wkt2 = sr.ExportToWkt();

            Assert.AreEqual(wkt, wkt2);

            Assert.AreNotEqual(wkt, esri);
        }

        [Test]
        public void GetEPSGCode()
        {
            var sr = new SpatialReference();
            const int Amersfoort = 28992;
            if (!sr.ImportFromEpsg(Amersfoort))
            {
                Assert.Fail("Failed to import projection: " + Amersfoort);
            }

            var code = sr.GetEpsgCode();
            Assert.AreEqual(Amersfoort, code);

            // Load shapefile and get its projection:
            const string sfFilename = @"D:\dev\GIS-Data\MapWindow-Projects\TheNetherlands\Assen.shp";
            var ds = GeoSource.Open(sfFilename);
            var layer = ds as ILayerSource;
            Assert.IsNotNull(layer);
            var layerCode = layer.Projection.GetEpsgCode();
            Assert.AreEqual(Amersfoort, layerCode);
        }
    }
}
