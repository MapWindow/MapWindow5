namespace MW5.Plugins.Symbology.Controls
{
    partial class JoinControl
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
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStop = new System.Windows.Forms.ToolStripButton();
            this.toolStopAll = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.joinsGrid1 = new MW5.Attributes.Controls.JoinsGrid();
            this.toolStripEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.joinsGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripEx1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx1.ForeColor = System.Drawing.Color.Black;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolEdit,
            this.toolStop,
            this.toolStopAll});
            this.toolStripEx1.Location = new System.Drawing.Point(6, 229);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Office12Mode = false;
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.Size = new System.Drawing.Size(217, 25);
            this.toolStripEx1.TabIndex = 1;
            this.toolStripEx1.Text = "toolStripEx1";
            this.toolStripEx1.VisualStyle = Syncfusion.Windows.Forms.Tools.ToolStripExStyle.Metro;
            // 
            // toolAdd
            // 
            this.toolAdd.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_field_add16;
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(49, 22);
            this.toolAdd.Text = "Add";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolEdit
            // 
            this.toolEdit.ForeColor = System.Drawing.Color.Black;
            this.toolEdit.Image = global::MW5.Plugins.Symbology.Properties.Resources.icon_layer_edit;
            this.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEdit.Name = "toolEdit";
            this.toolEdit.Size = new System.Drawing.Size(47, 22);
            this.toolEdit.Text = "Edit";
            this.toolEdit.Click += new System.EventHandler(this.toolEdit_Click);
            // 
            // toolStop
            // 
            this.toolStop.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_remove16;
            this.toolStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStop.Name = "toolStop";
            this.toolStop.Size = new System.Drawing.Size(51, 22);
            this.toolStop.Text = "Stop";
            this.toolStop.Click += new System.EventHandler(this.toolStop_Click);
            // 
            // toolStopAll
            // 
            this.toolStopAll.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_clear24;
            this.toolStopAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStopAll.Name = "toolStopAll";
            this.toolStopAll.Size = new System.Drawing.Size(68, 20);
            this.toolStopAll.Text = "Stop All";
            this.toolStopAll.Click += new System.EventHandler(this.toolStopAll_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "External datasource joined to this table.";
            // 
            // joinsGrid1
            // 
            this.joinsGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.joinsGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.joinsGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.joinsGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.joinsGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.joinsGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.joinsGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.joinsGrid1.FreezeCaption = false;
            this.joinsGrid1.Location = new System.Drawing.Point(3, 31);
            this.joinsGrid1.Name = "joinsGrid1";
            this.joinsGrid1.Size = new System.Drawing.Size(401, 185);
            this.joinsGrid1.TabIndex = 0;
            this.joinsGrid1.TableDescriptor.AllowEdit = false;
            this.joinsGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.joinsGrid1.TableOptions.AllowDropDownCell = false;
            this.joinsGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.joinsGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.joinsGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.joinsGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.joinsGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.joinsGrid1.Text = "joinsGrid1";
            this.joinsGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.joinsGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.joinsGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.joinsGrid1.VersionInfo = "5.0.1.0";
            this.joinsGrid1.WrapWithPanel = false;
            // 
            // JoinControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStripEx1);
            this.Controls.Add(this.joinsGrid1);
            this.Name = "JoinControl";
            this.Size = new System.Drawing.Size(407, 262);
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.joinsGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Attributes.Controls.JoinsGrid joinsGrid1;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolEdit;
        private System.Windows.Forms.ToolStripButton toolStop;
        private System.Windows.Forms.ToolStripButton toolStopAll;
        private System.Windows.Forms.Label label1;
    }
}
