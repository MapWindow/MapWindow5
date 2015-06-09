using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.TableEditor.Model;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.TableEditor.Editor
{
    public class TableEditorGrid: VirtualGrid
    {
        private readonly Color _joinColumnBackColor = Color.OldLace;

        private IFeatureSet _shapefile;
        private IAttributeTable _table;

        public TableEditorGrid()
        {
            CellValueNeeded += GridCellValueNeeded;
            CellValuePushed += GridCellValuePushed;
            ColumnHeaderMouseClick += GridColumnHeaderMouseClick;
        }

        [Browsable(false)]
        public IFeatureSet TableSource
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

                RowCount = 0;
                
                // this will clear all rows at once or else it will try to remove them one by one (veeeery slow)
                RowCount = _table.NumRows;

                bool editing = TableSource.EditingTable;
                ReadOnly = !editing;

                Invalidate();
            }
        }

        protected override IFeatureSet FeatureSet
        {
            get { return _shapefile; }
        }

        private void InitColumns(IAttributeTable table)
        {
            Columns.Clear();

            foreach(var fld in table.Fields)
            {
                var cmn = new DataGridViewTextBoxColumn
                {
                    HeaderText = fld.DisplayName,
                    SortMode = DataGridViewColumnSortMode.Programmatic,
                    Visible = fld.Visible,
                };

                if (table.FieldIsJoined(fld.Index))
                {
                    cmn.CellTemplate.Style.BackColor = _joinColumnBackColor;    
                }

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
            e.Value = _table.CellValue(e.ColumnIndex, realIndex);
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

            var fld = _table.Fields[e.ColumnIndex];
            switch (fld.Type)
            {
                case AttributeType.String:
                    SortByColumn<string>(e.ColumnIndex, ascending);
                    break;
                case AttributeType.Integer:
                    SortByColumn<int>(e.ColumnIndex, ascending);
                    break;
                case AttributeType.Double:
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
                var val = _table.CellValue(cmnIndex, i);
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

        public bool FindNext(SearchInfo info)
        {
            for (var i = info.RowIndex; i < Rows.Count; i++)
            {
                for (var j = 0; j < Columns.Count; j++)
                {
                    if (i == info.RowIndex && j <= info.ColumnIndex)
                    {
                        continue;
                    }

                    if (this[j, i].Value == null)
                    {
                        continue;
                    }

                    if (!this[j, i].Visible)
                    {
                        continue;
                    }

                    try
                    {
                        var cellValue = this[j, i].Value.ToString();
                        if (cellValue.ToLower().Contains(info.Token))
                        {
                            CurrentCell = this[j, i];
                            info.AddNewMatch(i, j);
                            return true;
                        }
                    }
                    catch {}
                }
            }

            return false;
        }
    }
}
