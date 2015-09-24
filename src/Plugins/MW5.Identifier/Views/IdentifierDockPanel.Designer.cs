using MW5.Plugins.Identifier.Controls;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.Identifier.Views
{
    partial class IdentifierDockPanel
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
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeNodeAdvStyleInfo treeNodeAdvStyleInfo1 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeNodeAdvStyleInfo();
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeNodeAdvSubItemStyleInfo treeNodeAdvSubItemStyleInfo1 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeNodeAdvSubItemStyleInfo();
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdvStyleInfo treeColumnAdvStyleInfo1 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdvStyleInfo();
            this._cboIdentifierMode = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolZoomToShape = new System.Windows.Forms.ToolStripButton();
            this.toolClear = new System.Windows.Forms.ToolStripButton();
            this.lblEmpty = new System.Windows.Forms.Label();
            this._treeView = new MW5.Plugins.Identifier.Controls.IdentifierTreeView();
            ((System.ComponentModel.ISupportInitialize)(this._cboIdentifierMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStripEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._treeView)).BeginInit();
            this.SuspendLayout();
            // 
            // _cboIdentifierMode
            // 
            this._cboIdentifierMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboIdentifierMode.BeforeTouchSize = new System.Drawing.Size(213, 21);
            this._cboIdentifierMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboIdentifierMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cboIdentifierMode.Location = new System.Drawing.Point(45, 6);
            this._cboIdentifierMode.Name = "_cboIdentifierMode";
            this._cboIdentifierMode.Size = new System.Drawing.Size(213, 21);
            this._cboIdentifierMode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mode";
            // 
            // panel1
            // 
            this.panel1.BorderColor = System.Drawing.Color.Gray;
            this.panel1.BorderSides = System.Windows.Forms.Border3DSide.Top;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._cboIdentifierMode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 34);
            this.panel1.TabIndex = 5;
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolZoomToShape,
            this.toolClear});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.ShowItemToolTips = true;
            this.toolStripEx1.Size = new System.Drawing.Size(268, 35);
            this.toolStripEx1.TabIndex = 45;
            this.toolStripEx1.Text = "toolStripEx1";
            // 
            // toolZoomToShape
            // 
            this.toolZoomToShape.Checked = true;
            this.toolZoomToShape.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolZoomToShape.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolZoomToShape.Image = global::MW5.Plugins.Identifier.Properties.Resources.icon_zoom_to_layer;
            this.toolZoomToShape.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolZoomToShape.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolZoomToShape.Name = "toolZoomToShape";
            this.toolZoomToShape.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.toolZoomToShape.Size = new System.Drawing.Size(38, 32);
            this.toolZoomToShape.Text = "Zoom to Shape";
            // 
            // toolClear
            // 
            this.toolClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolClear.Image = global::MW5.Plugins.Identifier.Properties.Resources.img_clear24;
            this.toolClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClear.Name = "toolClear";
            this.toolClear.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.toolClear.Size = new System.Drawing.Size(38, 32);
            this.toolClear.Text = "Clear";
            // 
            // lblEmpty
            // 
            this.lblEmpty.BackColor = System.Drawing.Color.White;
            this.lblEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmpty.Location = new System.Drawing.Point(0, 35);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(268, 175);
            this.lblEmpty.TabIndex = 47;
            this.lblEmpty.Text = "No items are identified.";
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _treeView
            // 
            this._treeView.AutoAdjustMultiLineHeight = true;
            treeNodeAdvStyleInfo1.ThemesEnabled = false;
            this._treeView.BaseStylePairs.AddRange(new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.StyleNamePair[] {
            new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.StyleNamePair("Standard", treeNodeAdvStyleInfo1),
            new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.StyleNamePair("Standard - SubItem", treeNodeAdvSubItemStyleInfo1),
            new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.StyleNamePair("Standard - Column", treeColumnAdvStyleInfo1)});
            this._treeView.BeforeTouchSize = new System.Drawing.Size(268, 175);
            this._treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._treeView.ColumnsHeaderBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control);
            this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeView.FullRowSelect = true;
            this._treeView.GutterSpace = 12;
            // 
            // 
            // 
            this._treeView.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._treeView.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this._treeView.HelpTextControl.Name = "m_helpText";
            this._treeView.HelpTextControl.Size = new System.Drawing.Size(49, 15);
            this._treeView.HelpTextControl.TabIndex = 0;
            this._treeView.HelpTextControl.Text = "help text";
            this._treeView.HideSelection = false;
            this._treeView.Location = new System.Drawing.Point(0, 35);
            this._treeView.Name = "_treeView";
            this._treeView.NodeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._treeView.SelectedNodeBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control);
            this._treeView.SelectedNodeForeColor = System.Drawing.SystemColors.ControlText;
            this._treeView.Size = new System.Drawing.Size(268, 175);
            this._treeView.TabIndex = 46;
            this._treeView.Text = "infoTreeViewBase1";
            this._treeView.ThemesEnabled = false;
            // 
            // 
            // 
            this._treeView.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this._treeView.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._treeView.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this._treeView.ToolTipControl.Name = "m_toolTip";
            this._treeView.ToolTipControl.Size = new System.Drawing.Size(41, 15);
            this._treeView.ToolTipControl.TabIndex = 1;
            this._treeView.ToolTipControl.Text = "toolTip";
            this._treeView.Visible = false;
            // 
            // IdentifierDockPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this._treeView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripEx1);
            this.Name = "IdentifierDockPanel";
            this.Size = new System.Drawing.Size(268, 244);
            ((System.ComponentModel.ISupportInitialize)(this._cboIdentifierMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._treeView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv _cboIdentifierMode;
        private System.Windows.Forms.Label label1;
        private GradientPanel panel1;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripButton toolClear;
        private IdentifierTreeView _treeView;
        private System.Windows.Forms.ToolStripButton toolZoomToShape;
        private System.Windows.Forms.Label lblEmpty;

    }
}
