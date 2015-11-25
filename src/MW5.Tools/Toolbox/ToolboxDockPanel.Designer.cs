using System.ComponentModel;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Toolbox
{
    public partial class ToolboxDockPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolboxDockPanel));
            this.splitContainerAdv1 = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this._treeView = new MW5.Tools.Toolbox.ToolboxTreeView();
            this.contextMenuStripEx1 = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            this.mnuRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBatchRun = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.txtSearch = new MW5.UI.Controls.WatermarkTextbox();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolRun = new System.Windows.Forms.ToolStripButton();
            this.toolBatchRun = new System.Windows.Forms.ToolStripButton();
            this._textbox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).BeginInit();
            this.splitContainerAdv1.Panel1.SuspendLayout();
            this.splitContainerAdv1.Panel2.SuspendLayout();
            this.splitContainerAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._treeView)).BeginInit();
            this.contextMenuStripEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerAdv1
            // 
            this.splitContainerAdv1.BeforeTouchSize = 7;
            this.splitContainerAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAdv1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerAdv1.Name = "splitContainerAdv1";
            this.splitContainerAdv1.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // splitContainerAdv1.Panel1
            // 
            this.splitContainerAdv1.Panel1.Controls.Add(this._treeView);
            this.splitContainerAdv1.Panel1.Controls.Add(this.gradientPanel1);
            this.splitContainerAdv1.Panel1.Controls.Add(this.toolStripEx1);
            // 
            // splitContainerAdv1.Panel2
            // 
            this.splitContainerAdv1.Panel2.Controls.Add(this._textbox);
            this.splitContainerAdv1.Size = new System.Drawing.Size(252, 220);
            this.splitContainerAdv1.SplitterDistance = 156;
            this.splitContainerAdv1.TabIndex = 0;
            this.splitContainerAdv1.Text = "splitContainerAdv1";
            // 
            // _treeView
            // 
            this._treeView.ApplyStyle = true;
            this._treeView.BackColor = System.Drawing.Color.White;
            this._treeView.BeforeTouchSize = new System.Drawing.Size(252, 94);
            this._treeView.BorderSingle = System.Windows.Forms.ButtonBorderStyle.None;
            this._treeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._treeView.CanSelectDisabledNode = false;
            this._treeView.ContextMenuStrip = this.contextMenuStripEx1;
            this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this._treeView.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this._treeView.HelpTextControl.Name = "helpText";
            this._treeView.HelpTextControl.TabIndex = 0;
            this._treeView.HideSelection = false;
            this._treeView.Location = new System.Drawing.Point(0, 62);
            this._treeView.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this._treeView.Name = "_treeView";
            this._treeView.ShowFocusRect = true;
            this._treeView.ShowSuperTooltip = true;
            this._treeView.Size = new System.Drawing.Size(252, 94);
            this._treeView.TabIndex = 2;
            this._treeView.Text = "toolboxTreeView1";
            // 
            // 
            // 
            this._treeView.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this._treeView.ToolTipControl.Name = "toolTip";
            this._treeView.ToolTipControl.TabIndex = 1;
            this._treeView.ToolTipDuration = 0;
            // 
            // contextMenuStripEx1
            // 
            this.contextMenuStripEx1.DropShadowEnabled = false;
            this.contextMenuStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRun,
            this.mnuBatchRun});
            this.contextMenuStripEx1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(236)))), ((int)(((byte)(249)))));
            this.contextMenuStripEx1.Name = "contextMenuStripEx1";
            this.contextMenuStripEx1.Size = new System.Drawing.Size(148, 48);
            this.contextMenuStripEx1.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.Metro;
            // 
            // mnuRun
            // 
            this.mnuRun.Name = "mnuRun";
            this.mnuRun.Size = new System.Drawing.Size(147, 22);
            this.mnuRun.Text = "Execute";
            // 
            // mnuBatchRun
            // 
            this.mnuBatchRun.Name = "mnuBatchRun";
            this.mnuBatchRun.Size = new System.Drawing.Size(147, 22);
            this.mnuBatchRun.Text = "Batch execute";
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gradientPanel1.Controls.Add(this.txtSearch);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 37);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(252, 25);
            this.gradientPanel1.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BeforeTouchSize = new System.Drawing.Size(252, 21);
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Cue = "Enter tool name";
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.FarImage = ((System.Drawing.Image)(resources.GetObject("txtSearch.FarImage")));
            this.txtSearch.FocusBorderColor = System.Drawing.Color.Gray;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.txtSearch.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSearch.MinimumSize = new System.Drawing.Size(24, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ShowClearButton = true;
            this.txtSearch.Size = new System.Drawing.Size(252, 21);
            this.txtSearch.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.txtSearch.TabIndex = 0;
            this.txtSearch.ThemesEnabled = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.OnSearchTextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnSearchKeyDown);
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolRun,
            this.toolBatchRun});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.ShowItemToolTips = true;
            this.toolStripEx1.Size = new System.Drawing.Size(252, 37);
            this.toolStripEx1.TabIndex = 2;
            this.toolStripEx1.Text = "toolStripEx1";
            // 
            // toolRun
            // 
            this.toolRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRun.Image = global::MW5.Tools.Properties.Resources.img_run24;
            this.toolRun.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRun.Name = "toolRun";
            this.toolRun.Padding = new System.Windows.Forms.Padding(3);
            this.toolRun.Size = new System.Drawing.Size(34, 34);
            this.toolRun.Text = "Execute tool";
            // 
            // toolBatchRun
            // 
            this.toolBatchRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBatchRun.Image = global::MW5.Tools.Properties.Resources.img_run_batch24;
            this.toolBatchRun.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBatchRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBatchRun.Name = "toolBatchRun";
            this.toolBatchRun.Padding = new System.Windows.Forms.Padding(3);
            this.toolBatchRun.Size = new System.Drawing.Size(34, 34);
            this.toolBatchRun.Text = "Execute tool in batch mode";
            // 
            // _textbox
            // 
            this._textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textbox.Location = new System.Drawing.Point(0, 0);
            this._textbox.Name = "_textbox";
            this._textbox.Size = new System.Drawing.Size(252, 57);
            this._textbox.TabIndex = 2;
            this._textbox.TabStop = false;
            this._textbox.Text = "";
            // 
            // ToolboxDockPanel
            // 
            this.Controls.Add(this.splitContainerAdv1);
            this.Name = "ToolboxDockPanel";
            this.Size = new System.Drawing.Size(252, 220);
            this.splitContainerAdv1.Panel1.ResumeLayout(false);
            this.splitContainerAdv1.Panel1.PerformLayout();
            this.splitContainerAdv1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).EndInit();
            this.splitContainerAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._treeView)).EndInit();
            this.contextMenuStripEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ToolboxTreeView _treeView;
        private RichTextBox _textbox;
        private SplitContainerAdv splitContainerAdv1;
        private ContextMenuStripEx contextMenuStripEx1;
        private ToolStripMenuItem mnuRun;
        private ToolStripMenuItem mnuBatchRun;
        private GradientPanel gradientPanel1;
        private UI.Controls.WatermarkTextbox txtSearch;
        private ToolStripEx toolStripEx1;
        private ToolStripButton toolRun;
        private ToolStripButton toolBatchRun;
    }
}
