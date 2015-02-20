using System.Diagnostics;
using System.Linq;
using MW5.Core;
using MW5.Core.Concrete;

namespace MW5.ConsoleTest
{
    public static class Tests
    {
        public static void TestVectorDatasource()
        {
            string connection = "PG:dbname=london host=localhost user=postgres password=1234";
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
        
        public static void TestAttributeTable()
        {
            const string filename = @"d:\data\sf\buildings.shp";
            var fs = new FeatureSet(filename);
            foreach (var fld in fs.Table.Fields)
            {
                Debug.Print("Field: " + fld.Name);
            }
        }

        public static void TestImage()
        {
            var bmp = BitmapSource.Open(@"d:\data\raster\volk.bmp", false);

            Debug.Print("Width: " + bmp.Width);
            Debug.Print("Height: " + bmp.Height);
            Debug.Print("BitmapSource: " + (bmp is BitmapSource));
        }

        public static void TestLabels()
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

        public static void TestFeatureSet()
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

        public static void TestFields()
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
    }
}
