using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MW5.Core;
using MW5.Core.Concrete;
using MW5.Core.Events;

namespace MW5.GuiTest
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
            //LoadShapefile();
            //mapControl1.Cursor
            TestTiles();
        }

        private void TestTiles()
        {
            var providers = mapControl1.Tiles.Providers;
            foreach (var p in providers)
            {
                Debug.Print("Name: " + p.Name);
                Debug.Print("Url pattern: " + p.UrlPattern);
                Debug.Print("Version: " + p.Version);
                Debug.Print("------");
            }
        }

        private void LoadImage()
        {
            var bmp = BitmapSource.Open(@"d:\data\raster\Clip_L7_20000423_B2.tif", false);
            int handle = mapControl1.Layers.Add(bmp);
            Debug.Print("Image is loaded: " + handle);
            Debug.Print("Width: " + bmp.Width);
            Debug.Print("Height: " + bmp.Height);
        }

        private void LoadShapefile()
        {
            var fs = new FeatureSet(@"d:\data\sf\buildings.shp");
            var fill = fs.Style.Fill;
            fill.Color = Color.LightGreen;
            fill.FillType = FillType.Solid;
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
            fs.Categories.ApplyColorRamp(ColorRampType.Graduated, new ColorRamp(Color.Yellow, Color.Red));

            fs.Labels.Generate("[Type]", LabelPosition.Centroid);
            var style = fs.Labels.Style;
            style.FontColor = Color.White;
            style.FrameBackColor = Color.Gray;

            mapControl1.Layers.Add(fs);
            
            mapControl1.MapCursor = MapCursor.SelectByPolygon;

            fs = new FeatureSet(@"d:\data\sf\landuse.shp");
            mapControl1.Layers.Add(fs);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mapControl1.ChooseLayer += mapControl1_ChooseLayer;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            mapControl1.ChooseLayer -= mapControl1_ChooseLayer;
        }

        void mapControl1_ChooseLayer(object sender, ChooseLayerEventArgs e)
        {
            e.LayerHandle = 0;
            MessageBox.Show("Choose layer");
        }
    }
}
