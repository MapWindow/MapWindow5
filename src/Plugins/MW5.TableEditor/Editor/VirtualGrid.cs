using System;
using System.Drawing;
using System.Windows.Forms;

namespace MW5.Plugins.TableEditor.Editor
{
    internal class VirtualGrid: DataGridView
    {
        private readonly RowManager _rowManager = new RowManager();
        private Color _selectionColor = Color.LightBlue;

        public new event EventHandler<EventArgs> SelectionChanged;

        private void FireSelectionChanged()
        {
            var handler = SelectionChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        public VirtualGrid()
        {
            VirtualMode = true;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            BackgroundColor = Color.LightGray;
            BorderStyle = BorderStyle.None;
            
            SelectionMode = DataGridViewSelectionMode.CellSelect;
            DefaultCellStyle.SelectionBackColor = Color.White;
            DefaultCellStyle.SelectionForeColor = Color.Black;
            
            RowPrePaint += GridRowPrePaint;
            RowPostPaint += GridRowPostPaint;
            RowHeaderMouseClick += GridRowHeaderMouseClick;
        }

        public Color SelectionColor
        {
            get { return _selectionColor; }
            set { _selectionColor = value; }
        }

        protected RowManager RowManager
        {
            get { return _rowManager; }
        }

        private void GridRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var rowBounds = new Rectangle(
                RowHeadersWidth,
                e.RowBounds.Top,
                Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - HorizontalScrollingOffset + 1,
                e.RowBounds.Height);

            if (_rowManager[e.RowIndex].Selected)
            {
                e.PaintParts &= ~DataGridViewPaintParts.SelectionBackground;
                e.PaintParts &= ~DataGridViewPaintParts.Background;
                e.PaintHeader(false);
                e.Graphics.FillRectangle(new SolidBrush(_selectionColor), rowBounds);
            }
        }

        private void GridRowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (_rowManager[e.RowIndex].Selected)
            {
                var r = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, RowHeadersWidth, e.RowBounds.Height);
                var brush = new SolidBrush(Color.FromArgb(64, _selectionColor));
                e.Graphics.FillRectangle(brush, r);
            }
        }

        private void GridRowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _rowManager.OnRowHeaderClicked(e.RowIndex, ModifierKeys);

            if (ModifierKeys == Keys.Control)
            {
                InvalidateRow(e.RowIndex);
            }
            else
            {
                Invalidate();
            }

            FireSelectionChanged();
        }
    }
}
