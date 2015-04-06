namespace MW5.Controls
{
    partial class LegendDockPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.legendControl1 = new MW5.Api.Legend.LegendControl(this.components);
            this.contextMenuStripEx1 = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            this.mnuZoomToLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpenFileLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // legendControl1
            // 
            this.legendControl1.BackColor = System.Drawing.Color.White;
            this.legendControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legendControl1.DrawLines = true;
            this.legendControl1.Location = new System.Drawing.Point(0, 0);
            this.legendControl1.Map = null;
            this.legendControl1.Name = "legendControl1";
            this.legendControl1.SelectedLayer = null;
            this.legendControl1.SelectedLayerHandle = -1;
            this.legendControl1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.legendControl1.ShowGroupIcons = true;
            this.legendControl1.ShowLabels = false;
            this.legendControl1.Size = new System.Drawing.Size(233, 325);
            this.legendControl1.TabIndex = 0;
            // 
            // contextMenuStripEx1
            // 
            this.contextMenuStripEx1.DropShadowEnabled = false;
            this.contextMenuStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuZoomToLayer,
            this.toolStripSeparator1,
            this.mnuSaveStyle,
            this.mnuLoadStyle,
            this.toolStripSeparator2,
            this.mnuOpenFileLocation,
            this.mnuRemoveLayer,
            this.toolStripSeparator3,
            this.mnuProperties});
            this.contextMenuStripEx1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(236)))), ((int)(((byte)(249)))));
            this.contextMenuStripEx1.Name = "contextMenuStripEx1";
            this.contextMenuStripEx1.Size = new System.Drawing.Size(169, 154);
            this.contextMenuStripEx1.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.Metro;
            // 
            // mnuZoomToLayer
            // 
            this.mnuZoomToLayer.Name = "mnuZoomToLayer";
            this.mnuZoomToLayer.Size = new System.Drawing.Size(168, 22);
            this.mnuZoomToLayer.Text = "Zoom to layer";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuSaveStyle
            // 
            this.mnuSaveStyle.Name = "mnuSaveStyle";
            this.mnuSaveStyle.Size = new System.Drawing.Size(168, 22);
            this.mnuSaveStyle.Text = "Save layer style";
            // 
            // mnuLoadStyle
            // 
            this.mnuLoadStyle.Name = "mnuLoadStyle";
            this.mnuLoadStyle.Size = new System.Drawing.Size(168, 22);
            this.mnuLoadStyle.Text = "Load layer style";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuOpenFileLocation
            // 
            this.mnuOpenFileLocation.Name = "mnuOpenFileLocation";
            this.mnuOpenFileLocation.Size = new System.Drawing.Size(168, 22);
            this.mnuOpenFileLocation.Text = "Open file location";
            // 
            // mnuRemoveLayer
            // 
            this.mnuRemoveLayer.Name = "mnuRemoveLayer";
            this.mnuRemoveLayer.Size = new System.Drawing.Size(168, 22);
            this.mnuRemoveLayer.Text = "Remove layer";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuProperties
            // 
            this.mnuProperties.Name = "mnuProperties";
            this.mnuProperties.Size = new System.Drawing.Size(168, 22);
            this.mnuProperties.Text = "Properties";
            // 
            // LegendDockPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.legendControl1);
            this.Name = "LegendDockPanel";
            this.Size = new System.Drawing.Size(233, 325);
            this.contextMenuStripEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Api.Legend.LegendControl legendControl1;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx contextMenuStripEx1;
        private System.Windows.Forms.ToolStripMenuItem mnuZoomToLayer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveStyle;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadStyle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenFileLocation;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveLayer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuProperties;
    }
}
