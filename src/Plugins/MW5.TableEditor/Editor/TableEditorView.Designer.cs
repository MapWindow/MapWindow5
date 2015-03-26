namespace MW5.Plugins.TableEditor.Editor
{
    partial class TableEditorView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableEditorView));
            this._grid = new MW5.Plugins.TableEditor.Editor.TableEditorGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnJoin = new System.Windows.Forms.Button();
            this.UpdateMeasurements = new System.Windows.Forms.Button();
            this.btnFieldCalculator = new System.Windows.Forms.Button();
            this.btnImportFieldsFromDBF = new System.Windows.Forms.Button();
            this.tbbQuery = new System.Windows.Forms.Button();
            this.btnShowSelected = new System.Windows.Forms.Button();
            this.btnZoomToSelected = new System.Windows.Forms.Button();
            this._lblAmountSelected = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.BackgroundColor = System.Drawing.Color.LightGray;
            this._grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.Location = new System.Drawing.Point(0, 0);
            this._grid.Name = "_grid";
            this._grid.SelectionColor = System.Drawing.Color.LightBlue;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._grid.Size = new System.Drawing.Size(725, 395);
            this._grid.TabIndex = 0;
            this._grid.VirtualMode = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnJoin);
            this.panel1.Controls.Add(this.UpdateMeasurements);
            this.panel1.Controls.Add(this.btnFieldCalculator);
            this.panel1.Controls.Add(this.btnImportFieldsFromDBF);
            this.panel1.Controls.Add(this.tbbQuery);
            this.panel1.Controls.Add(this.btnShowSelected);
            this.panel1.Controls.Add(this.btnZoomToSelected);
            this.panel1.Controls.Add(this._lblAmountSelected);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 395);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 59);
            this.panel1.TabIndex = 14;
            // 
            // btnJoin
            // 
            this.btnJoin.Image = ((System.Drawing.Image)(resources.GetObject("btnJoin.Image")));
            this.btnJoin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnJoin.Location = new System.Drawing.Point(235, 6);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(32, 32);
            this.btnJoin.TabIndex = 20;
            // 
            // UpdateMeasurements
            // 
            this.UpdateMeasurements.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UpdateMeasurements.Image = ((System.Drawing.Image)(resources.GetObject("UpdateMeasurements.Image")));
            this.UpdateMeasurements.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UpdateMeasurements.Location = new System.Drawing.Point(197, 6);
            this.UpdateMeasurements.Name = "UpdateMeasurements";
            this.UpdateMeasurements.Size = new System.Drawing.Size(32, 32);
            this.UpdateMeasurements.TabIndex = 18;
            this.UpdateMeasurements.Tag = "";
            // 
            // btnFieldCalculator
            // 
            this.btnFieldCalculator.Image = ((System.Drawing.Image)(resources.GetObject("btnFieldCalculator.Image")));
            this.btnFieldCalculator.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFieldCalculator.Location = new System.Drawing.Point(82, 6);
            this.btnFieldCalculator.Name = "btnFieldCalculator";
            this.btnFieldCalculator.Size = new System.Drawing.Size(32, 32);
            this.btnFieldCalculator.TabIndex = 17;
            this.btnFieldCalculator.Tag = "";
            // 
            // btnImportFieldsFromDBF
            // 
            this.btnImportFieldsFromDBF.Image = ((System.Drawing.Image)(resources.GetObject("btnImportFieldsFromDBF.Image")));
            this.btnImportFieldsFromDBF.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnImportFieldsFromDBF.Location = new System.Drawing.Point(159, 6);
            this.btnImportFieldsFromDBF.Name = "btnImportFieldsFromDBF";
            this.btnImportFieldsFromDBF.Size = new System.Drawing.Size(32, 32);
            this.btnImportFieldsFromDBF.TabIndex = 16;
            // 
            // tbbQuery
            // 
            this.tbbQuery.Image = global::MW5.Plugins.TableEditor.Properties.Resources.filter;
            this.tbbQuery.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbbQuery.Location = new System.Drawing.Point(120, 6);
            this.tbbQuery.Name = "tbbQuery";
            this.tbbQuery.Size = new System.Drawing.Size(32, 32);
            this.tbbQuery.TabIndex = 15;
            // 
            // btnShowSelected
            // 
            this.btnShowSelected.Image = ((System.Drawing.Image)(resources.GetObject("btnShowSelected.Image")));
            this.btnShowSelected.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnShowSelected.Location = new System.Drawing.Point(44, 6);
            this.btnShowSelected.Name = "btnShowSelected";
            this.btnShowSelected.Size = new System.Drawing.Size(32, 32);
            this.btnShowSelected.TabIndex = 14;
            // 
            // btnZoomToSelected
            // 
            this.btnZoomToSelected.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomToSelected.Image")));
            this.btnZoomToSelected.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZoomToSelected.Location = new System.Drawing.Point(6, 6);
            this.btnZoomToSelected.Name = "btnZoomToSelected";
            this.btnZoomToSelected.Size = new System.Drawing.Size(32, 32);
            this.btnZoomToSelected.TabIndex = 13;
            this.btnZoomToSelected.Tag = "";
            // 
            // _lblAmountSelected
            // 
            this._lblAmountSelected.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblAmountSelected.Location = new System.Drawing.Point(3, 41);
            this._lblAmountSelected.Name = "_lblAmountSelected";
            this._lblAmountSelected.Size = new System.Drawing.Size(286, 18);
            this._lblAmountSelected.TabIndex = 12;
            this._lblAmountSelected.Text = "0 of 0 Selected";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(617, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(514, 7);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(97, 30);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // TableEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 454);
            this.ControlBox = false;
            this.Controls.Add(this._grid);
            this.Controls.Add(this.panel1);
            this.Name = "TableEditorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attribute Table Editor";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableEditorGrid _grid;
        protected System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button btnJoin;
        internal System.Windows.Forms.Button UpdateMeasurements;
        internal System.Windows.Forms.Button btnFieldCalculator;
        internal System.Windows.Forms.Button btnImportFieldsFromDBF;
        internal System.Windows.Forms.Button tbbQuery;
        internal System.Windows.Forms.Button btnShowSelected;
        private System.Windows.Forms.Button btnZoomToSelected;
        private System.Windows.Forms.Label _lblAmountSelected;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;

    }
}