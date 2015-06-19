namespace MW5.Plugins.TableEditor.Views
{
    partial class FieldStatsView
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
            this.cboField = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCopy = new Syncfusion.Windows.Forms.ButtonAdv();
            this.fieldStatsGrid1 = new MW5.Plugins.TableEditor.Controls.FieldStatsGrid();
            ((System.ComponentModel.ISupportInitialize)(this.cboField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldStatsGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboField
            // 
            this.cboField.BeforeTouchSize = new System.Drawing.Size(223, 21);
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboField.Location = new System.Drawing.Point(58, 21);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(223, 21);
            this.cboField.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Field";
            // 
            // btnClose
            // 
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(75, 26);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(206, 216);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            // 
            // btnCopy
            // 
            this.btnCopy.BeforeTouchSize = new System.Drawing.Size(75, 26);
            this.btnCopy.IsBackStageButton = false;
            this.btnCopy.Location = new System.Drawing.Point(125, 216);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 26);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy";
            // 
            // fieldStatsGrid1
            // 
            this.fieldStatsGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldStatsGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldStatsGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldStatsGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldStatsGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.fieldStatsGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.fieldStatsGrid1.FreezeCaption = false;
            this.fieldStatsGrid1.Location = new System.Drawing.Point(15, 58);
            this.fieldStatsGrid1.Name = "fieldStatsGrid1";
            this.fieldStatsGrid1.Size = new System.Drawing.Size(266, 152);
            this.fieldStatsGrid1.TabIndex = 5;
            this.fieldStatsGrid1.TableDescriptor.AllowEdit = false;
            this.fieldStatsGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.fieldStatsGrid1.TableOptions.AllowDropDownCell = false;
            this.fieldStatsGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.fieldStatsGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.fieldStatsGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.fieldStatsGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.fieldStatsGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.fieldStatsGrid1.Text = "fieldStatsGrid1";
            this.fieldStatsGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.fieldStatsGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.fieldStatsGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.fieldStatsGrid1.VersionInfo = "0.0.1.0";
            this.fieldStatsGrid1.WrapWithPanel = true;
            // 
            // FieldStatsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(293, 250);
            this.Controls.Add(this.fieldStatsGrid1);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboField);
            this.Name = "FieldStatsView";
            this.Text = "Field Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.cboField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldStatsGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboField;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private Syncfusion.Windows.Forms.ButtonAdv btnCopy;
        private Controls.FieldStatsGrid fieldStatsGrid1;
    }
}