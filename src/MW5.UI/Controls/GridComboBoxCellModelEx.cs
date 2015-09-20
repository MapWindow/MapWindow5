using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms.Grid;

namespace MW5.UI.Controls
{
    /// <remarks>
    /// For testing only.
    /// </remarks>
    public class GridComboBoxCellModelEx : GridComboBoxCellModel
    {
        public GridComboBoxCellModelEx(GridModel grid)
            : base(grid)
        {
            
        }

        public override GridCellRendererBase CreateRenderer(GridControlBase control)
        {
            return new GridComboBoxCellRendererEx(control, this);
        }
    }
}
