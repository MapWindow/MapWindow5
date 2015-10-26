using System.Windows.Forms;
using MW5.Plugins.Printing.Controls.PropertyGrid;
using MW5.Plugins.Printing.Views.Panels;

namespace MW5.Plugins.Printing.Controls.Layout
{
    partial class ZoomableLayoutControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any Resources. being used.
        /// </summary>
        /// <param name="disposing">true if managed Resources. should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZoomableLayoutControl));
            
            this._contextMenuRight = new System.Windows.Forms.ContextMenu();
            this._cMnuMoveUp = new System.Windows.Forms.MenuItem();
            this._cMnuMoveDown = new System.Windows.Forms.MenuItem();
            this._menuItem2 = new System.Windows.Forms.MenuItem();
            this._cMnuSelAli = new System.Windows.Forms.MenuItem();
            this._cMnuSelLeft = new System.Windows.Forms.MenuItem();
            this._cMnuSelRight = new System.Windows.Forms.MenuItem();
            this._cMnuSelTop = new System.Windows.Forms.MenuItem();
            this._cMnuSelBottom = new System.Windows.Forms.MenuItem();
            this._cMnuSelHor = new System.Windows.Forms.MenuItem();
            this._cMnuSelVert = new System.Windows.Forms.MenuItem();
            this._cMnuMarAli = new System.Windows.Forms.MenuItem();
            this._cMnuMargLeft = new System.Windows.Forms.MenuItem();
            this._cMnuMargRight = new System.Windows.Forms.MenuItem();
            this._cMnuMargTop = new System.Windows.Forms.MenuItem();
            this._cMnuMargBottom = new System.Windows.Forms.MenuItem();
            this._cMnuMargHor = new System.Windows.Forms.MenuItem();
            this._cMnuMargVert = new System.Windows.Forms.MenuItem();
            this._menuItem19 = new System.Windows.Forms.MenuItem();
            this._cMnuSelFit = new System.Windows.Forms.MenuItem();
            this._cMnuSelWidth = new System.Windows.Forms.MenuItem();
            this._cMnuSelHeight = new System.Windows.Forms.MenuItem();
            this._cMnuMarFit = new System.Windows.Forms.MenuItem();
            this._cMnuMargWidth = new System.Windows.Forms.MenuItem();
            this._cMnuMargHeight = new System.Windows.Forms.MenuItem();
            this._menuItem4 = new System.Windows.Forms.MenuItem();
            this._cMnuDelete = new System.Windows.Forms.MenuItem();
            
            this.SuspendLayout();
            
            // 
            // _contextMenuRight
            // 
            this._contextMenuRight.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._cMnuMoveUp,
            this._cMnuMoveDown,
            this._menuItem2,
            this._cMnuSelAli,
            this._cMnuMarAli,
            this._menuItem19,
            this._cMnuSelFit,
            this._cMnuMarFit,
            this._menuItem4,
            this._cMnuDelete});
            resources.ApplyResources(this._contextMenuRight, "_contextMenuRight");
            // 
            // _cMnuMoveUp
            // 
            resources.ApplyResources(this._cMnuMoveUp, "_cMnuMoveUp");
            this._cMnuMoveUp.Index = 0;
            this._cMnuMoveUp.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutMenuStripSelectMoveUp;
            // 
            // _cMnuMoveDown
            // 
            resources.ApplyResources(this._cMnuMoveDown, "_cMnuMoveDown");
            this._cMnuMoveDown.Index = 1;
            this._cMnuMoveDown.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutMenuStripSelectMoveDown;
            // 
            // _menuItem2
            // 
            resources.ApplyResources(this._menuItem2, "_menuItem2");
            this._menuItem2.Index = 2;
            // 
            // _cMnuSelAli
            // 
            resources.ApplyResources(this._cMnuSelAli, "_cMnuSelAli");
            this._cMnuSelAli.Index = 3;
            this._cMnuSelAli.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._cMnuSelLeft,
            this._cMnuSelRight,
            this._cMnuSelTop,
            this._cMnuSelBottom,
            this._cMnuSelHor,
            this._cMnuSelVert});
            this._cMnuSelAli.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuSelectionAlignment;
            // 
            // _cMnuSelLeft
            // 
            resources.ApplyResources(this._cMnuSelLeft, "_cMnuSelLeft");
            this._cMnuSelLeft.Index = 0;
            this._cMnuSelLeft.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuLeft;
            // 
            // _cMnuSelRight
            // 
            resources.ApplyResources(this._cMnuSelRight, "_cMnuSelRight");
            this._cMnuSelRight.Index = 1;
            this._cMnuSelRight.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuRight;
            // 
            // _cMnuSelTop
            // 
            resources.ApplyResources(this._cMnuSelTop, "_cMnuSelTop");
            this._cMnuSelTop.Index = 2;
            this._cMnuSelTop.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuTop;
            // 
            // _cMnuSelBottom
            // 
            resources.ApplyResources(this._cMnuSelBottom, "_cMnuSelBottom");
            this._cMnuSelBottom.Index = 3;
            this._cMnuSelBottom.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuBottom;
            // 
            // _cMnuSelHor
            // 
            resources.ApplyResources(this._cMnuSelHor, "_cMnuSelHor");
            this._cMnuSelHor.Index = 4;
            this._cMnuSelHor.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuHor;
            // 
            // _cMnuSelVert
            // 
            resources.ApplyResources(this._cMnuSelVert, "_cMnuSelVert");
            this._cMnuSelVert.Index = 5;
            this._cMnuSelVert.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuVert;
            // 
            // _cMnuMarAli
            // 
            resources.ApplyResources(this._cMnuMarAli, "_cMnuMarAli");
            this._cMnuMarAli.Index = 4;
            this._cMnuMarAli.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._cMnuMargLeft,
            this._cMnuMargRight,
            this._cMnuMargTop,
            this._cMnuMargBottom,
            this._cMnuMargHor,
            this._cMnuMargVert});
            this._cMnuMarAli.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuMargAlign;
            // 
            // _cMnuMargLeft
            // 
            resources.ApplyResources(this._cMnuMargLeft, "_cMnuMargLeft");
            this._cMnuMargLeft.Index = 0;
            this._cMnuMargLeft.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuLeft;
            // 
            // _cMnuMargRight
            // 
            resources.ApplyResources(this._cMnuMargRight, "_cMnuMargRight");
            this._cMnuMargRight.Index = 1;
            this._cMnuMargRight.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuRight;
            // 
            // _cMnuMargTop
            // 
            resources.ApplyResources(this._cMnuMargTop, "_cMnuMargTop");
            this._cMnuMargTop.Index = 2;
            this._cMnuMargTop.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuTop;
            // 
            // _cMnuMargBottom
            // 
            resources.ApplyResources(this._cMnuMargBottom, "_cMnuMargBottom");
            this._cMnuMargBottom.Index = 3;
            this._cMnuMargBottom.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuBottom;
            // 
            // _cMnuMargHor
            // 
            resources.ApplyResources(this._cMnuMargHor, "_cMnuMargHor");
            this._cMnuMargHor.Index = 4;
            this._cMnuMargHor.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuHor;
            // 
            // _cMnuMargVert
            // 
            resources.ApplyResources(this._cMnuMargVert, "_cMnuMargVert");
            this._cMnuMargVert.Index = 5;
            this._cMnuMargVert.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuVert;
            // 
            // _menuItem19
            // 
            resources.ApplyResources(this._menuItem19, "_menuItem19");
            this._menuItem19.Index = 5;
            // 
            // _cMnuSelFit
            // 
            resources.ApplyResources(this._cMnuSelFit, "_cMnuSelFit");
            this._cMnuSelFit.Index = 6;
            this._cMnuSelFit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._cMnuSelWidth,
            this._cMnuSelHeight});
            this._cMnuSelFit.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuSelectionFit;
            // 
            // _cMnuSelWidth
            // 
            resources.ApplyResources(this._cMnuSelWidth, "_cMnuSelWidth");
            this._cMnuSelWidth.Index = 0;
            this._cMnuSelWidth.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuWidth;
            // 
            // _cMnuSelHeight
            // 
            resources.ApplyResources(this._cMnuSelHeight, "_cMnuSelHeight");
            this._cMnuSelHeight.Index = 1;
            this._cMnuSelHeight.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuHeight;
            // 
            // _cMnuMarFit
            // 
            resources.ApplyResources(this._cMnuMarFit, "_cMnuMarFit");
            this._cMnuMarFit.Index = 7;
            this._cMnuMarFit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._cMnuMargWidth,
            this._cMnuMargHeight});
            this._cMnuMarFit.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuMarginFit;
            // 
            // _cMnuMargWidth
            // 
            resources.ApplyResources(this._cMnuMargWidth, "_cMnuMargWidth");
            this._cMnuMargWidth.Index = 0;
            this._cMnuMargWidth.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuWidth;
            // 
            // _cMnuMargHeight
            // 
            resources.ApplyResources(this._cMnuMargHeight, "_cMnuMargHeight");
            this._cMnuMargHeight.Index = 1;
            this._cMnuMargHeight.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutCmnuHeight;
            // 
            // _menuItem4
            // 
            resources.ApplyResources(this._menuItem4, "_menuItem4");
            this._menuItem4.Index = 8;
            // 
            // _cMnuDelete
            // 
            resources.ApplyResources(this._cMnuDelete, "_cMnuDelete");
            this._cMnuDelete.Index = 9;
            this._cMnuDelete.Text = global::MW5.Plugins.Printing.Properties.Strings.LayoutMenuStripSelectDelete;
            
            this.ResumeLayout(false);
        }

        #endregion Windows Form Designer generated code

        private MenuItem _cMnuDelete;
        private MenuItem _cMnuMarAli;
        private MenuItem _cMnuMarFit;
        private MenuItem _cMnuMargBottom;
        private MenuItem _cMnuMargHeight;
        private MenuItem _cMnuMargHor;
        private MenuItem _cMnuMargLeft;
        private MenuItem _cMnuMargRight;
        private MenuItem _cMnuMargTop;
        private MenuItem _cMnuMargVert;
        private MenuItem _cMnuMargWidth;
        private MenuItem _cMnuMoveDown;
        private MenuItem _cMnuMoveUp;
        protected MenuItem _cMnuSelAli;
        private MenuItem _cMnuSelBottom;
        protected MenuItem _cMnuSelFit;
        private MenuItem _cMnuSelHeight;
        private MenuItem _cMnuSelHor;
        private MenuItem _cMnuSelLeft;
        private MenuItem _cMnuSelRight;
        private MenuItem _cMnuSelTop;
        private MenuItem _cMnuSelVert;
        private MenuItem _cMnuSelWidth;
        private MenuItem _menuItem19;
        private MenuItem _menuItem2;
        private MenuItem _menuItem4;
        
        protected ContextMenu _contextMenuRight;
        protected LayoutListBox _layoutListBox;
        protected PropertiesDockPanel _layoutPropertyGrip;
    }
}
