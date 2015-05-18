namespace MW5.Plugins.Symbology.Controls
{
    partial class OverviewControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverviewControl));
            this.configPanelControl1 = new MW5.UI.Controls.ConfigPanelControl();
            this._overviewGrid1 = new MW5.Plugins.Symbology.Controls.OverviewGrid();
            this.btnClearOverviews = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuildOverviews = new Syncfusion.Windows.Forms.ButtonAdv();
            this.cboOverviewType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboOverviewSampling = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).BeginInit();
            this.configPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._overviewGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOverviewType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOverviewSampling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // configPanelControl1
            // 
            this.configPanelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configPanelControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl1.Controls.Add(this._overviewGrid1);
            this.configPanelControl1.Controls.Add(this.btnClearOverviews);
            this.configPanelControl1.Controls.Add(this.label8);
            this.configPanelControl1.Controls.Add(this.btnBuildOverviews);
            this.configPanelControl1.Controls.Add(this.cboOverviewType);
            this.configPanelControl1.Controls.Add(this.label6);
            this.configPanelControl1.Controls.Add(this.label10);
            this.configPanelControl1.Controls.Add(this.cboOverviewSampling);
            this.configPanelControl1.HeaderText = "Pyramid generation";
            this.configPanelControl1.Location = new System.Drawing.Point(4, 111);
            this.configPanelControl1.Name = "configPanelControl1";
            this.configPanelControl1.Size = new System.Drawing.Size(500, 179);
            this.configPanelControl1.TabIndex = 52;
            // 
            // _overviewGrid1
            // 
            this._overviewGrid1.BackColor = System.Drawing.SystemColors.Window;
            this._overviewGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._overviewGrid1.FreezeCaption = false;
            this._overviewGrid1.Location = new System.Drawing.Point(262, 53);
            this._overviewGrid1.Name = "_overviewGrid1";
            this._overviewGrid1.Size = new System.Drawing.Size(221, 110);
            this._overviewGrid1.TabIndex = 50;
            this._overviewGrid1.WrapWithPanel = true;
            // 
            // btnClearOverviews
            // 
            this.btnClearOverviews.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnClearOverviews.IsBackStageButton = false;
            this.btnClearOverviews.Location = new System.Drawing.Point(92, 140);
            this.btnClearOverviews.Name = "btnClearOverviews";
            this.btnClearOverviews.Size = new System.Drawing.Size(75, 23);
            this.btnClearOverviews.TabIndex = 48;
            this.btnClearOverviews.Text = "Clear";
            this.btnClearOverviews.Click += new System.EventHandler(this.btnClearOverviews_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Overview format:";
            // 
            // btnBuildOverviews
            // 
            this.btnBuildOverviews.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnBuildOverviews.IsBackStageButton = false;
            this.btnBuildOverviews.Location = new System.Drawing.Point(11, 140);
            this.btnBuildOverviews.Name = "btnBuildOverviews";
            this.btnBuildOverviews.Size = new System.Drawing.Size(75, 23);
            this.btnBuildOverviews.TabIndex = 47;
            this.btnBuildOverviews.Text = "Generate";
            this.btnBuildOverviews.Click += new System.EventHandler(this.btnBuildOverviews_Click);
            // 
            // cboOverviewType
            // 
            this.cboOverviewType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOverviewType.BeforeTouchSize = new System.Drawing.Size(234, 21);
            this.cboOverviewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOverviewType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboOverviewType.Location = new System.Drawing.Point(11, 53);
            this.cboOverviewType.Name = "cboOverviewType";
            this.cboOverviewType.Size = new System.Drawing.Size(234, 21);
            this.cboOverviewType.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Resampling method:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(283, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Available scales:";
            // 
            // cboOverviewSampling
            // 
            this.cboOverviewSampling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOverviewSampling.BeforeTouchSize = new System.Drawing.Size(235, 21);
            this.cboOverviewSampling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOverviewSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboOverviewSampling.Location = new System.Drawing.Point(10, 102);
            this.cboOverviewSampling.Name = "cboOverviewSampling";
            this.cboOverviewSampling.Size = new System.Drawing.Size(235, 21);
            this.cboOverviewSampling.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(56, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(431, 78);
            this.label9.TabIndex = 51;
            this.label9.Text = resources.GetString("label9.Text");
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(18, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 50;
            this.pictureBox2.TabStop = false;
            // 
            // OverviewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.configPanelControl1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox2);
            this.Name = "OverviewControl";
            this.Size = new System.Drawing.Size(513, 283);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).EndInit();
            this.configPanelControl1.ResumeLayout(false);
            this.configPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._overviewGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOverviewType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOverviewSampling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.Controls.ConfigPanelControl configPanelControl1;
        private Syncfusion.Windows.Forms.ButtonAdv btnClearOverviews;
        private System.Windows.Forms.Label label8;
        private Syncfusion.Windows.Forms.ButtonAdv btnBuildOverviews;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboOverviewType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboOverviewSampling;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private OverviewGrid _overviewGrid1;
    }
}
