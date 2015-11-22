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
            this.components = new System.ComponentModel.Container();
            this.splitContainerAdv1 = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this._treeView = new MW5.Tools.Toolbox.ToolboxTreeView();
            this.contextMenuStripEx1 = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            this.mnuRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBatchRun = new System.Windows.Forms.ToolStripMenuItem();
            this._textbox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).BeginInit();
            this.splitContainerAdv1.Panel1.SuspendLayout();
            this.splitContainerAdv1.Panel2.SuspendLayout();
            this.splitContainerAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._treeView)).BeginInit();
            this.contextMenuStripEx1.SuspendLayout();
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
            // 
            // splitContainerAdv1.Panel2
            // 
            this.splitContainerAdv1.Panel2.Controls.Add(this._textbox);
            this.splitContainerAdv1.Size = new System.Drawing.Size(150, 150);
            this.splitContainerAdv1.SplitterDistance = 107;
            this.splitContainerAdv1.TabIndex = 0;
            this.splitContainerAdv1.Text = "splitContainerAdv1";
            // 
            // _treeView
            // 
            this._treeView.ApplyStyle = true;
            this._treeView.BackColor = System.Drawing.Color.White;
            this._treeView.BeforeTouchSize = new System.Drawing.Size(150, 107);
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
            this._treeView.Location = new System.Drawing.Point(0, 0);
            this._treeView.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this._treeView.Name = "_treeView";
            this._treeView.ShowFocusRect = true;
            this._treeView.ShowSuperTooltip = true;
            this._treeView.Size = new System.Drawing.Size(150, 107);
            this._treeView.TabIndex = 0;
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
            // _textbox
            // 
            this._textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textbox.Location = new System.Drawing.Point(0, 0);
            this._textbox.Name = "_textbox";
            this._textbox.Size = new System.Drawing.Size(150, 36);
            this._textbox.TabIndex = 1;
            this._textbox.Text = "";
            // 
            // ToolboxDockPanel
            // 
            this.Controls.Add(this.splitContainerAdv1);
            this.Name = "ToolboxDockPanel";
            this.splitContainerAdv1.Panel1.ResumeLayout(false);
            this.splitContainerAdv1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).EndInit();
            this.splitContainerAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._treeView)).EndInit();
            this.contextMenuStripEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolboxTreeView _treeView;
        private RichTextBox _textbox;
        private SplitContainerAdv splitContainerAdv1;
        private ContextMenuStripEx contextMenuStripEx1;
        private ToolStripMenuItem mnuRun;
        private ToolStripMenuItem mnuBatchRun;
    }
}
