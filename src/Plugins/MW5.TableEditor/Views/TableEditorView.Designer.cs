using System.Windows.Forms;
using MW5.Plugins.TableEditor.Editor;
using Syncfusion.Windows.Forms;

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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dockingManager1 = new Syncfusion.Windows.Forms.Tools.DockingManager(this.components);
            this.toolStripEx1 = new System.Windows.Forms.ToolStrip();
            this.toolEdit = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuStartEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSelection = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuShowSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoomToSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoomToEdited = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportFeatures = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFields = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuAddField = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRenameField = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCalculateField = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdateMeasurements = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRemoveField = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTools = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuImportFieldDefinitions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGenerateOrUpdateShapeID = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyShapeIDs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportExtData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolJoin = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolLayout = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuLayoutVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLayoutHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLayoutTabbed = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNoLayers = new System.Windows.Forms.Label();
            this.mnuFindNext = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dockingManager1)).BeginInit();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockingManager1
            // 
            this.dockingManager1.ActiveCaptionFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockingManager1.AutoHideTabFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockingManager1.DockLayoutStream = ((System.IO.MemoryStream)(resources.GetObject("dockingManager1.DockLayoutStream")));
            this.dockingManager1.DockTabFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockingManager1.EnableAutoAdjustCaption = true;
            this.dockingManager1.HostControl = this;
            this.dockingManager1.InActiveCaptionBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212))))));
            this.dockingManager1.InActiveCaptionFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockingManager1.MetroButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dockingManager1.MetroCaptionColor = System.Drawing.Color.White;
            this.dockingManager1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dockingManager1.MetroSplitterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(159)))), ((int)(((byte)(183)))));
            this.dockingManager1.ReduceFlickeringInRtl = false;
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"));
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"));
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"));
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"));
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"));
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.AutoSize = false;
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolEdit,
            this.toolStripSeparator1,
            this.toolSelection,
            this.toolFields,
            this.toolTools,
            this.toolStripSeparator6,
            this.toolLayout});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.ShowItemToolTips = false;
            this.toolStripEx1.Size = new System.Drawing.Size(712, 32);
            this.toolStripEx1.TabIndex = 18;
            this.toolStripEx1.Text = "toolStripEx1";
            // 
            // toolEdit
            // 
            this.toolEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStartEdit,
            this.toolStripSeparator3,
            this.mnuSaveChanges});
            this.toolEdit.Image = global::MW5.Plugins.TableEditor.Properties.Resources.icon_layer_edit;
            this.toolEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEdit.Name = "toolEdit";
            this.toolEdit.Size = new System.Drawing.Size(37, 29);
            this.toolEdit.Text = "toolStripDropDownButton5";
            // 
            // mnuStartEdit
            // 
            this.mnuStartEdit.Name = "mnuStartEdit";
            this.mnuStartEdit.Size = new System.Drawing.Size(145, 22);
            this.mnuStartEdit.Text = "Start editing";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(142, 6);
            // 
            // mnuSaveChanges
            // 
            this.mnuSaveChanges.Name = "mnuSaveChanges";
            this.mnuSaveChanges.Size = new System.Drawing.Size(145, 22);
            this.mnuSaveChanges.Text = "Save changes";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolSelection
            // 
            this.toolSelection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowSelected,
            this.mnuZoomToSelected,
            this.mnuZoomToEdited,
            this.toolStripSeparator5,
            this.mnuQuery,
            this.toolStripSeparator2,
            this.mnuSelectAll,
            this.mnuClearSelection,
            this.mnuExportFeatures,
            this.toolStripMenuItem3,
            this.mnuInvertSelection});
            this.toolSelection.ForeColor = System.Drawing.Color.Black;
            this.toolSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSelection.Name = "toolSelection";
            this.toolSelection.Size = new System.Drawing.Size(68, 29);
            this.toolSelection.Text = "Selection";
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuQuery
            // 
            this.mnuQuery.Name = "mnuQuery";
            this.mnuQuery.Size = new System.Drawing.Size(224, 22);
            this.mnuQuery.Text = "Query";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Name = "mnuSelectAll";
            this.mnuSelectAll.Size = new System.Drawing.Size(224, 22);
            this.mnuSelectAll.Text = "Select All";
            // 
            // mnuClearSelection
            // 
            this.mnuClearSelection.Name = "mnuClearSelection";
            this.mnuClearSelection.Size = new System.Drawing.Size(224, 22);
            this.mnuClearSelection.Text = "Select None";
            // 
            // mnuExportFeatures
            // 
            this.mnuExportFeatures.Name = "mnuExportFeatures";
            this.mnuExportFeatures.Size = new System.Drawing.Size(224, 22);
            this.mnuExportFeatures.Text = "Export Selected Features";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuInvertSelection
            // 
            this.mnuInvertSelection.Name = "mnuInvertSelection";
            this.mnuInvertSelection.Size = new System.Drawing.Size(224, 22);
            this.mnuInvertSelection.Text = "Invert Selection";
            // 
            // toolFields
            // 
            this.toolFields.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddField,
            this.toolStripSeparator4,
            this.mnuRenameField,
            this.mnuCalculateField,
            this.mnuUpdateMeasurements,
            this.toolStripMenuItem1,
            this.mnuRemoveField});
            this.toolFields.ForeColor = System.Drawing.Color.Black;
            this.toolFields.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolFields.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFields.Name = "toolFields";
            this.toolFields.Size = new System.Drawing.Size(50, 29);
            this.toolFields.Text = "Fields";
            // 
            // mnuAddField
            // 
            this.mnuAddField.Name = "mnuAddField";
            this.mnuAddField.Size = new System.Drawing.Size(193, 22);
            this.mnuAddField.Text = "Add Field";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuRenameField
            // 
            this.mnuRenameField.Name = "mnuRenameField";
            this.mnuRenameField.Size = new System.Drawing.Size(193, 22);
            this.mnuRenameField.Text = "Rename Field";
            // 
            // mnuCalculateField
            // 
            this.mnuCalculateField.Name = "mnuCalculateField";
            this.mnuCalculateField.Size = new System.Drawing.Size(193, 22);
            this.mnuCalculateField.Text = "Calculate Field";
            // 
            // mnuUpdateMeasurements
            // 
            this.mnuUpdateMeasurements.Name = "mnuUpdateMeasurements";
            this.mnuUpdateMeasurements.Size = new System.Drawing.Size(193, 22);
            this.mnuUpdateMeasurements.Text = "Update Measurements";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuRemoveField
            // 
            this.mnuRemoveField.Name = "mnuRemoveField";
            this.mnuRemoveField.Size = new System.Drawing.Size(193, 22);
            this.mnuRemoveField.Text = "Remove Field";
            // 
            // toolTools
            // 
            this.toolTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFind,
            this.mnuFindNext,
            this.mnuReplace,
            this.toolStripSeparator7,
            this.mnuImportFieldDefinitions,
            this.mnuGenerateOrUpdateShapeID,
            this.mnuCopyShapeIDs,
            this.mnuImportExtData,
            this.toolJoin});
            this.toolTools.ForeColor = System.Drawing.Color.Black;
            this.toolTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTools.Name = "toolTools";
            this.toolTools.Size = new System.Drawing.Size(49, 29);
            this.toolTools.Text = "Tools";
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
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(269, 6);
            // 
            // mnuImportFieldDefinitions
            // 
            this.mnuImportFieldDefinitions.Name = "mnuImportFieldDefinitions";
            this.mnuImportFieldDefinitions.Size = new System.Drawing.Size(272, 22);
            this.mnuImportFieldDefinitions.Text = "Import Field Definitions from DBF";
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
            // toolJoin
            // 
            this.toolJoin.ForeColor = System.Drawing.Color.Black;
            this.toolJoin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolJoin.Name = "toolJoin";
            this.toolJoin.Size = new System.Drawing.Size(137, 19);
            this.toolJoin.Text = "Join external datasource";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 32);
            // 
            // toolLayout
            // 
            this.toolLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLayoutVertical,
            this.mnuLayoutHorizontal,
            this.mnuLayoutTabbed});
            this.toolLayout.ForeColor = System.Drawing.Color.Black;
            this.toolLayout.Image = ((System.Drawing.Image)(resources.GetObject("toolLayout.Image")));
            this.toolLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLayout.Name = "toolLayout";
            this.toolLayout.Size = new System.Drawing.Size(56, 29);
            this.toolLayout.Text = "Layout";
            // 
            // mnuLayoutVertical
            // 
            this.mnuLayoutVertical.Name = "mnuLayoutVertical";
            this.mnuLayoutVertical.Size = new System.Drawing.Size(129, 22);
            this.mnuLayoutVertical.Text = "Vertical";
            // 
            // mnuLayoutHorizontal
            // 
            this.mnuLayoutHorizontal.Name = "mnuLayoutHorizontal";
            this.mnuLayoutHorizontal.Size = new System.Drawing.Size(129, 22);
            this.mnuLayoutHorizontal.Text = "Horizontal";
            // 
            // mnuLayoutTabbed
            // 
            this.mnuLayoutTabbed.Name = "mnuLayoutTabbed";
            this.mnuLayoutTabbed.Size = new System.Drawing.Size(129, 22);
            this.mnuLayoutTabbed.Text = "Tabbed";
            // 
            // lblNoLayers
            // 
            this.lblNoLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNoLayers.Location = new System.Drawing.Point(0, 32);
            this.lblNoLayers.Name = "lblNoLayers";
            this.lblNoLayers.Size = new System.Drawing.Size(712, 272);
            this.lblNoLayers.TabIndex = 19;
            this.lblNoLayers.Text = "No layers are opened in the table editor.";
            this.lblNoLayers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mnuFindNext
            // 
            this.mnuFindNext.Name = "mnuFindNext";
            this.mnuFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuFindNext.Size = new System.Drawing.Size(272, 22);
            this.mnuFindNext.Text = "Find next";
            // 
            // TableEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNoLayers);
            this.Controls.Add(this.toolStripEx1);
            this.Name = "TableEditorView";
            this.Size = new System.Drawing.Size(712, 304);
            ((System.ComponentModel.ISupportInitialize)(this.dockingManager1)).EndInit();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private Syncfusion.Windows.Forms.Tools.DockingManager dockingManager1;
        private ToolStrip toolStripEx1;
        private System.Windows.Forms.ToolStripDropDownButton toolFields;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuAddField;
        private ToolStripMenuItem mnuRenameField;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem mnuRemoveField;
        private ToolStripMenuItem mnuCalculateField;
        private ToolStripDropDownButton toolSelection;
        private ToolStripMenuItem mnuQuery;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem mnuSelectAll;
        private ToolStripMenuItem mnuClearSelection;
        private ToolStripMenuItem mnuExportFeatures;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem mnuInvertSelection;
        private ToolStripDropDownButton toolTools;
        private ToolStripMenuItem mnuFind;
        private ToolStripMenuItem mnuReplace;
        private ToolStripMenuItem mnuImportFieldDefinitions;
        private ToolStripMenuItem mnuGenerateOrUpdateShapeID;
        private ToolStripMenuItem mnuCopyShapeIDs;
        private ToolStripMenuItem mnuImportExtData;
        private ToolStripDropDownButton toolEdit;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem mnuShowSelected;
        private ToolStripMenuItem mnuZoomToSelected;
        private ToolStripMenuItem mnuZoomToEdited;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripDropDownButton toolLayout;
        private ToolStripMenuItem mnuLayoutVertical;
        private ToolStripMenuItem mnuLayoutHorizontal;
        private ToolStripMenuItem mnuLayoutTabbed;
        private Label lblNoLayers;
        private ToolStripButton toolJoin;
        private ToolStripMenuItem mnuStartEdit;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem mnuSaveChanges;
        private ToolStripMenuItem mnuUpdateMeasurements;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem mnuFindNext;

    }
}