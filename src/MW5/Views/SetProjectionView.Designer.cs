namespace MW5.Views
{
    partial class SetProjectionView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.optEmpty = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.optWellKnown = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.optDefinition = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.cboWellKnown = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.txtDefinition = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.optEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optWellKnown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDefinition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWellKnown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefinition)).BeginInit();
            this.SuspendLayout();
            // 
            // optEmpty
            // 
            this.optEmpty.BeforeTouchSize = new System.Drawing.Size(268, 21);
            this.optEmpty.DrawFocusRectangle = false;
            this.optEmpty.Location = new System.Drawing.Point(26, 26);
            this.optEmpty.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.optEmpty.Name = "optEmpty";
            this.optEmpty.Size = new System.Drawing.Size(268, 21);
            this.optEmpty.Style = Syncfusion.Windows.Forms.Tools.RadioButtonAdvStyle.Metro;
            this.optEmpty.TabIndex = 0;
            this.optEmpty.Text = "Empty (will be grabbed from the first layer)";
            this.optEmpty.ThemesEnabled = false;
            // 
            // optWellKnown
            // 
            this.optWellKnown.BeforeTouchSize = new System.Drawing.Size(157, 21);
            this.optWellKnown.DrawFocusRectangle = false;
            this.optWellKnown.Location = new System.Drawing.Point(26, 70);
            this.optWellKnown.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.optWellKnown.Name = "optWellKnown";
            this.optWellKnown.Size = new System.Drawing.Size(157, 21);
            this.optWellKnown.Style = Syncfusion.Windows.Forms.Tools.RadioButtonAdvStyle.Metro;
            this.optWellKnown.TabIndex = 1;
            this.optWellKnown.Text = "Well known projection";
            this.optWellKnown.ThemesEnabled = false;
            // 
            // optDefinition
            // 
            this.optDefinition.BeforeTouchSize = new System.Drawing.Size(406, 21);
            this.optDefinition.DrawFocusRectangle = false;
            this.optDefinition.Location = new System.Drawing.Point(26, 115);
            this.optDefinition.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.optDefinition.Name = "optDefinition";
            this.optDefinition.Size = new System.Drawing.Size(406, 21);
            this.optDefinition.Style = Syncfusion.Windows.Forms.Tools.RadioButtonAdvStyle.Metro;
            this.optDefinition.TabIndex = 2;
            this.optDefinition.Text = "Enter projection definition in any form (e.g. PROJ4, WKT, EPSG code):";
            this.optDefinition.ThemesEnabled = false;
            // 
            // cboWellKnown
            // 
            this.cboWellKnown.BackColor = System.Drawing.Color.White;
            this.cboWellKnown.BeforeTouchSize = new System.Drawing.Size(277, 21);
            this.cboWellKnown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWellKnown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboWellKnown.Location = new System.Drawing.Point(189, 70);
            this.cboWellKnown.Name = "cboWellKnown";
            this.cboWellKnown.Size = new System.Drawing.Size(277, 21);
            this.cboWellKnown.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.cboWellKnown.TabIndex = 3;
            // 
            // txtDefinition
            // 
            this.txtDefinition.BackColor = System.Drawing.Color.White;
            this.txtDefinition.BeforeTouchSize = new System.Drawing.Size(506, 99);
            this.txtDefinition.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtDefinition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDefinition.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDefinition.Location = new System.Drawing.Point(26, 153);
            this.txtDefinition.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtDefinition.Multiline = true;
            this.txtDefinition.Name = "txtDefinition";
            this.txtDefinition.Size = new System.Drawing.Size(506, 99);
            this.txtDefinition.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.txtDefinition.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(93, 29);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(334, 258);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(93, 29);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(93, 29);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(439, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            // 
            // SetProjectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(544, 296);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtDefinition);
            this.Controls.Add(this.cboWellKnown);
            this.Controls.Add(this.optDefinition);
            this.Controls.Add(this.optWellKnown);
            this.Controls.Add(this.optEmpty);
            this.Name = "SetProjectionView";
            this.Text = "Set Map Projection";
            ((System.ComponentModel.ISupportInitialize)(this.optEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optWellKnown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDefinition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWellKnown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefinition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv optEmpty;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv optWellKnown;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv optDefinition;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboWellKnown;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDefinition;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
    }
}