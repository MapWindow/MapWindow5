using System.ComponentModel;
using System.Windows.Forms;

namespace MW5.Plugins.Printing.Controls
{
    public partial class LayoutListBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutListBox));
            this._listbox = new System.Windows.Forms.ListBox();
            this._btnPanel = new System.Windows.Forms.Panel();
            this._btnDown = new System.Windows.Forms.Button();
            this._btnUp = new System.Windows.Forms.Button();
            this._btnRemove = new System.Windows.Forms.Button();
            this._listPanel = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._btnPanel.SuspendLayout();
            this._listPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _listbox
            // 
            this._listbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this._listbox, "_listbox");
            this._listbox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._listbox.FormattingEnabled = true;
            this._listbox.Name = "_listbox";
            this._listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this._listbox.SelectedIndexChanged += new System.EventHandler(this.OnListBoxSelectedIndexChanged);
            // 
            // _btnPanel
            // 
            this._btnPanel.Controls.Add(this._btnDown);
            this._btnPanel.Controls.Add(this._btnUp);
            this._btnPanel.Controls.Add(this._btnRemove);
            resources.ApplyResources(this._btnPanel, "_btnPanel");
            this._btnPanel.Name = "_btnPanel";
            // 
            // _btnDown
            // 
            resources.ApplyResources(this._btnDown, "_btnDown");
            this._btnDown.Name = "_btnDown";
            this.toolTip1.SetToolTip(this._btnDown, resources.GetString("_btnDown.ToolTip"));
            this._btnDown.UseVisualStyleBackColor = true;
            // 
            // _btnUp
            // 
            resources.ApplyResources(this._btnUp, "_btnUp");
            this._btnUp.Name = "_btnUp";
            this.toolTip1.SetToolTip(this._btnUp, resources.GetString("_btnUp.ToolTip"));
            this._btnUp.UseVisualStyleBackColor = true;
            // 
            // _btnRemove
            // 
            resources.ApplyResources(this._btnRemove, "_btnRemove");
            this._btnRemove.Name = "_btnRemove";
            this.toolTip1.SetToolTip(this._btnRemove, resources.GetString("_btnRemove.ToolTip"));
            this._btnRemove.UseVisualStyleBackColor = true;
            // 
            // _listPanel
            // 
            this._listPanel.BackColor = System.Drawing.Color.White;
            this._listPanel.Controls.Add(this._listbox);
            resources.ApplyResources(this._listPanel, "_listPanel");
            this._listPanel.Name = "_listPanel";
            // 
            // LayoutListBox
            // 
            this.Controls.Add(this._listPanel);
            this.Controls.Add(this._btnPanel);
            this.Name = "LayoutListBox";
            resources.ApplyResources(this, "$this");
            this._btnPanel.ResumeLayout(false);
            this._listPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Button _btnDown;
        private Panel _btnPanel;
        private Button _btnRemove;
        private Button _btnUp;
        private ListBox _listbox;
        private Panel _listPanel;
        private ToolTip toolTip1;

        #endregion
    }
}
