namespace MW5.UI.Legacy
{
    partial class LayersControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.dgv = new LayerStyleDataGridView();
            this.cmnCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCustom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            //this.btnClear.Image = global::MapWindow.Controls.Properties.Resources.Close;
            this.btnClear.Location = new System.Drawing.Point(135, 246);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(38, 31);
            this.btnClear.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnClear, "Remove all files");
            this.btnClear.UseVisualStyleBackColor = true;
            //this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            //this.btnRemove.Image = global::MapWindow.Controls.Properties.Resources.Minus;
            this.btnRemove.Location = new System.Drawing.Point(91, 246);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(38, 31);
            this.btnRemove.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnRemove, "Remove file");
            this.btnRemove.UseVisualStyleBackColor = true;
            //this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            //this.btnAdd.Image = global::MapWindow.Controls.Properties.Resources.Plus_orange;
            this.btnAdd.Location = new System.Drawing.Point(47, 246);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(38, 31);
            this.btnAdd.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnAdd, "Select files from project");
            this.btnAdd.UseVisualStyleBackColor = true;
            //this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            //this.btnOpen.Image = global::MapWindow.Controls.Properties.Resources.Folder_orange;
            this.btnOpen.Location = new System.Drawing.Point(3, 246);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(38, 31);
            this.btnOpen.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnOpen, "Select files from open dialog");
            this.btnOpen.UseVisualStyleBackColor = true;
            //this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnCheck,
            this.Column1,
            this.cmnCustom});
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.ShapefileDrawingColumn = -1;
            this.dgv.Size = new System.Drawing.Size(285, 240);
            this.dgv.TabIndex = 0;
            // 
            // cmnCheck
            // 
            this.cmnCheck.HeaderText = "";
            this.cmnCheck.Name = "cmnCheck";
            this.cmnCheck.Width = 30;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // cmnCustom
            // 
            this.cmnCustom.HeaderText = "Custom";
            this.cmnCustom.Name = "cmnCustom";
            this.cmnCustom.ReadOnly = true;
            // 
            // LayersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.dgv);
            this.MinimumSize = new System.Drawing.Size(233, 262);
            this.Name = "LayersControl";
            this.Size = new System.Drawing.Size(285, 280);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LayerStyleDataGridView dgv;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cmnCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCustom;
    }
}
