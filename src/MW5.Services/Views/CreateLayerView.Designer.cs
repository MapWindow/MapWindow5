namespace MW5.Services.Views
{
    partial class CreateLayerView
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
            this.label1 = new System.Windows.Forms.Label();
            this._layerNameTextbox = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label2 = new System.Windows.Forms.Label();
            this._layerTypeComboBox = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this._okButton = new Syncfusion.Windows.Forms.ButtonAdv();
            this._cancelButton = new Syncfusion.Windows.Forms.ButtonAdv();
            this.opt2D = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.optZ = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.optM = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this._layerNameTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._layerTypeComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt2D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optM)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Layer name";
            // 
            // _layerNameTextbox
            // 
            this._layerNameTextbox.BeforeTouchSize = new System.Drawing.Size(100, 20);
            this._layerNameTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._layerNameTextbox.Location = new System.Drawing.Point(103, 33);
            this._layerNameTextbox.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this._layerNameTextbox.Name = "_layerNameTextbox";
            this._layerNameTextbox.Size = new System.Drawing.Size(261, 20);
            this._layerNameTextbox.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this._layerNameTextbox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Layer type";
            // 
            // _layerTypeComboBox
            // 
            this._layerTypeComboBox.BeforeTouchSize = new System.Drawing.Size(261, 21);
            this._layerTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._layerTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._layerTypeComboBox.Location = new System.Drawing.Point(103, 75);
            this._layerTypeComboBox.Name = "_layerTypeComboBox";
            this._layerTypeComboBox.Size = new System.Drawing.Size(261, 21);
            this._layerTypeComboBox.TabIndex = 4;
            // 
            // _okButton
            // 
            this._okButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this._okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this._okButton.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this._okButton.ForeColor = System.Drawing.Color.White;
            this._okButton.IsBackStageButton = false;
            this._okButton.Location = new System.Drawing.Point(256, 143);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 6;
            this._okButton.Text = "Ok";
            this._okButton.UseVisualStyle = false;
            // 
            // _cancelButton
            // 
            this._cancelButton.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.IsBackStageButton = false;
            this._cancelButton.Location = new System.Drawing.Point(337, 143);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 7;
            this._cancelButton.Text = "Cancel";
            // 
            // opt2D
            // 
            this.opt2D.BeforeTouchSize = new System.Drawing.Size(92, 21);
            this.opt2D.Checked = true;
            this.opt2D.Location = new System.Drawing.Point(103, 102);
            this.opt2D.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.opt2D.Name = "opt2D";
            this.opt2D.Size = new System.Drawing.Size(92, 21);
            this.opt2D.TabIndex = 8;
            this.opt2D.Text = "Regular";
            this.opt2D.ThemesEnabled = false;
            // 
            // optZ
            // 
            this.optZ.BeforeTouchSize = new System.Drawing.Size(48, 21);
            this.optZ.Location = new System.Drawing.Point(201, 102);
            this.optZ.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.optZ.Name = "optZ";
            this.optZ.Size = new System.Drawing.Size(48, 21);
            this.optZ.TabIndex = 9;
            this.optZ.TabStop = false;
            this.optZ.Text = "Z";
            this.optZ.ThemesEnabled = false;
            // 
            // optM
            // 
            this.optM.BeforeTouchSize = new System.Drawing.Size(48, 21);
            this.optM.Location = new System.Drawing.Point(283, 102);
            this.optM.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.optM.Name = "optM";
            this.optM.Size = new System.Drawing.Size(48, 21);
            this.optM.TabIndex = 10;
            this.optM.TabStop = false;
            this.optM.Text = "M";
            this.optM.ThemesEnabled = false;
            // 
            // CreateLayerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(424, 178);
            this.Controls.Add(this.optM);
            this.Controls.Add(this.optZ);
            this.Controls.Add(this.opt2D);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._layerTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._layerNameTextbox);
            this.Controls.Add(this.label1);
            this.Name = "CreateLayerView";
            this.Text = "Create new layer";
            ((System.ComponentModel.ISupportInitialize)(this._layerNameTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._layerTypeComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt2D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt _layerNameTextbox;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv _layerTypeComboBox;
        private Syncfusion.Windows.Forms.ButtonAdv _okButton;
        private Syncfusion.Windows.Forms.ButtonAdv _cancelButton;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv opt2D;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv optZ;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv optM;
    }
}