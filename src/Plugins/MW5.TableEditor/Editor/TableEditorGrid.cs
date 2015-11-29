using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Model;
using MW5.Shared;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.TableEditor.Editor
{
    public class TableEditorGrid: VirtualGrid
    {
        private readonly Color _joinColumnBackColor = Color.OldLace;
        public event EventHandler<ColumnEventArgs> ColumnContextNeeded;

        private IFeatureSet _shapefile;
        private IAttributeTable _table;
        private bool _ignoreCurrentCellChange;
        private bool _currentCellChanged;
        private int _layerHandle;

        public TableEditorGrid()
        {
            CellValueNeeded += GridCellValueNeeded;
            CellValuePushed += GridCellValuePushed;
            CurrentCellChanged += OnCurrentCellChanged;
            ColumnHeaderMouseClick += OnColumnHeaderMouseClick;

            _layerHandle = -1;
        }

        [Browsable(false)]
        public IFeatureSet TableSource
        {
            get { return _shapefile; }
        }

        public int LayerHandle
        {
            get { return _layerHandle;  }
        }

        public void SetTableSource(IFeatureSet fs, int layerHandle)
        {
            if (fs == null)
            {
                RowCount = 0;
                return;
            }

            _layerHandle = layerHandle;
            _shapefile = fs;
            _table = fs.Table;

            InitColumns(_table);

            RowManager.Reset(_shapefile);

            RowCount = 0;

            // this will clear all rows at once or else it will try to remove them one by one (veeeery slow)
            RowCount = _table.NumRows;

            bool editing = _shapefile.CanEditTable();

            ReadOnly = !editing;
        }

        protected override IFeatureSet FeatureSet
        {
            get { return _shapefile; }
        }

        /// <summary>
        /// Gets width of columns with MapWinGIS field as key.
        /// </summary>
        private Dictionary<object, int> SaveColumnWidth()
        {
            var dict = new Dictionary<object, int>();
            for (int i = 0; i < Columns.Count; i++)
            {
                dict.Add(GetField(i).InternalObject, Columns[i].Width);
            }

            return dict;
        }

        private void InitColumns(IAttributeTable table)
        {
            var widths = SaveColumnWidth();

            Columns.Clear();

            bool showAliases = AppConfig.Instance.TableEditorShowAliases;

            foreach(var fld in table.Fields)
            {
                var cmn = new DataGridViewTextBoxColumn
                {
                    HeaderText = showAliases ? fld.DisplayName : fld.Name,
                    SortMode = DataGridViewColumnSortMode.Programmatic,
                    Visible = fld.Visible,
                    Tag = fld,
                };

                if (widths.ContainsKey(fld.InternalObject))
                {
                    cmn.Width = widths[fld.InternalObject];
                }

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

        private void OnColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    var grid = sender as TableEditorGrid;
                    if (grid != null)
                    {
                        grid.ToggleColumnSorting(e.ColumnIndex);
                    }
                    break;
                case MouseButtons.Right:
                    var handler = ColumnContextNeeded;
                    if (handler != null)
                    {
                        handler(sender, new ColumnEventArgs(e.ColumnIndex, e.Location));
                    }
                    break;
            }
        }

        private void ToggleColumnSorting(int columnIndex)
        {
            bool ascending = true;
            if (RowManager.SortColumnIndex == columnIndex)
            {
                ascending = !RowManager.SortAscending;
            }

            SortByColumn(columnIndex, ascending);
        }

        public void SortByColumn(int columnIndex, bool ascending)
        {
            var fld = _table.Fields[columnIndex];
            switch (fld.Type)
            {
                case AttributeType.String:
                    SortByColumn<string>(columnIndex, ascending);
                    break;
                case AttributeType.Integer:
                    SortByColumn<int>(columnIndex, ascending);
                    break;
                case AttributeType.Double:
                    SortByColumn<double>(columnIndex, ascending);
                    break;
            }

            SetSortGlyph(columnIndex, ascending);

            Invalidate();
        }

        public void ClearSorting()
        {
            RowManager.ClearSorting(TableSource);

            foreach (DataGridViewColumn cmn in Columns)
            {
                cmn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

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
            int rowIndex = CurrentCell != null ? CurrentCell.RowIndex : 0;
            int colIndex = CurrentCell != null ? CurrentCell.ColumnIndex : 0;

            if (_currentCellChanged)
            {
                info.NewSearch = true;
                _currentCellChanged = false;
            }

            if (info.NewSearch)
            {
                info.Clear();
                info.StartRowIndex = rowIndex;
                info.StartColumnIndex = colIndex;
            }

            if (info.RestartSearch)
            {
                info.Clear();
                rowIndex = info.StartRowIndex;
                colIndex = info.StartColumnIndex;
            }

            if (info.Finished)
            {
                return false;
            }

            colIndex++;

            // search from the current cell to the end
            bool result = FindBelow(info, rowIndex, colIndex);

            if (result) return true;

            if (info.Finished) return false;
            
            return FindBelow(info, 0, 0);
        }

        private bool FindBelow(SearchInfo info, int rowIndex, int colIndex)
        {
            for (var i = rowIndex; i < Rows.Count; i++)
            {
                if (FindWithinRow(info, i, colIndex))
                {
                    return true;
                }

                colIndex = 0;  // all remaining records should be searched entirely

                if (info.Finished) return false;
            }

            return false;
        }

        private bool FindWithinRow(SearchInfo info, int rowIndex, int startAtColumnIndex = 0)
        {
            for (var j = startAtColumnIndex; j < Columns.Count; j++)
            {
                if (rowIndex == info.StartRowIndex && j == info.StartColumnIndex)
                {
                    info.Finished = true;
                }

                if (info.FieldIndex != -1 && j != info.FieldIndex)
                {
                    continue;       // it's wrong column
                }

                if (!this[j, rowIndex].Visible || this[j, rowIndex].Value == null)
                {
                    continue;
                }

                try
                {
                    var cellValue = this[j, rowIndex].Value.ToString();

                    if (info.Match(cellValue))
                    {
                        info.Count++;
                        _ignoreCurrentCellChange = true;
                        CurrentCell = this[j, rowIndex];
                        _ignoreCurrentCellChange = false;
                        return true;
                    }
                }
                catch { }

                if (info.Finished)
                {
                    return false;
                }
            }

            return false;
        }

        private void OnCurrentCellChanged(object sender, EventArgs e)
        {
            if (!_ignoreCurrentCellChange)
            {
                _currentCellChanged = true;
            }
        }

        public IAttributeField GetField(int columnIndex)
        {
            if (columnIndex >= 0 && columnIndex < Columns.Count)
            {
                return Columns[columnIndex].Tag as IAttributeField;
            }

            return null;
        }

        public bool Replace(SearchInfo info)
        {
            if (ReplaceCurrentCell(info))
            {
                FindNext(info);
                return true;
            }

            if (FindNext(info))
            {
                return true;    // let's make it visible what is about to be replaced
            }

            return false;
        }

        private bool ReplaceCurrentCell(SearchInfo info)
        {
            if (CurrentCell == null) return false;

            if (ValidateColumnForReplace(info, CurrentCell.ColumnIndex))
            {
                if (ReplaceCellValue(info, CurrentCell.ColumnIndex, CurrentCell.RowIndex))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ValidateColumnForReplace(SearchInfo info, int columnIndex)
        {
            if (info.FieldIndex != -1 && info.FieldIndex != columnIndex)
            {
                return false;
            }

            if (!ValidateReplaceValue(columnIndex, info.ReplaceWith))
            {
                return false;
            }

            return true;
        }

        private bool ReplaceCellValue(SearchInfo info, int colIndex, int rowIndex)
        {
            try
            {
                var cellValue = this[colIndex, rowIndex].Value.ToString();

                if (!info.Match(cellValue)) return false;

                var options = info.CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;

                this[colIndex, rowIndex].Value = Regex.Replace(cellValue, info.Token, info.ReplaceWith, options);

                return true;
            }
            catch(Exception ex)
            {
                Logger.Current.Error("Failed to replace value in table editor.", ex);
            }

            return false;
        }

        public int ReplaceAll(SearchInfo info)
        {
            int count = 0;
            
            for (var j = 0; j < Columns.Count; j++)
            {
                ValidateColumnForReplace(info, j);

                for (var i = 0; i < Rows.Count; i++)
                {
                    if (ReplaceCellValue(info, j, i))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private bool ValidateReplaceValue(int colIndex, string newValue)
        {
            var fld = GetField(colIndex);
            if (fld == null) return true;

            switch (fld.Type)
            {
                case AttributeType.String:
                    return true;
                case AttributeType.Integer:
                    return NumericHelper.IsNumeric(newValue, NumberStyles.Integer);
                case AttributeType.Double:
                    return NumericHelper.IsNumeric(newValue, NumberStyles.Float);
            }

            return true;
        }
    }
}
