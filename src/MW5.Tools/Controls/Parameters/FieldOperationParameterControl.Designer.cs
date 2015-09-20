using System.Windows.Forms;

namespace MW5.Tools.Controls.Parameters
{
    partial class FieldOperationParameterControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fieldOperationGrid1 = new MW5.Tools.Controls.FieldOperationGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnAdd = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnAddAll = new Syncfusion.Windows.Forms.ButtonAdv();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldOperationGrid1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnAddAll, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(355, 304);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fieldOperationGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 251);
            this.panel1.TabIndex = 3;
            // 
            // fieldOperationGrid1
            // 
            this.fieldOperationGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldOperationGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldOperationGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldOperationGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldOperationGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.fieldOperationGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.fieldOperationGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldOperationGrid1.FreezeCaption = false;
            this.fieldOperationGrid1.Location = new System.Drawing.Point(0, 0);
            this.fieldOperationGrid1.Name = "fieldOperationGrid1";
            this.fieldOperationGrid1.Size = new System.Drawing.Size(300, 251);
            this.fieldOperationGrid1.TabIndex = 2;
            this.fieldOperationGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.fieldOperationGrid1.TableOptions.AllowDropDownCell = true;
            this.fieldOperationGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.fieldOperationGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.fieldOperationGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.None;
            this.fieldOperationGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.fieldOperationGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.fieldOperationGrid1.Text = "fieldOperationGrid1";
            this.fieldOperationGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.fieldOperationGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.fieldOperationGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.fieldOperationGrid1.VersionInfo = "5.0.1.0";
            this.fieldOperationGrid1.WrapWithPanel = true;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(314, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(33, 251);
            this.panel2.TabIndex = 12;
            // 
            // btnClear
            // 
            this.btnClear.BeforeTouchSize = new System.Drawing.Size(27, 26);
            this.btnClear.Image = global::MW5.Tools.Properties.Resources.img_clear16;
            this.btnClear.IsBackStageButton = false;
            this.btnClear.Location = new System.Drawing.Point(3, 30);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(27, 26);
            this.btnClear.TabIndex = 12;
            this.btnClear.Click += new System.EventHandler(this.OnClearClick);
            // 
            // btnAdd
            // 
            this.btnAdd.BeforeTouchSize = new System.Drawing.Size(27, 26);
            this.btnAdd.Image = global::MW5.Tools.Properties.Resources.img_add16;
            this.btnAdd.IsBackStageButton = false;
            this.btnAdd.Location = new System.Drawing.Point(2, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(27, 26);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Click += new System.EventHandler(this.OnAddClick);
            // 
            // btnAddAll
            // 
            this.btnAddAll.BeforeTouchSize = new System.Drawing.Size(78, 22);
            this.btnAddAll.IsBackStageButton = false;
            this.btnAddAll.Location = new System.Drawing.Point(8, 276);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(78, 22);
            this.btnAddAll.TabIndex = 13;
            this.btnAddAll.Text = "Add all";
            this.btnAddAll.Click += new System.EventHandler(this.OnAddAllClick);
            // 
            // FieldOperationParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FieldOperationParameterControl";
            this.Size = new System.Drawing.Size(355, 304);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fieldOperationGrid1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private FieldOperationGrid fieldOperationGrid1;
        private System.Windows.Forms.Panel panel1;
        private Panel panel2;
        private Syncfusion.Windows.Forms.ButtonAdv btnAdd;
        private Syncfusion.Windows.Forms.ButtonAdv btnClear;
        private Syncfusion.Windows.Forms.ButtonAdv btnAddAll;
    }
}
