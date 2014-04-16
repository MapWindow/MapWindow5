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
    using System.IO;
    using System.Windows.Forms;

    using MapWinGIS;

    using Syncfusion.Windows.Forms.Tools;

    /// <summary>
    /// The main form.
    /// </summary>
    public partial class MainForm : Syncfusion.Windows.Forms.MetroForm, ICallback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();

            // TODO: Doesn't work:
            //this.axMap1.GlobalCallback = this;

            var gs = new GlobalSettingsClass { GridProxyFormat = tkGridProxyFormat.gpfTiffProxy };
            this.toolStripProgressBar1.Minimum = 0;
            this.toolStripProgressBar1.Maximum = 100;
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
            throw new NotImplementedException();
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
            this.toolStripProgressBar1.Value = percent;
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

            // Clear legend
            if (this.Legend.Nodes[0].Nodes.Count > 0)
            {
                for (var i = this.Legend.Nodes[0].Nodes.Count - 1; i >= 0; i--)
                {
                    this.Legend.Nodes[0].Nodes[i].Remove();
                }
            }
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
            this.toolStripProgressBar1.Value = 0;

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
        }
    }
}
