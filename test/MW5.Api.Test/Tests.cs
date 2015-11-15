// -------------------------------------------------------------------------------------------
// <copyright file="Tests.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.API.Test.Properties;
using NUnit.Framework;

namespace MW5.API.Test
{
    // TODO: add verification conditions
    [TestFixture]
    public class Tests
    {
        private static string FranceProjectPath
        {
            get { return Path.Combine(Settings.Default.GisDataPath, @"MapWindow-Projects\France\"); }
        }

        private static string UsaShapefilesPath
        {
            get { return Path.Combine(Settings.Default.GisDataPath, @"MapWindow-Projects\UnitedStates\Shapefiles\"); }
        }

        private static string WorldProjectPath
        {
            get { return Path.Combine(Settings.Default.GisDataPath, @"MapWindow-Projects\World\"); }
        }

        private static readonly IList<string> FrenchShapefiles = new List<string> { "COMMUNE.SHP", "COMMUNICATION_RESTREINTE.SHP", "LIMITE_ADMINISTRATIVE.SHP", "NOEUD_COMMUNE.SHP", "NOEUD_FERRE.SHP", "NOEUD_ROUTIER.SHP", "Routes3D.shp", "TRONCON_HYDROGRAPHIQUE.SHP", "TRONCON_ROUTE.SHP", "TRONCON_VOIE_FERREE.SHP", "ZONE_OCCUPATION_SOL.SHP" };

        [Test, TestCaseSource("FrenchShapefiles")]
        public void AttributeTable(string shapefilename)
        {
            using (var fs = new FeatureSet(Path.Combine(FranceProjectPath, "Shapefiles", shapefilename)))
            {
                Assert.IsTrue(fs.Table.Fields.Count > 0, "Shapefile has no attribute fields");
                fs.Close();
            }
        }

        [Test]
        public void Callback()
        {
            var cb = new CustomCallback();
            GlobalListeners.Attach(cb);

            var fs = new FeatureSet(Path.Combine(UsaShapefilesPath, "cities.shp"));
            fs.StartEditingShapes();
            fs.Close();
        }

        [Test, TestCaseSource("FrenchShapefiles")]
        public void EditShapefile(string shapefilename)
        {
            using (var fs = new FeatureSet(Path.Combine(FranceProjectPath, "Shapefiles", shapefilename)))
            {
                // Go to edit mode:
                fs.StartEditingShapes();
                Assert.IsTrue(fs.EditingShapes, "Could not set in edit mode");
                // Save shapefile:
                fs.Save();
                // Close feature set:
                fs.Close();
            }
        }

        [Test, TestCaseSource("FrenchShapefiles")]
        public void IsVector(string shapefilename)
        {
            using (var fs = new FeatureSet(Path.Combine(FranceProjectPath, "Shapefiles", shapefilename)))
            {
                Assert.IsTrue(fs.IsVector, "File is not a shapefile");
                // Close feature set:
                fs.Close();
            }
        }

        [Test, TestCaseSource("FrenchShapefiles")]
        public void HasInvalidShapes(string shapefilename)
        {
            using (var fs = new FeatureSet(Path.Combine(FranceProjectPath, "Shapefiles", shapefilename)))
            {
                Assert.IsFalse(fs.HasInvalidShapes(), "Shapefile has invalid shapes");
                // Close feature set:
                fs.Close();
            }
        }

        [Test, TestCaseSource("FrenchShapefiles")]
        public void FeatureSet(string shapefilename)
        {
            using (var fs = new FeatureSet(Path.Combine(FranceProjectPath, "Shapefiles", shapefilename)))
            {
                Debug.Print("Geometry type: " + fs.GeometryType);
                Debug.Print("Number of features: " + fs.Features.Count());

                using (var g = fs.Features.First().Geometry)
                {
                    foreach (var pnt in g.Points)
                    {
                        Debug.Print("X: {0}; Y: {1}", pnt.X, pnt.Y);
                    }

                    var bytes = g.ExportToBinary();
                    Assert.IsNotNull(bytes, "ExportToBinary returned null");
                    Debug.Print("Number of points: " + g.Points.Count);
                    using (var g2 = new Geometry(g.GeometryType))
                    {
                        var result = g2.ImportFromBinary(bytes);
                        Assert.IsTrue(result, "ImportFromBinary failed");
                        Debug.Print("Imported: {0}", g2.Points.Count);
                    }
                }
                fs.Close();
            }
        }

        [Test]
        public void Fields()
        {
            var filename = Path.Combine(UsaShapefilesPath, "cities.shp");
            using (var fs = new FeatureSet(filename))
            {
                foreach (var ft in fs.Features)
                {
                    Debug.Print("Number of points: " + ft.Geometry.Points.Count);

                    for (int i = 0; i < ft.NumFields; i++)
                    {
                        var fld = ft.GetField(i);
                        Debug.Print("{0}: {1}", fld.Name, ft.GetValue(i));
                    }
                    //var values = ft.Values;
                    //for (int i = 0; i < values.Count; i++)
                    //{
                    //    var fld = values.GetField(i);
                    //    Debug.Print("{0}: {1}", fld.Name, values.GetAsString(i));
                    //}
                }
                fs.Close();
            }
        }

        [Test]
        public void Image()
        {
            using (var bmp = BitmapSource.Open(Path.Combine(WorldProjectPath, "Raster", "NE2_50M_SR.jpg"), false))
            {
                Assert.IsNotNull(bmp, "Couldn't open BitmapSource");
                Debug.Print("Width: " + bmp.Width);
                Debug.Print("Height: " + bmp.Height);
                Debug.Print("BitmapSource: " + (bmp is BitmapSource));
                bmp.Close();
            }
        }

        [Test]
        public void Labels()
        {
            var filename = Path.Combine(UsaShapefilesPath, "cities.shp");
            var fs = new FeatureSet(filename);

            int count = fs.Labels.Generate("[type]", LabelPosition.Centroid);
            Debug.Print("Labels generated: " + count);

            var labels = fs.Labels.Items;
            foreach (var lbl in labels)
            {
                Debug.Print(lbl.Text);
            }
        }

        [Test]
        public void LoadImage()
        {
            //var bmp = BitmapSource.Open(@"d:\data\raster\Clip_L7_20000423_B2.tif", false);
            //int handle = mapControl1.Layers.Add(bmp);
            //Debug.Print("Image is loaded: " + handle);
            //Debug.Print("Width: " + bmp.Width);
            //Debug.Print("Height: " + bmp.Height);
        }

        [Test]
        public void LoadShapefile()
        {
            using (var fs = new FeatureSet(Path.Combine(UsaShapefilesPath, "cities.shp")))
            {
                var fill = fs.Style.Fill;
                fill.Color = Color.LightGreen;
                fill.Type = FillType.Solid;
                //fill.HatchStyle = HatchStyle.Cross;
                //fill.BackgroundHatchColor = Color.Moccasin;
                //fill.BackgroundHatchTransparent = false;

                //foreach (var ft in fs.Features)
                //{
                //    ft.Selected = true;
                //}

                if (fs.Categories.GenerateUniqueValues("Type"))
                {
                    Debug.Print("Number of categories generated: " + fs.Categories.Count);
                    foreach (var ct in fs.Categories)
                    {
                        Debug.Print("Expression: " + ct.Expression);
                    }
                }
                else
                {
                    Assert.Fail("Could not generate categories");
                }
                fs.Categories.ApplyExpressions();
                fs.Categories.ApplyColorScheme(SchemeType.Graduated, new ColorRamp(Color.Yellow, Color.Red));

                fs.Labels.Generate("[Type]", LabelPosition.Centroid);
                var style = fs.Labels.Style;
                style.FontColor = Color.White;
                style.FrameBackColor = Color.Gray;

                //mapControl1.Layers.Add(fs);
                //mapControl1.MapCursor = MapCursor.SelectByPolygon;
                //fs = new FeatureSet(@"d:\data\sf\landuse.shp");
                //mapControl1.Layers.Add(fs);

                fs.Close();
            }
        }

        [Test]
        public void TestBands()
        {
            Debug.WriteLine("In TestBands");
            using (var raster = BitmapSource.Open(Path.Combine(FranceProjectPath, "Rasters", "DTM75.vrt"), false) as IRasterSource)
            {
                Assert.IsNotNull(raster, "Could not open raster");
                foreach (var band in raster.Bands)
                {
                    Debug.Print("BAND: ");
                    Debug.Print("No data value: " + band.NoDataValue);
                    Debug.Print("Minimum: " + band.Minimum);
                    Debug.Print("Maximum: " + band.Maximum);
                    Debug.Print("Overview count: " + band.Overviews.Count);
                    Debug.Print("Color interpretation: " + band.ColorInterpretation);
                }
                raster.Close();
            }
        }

        // TODO Make more generic connection string
        // [Test]
        public void VectorDatasource()
        {
            const string connection = "PG:dbname=london host=localhost user=postgres password=1234";
            var ds = new VectorDatasource(connection);
            foreach (VectorLayer layer in ds)
            {
                Debug.Print("Layer: " + layer.Name);
            }

            var lyr = ds.GetLayer(0);
            var fs = lyr.Data.Features;
            Debug.Print("Number of features: " + fs.Count());

            int count = 0;
            foreach (var ft in fs)
            {
                Debug.Print("Feature: {0}; Number of points: {1}", count++, ft.Geometry.Points.Count);
            }
        }
    }
}