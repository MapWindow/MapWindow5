using System;
using System.Drawing;
using System.Windows.Forms;
using MW5.Api.Interfaces;

namespace MW5.Plugins.TableEditor.Editor
{
    public abstract class VirtualGrid: DataGridView
    {
        protected RowManager _rowManager;
        private Color _selectionColor = Color.LightBlue;
        private int _lastIndex = -1;        // for group selection with Shift

        public new event EventHandler<EventArgs> SelectionChanged;

        protected VirtualGrid()
        {
            VirtualMode = true;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            BackgroundColor = Color.LightGray;
            BorderStyle = BorderStyle.None;

            SetSelectionMode(DataGridViewSelectionMode.CellSelect);
            
            RowPrePaint += GridRowPrePaint;
            RowPostPaint += GridRowPostPaint;
            RowHeaderMouseClick += GridRowHeaderMouseClick;
            CellPainting += VirtualGrid_CellPainting;
        }

        public void SetSelectionMode(DataGridViewSelectionMode mode)
        {
            switch (mode)
            {
                case DataGridViewSelectionMode.FullColumnSelect:
                    DefaultCellStyle.SelectionBackColor = _selectionColor;
                    SelectionMode = mode;
                    break;
                default:
                    SelectionMode = DataGridViewSelectionMode.CellSelect;
                    DefaultCellStyle.SelectionBackColor = Color.White;
                    DefaultCellStyle.SelectionForeColor = Color.Black;
                    break;
            }
        }

        protected abstract IFeatureSet FeatureSet { get; }

        public Color SelectionColor
        {
            get { return _selectionColor; }
            set { _selectionColor = value; }
        }

        public Color CurrentCellBorderColor { get; set; }

        public RowManager RowManager
        {
            get { return _rowManager; }
            set { _rowManager = value; }
        }

        private void GridRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var rowBounds = new Rectangle(
                RowHeadersWidth,
                e.RowBounds.Top,
                Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - HorizontalScrollingOffset + 1,
                e.RowBounds.Height);

            int realIndex = _rowManager.RealIndex(e.RowIndex);

            if (FeatureSet.FeatureSelected(realIndex))
            {
                e.PaintParts &= ~DataGridViewPaintParts.Background;
                e.PaintHeader(false);
                e.Graphics.FillRectangle(new SolidBrush(_selectionColor), rowBounds);
            }
        }

        private void GridRowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int realIndex = _rowManager.RealIndex(e.RowIndex);

            if (FeatureSet.FeatureSelected(realIndex))
            {
                var r = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, RowHeadersWidth, e.RowBounds.Height);
                var brush = new SolidBrush(Color.FromArgb(64, _selectionColor));
                e.Graphics.FillRectangle(brush, r);
            }
        }

        private void GridRowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OnRowHeaderClicked(e.RowIndex, ModifierKeys);

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

        private void VirtualGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (CurrentCell == null || CurrentCell.RowIndex != e.RowIndex || CurrentCell.ColumnIndex != e.ColumnIndex)
            {
                return;
            }

            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
            using (Pen p = new Pen(CurrentCellBorderColor, 3))
            {
                Rectangle rect = e.CellBounds;
                rect.X += 1;
                rect.Y += 1;
                rect.Width -= 3;
                rect.Height -= 3;
                e.Graphics.DrawRectangle(p, rect);
            }
            e.Handled = true;
        }

        private void OnRowHeaderClicked(int rowIndex, Keys keys)
        {
            var sf = FeatureSet;

            if (keys != Keys.Shift && keys != Keys.Control)
            {
                sf.ClearSelection();
            }

            if (keys == Keys.Shift && _lastIndex != -1)
            {
                int realIndex = RowManager.RealIndex(_lastIndex);
                bool state = sf.FeatureSelected(realIndex);

                int min = Math.Min(_lastIndex, rowIndex);
                int max = Math.Max(_lastIndex, rowIndex);

                for (int i = min; i <= max; i++)
                {
                    realIndex = RowManager.RealIndex(i);
                    sf.FeatureSelected(realIndex, state);
                }
            }
            else
            {
                int realIndex = RowManager.RealIndex(rowIndex);
                sf.FeatureSelected(realIndex, !sf.FeatureSelected(realIndex));
            }

            _lastIndex = rowIndex;
        }

        private void FireSelectionChanged()
        {
            var handler = SelectionChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
