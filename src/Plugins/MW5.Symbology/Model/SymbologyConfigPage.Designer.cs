using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.Symbology.Model
{
    partial class SymbologyConfigPage
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
            this.configPanelControl1 = new MW5.UI.Controls.ConfigPanelControl();
            this.btnChartsScheme = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRasterScheme = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnVectorScheme = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.configPanelControl2 = new MW5.UI.Controls.ConfigPanelControl();
            this.btnOpenTextures = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOpenIcons = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTexurePath = new System.Windows.Forms.TextBox();
            this.txtIconPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.icbCharts = new MW5.Plugins.Symbology.Controls.ImageCombo.ColorSchemeCombo();
            this.icbRaster = new MW5.Plugins.Symbology.Controls.ImageCombo.ColorSchemeCombo();
            this.icbVector = new MW5.Plugins.Symbology.Controls.ImageCombo.ColorSchemeCombo();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).BeginInit();
            this.configPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // configPanelControl1
            // 
            this.configPanelControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl1.Controls.Add(this.label6);
            this.configPanelControl1.Controls.Add(this.btnChartsScheme);
            this.configPanelControl1.Controls.Add(this.btnRasterScheme);
            this.configPanelControl1.Controls.Add(this.btnVectorScheme);
            this.configPanelControl1.Controls.Add(this.icbCharts);
            this.configPanelControl1.Controls.Add(this.label3);
            this.configPanelControl1.Controls.Add(this.icbRaster);
            this.configPanelControl1.Controls.Add(this.label2);
            this.configPanelControl1.Controls.Add(this.icbVector);
            this.configPanelControl1.Controls.Add(this.label1);
            this.configPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl1.HeaderText = "Color schemes";
            this.configPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.configPanelControl1.Name = "configPanelControl1";
            this.configPanelControl1.Size = new System.Drawing.Size(425, 206);
            this.configPanelControl1.TabIndex = 0;
            // 
            // btnChartsScheme
            // 
            this.btnChartsScheme.BeforeTouchSize = new System.Drawing.Size(28, 23);
            this.btnChartsScheme.IsBackStageButton = false;
            this.btnChartsScheme.Location = new System.Drawing.Point(279, 159);
            this.btnChartsScheme.Name = "btnChartsScheme";
            this.btnChartsScheme.Size = new System.Drawing.Size(28, 23);
            this.btnChartsScheme.TabIndex = 9;
            this.btnChartsScheme.Text = "...";
            this.btnChartsScheme.Click += new System.EventHandler(this.OnChartsSchemeClick);
            // 
            // btnRasterScheme
            // 
            this.btnRasterScheme.BeforeTouchSize = new System.Drawing.Size(28, 23);
            this.btnRasterScheme.IsBackStageButton = false;
            this.btnRasterScheme.Location = new System.Drawing.Point(279, 118);
            this.btnRasterScheme.Name = "btnRasterScheme";
            this.btnRasterScheme.Size = new System.Drawing.Size(28, 23);
            this.btnRasterScheme.TabIndex = 8;
            this.btnRasterScheme.Text = "...";
            this.btnRasterScheme.Click += new System.EventHandler(this.OnRasterSchemeClick);
            // 
            // btnVectorScheme
            // 
            this.btnVectorScheme.BeforeTouchSize = new System.Drawing.Size(28, 23);
            this.btnVectorScheme.IsBackStageButton = false;
            this.btnVectorScheme.Location = new System.Drawing.Point(279, 77);
            this.btnVectorScheme.Name = "btnVectorScheme";
            this.btnVectorScheme.Size = new System.Drawing.Size(28, 23);
            this.btnVectorScheme.TabIndex = 7;
            this.btnVectorScheme.Text = "...";
            this.btnVectorScheme.Click += new System.EventHandler(this.OnVectorSchemeClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Charts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Raster";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vector";
            // 
            // configPanelControl2
            // 
            this.configPanelControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl2.Controls.Add(this.label7);
            this.configPanelControl2.Controls.Add(this.btnOpenTextures);
            this.configPanelControl2.Controls.Add(this.btnOpenIcons);
            this.configPanelControl2.Controls.Add(this.label5);
            this.configPanelControl2.Controls.Add(this.txtTexurePath);
            this.configPanelControl2.Controls.Add(this.txtIconPath);
            this.configPanelControl2.Controls.Add(this.label4);
            this.configPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl2.HeaderText = "Images and textures";
            this.configPanelControl2.Location = new System.Drawing.Point(0, 206);
            this.configPanelControl2.Name = "configPanelControl2";
            this.configPanelControl2.Size = new System.Drawing.Size(425, 160);
            this.configPanelControl2.TabIndex = 1;
            // 
            // btnOpenTextures
            // 
            this.btnOpenTextures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenTextures.BeforeTouchSize = new System.Drawing.Size(49, 23);
            this.btnOpenTextures.IsBackStageButton = false;
            this.btnOpenTextures.Location = new System.Drawing.Point(361, 119);
            this.btnOpenTextures.Name = "btnOpenTextures";
            this.btnOpenTextures.Size = new System.Drawing.Size(49, 23);
            this.btnOpenTextures.TabIndex = 11;
            this.btnOpenTextures.Text = "Open";
            this.btnOpenTextures.Click += new System.EventHandler(this.OnOpenTexturesClick);
            // 
            // btnOpenIcons
            // 
            this.btnOpenIcons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenIcons.BeforeTouchSize = new System.Drawing.Size(49, 23);
            this.btnOpenIcons.IsBackStageButton = false;
            this.btnOpenIcons.Location = new System.Drawing.Point(361, 79);
            this.btnOpenIcons.Name = "btnOpenIcons";
            this.btnOpenIcons.Size = new System.Drawing.Size(49, 23);
            this.btnOpenIcons.TabIndex = 10;
            this.btnOpenIcons.Text = "Open";
            this.btnOpenIcons.Click += new System.EventHandler(this.OnOpenIconsClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Textures";
            // 
            // txtTexurePath
            // 
            this.txtTexurePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTexurePath.Location = new System.Drawing.Point(99, 121);
            this.txtTexurePath.Name = "txtTexurePath";
            this.txtTexurePath.ReadOnly = true;
            this.txtTexurePath.Size = new System.Drawing.Size(256, 20);
            this.txtTexurePath.TabIndex = 4;
            // 
            // txtIconPath
            // 
            this.txtIconPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIconPath.Location = new System.Drawing.Point(99, 81);
            this.txtIconPath.Name = "txtIconPath";
            this.txtIconPath.ReadOnly = true;
            this.txtIconPath.Size = new System.Drawing.Size(256, 20);
            this.txtIconPath.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Icons";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(313, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Color schemes to be used for vector and raster layers and charts.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(353, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Location of available icons for point layers and textures for polygon layers.";
            // 
            // icbCharts
            // 
            this.icbCharts.ComboStyle = MW5.Api.Enums.SchemeType.Graduated;
            this.icbCharts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbCharts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbCharts.FormattingEnabled = true;
            this.icbCharts.Location = new System.Drawing.Point(102, 161);
            this.icbCharts.Name = "icbCharts";
            this.icbCharts.OutlineColor = System.Drawing.Color.Black;
            this.icbCharts.Size = new System.Drawing.Size(171, 21);
            this.icbCharts.TabIndex = 6;
            this.icbCharts.Scheme = MW5.Plugins.Symbology.SchemeTarget.Charts;
            // 
            // icbRaster
            // 
            this.icbRaster.ComboStyle = MW5.Api.Enums.SchemeType.Graduated;
            this.icbRaster.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbRaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbRaster.FormattingEnabled = true;
            this.icbRaster.Location = new System.Drawing.Point(102, 120);
            this.icbRaster.Name = "icbRaster";
            this.icbRaster.OutlineColor = System.Drawing.Color.Black;
            this.icbRaster.Size = new System.Drawing.Size(171, 21);
            this.icbRaster.TabIndex = 4;
            this.icbRaster.Scheme = MW5.Plugins.Symbology.SchemeTarget.Raster;
            // 
            // icbVector
            // 
            this.icbVector.ComboStyle = MW5.Api.Enums.SchemeType.Graduated;
            this.icbVector.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbVector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbVector.FormattingEnabled = true;
            this.icbVector.Location = new System.Drawing.Point(102, 79);
            this.icbVector.Name = "icbVector";
            this.icbVector.OutlineColor = System.Drawing.Color.Black;
            this.icbVector.Size = new System.Drawing.Size(171, 21);
            this.icbVector.TabIndex = 2;
            this.icbVector.Scheme = MW5.Plugins.Symbology.SchemeTarget.Vector;
            // 
            // SymbologyConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.configPanelControl2);
            this.Controls.Add(this.configPanelControl1);
            this.Name = "SymbologyConfigPage";
            this.Size = new System.Drawing.Size(425, 369);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).EndInit();
            this.configPanelControl1.ResumeLayout(false);
            this.configPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            this.configPanelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.ConfigPanelControl configPanelControl1;
        private Syncfusion.Windows.Forms.ButtonAdv btnChartsScheme;
        private Syncfusion.Windows.Forms.ButtonAdv btnRasterScheme;
        private Syncfusion.Windows.Forms.ButtonAdv btnVectorScheme;
        private Controls.ImageCombo.ColorSchemeCombo icbCharts;
        private System.Windows.Forms.Label label3;
        private Controls.ImageCombo.ColorSchemeCombo icbRaster;
        private System.Windows.Forms.Label label2;
        private Controls.ImageCombo.ColorSchemeCombo icbVector;
        private System.Windows.Forms.Label label1;
        private UI.Controls.ConfigPanelControl configPanelControl2;
        private Syncfusion.Windows.Forms.ButtonAdv btnOpenIcons;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTexurePath;
        private System.Windows.Forms.TextBox txtIconPath;
        private Syncfusion.Windows.Forms.ButtonAdv btnOpenTextures;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
