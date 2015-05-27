namespace MW5.Configuration
{
    partial class MapConfigPage
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
            this.configPanelControl2 = new MW5.UI.Controls.ConfigPanelControl();
            this.chkShowRedrawTime = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowRedrawTime)).BeginInit();
            this.SuspendLayout();
            // 
            // configPanelControl2
            // 
            this.configPanelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configPanelControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl2.Controls.Add(this.chkShowRedrawTime);
            this.configPanelControl2.HeaderText = "Map options";
            this.configPanelControl2.Location = new System.Drawing.Point(7, 13);
            this.configPanelControl2.Name = "configPanelControl2";
            this.configPanelControl2.Size = new System.Drawing.Size(370, 149);
            this.configPanelControl2.TabIndex = 8;
            // 
            // chkShowRedrawTime
            // 
            this.chkShowRedrawTime.BeforeTouchSize = new System.Drawing.Size(188, 21);
            this.chkShowRedrawTime.Location = new System.Drawing.Point(16, 38);
            this.chkShowRedrawTime.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkShowRedrawTime.Name = "chkShowRedrawTime";
            this.chkShowRedrawTime.Size = new System.Drawing.Size(188, 21);
            this.chkShowRedrawTime.TabIndex = 10;
            this.chkShowRedrawTime.Text = "Show redraw time";
            this.chkShowRedrawTime.ThemesEnabled = false;
            // 
            // MapConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.configPanelControl2);
            this.Name = "MapConfigPage";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(390, 297);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkShowRedrawTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkShowRedrawTime;
        private UI.Controls.ConfigPanelControl configPanelControl2;

    }
}
