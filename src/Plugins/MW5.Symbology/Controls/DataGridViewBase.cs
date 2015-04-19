using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class DataGridViewBase : DataGridView
    {
        public DataGridViewBase()
        {
            InitializeComponent();

            CellPainting += OnCellPainting;
        }

        /// <summary>
        /// Drawing the focus rectangle
        /// </summary>
        private void OnCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (CurrentCell == null)
            {
                return;
            }

            if (e.ColumnIndex == CurrentCell.ColumnIndex && e.RowIndex == CurrentCell.RowIndex)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                using (Pen p = new Pen(Color.Black, 4))
                {
                    Rectangle rect = e.CellBounds;
                    rect.Width -= 1;
                    rect.Height -= 1;
                    ControlPaint.DrawFocusRectangle(e.Graphics, rect);
                }
                e.Handled = true;
            }
        }
    }
}
