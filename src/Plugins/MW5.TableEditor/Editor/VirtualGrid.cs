using System;
using System.Drawing;
using System.Windows.Forms;
using MapWinGIS;

namespace MW5.Plugins.TableEditor.Editor
{
    internal abstract class VirtualGrid: DataGridView
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
            
            SelectionMode = DataGridViewSelectionMode.CellSelect;
            DefaultCellStyle.SelectionBackColor = Color.White;
            DefaultCellStyle.SelectionForeColor = Color.Black;
            
            RowPrePaint += GridRowPrePaint;
            RowPostPaint += GridRowPostPaint;
            RowHeaderMouseClick += GridRowHeaderMouseClick;
        }

        protected abstract Shapefile Shapefile { get; }

        public Color SelectionColor
        {
            get { return _selectionColor; }
            set { _selectionColor = value; }
        }

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

            if (Shapefile.ShapeSelected[realIndex])
            {
                e.PaintParts &= ~DataGridViewPaintParts.SelectionBackground;
                e.PaintParts &= ~DataGridViewPaintParts.Background;
                e.PaintHeader(false);
                e.Graphics.FillRectangle(new SolidBrush(_selectionColor), rowBounds);
            }
        }

        private void GridRowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int realIndex = _rowManager.RealIndex(e.RowIndex);

            if (Shapefile.ShapeSelected[realIndex])
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

        private void OnRowHeaderClicked(int rowIndex, Keys keys)
        {
            var sf = Shapefile;

            if (keys != Keys.Shift && keys != Keys.Control)
            {
                sf.SelectNone();
            }

            if (keys == Keys.Shift && _lastIndex != -1)
            {
                int realIndex = RowManager.RealIndex(_lastIndex);
                bool state = sf.ShapeSelected[realIndex];

                int min = Math.Min(_lastIndex, rowIndex);
                int max = Math.Max(_lastIndex, rowIndex);

                for (int i = min; i <= max; i++)
                {
                    realIndex = RowManager.RealIndex(i);
                    sf.ShapeSelected[realIndex] = state;
                }
            }
            else
            {
                int realIndex = RowManager.RealIndex(rowIndex);
                sf.ShapeSelected[realIndex] = !sf.ShapeSelected[realIndex];
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
