// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddLayersForm.cs" company="TopX Geo-ICT, The Netherlands">
//   MPL
// </copyright>
// <summary>
//   Form to select and open geospatial data
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MapWindow.Forms
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Web.UI.Design;
    using System.Windows.Forms;
    
    using MapWinGIS;
    using Syncfusion.Windows.Forms.Tools;

    using Point = System.Drawing.Point;
    using TabSizeMode = Syncfusion.Windows.Forms.Tools.TabSizeMode;

    /// <summary>
    /// The add layers form.
    /// </summary>
    public partial class AddLayersForm : Syncfusion.Windows.Forms.MetroForm
    {
        /// <summary>
        /// The reference to the map.
        /// </summary>
        private readonly AxMapWinGIS.AxMap theMap;

        /// <summary>
        /// The reference to the main form.
        /// </summary>
        private readonly ICallback theMainform;

        /// <summary>
        /// Gets or sets the layer handle.
        /// </summary>
        internal int LayerHandle { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddLayersForm"/> class.
        /// </summary>
        /// <param name="myMap">
        /// The my map.
        /// </param>
        /// <param name="myMainform">
        /// The my mainform.
        /// </param>
        public AddLayersForm(AxMapWinGIS.AxMap myMap, ICallback myMainform)
        {
            this.InitializeComponent();

            // Save references:
            this.theMap = myMap;
            this.theMainform = myMainform;
            this.LayerHandle = -1;

            // Set tab control:
            this.SetTabStyle();
        }

        /// <summary>
        /// Override the on shown event to get this form in the center of its parent
        /// </summary>
        /// <param name="e">
        /// The event arguments
        /// </param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.Owner == null || this.StartPosition != FormStartPosition.Manual)
            {
                return;
            }

            var offset = this.Owner.OwnedForms.Length * 38;  // approx. 10mm
            var p = new Point(this.Owner.Left + (this.Owner.Width / 2) - (this.Width / 2) + offset, this.Owner.Top + (this.Owner.Height / 2) - (this.Height / 2) + offset);
            this.Location = p;
        }

        /// <summary>
        /// Select shapefile.
        /// </summary>
        /// <param name="textBox">
        /// The text box.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        private static void SelectShapefile(Control textBox, string title)
        {
            using (var ofd = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = @"Shapefiles|*.shp",
                Multiselect = false,
                SupportMultiDottedExtensions = true,
                Title = title
            })
            {
                if (textBox.Text != string.Empty)
                {
                    var folder = Path.GetDirectoryName(textBox.Text);
                    if (folder != null)
                    {
                        if (Directory.Exists(folder))
                        {
                            ofd.InitialDirectory = folder;
                        }
                    }
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = ofd.FileName;
                }
            }
        }


        /// <summary>
        /// The set tab style.
        /// </summary>
        private void SetTabStyle()
        {
            this.tabControlAdv1.TabStyle = typeof(TabRenderer3D);
            this.tabControlAdv1.Alignment = TabAlignment.Left;
            this.tabControlAdv1.ItemSize = new Size(50, 130);
            this.tabControlAdv1.SizeMode = TabSizeMode.Fixed;
            this.tabControlAdv1.ActiveTabColor = Color.White;
            this.tabControlAdv1.TabPanelBackColor = Color.FromArgb(183, 212, 241);
            this.tabControlAdv1.TabGap = 10;
        }

        /// <summary>
        /// Override the normal drawing of the tabs
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="drawItemInfo">
        /// The draw item info.
        /// </param>
        private void TabControlAdv1DrawItem(object sender, DrawTabEventArgs drawItemInfo)
        {
            drawItemInfo.DrawBackground();
            drawItemInfo.DrawInterior();

            var rectTab = drawItemInfo.Bounds;
            var g = drawItemInfo.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Create a path for the border
            var gp = new GraphicsPath();

            gp.AddBezier(
                rectTab.Right - 1,
                rectTab.Bottom + 6,
                rectTab.Right - 1,
                rectTab.Bottom + 2,
                rectTab.Left,
                rectTab.Bottom - 3,
                rectTab.Left,
                rectTab.Bottom - 7);
            gp.AddLine(rectTab.Left, rectTab.Bottom - 4, rectTab.Left, rectTab.Top + 5);

            Point[] curvePoints1 =
                {
                    new Point(rectTab.Left, rectTab.Top + 5), 
                    new Point(rectTab.Left + 2, rectTab.Top + 2), 
                    new Point(rectTab.Left + 3, rectTab.Top + 1), 
                    new Point(rectTab.Left + 5, rectTab.Top)
                };
            gp.AddCurve(curvePoints1);
            gp.AddBezier(curvePoints1[0], curvePoints1[1], curvePoints1[2], curvePoints1[3]);
            gp.AddLine(curvePoints1[3], new Point(rectTab.Right - 6, rectTab.Top));
            Point[] curvePoints2 =
                {
                    new Point(rectTab.Right - 6, rectTab.Top), 
                    new Point(rectTab.Right - 2, rectTab.Top - 1), 
                    new Point(rectTab.Right - 2, rectTab.Top - 3), 
                    new Point(rectTab.Right - 1, rectTab.Top - 5)
                };
            gp.AddCurve(curvePoints2);

            if (((int)drawItemInfo.State & (int)DrawItemState.Selected) > 0)
            {
                g.FillPath(new SolidBrush(drawItemInfo.BackColor), gp);

                drawItemInfo.DrawInterior();
            }
            else
            {
                // Draw the Text and Image first
                drawItemInfo.DrawInterior();

                // Then alpha blend active tab color over it
                g.FillPath(new SolidBrush(Color.FromArgb(128, this.tabControlAdv1.ActiveTabColor)), gp);
            }
        }

        /// <summary>
        /// Select shapefile button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SelectShapefileButtonClick(object sender, EventArgs e)
        {
            SelectShapefile(this.SelectShapefileTextbox, "Select shapefile to open");
        }

        /// <summary>
        /// The button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void AddShapefileToMapButton(object sender, EventArgs e)
        {
            // TODO: Check if SelectShapefileTextbox.Text is not empty and if the file exists
 
            // Make form a bit transparent:
            this.Opacity = 0.5;
            Application.DoEvents();

            // reset layer handle:
            this.LayerHandle = -1;

            // Easy way:
            /*
            this.LayerHandle = this.theMap.AddLayerFromFilename(this.SelectShapefileTextbox.Text, tkFileOpenStrategy.fosAutoDetect, true);
            if (this.LayerHandle == -1)
            {
                this.theMainform.Error(string.Empty, "Failed to open datasource: " + this.theMap.FileManager.ErrorMsg[this.theMap.FileManager.LastErrorCode]);
                return;
            }
            */
            
            // More options way:
            var sf = this.OpenShapefile(this.SelectShapefileTextbox.Text);
            
            /*
            // Reproject shapefile:
            var geoprojection = new GeoProjectionClass();
            geoprojection.ImportFromEPSG(3857);
            var reprojectedCount = 0;
            var sfReprojected = sf.Reproject(geoprojection, ref reprojectedCount);
            if (sfReprojected == null)
            {
                MessageBox.Show(sf.ErrorMsg[sf.LastErrorCode]);
            }
            else
            {
                var newFilename = this.SelectShapefileTextbox.Text.Replace(".shp", "-3857.shp");
                if (!sfReprojected.SaveAs(newFilename))
                {
                    MessageBox.Show(sfReprojected.ErrorMsg[sfReprojected.LastErrorCode]);
                }
                else
                {
                    this.theMainform.Progress(null, 0, "Saved as " + newFilename);
                    File.Copy(this.SelectShapefileTextbox.Text + ".mwsymb", newFilename + ".mwsymb");
                    this.LayerHandle = this.theMap.AddLayer(sfReprojected, true);
                }

                this.Close();
                return;
            }
            */

            // For this test use the random coloring:
            // this.ApplyRandomPolygonColors(ref sf);

            // Add to map:
            this.LayerHandle = this.theMap.AddLayer(sf, true);

            // Apply symbology manually in case the shapefile is reprojected:
            // TODO: How to check?
            var description = "Hungary border";
            this.theMap.LoadLayerOptions(this.LayerHandle, this.SelectShapefileTextbox.Text + ".mwsymb", ref description);
            this.theMap.Redraw();

            this.theMainform.Progress(string.Empty, 100, "Done");

            // Close this form:
            this.Close();
        }

        /// <summary>
        /// Apply random polygon colors.
        /// </summary>
        /// <param name="sf">
        /// The sf.
        /// </param>
        private void ApplyRandomPolygonColors(ref Shapefile sf)
        {
            if (sf.ShapefileType != ShpfileType.SHP_POLYGON && sf.ShapefileType != ShpfileType.SHP_POLYGONM
                && sf.ShapefileType != ShpfileType.SHP_POLYGONZ)
            {
                // Nothing to do:
                return;
            }

            var scheme = new ColorScheme();
            scheme.AddBreak(0.0, ColorToUInt(Color.FromArgb(254, 240, 217), true));
            scheme.AddBreak(0.25, ColorToUInt(Color.FromArgb(253, 204, 138), true));
            scheme.AddBreak(0.5, ColorToUInt(Color.FromArgb(252, 141, 89), true));
            scheme.AddBreak(0.75, ColorToUInt(Color.FromArgb(227, 74, 51), true));
            scheme.AddBreak(1.0, ColorToUInt(Color.FromArgb(179, 0, 0), true));
            
            // Set transparency first:
            sf.DefaultDrawingOptions.FillTransparency = 125;

            // Generate unique random polygon colors:
            sf.Categories.GeneratePolygonColors(scheme);
        }

        /// <summary>
        /// Convert color to unsigned integer.
        /// </summary>
        /// <param name="color">
        /// The color.
        /// </param>
        /// <param name="swap">
        /// The swap.
        /// </param>
        /// <returns>
        /// The <see cref="uint"/>.
        /// </returns>
        private static uint ColorToUInt(Color color, bool swap = false)
        {
            if (swap)
            {
                // Known bug: https://groups.google.com/forum/?hl=sv#!msg/microsoft.public.dotnet.framework.windowsforms/i-_U3jeZ9g4/uYENEX0oOjAJ
                return (uint)((color.A << 24) | color.R | (color.G << 8) | (color.B << 16));
            }

            return (uint)((color.A << 24) | (color.R << 16) | (color.G << 8) | (color.B << 0));
        }

        /// <summary>
        /// Open the shapefile.
        /// </summary>
        /// <param name="shapefilename">
        /// The shapefile name.
        /// </param>
        /// <returns>
        /// The <see cref="Shapefile"/>.
        /// </returns>
        private Shapefile OpenShapefile(string shapefilename)
        {
            if (!File.Exists(shapefilename))
            {
                this.theMainform.Error(string.Empty, "Cannot find the file: " + shapefilename);
                return null;
            }

            var sf = new Shapefile { GlobalCallback = this.theMainform };
            this.theMainform.Progress(string.Empty, 0, "Start opening " + Path.GetFileName(shapefilename));
            if (!sf.Open(shapefilename, this.theMainform))
            {
                var msg = string.Format("Error opening shapefile: {0}", sf.ErrorMsg[sf.LastErrorCode]);
                System.Diagnostics.Debug.WriteLine(msg);
                this.theMainform.Error(string.Empty, msg);
                return null;
            }

            return sf;
        }

        private void SelectGridfileButtonClick(object sender, EventArgs e)
        {
            SelectGridfile(this.SelectGridfileTextbox, "Select a grid file");
        }

        /// <summary>Select a grid file</summary>
        /// <param name="textBox">
        /// The text box.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        private static void SelectGridfile(TextBox textBox, string title)
        {
            var grd = new Grid();

            using (var ofd = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = grd.CdlgFilter,
                Multiselect = false,
                SupportMultiDottedExtensions = true,
                Title = title
            })
            {
                if (textBox.Text != string.Empty)
                {
                    var folder = Path.GetDirectoryName(textBox.Text);
                    if (folder != null)
                    {
                        if (Directory.Exists(folder))
                        {
                            ofd.InitialDirectory = folder;
                        }
                    }
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = ofd.FileName;
                }
            }
        }

        private void OpenGridFileButton_Click(object sender, EventArgs e)
        {
            // Make form a bit transparent:
            this.Opacity = 0.5;
            Application.DoEvents();

            // reset layer handle:
            this.LayerHandle = -1;

            // Add layer:
            this.LayerHandle = this.OpenGridfile(this.SelectGridfileTextbox.Text);
            
            // Make the grid a little bit transparent:


            this.theMainform.Progress(string.Empty, 100, "Done");

            // Close this form:
            this.Close();
        }

        private int OpenGridfile(string gridfilename)
        {
            if (!File.Exists(gridfilename))
            {
                this.theMainform.Error(string.Empty, "Cannot find the file: " + gridfilename);
                return -1;
            }

            var hndl = this.theMap.AddLayerFromFilename(gridfilename, tkFileOpenStrategy.fosAutoDetect, true);

            return hndl;
        }

        /// <summary>
        /// The select gridfile textbox text changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SelectGridfileTextboxTextChanged(object sender, EventArgs e)
        {
            var gridfilename = this.SelectGridfileTextbox.Text;

            if (!File.Exists(gridfilename))
            {
                this.GridfilePropertiesTextbox.Text = @"Cannot find the file: " + gridfilename;
                return;
            }

            // Get GDAL info:
            var utils = new UtilsClass();
            var gdalInfo = utils.GDALInfo(gridfilename, "-stats -noct -nogcp -nrat -proj4", this.theMainform);
            if (gdalInfo != null)
            {
                this.GridfilePropertiesTextbox.Text = gdalInfo.Replace("\n", Environment.NewLine);
            }
        }

        /// <summary>
        /// The select shapefile textbox text changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SelectShapefileTextboxTextChanged(object sender, EventArgs e)
        {
            var filename = this.SelectShapefileTextbox.Text;
            if (!File.Exists(filename))
            {
                this.GridfilePropertiesTextbox.Text = @"Cannot find the file: " + filename;
                return;
            }

            // Get OGR info:
            var utils = new UtilsClass();
            var ogrInfo = utils.OGRInfo(
                filename,
                "-so -fields=YES -geom=NO",
                Path.GetFileNameWithoutExtension(filename),
                this.theMainform);
            if (ogrInfo != null)
            {
                this.ShapefileInformationTextbox.Text = ogrInfo.Replace("\n", Environment.NewLine);
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
