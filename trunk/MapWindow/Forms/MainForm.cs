using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MapWindow
{
    using System.IO;
    using System.Runtime.Remoting.Messaging;

    using MapWinGIS;

    public partial class MainForm : Syncfusion.Windows.Forms.MetroForm, MapWinGIS.ICallback
    {
        public MainForm()
        {
            InitializeComponent();

            // TODO: Doesn't work:
            //this.axMap1.GlobalCallback = this;

            var gs = new GlobalSettingsClass { GridProxyFormat = tkGridProxyFormat.gpfTiffProxy };
            this.toolStripProgressBar1.Minimum = 0;
            this.toolStripProgressBar1.Maximum = 100;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
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

        private void axMap1_FileDropped(object sender, AxMapWinGIS._DMapEvents_FileDroppedEvent e)
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

        public void Error(string KeyOfSender, string ErrorMsg)
        {
            throw new NotImplementedException();
        }

        public void Progress(string KeyOfSender, int Percent, string Message)
        {
            this.toolStripProgressBar1.Value = Percent;
        }
    }
}
