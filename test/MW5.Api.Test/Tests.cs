using System.Diagnostics;
using System.Drawing;
using System.Linq;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Shared;
using NUnit.Framework;

namespace MW5.API.Test
{
    // TODO: add verification conditions
    //[TestFixture]
    public class Tests
    {
        [Test]
        public void Callback()
        {
            var cb = new CustomCallback();
            ApplicationCallback.Attach(cb);

            var fs = new FeatureSet(@"d:\data\sf\buildings.shp");
            fs.StartEditingShapes();
            fs.Close();
        }

        [Test]
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

        [Test]
        public void AttributeTable()
        {
            const string filename = @"d:\data\sf\buildings.shp";
            var fs = new FeatureSet(filename);
            foreach (var fld in fs.Table.Fields)
            {
                Debug.Print("Field: " + fld.Name);
            }
        }

        [Test]
        public void Image()
        {
            var bmp = BitmapSource.Open(@"d:\data\raster\volk.bmp", false);

            Debug.Print("Width: " + bmp.Width);
            Debug.Print("Height: " + bmp.Height);
            Debug.Print("BitmapSource: " + (bmp is BitmapSource));
        }

        [Test]
        public void Labels()
        {
            const string filename = @"d:\data\sf\buildings.shp";
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
        public void FeatureSet()
        {
            const string filename = @"d:\data\sf\buildings.shp";
            var fs = new FeatureSet(filename);
            Debug.Print("Geometry type: " + fs.GeometryType);
            Debug.Print("Number of features: " + fs.Features.Count());

            var g = fs.Features.First().Geometry;
            foreach (var pnt in g.Points)
            {
                Debug.Print("X: {0}; Y: {1}", pnt.X, pnt.Y);
            }

            var bytes = g.ExportToBinary();
            if (bytes != null)
            {
                Debug.Print("Number of points: " + g.Points.Count);
                var g2 = new Geometry(g.GeometryType);
                bool result = g2.ImportFromBinary(bytes);
                Debug.Print("Imported: {0} {1}", result, g2.Points.Count);
            }
        }

        [Test]
        public void Fields()
        {
            const string filename = @"d:\data\sf\buildings.shp";
            var fs = new FeatureSet(filename);

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
            var fs = new FeatureSet(@"d:\data\sf\buildings.shp");
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
            fs.Categories.ApplyExpressions();
            fs.Categories.ApplyColorScheme(ColorRampType.Graduated, new ColorRamp(Color.Yellow, Color.Red));

            fs.Labels.Generate("[Type]", LabelPosition.Centroid);
            var style = fs.Labels.Style;
            style.FontColor = Color.White;
            style.FrameBackColor = Color.Gray;

            //mapControl1.Layers.Add(fs);
            
            //mapControl1.MapCursor = MapCursor.SelectByPolygon;

            //fs = new FeatureSet(@"d:\data\sf\landuse.shp");
            //mapControl1.Layers.Add(fs);
        }

        private void TestBands()
        {
            string filename = "";   // TODO: set filename
            var raster = BitmapSource.Open(filename, false) as IRasterSource;
            if (raster != null)
            {
                var logger = Logger.Current;
                foreach (var band in raster.Bands)
                {
                    logger.Info("BAND: ");
                    logger.Info("No data value: " + band.NoDataValue);
                    logger.Info("Minimum: " + band.Minimum);
                    logger.Info("Maximum: " + band.Maximum);
                    logger.Info("Overview count: " + band.OverviewCount);
                    logger.Info("Color interpretation: " + band.ColorInterpretation);
                }
            }
        }
    }
}
