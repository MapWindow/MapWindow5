using System.Windows.Forms;

namespace MW5.Configuration
{
    partial class WidgetsConfigPage
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
            this.configPanelControl1 = new MW5.UI.Controls.ConfigPanelControl();
            this.cboScalebarUnits = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label4 = new System.Windows.Forms.Label();
            this.chkShowScalebar = new CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboZoombarVerbosity = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkShowZoombar = new CheckBox();
            this.chkShowRedrawTime = new CheckBox();
            this.udCoordinatePrecision = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cboAngleFormat = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label11 = new System.Windows.Forms.Label();
            this.cboCoordinateDisplay = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label10 = new System.Windows.Forms.Label();
            this.chkShowCoordinates = new CheckBox();
            this.configPanelControl2 = new MW5.UI.Controls.ConfigPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).BeginInit();
            this.configPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboScalebarUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboZoombarVerbosity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCoordinatePrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAngleFormat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCoordinateDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // configPanelControl1
            // 
            this.configPanelControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl1.Controls.Add(this.cboScalebarUnits);
            this.configPanelControl1.Controls.Add(this.label4);
            this.configPanelControl1.Controls.Add(this.chkShowScalebar);
            this.configPanelControl1.Controls.Add(this.label2);
            this.configPanelControl1.Controls.Add(this.cboZoombarVerbosity);
            this.configPanelControl1.Controls.Add(this.chkShowZoombar);
            this.configPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl1.HeaderText = "Map widgets";
            this.configPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.configPanelControl1.Name = "configPanelControl1";
            this.configPanelControl1.Size = new System.Drawing.Size(443, 130);
            this.configPanelControl1.TabIndex = 17;
            // 
            // cboScalebarUnits
            // 
            this.cboScalebarUnits.BeforeTouchSize = new System.Drawing.Size(173, 21);
            this.cboScalebarUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScalebarUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboScalebarUnits.Location = new System.Drawing.Point(242, 84);
            this.cboScalebarUnits.Name = "cboScalebarUnits";
            this.cboScalebarUnits.Size = new System.Drawing.Size(173, 21);
            this.cboScalebarUnits.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "units";
            // 
            // chkShowScalebar
            // 
            this.chkShowScalebar.Location = new System.Drawing.Point(16, 84);
            this.chkShowScalebar.Name = "chkShowScalebar";
            this.chkShowScalebar.Size = new System.Drawing.Size(126, 21);
            this.chkShowScalebar.TabIndex = 16;
            this.chkShowScalebar.Text = "Show scale bar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "verbosity";
            // 
            // cboZoombarVerbosity
            // 
            this.cboZoombarVerbosity.BeforeTouchSize = new System.Drawing.Size(173, 21);
            this.cboZoombarVerbosity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZoombarVerbosity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboZoombarVerbosity.Location = new System.Drawing.Point(242, 40);
            this.cboZoombarVerbosity.Name = "cboZoombarVerbosity";
            this.cboZoombarVerbosity.Size = new System.Drawing.Size(173, 21);
            this.cboZoombarVerbosity.TabIndex = 14;
            // 
            // chkShowZoombar
            // 
            this.chkShowZoombar.Location = new System.Drawing.Point(16, 40);
            this.chkShowZoombar.Name = "chkShowZoombar";
            this.chkShowZoombar.Size = new System.Drawing.Size(188, 21);
            this.chkShowZoombar.TabIndex = 13;
            this.chkShowZoombar.Text = "Show zoombar";
            // 
            // chkShowRedrawTime
            // 
            this.chkShowRedrawTime.Location = new System.Drawing.Point(16, 149);
            this.chkShowRedrawTime.Name = "chkShowRedrawTime";
            this.chkShowRedrawTime.Size = new System.Drawing.Size(188, 21);
            this.chkShowRedrawTime.TabIndex = 10;
            this.chkShowRedrawTime.Text = "Show redraw time";
            // 
            // udCoordinatePrecision
            // 
            this.udCoordinatePrecision.Enabled = false;
            this.udCoordinatePrecision.Location = new System.Drawing.Point(242, 120);
            this.udCoordinatePrecision.Name = "udCoordinatePrecision";
            this.udCoordinatePrecision.Size = new System.Drawing.Size(75, 20);
            this.udCoordinatePrecision.TabIndex = 25;
            this.udCoordinatePrecision.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(169, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "precision";
            // 
            // cboAngleFormat
            // 
            this.cboAngleFormat.BeforeTouchSize = new System.Drawing.Size(173, 21);
            this.cboAngleFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAngleFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboAngleFormat.Location = new System.Drawing.Point(242, 82);
            this.cboAngleFormat.Name = "cboAngleFormat";
            this.cboAngleFormat.Size = new System.Drawing.Size(173, 21);
            this.cboAngleFormat.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(169, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "angle format";
            // 
            // cboCoordinateDisplay
            // 
            this.cboCoordinateDisplay.BeforeTouchSize = new System.Drawing.Size(173, 21);
            this.cboCoordinateDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoordinateDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboCoordinateDisplay.Location = new System.Drawing.Point(242, 42);
            this.cboCoordinateDisplay.Name = "cboCoordinateDisplay";
            this.cboCoordinateDisplay.Size = new System.Drawing.Size(173, 21);
            this.cboCoordinateDisplay.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(169, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "display type";
            // 
            // chkShowCoordinates
            // 
            this.chkShowCoordinates.Location = new System.Drawing.Point(16, 42);
            this.chkShowCoordinates.Name = "chkShowCoordinates";
            this.chkShowCoordinates.Size = new System.Drawing.Size(126, 21);
            this.chkShowCoordinates.TabIndex = 19;
            this.chkShowCoordinates.Text = "Show coordinates";
            // 
            // configPanelControl2
            // 
            this.configPanelControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl2.Controls.Add(this.chkShowRedrawTime);
            this.configPanelControl2.Controls.Add(this.label10);
            this.configPanelControl2.Controls.Add(this.udCoordinatePrecision);
            this.configPanelControl2.Controls.Add(this.chkShowCoordinates);
            this.configPanelControl2.Controls.Add(this.label12);
            this.configPanelControl2.Controls.Add(this.cboCoordinateDisplay);
            this.configPanelControl2.Controls.Add(this.cboAngleFormat);
            this.configPanelControl2.Controls.Add(this.label11);
            this.configPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl2.HeaderText = "Information";
            this.configPanelControl2.Location = new System.Drawing.Point(0, 130);
            this.configPanelControl2.Name = "configPanelControl2";
            this.configPanelControl2.Size = new System.Drawing.Size(443, 185);
            this.configPanelControl2.TabIndex = 18;
            // 
            // WidgetsConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.configPanelControl2);
            this.Controls.Add(this.configPanelControl1);
            this.Name = "WidgetsConfigPage";
            this.Size = new System.Drawing.Size(443, 321);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).EndInit();
            this.configPanelControl1.ResumeLayout(false);
            this.configPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboScalebarUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboZoombarVerbosity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCoordinatePrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAngleFormat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCoordinateDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            this.configPanelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.ConfigPanelControl configPanelControl1;
        private CheckBox chkShowRedrawTime;
        private System.Windows.Forms.NumericUpDown udCoordinatePrecision;
        private System.Windows.Forms.Label label12;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboAngleFormat;
        private System.Windows.Forms.Label label11;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboCoordinateDisplay;
        private System.Windows.Forms.Label label10;
        private CheckBox chkShowCoordinates;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboScalebarUnits;
        private System.Windows.Forms.Label label4;
        private CheckBox chkShowScalebar;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboZoombarVerbosity;
        private CheckBox chkShowZoombar;
        private UI.Controls.ConfigPanelControl configPanelControl2;
    }
}
