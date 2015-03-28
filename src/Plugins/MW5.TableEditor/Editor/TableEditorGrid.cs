using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MapWinGIS;

namespace MW5.Plugins.TableEditor.Editor
{
    internal class TableEditorGrid: VirtualGrid
    {
        private Shapefile _shapefile;
        private Table _table;

        public TableEditorGrid()
        {
            CellValueNeeded += GridCellValueNeeded;
            CellValuePushed += GridCellValuePushed;
            ColumnHeaderMouseClick += GridColumnHeaderMouseClick;
        }

        [Browsable(false)]
        public Shapefile TableSource
        {
            get { return _shapefile; }
            set
            {
                if (value == null)
                {
                    RowCount = 0;
                    return;
                }

                _shapefile = value;
                _table = value.Table;

                InitColumns(_table);

                RowManager.Reset(_shapefile);

                RowCount = _table.NumRows;
            }
        }

        protected override Shapefile Shapefile
        {
            get { return _shapefile; }
        }

        private void InitColumns(Table table)
        {
            Columns.Clear();

            for (int i = 0; i < table.NumFields; i++)
            {
                var fld = table.Field[i];
                var cmn = new DataGridViewTextBoxColumn
                {
                    HeaderText = fld.Name,
                    SortMode = DataGridViewColumnSortMode.Programmatic
                };
                Columns.Add(cmn);
            }
        }

        private void GridCellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            int realIndex = RowManager.RealIndex(e.RowIndex);
            _table.EditCellValue(e.ColumnIndex, realIndex, e.Value);
        }

        private void GridCellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            int realIndex = RowManager.RealIndex(e.RowIndex);
            e.Value = _table.CellValue[e.ColumnIndex, realIndex];
        }

        private void SetSortGlyph(int cmnIndex, bool ascending)
        {
            foreach(DataGridViewColumn cmn in Columns)
            {
                if (cmn.Index == cmnIndex)
                {
                    cmn.HeaderCell.SortGlyphDirection = ascending
                        ? SortOrder.Ascending
                        : SortOrder.Descending;
                }
                else
                {
                    cmn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
        }

        private void GridColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            bool ascending = true;
            if (RowManager.SortColumnIndex == e.ColumnIndex)
            {
                ascending = !RowManager.SortAscending;
            }

            var fld = _table.Field[e.ColumnIndex];
            switch (fld.Type)
            {
                case FieldType.STRING_FIELD:
                    SortByColumn<string>(e.ColumnIndex, ascending);
                    break;
                case FieldType.INTEGER_FIELD:
                    SortByColumn<int>(e.ColumnIndex, ascending);
                    break;
                case FieldType.DOUBLE_FIELD:
                    SortByColumn<double>(e.ColumnIndex, ascending);
                    break;
            }

            SetSortGlyph(e.ColumnIndex, ascending);

            Invalidate();
        }

        private void SortByColumn<T>(int cmnIndex, bool ascending) where T: IComparable
        {
            var list = new List<SortItem<T>> {Capacity = _table.NumRows};

            string defValue = string.Empty;
            bool isString = typeof (T) == typeof (string);

            for (int i = 0; i < _table.NumRows; i++)
            {
                var val = _table.CellValue[cmnIndex, i];
                if (isString && val == null)
                {
                    val = defValue;
                }
                var item = new SortItem<T>((T) val, i);
                list.Add(item);
            }

            list.Sort();

            if (!ascending)
            {
                list.Reverse();
            }

            var result = list.Select(item => item.RealIndex);

            RowManager.SetSorting(cmnIndex, ascending, result);
        }
    }
}
