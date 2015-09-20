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
    public class GridComboBoxCellRendererEx: GridComboBoxCellRenderer
    {
        public GridComboBoxCellRendererEx(GridControlBase grid, GridCellModelBase cellModel)
            : base(grid, cellModel)
        {
            SupportsFocusControl = false;
        }

        protected override bool OnSaveChanges()
        {
            var info = Grid.Model[RowIndex, ColIndex];
            Type type = info.CellValue.GetType();

            if (type == ControlValue.GetType())
            {
                return base.OnSaveChanges();
            }

            Grid.Model[RowIndex, ColIndex].CellValue = info.CellValue;

            return true;
        }
    }
}
