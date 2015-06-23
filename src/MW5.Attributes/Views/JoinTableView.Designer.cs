using MW5.Attributes.Controls;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Attributes.Views
{
    partial class JoinTableView
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
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.groupKeys = new System.Windows.Forms.GroupBox();
            this.lblMatch = new System.Windows.Forms.Label();
            this.lblMatchJoin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCurrent = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboExternal = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.fieldsGrid1 = new FieldsGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDatasource = new MW5.UI.Controls.WatermarkTextbox();
            this.btnOpen = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label6 = new System.Windows.Forms.Label();
            this.cboOptions = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.lblOptions = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupKeys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExternal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGrid1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatasource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOptions)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(25, 442);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(99, 17);
            this.chkAll.TabIndex = 6;
            this.chkAll.Text = "Check all/none";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(315, 437);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(224, 437);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Join";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // groupKeys
            // 
            this.groupKeys.Controls.Add(this.lblMatch);
            this.groupKeys.Controls.Add(this.lblMatchJoin);
            this.groupKeys.Controls.Add(this.label5);
            this.groupKeys.Controls.Add(this.label4);
            this.groupKeys.Controls.Add(this.cboCurrent);
            this.groupKeys.Controls.Add(this.cboExternal);
            this.groupKeys.Controls.Add(this.label3);
            this.groupKeys.Enabled = false;
            this.groupKeys.Location = new System.Drawing.Point(12, 147);
            this.groupKeys.Name = "groupKeys";
            this.groupKeys.Size = new System.Drawing.Size(392, 92);
            this.groupKeys.TabIndex = 2;
            this.groupKeys.TabStop = false;
            this.groupKeys.Text = "Select Key Columns";
            // 
            // lblMatch
            // 
            this.lblMatch.AutoSize = true;
            this.lblMatch.Location = new System.Drawing.Point(20, 66);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(79, 13);
            this.lblMatch.TabIndex = 14;
            this.lblMatch.Text = "Matching rows:";
            // 
            // lblMatchJoin
            // 
            this.lblMatchJoin.AutoSize = true;
            this.lblMatchJoin.Location = new System.Drawing.Point(217, 66);
            this.lblMatchJoin.Name = "lblMatchJoin";
            this.lblMatchJoin.Size = new System.Drawing.Size(79, 13);
            this.lblMatchJoin.TabIndex = 13;
            this.lblMatchJoin.Text = "Matching rows:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(16, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Current";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(217, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "External";
            // 
            // cboCurrent
            // 
            this.cboCurrent.BeforeTouchSize = new System.Drawing.Size(158, 21);
            this.cboCurrent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboCurrent.Location = new System.Drawing.Point(19, 42);
            this.cboCurrent.Name = "cboCurrent";
            this.cboCurrent.Size = new System.Drawing.Size(158, 21);
            this.cboCurrent.TabIndex = 1;
            // 
            // cboExternal
            // 
            this.cboExternal.BeforeTouchSize = new System.Drawing.Size(158, 21);
            this.cboExternal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExternal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboExternal.Location = new System.Drawing.Point(220, 42);
            this.cboExternal.Name = "cboExternal";
            this.cboExternal.Size = new System.Drawing.Size(158, 21);
            this.cboExternal.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(183, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "____";
            // 
            // fieldsGrid1
            // 
            this.fieldsGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.fieldsGrid1.FreezeCaption = false;
            this.fieldsGrid1.Location = new System.Drawing.Point(3, 24);
            this.fieldsGrid1.Name = "fieldsGrid1";
            this.fieldsGrid1.Size = new System.Drawing.Size(385, 159);
            this.fieldsGrid1.TabIndex = 1;
            this.fieldsGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.fieldsGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.fieldsGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.fieldsGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.fieldsGrid1.Text = "fieldsGrid1";
            this.fieldsGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.fieldsGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.fieldsGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.fieldsGrid1.VersionInfo = "0.0.1.0";
            this.fieldsGrid1.WrapWithPanel = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDatasource);
            this.groupBox2.Controls.Add(this.btnOpen);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cboOptions);
            this.groupBox2.Controls.Add(this.lblOptions);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 119);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datasource";
            // 
            // txtDatasource
            // 
            this.txtDatasource.BeforeTouchSize = new System.Drawing.Size(218, 20);
            this.txtDatasource.Cue = "Open file to join";
            this.txtDatasource.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDatasource.Location = new System.Drawing.Point(101, 32);
            this.txtDatasource.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtDatasource.Name = "txtDatasource";
            this.txtDatasource.ReadOnly = true;
            this.txtDatasource.ShowClearButton = false;
            this.txtDatasource.Size = new System.Drawing.Size(218, 20);
            this.txtDatasource.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtDatasource.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.BeforeTouchSize = new System.Drawing.Size(53, 23);
            this.btnOpen.IsBackStageButton = false;
            this.btnOpen.Location = new System.Drawing.Point(325, 30);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(53, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Datasource";
            // 
            // cboOptions
            // 
            this.cboOptions.BeforeTouchSize = new System.Drawing.Size(277, 21);
            this.cboOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboOptions.Location = new System.Drawing.Point(101, 78);
            this.cboOptions.Name = "cboOptions";
            this.cboOptions.Size = new System.Drawing.Size(277, 21);
            this.cboOptions.TabIndex = 3;
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Location = new System.Drawing.Point(21, 82);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(57, 13);
            this.lblOptions.TabIndex = 24;
            this.lblOptions.Text = "Workbook";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.fieldsGrid1);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(12, 245);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 186);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Fields to join";
            // 
            // JoinTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 470);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupKeys);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "JoinTableView";
            this.Text = "Join table";
            this.groupKeys.ResumeLayout(false);
            this.groupKeys.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExternal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGrid1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatasource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOptions)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAll;
        private ButtonAdv btnCancel;
        private ButtonAdv btnOk;
        private System.Windows.Forms.GroupBox groupKeys;
        private System.Windows.Forms.Label lblMatch;
        private System.Windows.Forms.Label lblMatchJoin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ComboBoxAdv cboCurrent;
        private ComboBoxAdv cboExternal;
        private System.Windows.Forms.Label label3;
        private FieldsGrid fieldsGrid1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ButtonAdv btnOpen;
        private System.Windows.Forms.Label label6;
        private ComboBoxAdv cboOptions;
        private System.Windows.Forms.Label lblOptions;
        private UI.Controls.WatermarkTextbox txtDatasource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}