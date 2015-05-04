using MW5.Plugins.TableEditor.Editor;

namespace MW5.Plugins.TableEditor.Views
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableEditorView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnSaveChanges = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnStartEdit = new System.Windows.Forms.Button();
            this.btnShowSelected = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnUpdateMeasurements = new System.Windows.Forms.Button();
            this.btnCalculateField = new System.Windows.Forms.Button();
            this.btnImportFieldsFromDBF = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnZoomToSelected = new System.Windows.Forms.Button();
            this._lblAmountSelected = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddField = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveField = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRenameField = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoomToSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoomToEdited = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExportFeatures = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuImportFieldDefinitions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFieldCalculator = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGenerateOrUpdateShapeID = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyShapeIDs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportExtData = new System.Windows.Forms.ToolStripMenuItem();
            this.updateMeasurementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._grid = new MW5.Plugins.TableEditor.Editor.TableEditorGrid();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSaveChanges);
            this.panel1.Controls.Add(this.btnStartEdit);
            this.panel1.Controls.Add(this.btnShowSelected);
            this.panel1.Controls.Add(this.btnJoin);
            this.panel1.Controls.Add(this.btnUpdateMeasurements);
            this.panel1.Controls.Add(this.btnCalculateField);
            this.panel1.Controls.Add(this.btnImportFieldsFromDBF);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.btnZoomToSelected);
            this.panel1.Controls.Add(this._lblAmountSelected);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 395);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 59);
            this.panel1.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(628, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 26);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnSaveChanges.IsBackStageButton = false;
            this.btnSaveChanges.Location = new System.Drawing.Point(537, 9);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(85, 26);
            this.btnSaveChanges.TabIndex = 26;
            this.btnSaveChanges.Text = "Apply";
            // 
            // btnStartEdit
            // 
            this.btnStartEdit.Image = global::MW5.Plugins.TableEditor.Properties.Resources.icon_layer_edit;
            this.btnStartEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStartEdit.Location = new System.Drawing.Point(6, 3);
            this.btnStartEdit.Name = "btnStartEdit";
            this.btnStartEdit.Size = new System.Drawing.Size(32, 32);
            this.btnStartEdit.TabIndex = 23;
            this.toolTip1.SetToolTip(this.btnStartEdit, "Edit");
            // 
            // btnShowSelected
            // 
            this.btnShowSelected.Image = ((System.Drawing.Image)(resources.GetObject("btnShowSelected.Image")));
            this.btnShowSelected.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnShowSelected.Location = new System.Drawing.Point(82, 3);
            this.btnShowSelected.Name = "btnShowSelected";
            this.btnShowSelected.Size = new System.Drawing.Size(32, 32);
            this.btnShowSelected.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btnShowSelected, "Filter selected");
            // 
            // btnJoin
            // 
            this.btnJoin.Image = ((System.Drawing.Image)(resources.GetObject("btnJoin.Image")));
            this.btnJoin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnJoin.Location = new System.Drawing.Point(273, 3);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(32, 32);
            this.btnJoin.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btnJoin, "Join");
            // 
            // btnUpdateMeasurements
            // 
            this.btnUpdateMeasurements.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUpdateMeasurements.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateMeasurements.Image")));
            this.btnUpdateMeasurements.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdateMeasurements.Location = new System.Drawing.Point(235, 3);
            this.btnUpdateMeasurements.Name = "btnUpdateMeasurements";
            this.btnUpdateMeasurements.Size = new System.Drawing.Size(32, 32);
            this.btnUpdateMeasurements.TabIndex = 18;
            this.btnUpdateMeasurements.Tag = "";
            this.toolTip1.SetToolTip(this.btnUpdateMeasurements, "Update measurements");
            // 
            // btnCalculateField
            // 
            this.btnCalculateField.Image = ((System.Drawing.Image)(resources.GetObject("btnCalculateField.Image")));
            this.btnCalculateField.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCalculateField.Location = new System.Drawing.Point(120, 3);
            this.btnCalculateField.Name = "btnCalculateField";
            this.btnCalculateField.Size = new System.Drawing.Size(32, 32);
            this.btnCalculateField.TabIndex = 17;
            this.btnCalculateField.Tag = "";
            this.toolTip1.SetToolTip(this.btnCalculateField, "Calculate");
            // 
            // btnImportFieldsFromDBF
            // 
            this.btnImportFieldsFromDBF.Image = ((System.Drawing.Image)(resources.GetObject("btnImportFieldsFromDBF.Image")));
            this.btnImportFieldsFromDBF.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnImportFieldsFromDBF.Location = new System.Drawing.Point(197, 3);
            this.btnImportFieldsFromDBF.Name = "btnImportFieldsFromDBF";
            this.btnImportFieldsFromDBF.Size = new System.Drawing.Size(32, 32);
            this.btnImportFieldsFromDBF.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnImportFieldsFromDBF, "Import fields from DBF");
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::MW5.Plugins.TableEditor.Properties.Resources.filter;
            this.btnQuery.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnQuery.Location = new System.Drawing.Point(158, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(32, 32);
            this.btnQuery.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnQuery, "Query");
            // 
            // btnZoomToSelected
            // 
            this.btnZoomToSelected.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomToSelected.Image")));
            this.btnZoomToSelected.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZoomToSelected.Location = new System.Drawing.Point(44, 3);
            this.btnZoomToSelected.Name = "btnZoomToSelected";
            this.btnZoomToSelected.Size = new System.Drawing.Size(32, 32);
            this.btnZoomToSelected.TabIndex = 13;
            this.btnZoomToSelected.Tag = "";
            this.toolTip1.SetToolTip(this.btnZoomToSelected, "Zoom to selected");
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
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.selectionToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(725, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddField,
            this.mnuRemoveField,
            this.toolStripMenuItem1,
            this.mnuRenameField});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mnuAddField
            // 
            this.mnuAddField.Name = "mnuAddField";
            this.mnuAddField.Size = new System.Drawing.Size(145, 22);
            this.mnuAddField.Text = "Add Field";
            // 
            // mnuRemoveField
            // 
            this.mnuRemoveField.Name = "mnuRemoveField";
            this.mnuRemoveField.Size = new System.Drawing.Size(145, 22);
            this.mnuRemoveField.Text = "Remove Field";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 6);
            // 
            // mnuRenameField
            // 
            this.mnuRenameField.Name = "mnuRenameField";
            this.mnuRenameField.Size = new System.Drawing.Size(145, 22);
            this.mnuRenameField.Text = "Rename Field";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowSelected,
            this.mnuZoomToSelected,
            this.mnuZoomToEdited});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // mnuShowSelected
            // 
            this.mnuShowSelected.Name = "mnuShowSelected";
            this.mnuShowSelected.Size = new System.Drawing.Size(224, 22);
            this.mnuShowSelected.Text = "Show Only Selected Shapes";
            // 
            // mnuZoomToSelected
            // 
            this.mnuZoomToSelected.Name = "mnuZoomToSelected";
            this.mnuZoomToSelected.Size = new System.Drawing.Size(224, 22);
            this.mnuZoomToSelected.Text = "Zoom to Selected Shapes";
            // 
            // mnuZoomToEdited
            // 
            this.mnuZoomToEdited.Name = "mnuZoomToEdited";
            this.mnuZoomToEdited.Size = new System.Drawing.Size(224, 22);
            this.mnuZoomToEdited.Text = "Zoom to Shape Being Edited";
            // 
            // selectionToolStripMenuItem
            // 
            this.selectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQuery,
            this.toolStripMenuItem2,
            this.mnuSelectAll,
            this.mnuClearSelection,
            this.mnuInvertSelection,
            this.toolStripMenuItem3,
            this.mnuExportFeatures});
            this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
            this.selectionToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.selectionToolStripMenuItem.Text = "Selection";
            // 
            // mnuQuery
            // 
            this.mnuQuery.Name = "mnuQuery";
            this.mnuQuery.Size = new System.Drawing.Size(201, 22);
            this.mnuQuery.Text = "Query";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Name = "mnuSelectAll";
            this.mnuSelectAll.Size = new System.Drawing.Size(201, 22);
            this.mnuSelectAll.Text = "Select All";
            // 
            // mnuClearSelection
            // 
            this.mnuClearSelection.Name = "mnuClearSelection";
            this.mnuClearSelection.Size = new System.Drawing.Size(201, 22);
            this.mnuClearSelection.Text = "Select None";
            // 
            // mnuInvertSelection
            // 
            this.mnuInvertSelection.Name = "mnuInvertSelection";
            this.mnuInvertSelection.Size = new System.Drawing.Size(201, 22);
            this.mnuInvertSelection.Text = "Invert Selection";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuExportFeatures
            // 
            this.mnuExportFeatures.Name = "mnuExportFeatures";
            this.mnuExportFeatures.Size = new System.Drawing.Size(201, 22);
            this.mnuExportFeatures.Text = "Export Selected Features";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFind,
            this.mnuReplace,
            this.toolStripMenuItem4,
            this.mnuImportFieldDefinitions,
            this.mnuFieldCalculator,
            this.mnuGenerateOrUpdateShapeID,
            this.mnuCopyShapeIDs,
            this.mnuImportExtData,
            this.updateMeasurementsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // mnuFind
            // 
            this.mnuFind.Name = "mnuFind";
            this.mnuFind.Size = new System.Drawing.Size(272, 22);
            this.mnuFind.Text = "Find";
            // 
            // mnuReplace
            // 
            this.mnuReplace.Name = "mnuReplace";
            this.mnuReplace.Size = new System.Drawing.Size(272, 22);
            this.mnuReplace.Text = "Replace";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(269, 6);
            // 
            // mnuImportFieldDefinitions
            // 
            this.mnuImportFieldDefinitions.Name = "mnuImportFieldDefinitions";
            this.mnuImportFieldDefinitions.Size = new System.Drawing.Size(272, 22);
            this.mnuImportFieldDefinitions.Text = "Import Field Definitions from DBF";
            // 
            // mnuFieldCalculator
            // 
            this.mnuFieldCalculator.Name = "mnuFieldCalculator";
            this.mnuFieldCalculator.Size = new System.Drawing.Size(272, 22);
            this.mnuFieldCalculator.Text = "Field Calculator Tool";
            // 
            // mnuGenerateOrUpdateShapeID
            // 
            this.mnuGenerateOrUpdateShapeID.Name = "mnuGenerateOrUpdateShapeID";
            this.mnuGenerateOrUpdateShapeID.Size = new System.Drawing.Size(272, 22);
            this.mnuGenerateOrUpdateShapeID.Text = "Generate or Update MWShapeID Field";
            // 
            // mnuCopyShapeIDs
            // 
            this.mnuCopyShapeIDs.Name = "mnuCopyShapeIDs";
            this.mnuCopyShapeIDs.Size = new System.Drawing.Size(272, 22);
            this.mnuCopyShapeIDs.Text = "Copy ShapeIDs to Specified Field...";
            // 
            // mnuImportExtData
            // 
            this.mnuImportExtData.Name = "mnuImportExtData";
            this.mnuImportExtData.Size = new System.Drawing.Size(272, 22);
            this.mnuImportExtData.Text = "Import external data";
            // 
            // updateMeasurementsToolStripMenuItem
            // 
            this.updateMeasurementsToolStripMenuItem.Name = "updateMeasurementsToolStripMenuItem";
            this.updateMeasurementsToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.updateMeasurementsToolStripMenuItem.Text = "Update Measurements";
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.BackgroundColor = System.Drawing.Color.LightGray;
            this._grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.CurrentCellBorderColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.Location = new System.Drawing.Point(0, 24);
            this._grid.Name = "_grid";
            this._grid.RowManager = null;
            this._grid.SelectionColor = System.Drawing.Color.LightBlue;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._grid.Size = new System.Drawing.Size(725, 371);
            this._grid.TabIndex = 0;
            this._grid.TableSource = null;
            this._grid.VirtualMode = true;
            // 
            // TableEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 454);
            this.ControlBox = false;
            this.Controls.Add(this._grid);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "TableEditorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attribute Table Editor";
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableEditorGrid _grid;
        protected System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button btnJoin;
        internal System.Windows.Forms.Button btnUpdateMeasurements;
        internal System.Windows.Forms.Button btnCalculateField;
        internal System.Windows.Forms.Button btnImportFieldsFromDBF;
        internal System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnZoomToSelected;
        private System.Windows.Forms.Label _lblAmountSelected;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAddField;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveField;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuRenameField;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuShowSelected;
        private System.Windows.Forms.ToolStripMenuItem mnuZoomToSelected;
        private System.Windows.Forms.ToolStripMenuItem mnuZoomToEdited;
        private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mnuClearSelection;
        private System.Windows.Forms.ToolStripMenuItem mnuInvertSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuExportFeatures;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFind;
        private System.Windows.Forms.ToolStripMenuItem mnuReplace;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuImportFieldDefinitions;
        private System.Windows.Forms.ToolStripMenuItem mnuFieldCalculator;
        private System.Windows.Forms.ToolStripMenuItem mnuGenerateOrUpdateShapeID;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyShapeIDs;
        private System.Windows.Forms.ToolStripMenuItem mnuImportExtData;
        private System.Windows.Forms.ToolStripMenuItem updateMeasurementsToolStripMenuItem;
        internal System.Windows.Forms.Button btnShowSelected;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Button btnStartEdit;
        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private Syncfusion.Windows.Forms.ButtonAdv btnSaveChanges;

    }
}