using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Events;
using MW5.Plugins.Concrete;
using MW5.Shared;
using MW5.Shared.Log;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Controls
{
    public partial class GridListControl<T>
        where T: class
    {
        private void InitializeComponent()
        {
            this._grid = new GridControlBase();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.BackColor = System.Drawing.SystemColors.Window;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.FreezeCaption = false;
            this._grid.Location = new System.Drawing.Point(0, 0);
            this._grid.Name = "_grid";
            this._grid.Size = new System.Drawing.Size(150, 150);
            this._grid.TabIndex = 0;
            this._grid.Text = "gridGroupingControl1";
            this._grid.VersionInfo = "12.4450.0.24";
            // 
            // GridListControl
            // 
            this.Controls.Add(this._grid);
            this.Name = "GridListControl";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
