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
    using System.Globalization;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
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

            // TODO: Doesn't work:
            this.axMap1.GlobalCallback = this;
            this.axMap1.Tiles.GlobalCallback = this;

            // Tiles settings:
            this.axMap1.Tiles.AutodetectProxy();
            this.axMap1.Tiles.DoCaching[tkCacheType.Disk] = true;

            // probably better to turn if off otherwise on second run nothing will be downloaded (everything in cache)  
            this.axMap1.Tiles.UseCache[tkCacheType.Disk] = false;
            this.axMap1.Tiles.UseServer = true;

            var gs = new GlobalSettingsClass { GridProxyFormat = tkGridProxyFormat.gpfTiffProxy };
            this.statusStripProgressBar.Minimum = 0;
            this.statusStripProgressBar.Maximum = 100;
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
            MessageBox.Show(errorMsg, @"Error");
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
        private void AxMap1FileDropped(object sender, AxMapWinGIS._DMapEvents_FileDroppedEvent e)
        {
            this.statusStripProgressBar.Value = 0;
            this.axMap1.FileManager.GlobalCallback = this;

            // TODO use async:
            var hndl = this.axMap1.AddLayerFromFilename(e.filename, tkFileOpenStrategy.fosAutoDetect, true);
            if (hndl == -1)
            {
                return;
            }

            // Check if a symbology file is present:
            var symbFilename = e.filename + ".mwsymb";
            if (File.Exists(symbFilename))
            {
                var layerDesc = string.Empty;
                this.axMap1.LoadLayerOptions(hndl, string.Empty, ref layerDesc);
            }

            // Redraw map:
            this.axMap1.Redraw2(tkRedrawType.RedrawAll);

            // Add t0 legend:
            var nodeName = this.axMap1.get_LayerName(hndl);
            if (nodeName == string.Empty)
            {
                nodeName = Path.GetFileNameWithoutExtension(this.axMap1.get_LayerFilename(hndl));
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
            // Projection:
            var projection = this.axMap1.Projection.ToString();
            var geoProjection = this.axMap1.GeoProjection;
            if (geoProjection != null)
            {
                int epsgCode;
                if (geoProjection.TryAutoDetectEpsg(out epsgCode))
                {
                    projection = epsgCode.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    if (geoProjection.ProjectionName != "unnamed")
                    {
                        projection = geoProjection.ProjectionName;
                    }
                }
            }

            // Workaround:
            if (this.axMap1.Projection == tkMapProjection.PROJECTION_GOOGLE_MERCATOR)
            {
                projection = "EPSG:3857";
            }

            if (this.axMap1.Projection == tkMapProjection.PROJECTION_WGS84)
            {
                projection = "WGS84";
            }

            this.statusStripProjection.Text = projection;

            // MapUnits:
            this.statusStripMapUnits.Text = this.axMap1.MapUnits.ToString();

            // Tiles
            var tiles = this.axMap1.Tiles;
            if (tiles.Visible)
            {
                this.statusStripTilesProvider.Text = tiles.ProviderName;
                this.statusStripZoomLevels.Enabled = true;
                this.statusStripZoomLevels.Minimum = tiles.minZoom;
                this.statusStripZoomLevels.Maximum = tiles.maxZoom;
                this.statusStripZoomLevels.Value = tiles.CurrentZoom;
            }
            else
            {
                this.statusStripTilesProvider.Text = @"Disabled";
                this.statusStripZoomLevels.Enabled = false;
            }
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
            // Reset status strip:
            this.SetStatusstripControls();
        }

        /// <summary>
        /// The status strip zoom levels value changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void StatusStripZoomLevelsValueChanged(object sender, EventArgs e)
        {
            // update zoomlevel:
            this.axMap1.ZoomToTileLevel(this.statusStripZoomLevels.Value);
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
        private void AxMap1MouseMoveEvent(object sender, AxMapWinGIS._DMapEvents_MouseMoveEvent e)
        {
            // TODO Much too slow and wrong coordinates
            double projX = 0;
            double projY = 0;
            this.axMap1.PixelToProj(e.x, e.y, ref projX, ref projY);
            var coordinates = projX.ToString(CultureInfo.InvariantCulture) + "; "
                                 + projY.ToString(CultureInfo.InvariantCulture);

            this.statusStripCoordinates.Text = coordinates;
        }

        /// <summary>
        /// The map extents changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void AxMap1ExtentsChanged(object sender, EventArgs e)
        {
            // Update trackbar:
            this.statusStripZoomLevels.Value = this.axMap1.CurrentZoom;
        }
    }
}
