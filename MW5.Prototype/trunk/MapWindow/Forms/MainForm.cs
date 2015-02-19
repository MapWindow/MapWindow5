// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="TopX Geo-ICT, The Netherlands">
//   MPL
// </copyright>
// <summary>
//   Defines the MainForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MapWindow.Forms
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
 
    using AxMapWinGIS;
    using MapWinGIS;
    using Syncfusion.Windows.Forms.Tools;

    /// <summary>
    /// The main form.
    /// </summary>
    [ComVisible(true)]
    public partial class MainForm : Syncfusion.Windows.Forms.MetroForm, ICallback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="keyOfSender">
        /// The key Of the Sender.
        /// </param>
        /// <param name="errorMsg">
        /// The error message.
        /// </param>
        /// <exception cref="NotImplementedException">Needs to be implemented
        /// </exception>
        public void Error(string keyOfSender, string errorMsg)
        {
            // MessageBox.Show(errorMsg, @"Error");
            this.ProgressTextbox.Text += string.Format("{0}***** ERROR! {1}{0}", Environment.NewLine, errorMsg);
        }

        /// <summary>
        /// The progress.
        /// </summary>
        /// <param name="keyOfSender">
        /// The key Of Sender.
        /// </param>
        /// <param name="percent">
        /// The percent.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Progress(string keyOfSender, int percent, string message)
        {
            this.statusStripProgressBar.Value = percent;

            if (this.statusStripProgressLabel.Text != message)
            {
                this.statusStripProgressLabel.Text = message;
                this.statusStripProgressLabel.Invalidate();
                this.statusStripEx1.Update();
            }

            switch (percent)
            {
                case 0:
                    if (message != string.Empty)
                    {
                        this.ProgressTextbox.AppendText(message + Environment.NewLine);
                    }

                    break;
                case 100:
                    this.ProgressTextbox.AppendText(message + Environment.NewLine);
                    break;
                default:
                    var msg = percent + @"% ... ";
                    this.ProgressTextbox.AppendText(msg);
                    break;
            }
        }

        /// <summary>
        /// Set default settings.
        /// </summary>
        private void SetDefaultSettings()
        {
            // TODO: Save in user config file
            // TODO: Read user config file
            // TODO: Use form to change

            // Tiles settings:
            this.axMap1.Tiles.AutodetectProxy();
            this.axMap1.Tiles.DoCaching[tkCacheType.Disk] = true;

            // probably better to turn if off otherwise on second run nothing will be downloaded (everything in cache)  
            this.axMap1.Tiles.UseCache[tkCacheType.Disk] = false;
            this.axMap1.Tiles.UseServer = true;

            var gs = new GlobalSettingsClass
                         {
                             DefaultColorSchemeForGrids = PredefinedColorScheme.FallLeaves,
                             GeometryEngine = tkGeometryEngine.engineGeos,
                             GridProxyFormat = tkGridProxyFormat.gpfTiffProxy,
                             GridProxyMode = tkGridProxyMode.gpmAuto,
                             RandomColorSchemeForGrids = true,
                             RasterOverviewCreation = tkRasterOverviewCreation.rocYes,
                             RasterOverviewResampling = tkGDALResamplingMethod.grmGauss,
                             SaveGridColorSchemeToFile = true,
                             ShapeInputValidationMode = tkShapeValidationMode.TryFixProceedOnFailure,
                             TiffCompression = tkTiffCompression.tkmJPEG,
                             ZoomToFirstLayer = true,
                             ImageDownsamplingMode = tkInterpolationMode.imBilinear,
                             ImageUpsamplingMode = tkInterpolationMode.imHighQualityBilinear
                         };

            this.statusStripProgressBar.Minimum = 0;
            this.statusStripProgressBar.Maximum = 100;

            // To enable coordinates in status strip:
            this.axMap1.SendMouseMove = true;

            // What to show on the map:
            this.axMap1.ShowCoordinates = tkCoordinatesDisplay.cdmAuto;
            this.axMap1.ShowRedrawTime = false;
            this.axMap1.ShowVersionNumber = true;
            this.axMap1.ShowZoomBar = true;
            this.axMap1.AnimationOnZooming = tkCustomState.csAuto;
            this.axMap1.InertiaOnPanning = tkCustomState.csAuto;
        }

        /// <summary>
        /// The tool strip button 1_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            this.axMap1.Clear();
            this.statusStripProgressLabel.Text = @"Map cleared";

            // Disable tiles:
            this.axMap1.Tiles.Visible = false;

            // Clear legend
            if (this.Legend.Nodes[0].Nodes.Count > 0)
            {
                for (var i = this.Legend.Nodes[0].Nodes.Count - 1; i >= 0; i--)
                {
                    this.Legend.Nodes[0].Nodes[i].Remove();
                }
            }

            // Set default settings:
            this.SetDefaultSettings();

            // Reset status strip:
            this.SetStatusstripControls();
        }

        /// <summary>
        /// The ax map 1 file dropped.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void AxMap1FileDropped(object sender, _DMapEvents_FileDroppedEvent e)
        {
            this.statusStripProgressBar.Value = 0;

            this.statusStripProgressLabel.Text = @"Adding " + Path.GetFileName(e.filename);

            // TODO use async:
            var hndl = this.axMap1.AddLayerFromFilename(e.filename, tkFileOpenStrategy.fosAutoDetect, true);
            if (hndl == -1)
            {
                this.ProgressTextbox.AppendText(
                    "Failed to open datasource: " + this.axMap1.FileManager.ErrorMsg[this.axMap1.FileManager.LastErrorCode]);
                return;
            }

            // Set main form up front:
            this.Activate();

            this.AddToLegend(hndl);

            this.SetStatusstripControls();

            this.statusStripProgressLabel.Text = @"Done";
        }

        /// <summary>
        /// Add to legend.
        /// </summary>
        /// <param name="hndl">
        /// The handle
        /// </param>
        private void AddToLegend(int hndl)
        {
            // Add to legend:
            var nodeName = this.axMap1.get_LayerName(hndl);
            var filename = this.axMap1.get_LayerFilename(hndl);
            if (nodeName == string.Empty)
            {
                nodeName = Path.GetFileNameWithoutExtension(filename);
            }

            var newNode = new TreeNodeAdv(nodeName) { CheckState = CheckState.Checked };

            this.Legend.Nodes[0].Nodes.Insert(0, newNode);
            this.statusStripProgressBar.Value = 100;
        }

        /// <summary>
        /// Set the status strip controls.
        /// </summary>
        private void SetStatusstripControls()
        {
            if (this.axMap1.Tiles.Visible == false && this.axMap1.NumLayers == 0)
            {
                // Nothing loaded so clear all:
                this.statusStripCoordinates.Text = string.Empty;
                this.statusStripMapUnits.Text = string.Empty;
                this.statusStripProjection.Text = string.Empty;
                this.statusStripTilesProvider.Text = @"No tiles";
                return;
            }
            
            // Projection:
            var projection = this.axMap1.Projection.ToString();
            var geoProjection = this.axMap1.GeoProjection;
            if (geoProjection.IsEmpty)
            {
                // Could be a grid file
                // TODO Needs more work:
                var img = this.axMap1.get_Image(0);
                if (img != null)
                {
                    var grd = img.OpenAsGrid();
                    if (!grd.Header.GeoProjection.IsEmpty)
                    {
                        geoProjection = grd.Header.GeoProjection;
                    }
                }
            }

            // Skip if it is still empty:
            if (!geoProjection.IsEmpty)
            {
                int epsgCode;
                if (geoProjection.TryAutoDetectEpsg(out epsgCode))
                {
                    projection = "EPSG:" + epsgCode.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    if (geoProjection.IsProjected)
                    {
                        if (geoProjection.ProjectionName != "unnamed")
                        {
                            projection = geoProjection.ProjectionName;
                        }
                    }

                    if (geoProjection.IsGeographic)
                    {
                        projection = geoProjection.GeogCSName;
                    }

                    // Try again:
                    if (geoProjection.ImportFromWKT(geoProjection.ExportToWKT()))
                    {
                        if (geoProjection.TryAutoDetectEpsg(out epsgCode))
                        {
                            projection = "EPSG:" + epsgCode.ToString(CultureInfo.InvariantCulture);
                        }
                    }

                }
            }

            this.statusStripProjection.Text = projection;

            // MapUnits:
            this.statusStripMapUnits.Text = this.axMap1.MapUnits.ToString().Replace("um", string.Empty);

            // Tiles
            var tiles = this.axMap1.Tiles;
            this.statusStripTilesProvider.Text = tiles.Visible ? tiles.ProviderName : @"No tiles";
        }

        /// <summary>
        /// The main form load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MainFormLoad(object sender, EventArgs e)
        {
            // To avoid flickering:
            this.axMap1.LockWindow(tkLockMode.lmLock);
            this.SuspendLayout();

            // For ICallBack:
            this.axMap1.GlobalCallback = this;
            this.axMap1.Tiles.GlobalCallback = this;
            this.axMap1.FileManager.GlobalCallback = this;

            this.SetDefaultSettings();

            // Get size from settings:
            this.Size = new Size(
                Width = Properties.Settings.Default.MainForm_SizeWidth,
                Height = Properties.Settings.Default.MainForm_SizeHeight);

            // Reset status strip:
            this.SetStatusstripControls();

            this.ResumeLayout();

            // Get zoom level from settings:
            this.axMap1.CurrentZoom = Properties.Settings.Default.CurrentZoomlevel;

            // Get lat/long from settings:
            this.axMap1.Longitude = Properties.Settings.Default.CurrentLongitude;
            this.axMap1.Latitude = Properties.Settings.Default.CurrentLatitude;

            // Enable again:
            this.axMap1.LockWindow(tkLockMode.lmUnlock);
        }

        /// <summary>
        /// The map mouse move event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void AxMap1MouseMoveEvent(object sender, _DMapEvents_MouseMoveEvent e)
        {
            double lat = 0.0, lon = 0.0;
            string coordinates;
            
            if (this.axMap1.PixelToDegrees(e.x, e.y, ref lon, ref lat))
            {
                coordinates = string.Format("{0:0.000}, {1:0.000}", lat, lon);
            }
            else
            {
                double clientX = 0.0, clientY = 0.0;
                this.axMap1.PixelToProj(e.x, e.y, ref clientX, ref clientY);
                coordinates = string.Format("{0:0.00}, {1:0.00}", clientX, clientY);
            }

            this.statusStripCoordinates.Text = coordinates;
            this.statusStripCoordinates.Invalidate();
            this.statusStripEx1.Update();
        }

        /// <summary>
        /// The tool button add layer click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ToolButtonAddLayerClick(object sender, EventArgs e)
        {
            // TODO prevent multiple opens:
            var addLayerForm = new AddLayersForm(this.axMap1, this);
            addLayerForm.ShowDialog(this);

            // get handle of added layer:
            if (addLayerForm.LayerHandle == -1)
            {
                return;
            }

            // Add to legend
            this.AddToLegend(addLayerForm.LayerHandle);

            // Update status strip:
            this.SetStatusstripControls();
        }

        /// <summary>
        /// The main form closing.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the manually settings:
            Properties.Settings.Default.MainForm_windowState = this.WindowState;

            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.MainForm_SizeHeight = this.Size.Height;
                Properties.Settings.Default.MainForm_SizeWidth = this.Size.Width;
            }
            else
            {
                if (this.WindowState == FormWindowState.Minimized) 
                {
                    // Never start minimized
                    Properties.Settings.Default.MainForm_windowState = FormWindowState.Normal;
                }

                Properties.Settings.Default.MainForm_SizeHeight = this.RestoreBounds.Size.Height;
                Properties.Settings.Default.MainForm_SizeWidth = this.RestoreBounds.Size.Width;
            }

            if (this.axMap1.Tiles.Visible)
            {
                Properties.Settings.Default.CurrentZoomlevel = this.axMap1.CurrentZoom;
                Properties.Settings.Default.CurrentLongitude = this.axMap1.Longitude;
                Properties.Settings.Default.CurrentLatitude = this.axMap1.Latitude;
            }

            // Save the settings:
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// The status strip tiles provider double click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void StatusStripTilesProviderDoubleClick(object sender, EventArgs e)
        {
            // Enable default tiling again:
            if (this.axMap1.NumLayers == 0)
            {
                // Set map projection:
                var geoprojection = new GeoProjectionClass();
                geoprojection.ImportFromEPSG(3857);
                this.axMap1.GeoProjection = geoprojection;
            }

            this.axMap1.Tiles.Visible = true;
            this.SetStatusstripControls();
        }
    }
}
