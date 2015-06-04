using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.TableEditor.Views
{
    partial class JoinDbfView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMatch = new System.Windows.Forms.Label();
            this.lblMatchJoin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCurrent = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboExternal = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.fieldsGrid1 = new MW5.Plugins.TableEditor.Controls.FieldsGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExternal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(12, 274);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(99, 17);
            this.chkAll.TabIndex = 21;
            this.chkAll.Text = "Check all/none";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(283, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(202, 270);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 18;
            this.btnOk.Text = "Join";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMatch);
            this.groupBox1.Controls.Add(this.lblMatchJoin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboCurrent);
            this.groupBox1.Controls.Add(this.cboExternal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 92);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Key Columns";
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
            this.lblMatchJoin.Location = new System.Drawing.Point(189, 66);
            this.lblMatchJoin.Name = "lblMatchJoin";
            this.lblMatchJoin.Size = new System.Drawing.Size(79, 13);
            this.lblMatchJoin.TabIndex = 13;
            this.lblMatchJoin.Text = "Matching rows:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(28, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Current";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(189, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "External";
            // 
            // cboCurrent
            // 
            this.cboCurrent.BeforeTouchSize = new System.Drawing.Size(130, 21);
            this.cboCurrent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboCurrent.Location = new System.Drawing.Point(19, 42);
            this.cboCurrent.Name = "cboCurrent";
            this.cboCurrent.Size = new System.Drawing.Size(130, 21);
            this.cboCurrent.TabIndex = 8;
            // 
            // cboExternal
            // 
            this.cboExternal.BeforeTouchSize = new System.Drawing.Size(130, 21);
            this.cboExternal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExternal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboExternal.Location = new System.Drawing.Point(192, 42);
            this.cboExternal.Name = "cboExternal";
            this.cboExternal.Size = new System.Drawing.Size(130, 21);
            this.cboExternal.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(155, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "____";
            // 
            // fieldsGrid1
            // 
            this.fieldsGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.fieldsGrid1.FreezeCaption = false;
            this.fieldsGrid1.Location = new System.Drawing.Point(12, 110);
            this.fieldsGrid1.Name = "fieldsGrid1";
            this.fieldsGrid1.Size = new System.Drawing.Size(342, 154);
            this.fieldsGrid1.TabIndex = 22;
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
            // JoinDbfView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(366, 299);
            this.Controls.Add(this.fieldsGrid1);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Name = "JoinDbfView";
            this.Text = "Join table";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExternal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAll;
        private ButtonAdv btnCancel;
        private ButtonAdv btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMatch;
        private System.Windows.Forms.Label lblMatchJoin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ComboBoxAdv cboCurrent;
        private ComboBoxAdv cboExternal;
        private System.Windows.Forms.Label label3;
        private Controls.FieldsGrid fieldsGrid1;
    }
}