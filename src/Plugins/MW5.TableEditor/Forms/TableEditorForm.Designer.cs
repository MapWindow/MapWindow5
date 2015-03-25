using MW5.Plugins.TableEditor.Properties;

namespace MW5.Plugins.TableEditor.Forms
{
    partial class TableEditorForm
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableEditorForm));
          this.panel1 = new System.Windows.Forms.Panel();
          this.btnJoin = new System.Windows.Forms.Button();
          this.btnGetAll = new System.Windows.Forms.Button();
          this.UpdateMeasurements = new System.Windows.Forms.Button();
          this.btnFieldCalculator = new System.Windows.Forms.Button();
          this.btnImportFieldsFromDBF = new System.Windows.Forms.Button();
          this.tbbQuery = new System.Windows.Forms.Button();
          this.btnShowSelected = new System.Windows.Forms.Button();
          this.btnZoomToSelected = new System.Windows.Forms.Button();
          this.lblAmountSeleted = new System.Windows.Forms.Label();
          this.btnClose = new System.Windows.Forms.Button();
          this.btnApply = new System.Windows.Forms.Button();
          this.TableEditorDataGrid = new System.Windows.Forms.DataGridView();
          this.menuStrip1 = new System.Windows.Forms.MenuStrip();
          this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.addFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.removeFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
          this.renameFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuShowSelected = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuZoomToSelected = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuZoomToEdited = new System.Windows.Forms.ToolStripMenuItem();
          this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuQuery = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
          this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuSelectNone = new System.Windows.Forms.ToolStripMenuItem();
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
          this.mnuGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.mnuCalcValues = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuAssignValues = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
          this.mnuTrimAll = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuTrimSelected = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
          this.mnuStatistics = new System.Windows.Forms.ToolStripMenuItem();
          this.panel1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.TableEditorDataGrid)).BeginInit();
          this.menuStrip1.SuspendLayout();
          this.mnuGridView.SuspendLayout();
          this.SuspendLayout();
          // 
          // panel1
          // 
          this.panel1.Controls.Add(this.btnJoin);
          this.panel1.Controls.Add(this.btnGetAll);
          this.panel1.Controls.Add(this.UpdateMeasurements);
          this.panel1.Controls.Add(this.btnFieldCalculator);
          this.panel1.Controls.Add(this.btnImportFieldsFromDBF);
          this.panel1.Controls.Add(this.tbbQuery);
          this.panel1.Controls.Add(this.btnShowSelected);
          this.panel1.Controls.Add(this.btnZoomToSelected);
          this.panel1.Controls.Add(this.lblAmountSeleted);
          this.panel1.Controls.Add(this.btnClose);
          this.panel1.Controls.Add(this.btnApply);
          resources.ApplyResources(this.panel1, "panel1");
          this.panel1.Name = "panel1";
          this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1MouseMove);
          // 
          // btnJoin
          // 
          resources.ApplyResources(this.btnJoin, "btnJoin");
          this.btnJoin.Name = "btnJoin";
          this.toolTip1.SetToolTip(this.btnJoin, resources.GetString("btnJoin.ToolTip"));
          this.btnJoin.Click += new System.EventHandler(this.BtnJoinClick);
          // 
          // btnGetAll
          // 
          resources.ApplyResources(this.btnGetAll, "btnGetAll");
          this.btnGetAll.Name = "btnGetAll";
          this.btnGetAll.UseVisualStyleBackColor = true;
          this.btnGetAll.Click += new System.EventHandler(this.BtnGetAllClick);
          // 
          // UpdateMeasurements
          // 
          resources.ApplyResources(this.UpdateMeasurements, "UpdateMeasurements");
          this.UpdateMeasurements.Name = "UpdateMeasurements";
          this.UpdateMeasurements.Tag = "";
          this.toolTip1.SetToolTip(this.UpdateMeasurements, resources.GetString("UpdateMeasurements.ToolTip"));
          this.UpdateMeasurements.Click += new System.EventHandler(this.UpdateMeasurementsClick);
          // 
          // btnFieldCalculator
          // 
          resources.ApplyResources(this.btnFieldCalculator, "btnFieldCalculator");
          this.btnFieldCalculator.Name = "btnFieldCalculator";
          this.btnFieldCalculator.Tag = "";
          this.toolTip1.SetToolTip(this.btnFieldCalculator, resources.GetString("btnFieldCalculator.ToolTip"));
          this.btnFieldCalculator.Click += new System.EventHandler(this.BtnFieldCalculatorClick);
          // 
          // btnImportFieldsFromDBF
          // 
          resources.ApplyResources(this.btnImportFieldsFromDBF, "btnImportFieldsFromDBF");
          this.btnImportFieldsFromDBF.Name = "btnImportFieldsFromDBF";
          this.toolTip1.SetToolTip(this.btnImportFieldsFromDBF, resources.GetString("btnImportFieldsFromDBF.ToolTip"));
          this.btnImportFieldsFromDBF.Click += new System.EventHandler(this.BtnImportFieldsFromDbfClick);
          // 
          // tbbQuery
          // 
          this.tbbQuery.Image = Resources.filter;
          resources.ApplyResources(this.tbbQuery, "tbbQuery");
          this.tbbQuery.Name = "tbbQuery";
          this.toolTip1.SetToolTip(this.tbbQuery, resources.GetString("tbbQuery.ToolTip"));
          this.tbbQuery.Click += new System.EventHandler(this.TbbQueryClick);
          // 
          // btnShowSelected
          // 
          resources.ApplyResources(this.btnShowSelected, "btnShowSelected");
          this.btnShowSelected.Name = "btnShowSelected";
          this.toolTip1.SetToolTip(this.btnShowSelected, resources.GetString("btnShowSelected.ToolTip"));
          this.btnShowSelected.Click += new System.EventHandler(this.BtnShowSelectedClick);
          // 
          // btnZoomToSelected
          // 
          resources.ApplyResources(this.btnZoomToSelected, "btnZoomToSelected");
          this.btnZoomToSelected.Name = "btnZoomToSelected";
          this.btnZoomToSelected.Tag = "";
          this.toolTip1.SetToolTip(this.btnZoomToSelected, resources.GetString("btnZoomToSelected.ToolTip"));
          this.btnZoomToSelected.Click += new System.EventHandler(this.BtnZoomToSelectedClick);
          // 
          // lblAmountSeleted
          // 
          resources.ApplyResources(this.lblAmountSeleted, "lblAmountSeleted");
          this.lblAmountSeleted.Name = "lblAmountSeleted";
          // 
          // btnClose
          // 
          resources.ApplyResources(this.btnClose, "btnClose");
          this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnClose.Name = "btnClose";
          this.btnClose.UseVisualStyleBackColor = true;
          this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
          // 
          // btnApply
          // 
          resources.ApplyResources(this.btnApply, "btnApply");
          this.btnApply.Name = "btnApply";
          this.btnApply.UseVisualStyleBackColor = true;
          this.btnApply.Click += new System.EventHandler(this.BtnApplyClick);
          // 
          // TableEditorDataGrid
          // 
          this.TableEditorDataGrid.AllowUserToAddRows = false;
          this.TableEditorDataGrid.AllowUserToDeleteRows = false;
          this.TableEditorDataGrid.BackgroundColor = System.Drawing.Color.LightGray;
          this.TableEditorDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
          this.TableEditorDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          resources.ApplyResources(this.TableEditorDataGrid, "TableEditorDataGrid");
          this.TableEditorDataGrid.Name = "TableEditorDataGrid";
          this.TableEditorDataGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TableEditorDataGridColumnHeaderMouseClick);
          this.TableEditorDataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.TableEditorDataGridDataError);
          // 
          // menuStrip1
          // 
          this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.selectionToolStripMenuItem,
            this.toolsToolStripMenuItem});
          resources.ApplyResources(this.menuStrip1, "menuStrip1");
          this.menuStrip1.Name = "menuStrip1";
          // 
          // editToolStripMenuItem
          // 
          this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFieldToolStripMenuItem,
            this.removeFieldToolStripMenuItem,
            this.toolStripMenuItem1,
            this.renameFieldToolStripMenuItem});
          this.editToolStripMenuItem.Name = "editToolStripMenuItem";
          resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
          // 
          // addFieldToolStripMenuItem
          // 
          this.addFieldToolStripMenuItem.Name = "addFieldToolStripMenuItem";
          resources.ApplyResources(this.addFieldToolStripMenuItem, "addFieldToolStripMenuItem");
          this.addFieldToolStripMenuItem.Click += new System.EventHandler(this.AddFieldToolStripMenuItemClick);
          // 
          // removeFieldToolStripMenuItem
          // 
          this.removeFieldToolStripMenuItem.Name = "removeFieldToolStripMenuItem";
          resources.ApplyResources(this.removeFieldToolStripMenuItem, "removeFieldToolStripMenuItem");
          this.removeFieldToolStripMenuItem.Click += new System.EventHandler(this.RemoveFieldToolStripMenuItemClick);
          // 
          // toolStripMenuItem1
          // 
          this.toolStripMenuItem1.Name = "toolStripMenuItem1";
          resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
          // 
          // renameFieldToolStripMenuItem
          // 
          this.renameFieldToolStripMenuItem.Name = "renameFieldToolStripMenuItem";
          resources.ApplyResources(this.renameFieldToolStripMenuItem, "renameFieldToolStripMenuItem");
          this.renameFieldToolStripMenuItem.Click += new System.EventHandler(this.RenameFieldToolStripMenuItemClick);
          // 
          // viewToolStripMenuItem
          // 
          this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowSelected,
            this.mnuZoomToSelected,
            this.mnuZoomToEdited});
          this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
          resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
          // 
          // mnuShowSelected
          // 
          this.mnuShowSelected.Name = "mnuShowSelected";
          resources.ApplyResources(this.mnuShowSelected, "mnuShowSelected");
          this.mnuShowSelected.Click += new System.EventHandler(this.MnuShowSelectedClick);
          // 
          // mnuZoomToSelected
          // 
          this.mnuZoomToSelected.Name = "mnuZoomToSelected";
          resources.ApplyResources(this.mnuZoomToSelected, "mnuZoomToSelected");
          this.mnuZoomToSelected.Click += new System.EventHandler(this.MnuZoomToSelectedClick);
          // 
          // mnuZoomToEdited
          // 
          this.mnuZoomToEdited.Name = "mnuZoomToEdited";
          resources.ApplyResources(this.mnuZoomToEdited, "mnuZoomToEdited");
          this.mnuZoomToEdited.Click += new System.EventHandler(this.MnuZoomToEditedClick);
          // 
          // selectionToolStripMenuItem
          // 
          this.selectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQuery,
            this.toolStripMenuItem2,
            this.mnuSelectAll,
            this.mnuSelectNone,
            this.mnuInvertSelection,
            this.toolStripMenuItem3,
            this.mnuExportFeatures});
          this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
          resources.ApplyResources(this.selectionToolStripMenuItem, "selectionToolStripMenuItem");
          // 
          // mnuQuery
          // 
          this.mnuQuery.Name = "mnuQuery";
          resources.ApplyResources(this.mnuQuery, "mnuQuery");
          this.mnuQuery.Click += new System.EventHandler(this.MnuQueryClick);
          // 
          // toolStripMenuItem2
          // 
          this.toolStripMenuItem2.Name = "toolStripMenuItem2";
          resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
          // 
          // mnuSelectAll
          // 
          this.mnuSelectAll.Name = "mnuSelectAll";
          resources.ApplyResources(this.mnuSelectAll, "mnuSelectAll");
          this.mnuSelectAll.Click += new System.EventHandler(this.MnuSelectAllClick);
          // 
          // mnuSelectNone
          // 
          this.mnuSelectNone.Name = "mnuSelectNone";
          resources.ApplyResources(this.mnuSelectNone, "mnuSelectNone");
          this.mnuSelectNone.Click += new System.EventHandler(this.MnuSelectNoneClick);
          // 
          // mnuInvertSelection
          // 
          this.mnuInvertSelection.Name = "mnuInvertSelection";
          resources.ApplyResources(this.mnuInvertSelection, "mnuInvertSelection");
          this.mnuInvertSelection.Click += new System.EventHandler(this.MnuInvertSelectionClick);
          // 
          // toolStripMenuItem3
          // 
          this.toolStripMenuItem3.Name = "toolStripMenuItem3";
          resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
          // 
          // mnuExportFeatures
          // 
          this.mnuExportFeatures.Name = "mnuExportFeatures";
          resources.ApplyResources(this.mnuExportFeatures, "mnuExportFeatures");
          this.mnuExportFeatures.Click += new System.EventHandler(this.MnuExportFeaturesClick);
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
          resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
          // 
          // mnuFind
          // 
          this.mnuFind.Name = "mnuFind";
          resources.ApplyResources(this.mnuFind, "mnuFind");
          this.mnuFind.Click += new System.EventHandler(this.MnuFindClick);
          // 
          // mnuReplace
          // 
          this.mnuReplace.Name = "mnuReplace";
          resources.ApplyResources(this.mnuReplace, "mnuReplace");
          this.mnuReplace.Click += new System.EventHandler(this.MnuReplaceClick);
          // 
          // toolStripMenuItem4
          // 
          this.toolStripMenuItem4.Name = "toolStripMenuItem4";
          resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
          // 
          // mnuImportFieldDefinitions
          // 
          this.mnuImportFieldDefinitions.Name = "mnuImportFieldDefinitions";
          resources.ApplyResources(this.mnuImportFieldDefinitions, "mnuImportFieldDefinitions");
          this.mnuImportFieldDefinitions.Click += new System.EventHandler(this.MnuImportFieldDefinitionsClick);
          // 
          // mnuFieldCalculator
          // 
          this.mnuFieldCalculator.Name = "mnuFieldCalculator";
          resources.ApplyResources(this.mnuFieldCalculator, "mnuFieldCalculator");
          this.mnuFieldCalculator.Click += new System.EventHandler(this.MnuFieldCalculatorClick);
          // 
          // mnuGenerateOrUpdateShapeID
          // 
          this.mnuGenerateOrUpdateShapeID.Name = "mnuGenerateOrUpdateShapeID";
          resources.ApplyResources(this.mnuGenerateOrUpdateShapeID, "mnuGenerateOrUpdateShapeID");
          this.mnuGenerateOrUpdateShapeID.Click += new System.EventHandler(this.MnuGenerateOrUpdateShapeIDClick);
          // 
          // mnuCopyShapeIDs
          // 
          this.mnuCopyShapeIDs.Name = "mnuCopyShapeIDs";
          resources.ApplyResources(this.mnuCopyShapeIDs, "mnuCopyShapeIDs");
          this.mnuCopyShapeIDs.Click += new System.EventHandler(this.MnuCopyShapeIDsClick);
          // 
          // mnuImportExtData
          // 
          this.mnuImportExtData.Name = "mnuImportExtData";
          resources.ApplyResources(this.mnuImportExtData, "mnuImportExtData");
          this.mnuImportExtData.Click += new System.EventHandler(this.MnuImportExtDataClick);
          // 
          // updateMeasurementsToolStripMenuItem
          // 
          this.updateMeasurementsToolStripMenuItem.Name = "updateMeasurementsToolStripMenuItem";
          resources.ApplyResources(this.updateMeasurementsToolStripMenuItem, "updateMeasurementsToolStripMenuItem");
          this.updateMeasurementsToolStripMenuItem.Click += new System.EventHandler(this.UpdateMeasurementsToolStripMenuItemClick);
          // 
          // mnuGridView
          // 
          this.mnuGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCalcValues,
            this.mnuAssignValues,
            this.toolStripMenuItem5,
            this.mnuTrimAll,
            this.mnuTrimSelected,
            this.toolStripMenuItem6,
            this.mnuStatistics});
          this.mnuGridView.Name = "mnuGridView";
          this.mnuGridView.ShowImageMargin = false;
          resources.ApplyResources(this.mnuGridView, "mnuGridView");
          // 
          // mnuCalcValues
          // 
          this.mnuCalcValues.Name = "mnuCalcValues";
          resources.ApplyResources(this.mnuCalcValues, "mnuCalcValues");
          this.mnuCalcValues.Click += new System.EventHandler(this.MnuCalcValuesClick);
          // 
          // mnuAssignValues
          // 
          this.mnuAssignValues.Name = "mnuAssignValues";
          resources.ApplyResources(this.mnuAssignValues, "mnuAssignValues");
          this.mnuAssignValues.Click += new System.EventHandler(this.MnuAssignValuesClick);
          // 
          // toolStripMenuItem5
          // 
          this.toolStripMenuItem5.Name = "toolStripMenuItem5";
          resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
          // 
          // mnuTrimAll
          // 
          this.mnuTrimAll.Name = "mnuTrimAll";
          resources.ApplyResources(this.mnuTrimAll, "mnuTrimAll");
          this.mnuTrimAll.Click += new System.EventHandler(this.MnuTrimAllClick);
          // 
          // mnuTrimSelected
          // 
          this.mnuTrimSelected.Name = "mnuTrimSelected";
          resources.ApplyResources(this.mnuTrimSelected, "mnuTrimSelected");
          this.mnuTrimSelected.Click += new System.EventHandler(this.MnuTrimSelectedClick);
          // 
          // toolStripMenuItem6
          // 
          this.toolStripMenuItem6.Name = "toolStripMenuItem6";
          resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
          // 
          // mnuStatistics
          // 
          this.mnuStatistics.Name = "mnuStatistics";
          resources.ApplyResources(this.mnuStatistics, "mnuStatistics");
          this.mnuStatistics.Click += new System.EventHandler(this.MnuStatisticsClick);
          // 
          // frmTableEditor
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ControlBox = false;
          this.Controls.Add(this.TableEditorDataGrid);
          this.Controls.Add(this.panel1);
          this.Controls.Add(this.menuStrip1);
          this.DoubleBuffered = true;
          this.KeyPreview = true;
          this.MainMenuStrip = this.menuStrip1;
          this.Name = "TableEditorForm";
          this.panel1.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.TableEditorDataGrid)).EndInit();
          this.menuStrip1.ResumeLayout(false);
          this.menuStrip1.PerformLayout();
          this.mnuGridView.ResumeLayout(false);
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem renameFieldToolStripMenuItem;
        private System.Windows.Forms.DataGridView TableEditorDataGrid;
        private System.Windows.Forms.Label lblAmountSeleted;
        private System.Windows.Forms.Button btnZoomToSelected;
        internal System.Windows.Forms.Button btnShowSelected;
        private System.Windows.Forms.ToolStripMenuItem mnuShowSelected;
        private System.Windows.Forms.ToolStripMenuItem mnuZoomToSelected;
        private System.Windows.Forms.ToolStripMenuItem mnuZoomToEdited;
        private System.Windows.Forms.ToolStripMenuItem mnuQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectNone;
        private System.Windows.Forms.ToolStripMenuItem mnuInvertSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuExportFeatures;
        private System.Windows.Forms.ToolStripMenuItem mnuFind;
        private System.Windows.Forms.ToolStripMenuItem mnuReplace;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuImportFieldDefinitions;
        private System.Windows.Forms.ToolStripMenuItem mnuFieldCalculator;
        private System.Windows.Forms.ToolStripMenuItem mnuGenerateOrUpdateShapeID;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyShapeIDs;
        internal System.Windows.Forms.Button tbbQuery;
        internal System.Windows.Forms.Button btnImportFieldsFromDBF;
        internal System.Windows.Forms.Button btnFieldCalculator;
        private System.Windows.Forms.ToolStripMenuItem mnuImportExtData;
        internal System.Windows.Forms.Button UpdateMeasurements;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem updateMeasurementsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mnuGridView;
        private System.Windows.Forms.ToolStripMenuItem mnuCalcValues;
        private System.Windows.Forms.ToolStripMenuItem mnuAssignValues;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mnuTrimAll;
        private System.Windows.Forms.ToolStripMenuItem mnuTrimSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem mnuStatistics;
        private System.Windows.Forms.Button btnGetAll;
        internal System.Windows.Forms.Button btnJoin;
    }
}