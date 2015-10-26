using System.ComponentModel;

namespace MW5.Plugins.Printing.Controls.Layout
{
    partial class LayoutControlBase
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
            this._vScrollBar = new System.Windows.Forms.VScrollBar();
            this._hScrollBar = new System.Windows.Forms.HScrollBar();
            this._hScrollBarPanel = new System.Windows.Forms.Panel();
            this._hScrollBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _vScrollBar
            // 
            this._vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this._vScrollBar.Location = new System.Drawing.Point(316, 0);
            this._vScrollBar.Name = "_vScrollBar";
            this._vScrollBar.Size = new System.Drawing.Size(17, 238);
            this._vScrollBar.TabIndex = 0;
            this._vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VScrollBarScroll);
            // 
            // _hScrollBar
            // 
            this._hScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._hScrollBar.Location = new System.Drawing.Point(0, 0);
            this._hScrollBar.Name = "_hScrollBar";
            this._hScrollBar.Size = new System.Drawing.Size(314, 17);
            this._hScrollBar.TabIndex = 0;
            this._hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarScroll);
            // 
            // _hScrollBarPanel
            // 
            this._hScrollBarPanel.Controls.Add(this._hScrollBar);
            this._hScrollBarPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._hScrollBarPanel.Location = new System.Drawing.Point(0, 238);
            this._hScrollBarPanel.Name = "_hScrollBarPanel";
            this._hScrollBarPanel.Size = new System.Drawing.Size(333, 17);
            this._hScrollBarPanel.TabIndex = 1;
            // 
            // LayoutControlBase
            // 
            this.Controls.Add(this._vScrollBar);
            this.Controls.Add(this._hScrollBarPanel);
            this.Name = "LayoutControlBase";
            this.Size = new System.Drawing.Size(333, 255);
            this._hScrollBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
