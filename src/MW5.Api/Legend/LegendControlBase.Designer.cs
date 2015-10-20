using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Legend
{
    public partial class LegendControlBase
    {
        /// <summary>
        /// Destructor for the legend
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegendControlBase));
            this._vScrollBar = new System.Windows.Forms.VScrollBar();
            this._icons = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // _vScrollBar
            // 
            resources.ApplyResources(this._vScrollBar, "_vScrollBar");
            this._vScrollBar.Name = "_vScrollBar";
            this._vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VScrollBarScroll);
            // 
            // _icons
            // 
            this._icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_icons.ImageStream")));
            this._icons.TransparentColor = System.Drawing.Color.Transparent;
            this._icons.Images.SetKeyName(0, "img_raster.png");
            this._icons.Images.SetKeyName(1, "");
            this._icons.Images.SetKeyName(2, "");
            this._icons.Images.SetKeyName(3, "");
            this._icons.Images.SetKeyName(4, "");
            this._icons.Images.SetKeyName(5, "");
            this._icons.Images.SetKeyName(6, "img_label.png");
            this._icons.Images.SetKeyName(7, "img_label_grey.png");
            this._icons.Images.SetKeyName(8, "pen.png");
            this._icons.Images.SetKeyName(9, "database5.png");
            this._icons.Images.SetKeyName(10, "img_folder_open.png");
            this._icons.Images.SetKeyName(11, "img_folder_open.png");
            this._icons.Images.SetKeyName(12, "img_globe16.png");
            this._icons.Images.SetKeyName(13, "tag_gray.png");
            this._icons.Images.SetKeyName(14, "tag_blue.png");
            this._icons.Images.SetKeyName(15, "");
            // 
            // LegendControlBase
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._vScrollBar);
            this.Name = "LegendControlBase";
            resources.ApplyResources(this, "$this");
            this.ResumeLayout(false);

        }
    }
}
