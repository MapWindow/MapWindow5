namespace MW5.Tools.Controls.Parameters
{
    partial class BatchLayerParameterControl
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
            this.lblNumSelected = new System.Windows.Forms.Label();
            this.chkSelectedOnly = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnAdd = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOpen = new Syncfusion.Windows.Forms.ButtonAdv();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolParameterGrid1 = new MW5.Tools.Controls.ToolParameterGrid();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolParameterGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(330, 131);
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
            this.panel1.Controls.Add(this.lblNumSelected);
            this.panel1.Controls.Add(this.chkSelectedOnly);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 18);
            this.panel1.TabIndex = 6;
            // 
            // lblNumSelected
            // 
            this.lblNumSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumSelected.Location = new System.Drawing.Point(90, 0);
            this.lblNumSelected.Name = "lblNumSelected";
            this.lblNumSelected.Size = new System.Drawing.Size(192, 18);
            this.lblNumSelected.TabIndex = 6;
            this.lblNumSelected.Text = "Number of selected: 0";
            this.lblNumSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkSelectedOnly
            // 
            this.chkSelectedOnly.AutoSize = true;
            this.chkSelectedOnly.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkSelectedOnly.Location = new System.Drawing.Point(0, 0);
            this.chkSelectedOnly.Name = "chkSelectedOnly";
            this.chkSelectedOnly.Size = new System.Drawing.Size(90, 18);
            this.chkSelectedOnly.TabIndex = 5;
            this.chkSelectedOnly.Text = "Selected only";
            this.chkSelectedOnly.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnOpen);
            this.panel2.Location = new System.Drawing.Point(296, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(26, 82);
            this.panel2.TabIndex = 7;
            // 
            // btnClear
            // 
            this.btnClear.BeforeTouchSize = new System.Drawing.Size(27, 22);
            this.btnClear.Image = global::MW5.Tools.Properties.Resources.img_clear16_2;
            this.btnClear.IsBackStageButton = false;
            this.btnClear.Location = new System.Drawing.Point(0, 44);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(27, 22);
            this.btnClear.TabIndex = 7;
            this.btnClear.Click += new System.EventHandler(this.OnClearClick);
            // 
            // btnAdd
            // 
            this.btnAdd.BeforeTouchSize = new System.Drawing.Size(27, 22);
            this.btnAdd.Image = global::MW5.Tools.Properties.Resources.img_add16;
            this.btnAdd.IsBackStageButton = false;
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(27, 22);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Click += new System.EventHandler(this.OnAddClick);
            // 
            // btnOpen
            // 
            this.btnOpen.BeforeTouchSize = new System.Drawing.Size(27, 22);
            this.btnOpen.Image = global::MW5.Tools.Properties.Resources.img_folder_open;
            this.btnOpen.IsBackStageButton = false;
            this.btnOpen.Location = new System.Drawing.Point(0, 22);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(27, 22);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Click += new System.EventHandler(this.OnOpenClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toolParameterGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(8, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(282, 82);
            this.panel3.TabIndex = 9;
            // 
            // toolParameterGrid1
            // 
            this.toolParameterGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.toolParameterGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolParameterGrid1.FreezeCaption = false;
            this.toolParameterGrid1.Location = new System.Drawing.Point(0, 0);
            this.toolParameterGrid1.Name = "toolParameterGrid1";
            this.toolParameterGrid1.Size = new System.Drawing.Size(282, 82);
            this.toolParameterGrid1.TabIndex = 0;
            this.toolParameterGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.toolParameterGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.toolParameterGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.toolParameterGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.toolParameterGrid1.Text = "toolParameterGrid1";
            this.toolParameterGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.toolParameterGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.toolParameterGrid1.TopLevelGroupOptions.ShowColumnHeaders = false;
            this.toolParameterGrid1.VersionInfo = "5.0.1.0";
            this.toolParameterGrid1.WrapWithPanel = true;
            // 
            // BatchLayerParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BatchLayerParameterControl";
            this.Size = new System.Drawing.Size(330, 131);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolParameterGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumSelected;
        private System.Windows.Forms.CheckBox chkSelectedOnly;
        private System.Windows.Forms.Panel panel2;
        private Syncfusion.Windows.Forms.ButtonAdv btnOpen;
        private System.Windows.Forms.Panel panel3;
        private ToolParameterGrid toolParameterGrid1;
        private Syncfusion.Windows.Forms.ButtonAdv btnAdd;
        private Syncfusion.Windows.Forms.ButtonAdv btnClear;
    }
}
