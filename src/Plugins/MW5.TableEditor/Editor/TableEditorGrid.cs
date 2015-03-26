using System.Collections.Generic;
using System.ComponentModel;
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

                RowManager.Init(_shapefile);

                RowCount = _table.NumRows;
            }
        }

        public int SelectedCount
        {
            get { return RowManager.SelectedCount; }
        }

        public IEnumerable<int> SelectedIndices
        {
            get { return RowManager.SelectedIndices; }
        }

        public void OnDatasourceSelectionChanged()
        {
            RowManager.OnDatasourceSelectionChanged(_shapefile);
            Invalidate();
        }

        private void InitColumns(Table table)
        {
            Columns.Clear();

            for (int i = 0; i < table.NumFields; i++)
            {
                var fld = table.Field[i];
                var cmn = new DataGridViewTextBoxColumn { HeaderText = fld.Name };
                Columns.Add(cmn);
            }
        }

        private void GridCellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            _table.EditCellValue(e.ColumnIndex, e.RowIndex, e.Value);
        }

        private void GridCellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = _table.CellValue[e.ColumnIndex, e.RowIndex];
        }
    }
}
