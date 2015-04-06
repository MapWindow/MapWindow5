using MW5.Projections.UI.Controls;

namespace MW5.Projections.UI.Forms
{
    partial class ChooseProjectionForm
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
            Syncfusion.Windows.Forms.Tools.ToolTipInfo toolTipInfo1 = new Syncfusion.Windows.Forms.Tools.ToolTipInfo();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.superToolTip1 = new Syncfusion.Windows.Forms.Tools.SuperToolTip(this);
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxAdv1 = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this._projectionTreeView1 = new MW5.Projections.UI.Controls.ProjectionTreeView();
            this.txtSearch = new MW5.Projections.UI.Controls.WatermarkTextbox();
            this.chkUpdate = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._projectionTreeView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(377, 510);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(287, 510);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 31;
            this.btnOk.Text = "Ok";
            toolTipInfo1.Body.Size = new System.Drawing.Size(20, 20);
            toolTipInfo1.Body.Text = "sdf;lks;dlfk";
            toolTipInfo1.Footer.Size = new System.Drawing.Size(20, 20);
            toolTipInfo1.Header.Size = new System.Drawing.Size(20, 20);
            this.superToolTip1.SetToolTip(this.btnOk, toolTipInfo1);
            this.btnOk.UseVisualStyle = false;
            // 
            // superToolTip1
            // 
            this.superToolTip1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Coordinate systems:";
            // 
            // comboBoxAdv1
            // 
            this.comboBoxAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAdv1.BackColor = System.Drawing.Color.White;
            this.comboBoxAdv1.BeforeTouchSize = new System.Drawing.Size(154, 21);
            this.comboBoxAdv1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxAdv1.Items.AddRange(new object[] {
            "All"});
            this.comboBoxAdv1.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.comboBoxAdv1, "All"));
            this.comboBoxAdv1.Location = new System.Drawing.Point(308, 12);
            this.comboBoxAdv1.Name = "comboBoxAdv1";
            this.comboBoxAdv1.Size = new System.Drawing.Size(154, 21);
            this.comboBoxAdv1.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.comboBoxAdv1.TabIndex = 39;
            this.comboBoxAdv1.Text = "All";
            // 
            // _projectionTreeView1
            // 
            this._projectionTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._projectionTreeView1.BackColor = System.Drawing.Color.White;
            this._projectionTreeView1.BeforeTouchSize = new System.Drawing.Size(450, 443);
            this._projectionTreeView1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this._projectionTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._projectionTreeView1.CanSelectDisabledNode = false;
            this._projectionTreeView1.DelayToolTip = true;
            // 
            // 
            // 
            this._projectionTreeView1.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this._projectionTreeView1.HelpTextControl.Name = "helpText";
            this._projectionTreeView1.HelpTextControl.TabIndex = 0;
            this._projectionTreeView1.Location = new System.Drawing.Point(12, 61);
            this._projectionTreeView1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this._projectionTreeView1.Name = "_projectionTreeView1";
            this._projectionTreeView1.RecalculateExpansion = false;
            this._projectionTreeView1.SelectedNodeBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220))))));
            this._projectionTreeView1.ShowFocusRect = true;
            this._projectionTreeView1.Size = new System.Drawing.Size(450, 443);
            this._projectionTreeView1.SuspendExpandRecalculate = true;
            this._projectionTreeView1.TabIndex = 4;
            // 
            // 
            // 
            this._projectionTreeView1.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this._projectionTreeView1.ToolTipControl.Name = "toolTip";
            this._projectionTreeView1.ToolTipControl.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BeforeTouchSize = new System.Drawing.Size(290, 21);
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Cue = null;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.FarImage = global::MW5.Projections.Properties.Resources.img_clear_textbox;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSearch.MinimumSize = new System.Drawing.Size(24, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(290, 21);
            this.txtSearch.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.txtSearch.TabIndex = 33;
            this.txtSearch.ThemesEnabled = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseDown);
            // 
            // chkUpdate
            // 
            this.chkUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkUpdate.BeforeTouchSize = new System.Drawing.Size(150, 21);
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Location = new System.Drawing.Point(12, 510);
            this.chkUpdate.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(150, 21);
            this.chkUpdate.TabIndex = 40;
            this.chkUpdate.Text = "Update search on typing";
            this.chkUpdate.ThemesEnabled = false;
            // 
            // ChooseProjectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(474, 548);
            this.Controls.Add(this.chkUpdate);
            this.Controls.Add(this._projectionTreeView1);
            this.Controls.Add(this.comboBoxAdv1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.MinimizeBox = false;
            this.Name = "ChooseProjectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Coordinate System";
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._projectionTreeView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpdate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProjectionTreeView _projectionTreeView1;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private WatermarkTextbox txtSearch;
        private Syncfusion.Windows.Forms.Tools.SuperToolTip superToolTip1;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv comboBoxAdv1;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkUpdate;
    }
}