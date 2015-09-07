using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Events;
using MW5.Plugins.Concrete;
using MW5.Shared;
using MW5.Shared.Log;
using MW5.UI.Helpers;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Controls
{
    /// <summary>
    /// Provides strongly typed API for Syncfusion's GridGroupControl
    /// </summary>
    public class GridAdapter<T>
        where T: class
    {
        private readonly Dictionary<string, Func<T, int>> _iconSelectors = new Dictionary<string, Func<T, int>>();
        private SuperToolTip _lastTooltip = new SuperToolTip();
        private readonly GridGroupingControl _grid;
        private int _mouseOverIndex = 0;
        private bool _autoAdjustRowHeights;

        public GridAdapter(GridGroupingControl grid)
        {
            if (grid == null) throw new ArgumentNullException("grid");
            _grid = grid;

            SetDefaults();

            AttachEvents();
        }

        private void AttachEvents()
        {
            _grid.TableControlCellHitTest += grid_TableControlCellHitTest;
            _grid.TableControlPrepareViewStyleInfo += grid_TableControlPrepareViewStyleInfo;
            _grid.SelectedRecordsChanged += GridSelectedRecordsChanged;
            _grid.QueryCellStyleInfo += GridQueryCellStyleInfo;

            _grid.TableControl.MouseLeave += (s, e) => HideToolTip();
            _grid.TableControl.LostFocus += (s, e) => HideToolTip();
        }

        private void SetDefaults()
        {
            ToolTipDuration = 3000;
            ToolTipMaxWidth = 450;
            HotTrackingColor = Color.FromArgb(24, 51, 153, 255);
        }

        public event EventHandler<ToolTipGridEventArgs> PrepareToolTip;

        public event EventHandler<EventArgs> SelectionChanged;

        public bool ReadOnly
        {
            get { return _grid.BrowseOnly; }
            set
            {
                _grid.BrowseOnly = value;
                ShowEditors = !_grid.BrowseOnly;
                AllowCurrentCell = !_grid.BrowseOnly;
            }
        }

        private Color SelectionBackColor
        {
            get { return _grid.TableOptions.SelectionBackColor; }
            set { _grid.TableOptions.SelectionBackColor = value; }
        }

        public bool WrapText
        {
            get { return _grid.TableDescriptor.Appearance.AnyCell.WrapText; }
            set { _grid.TableDescriptor.Appearance.AnyCell.WrapText = value; }
        }

        public bool ShowEditors
        {
            get
            {
                return _grid.Table.Appearance.AnyCell.ShowButtons != GridShowButtons.Hide;
            }
            set
            {
                _grid.TableOptions.AllowDropDownCell = value;
                _grid.Table.Appearance.AnyCell.ShowButtons = value ? GridShowButtons.Show : GridShowButtons.Hide;
            }
        }

        public bool AutoAdjustRowHeights
        {
            get { return _autoAdjustRowHeights; }
            set
            {
                _autoAdjustRowHeights = value;
                if (value)
                {
                    _grid.TableModel.ColWidthsChanged += TableModel_ColWidthsChanged;
                }
                else
                {
                    _grid.TableModel.ColWidthsChanged -= TableModel_ColWidthsChanged;
                }
            }
        }

        private void TableModel_ColWidthsChanged(object sender, GridRowColSizeChangedEventArgs e)
        {
            _grid.AdjustRowHeights();
        }

        public event KeyEventHandler KeyDown
        {
            add { _grid.TableControl.KeyDown += value; }
            remove { _grid.TableControl.KeyDown -= value; }
        }

        public virtual object DataSource
        {
            get { return _grid.DataSource; }
            set { _grid.DataSource = value; }
        }

        public GridGroupingControl Grid
        {
            get { return _grid; }
        }

        public bool HotTracking { get; set; }

        public bool ShowSuperTooltips { get; set; }

        public int ToolTipDuration { get; set; }

        public Color HotTrackingColor { get; set; }

        public int ToolTipMaxWidth { get; set; }

        public bool SelectFirstRecord()
        {
            var record = _grid.Table.Records[0];
            if (record != null)
            {
                _grid.Table.SelectedRecords.Add(record);
                return true;
            }

            return false;
        }

        public bool SelectLastRow()
        {
            var table = Grid.Table;

            if (table.Records.Count > 0)
            {
                var r = table.Records[table.Records.Count - 1];
                table.SelectedRecords.Add(r);
                return true;
            }

            return false;
        }

        [Browsable(false)]
        public T SelectedItem
        {
            get
            {
                if (_grid.Table.SelectedRecords.Count == 0)
                {
                    return null;
                }

                return _grid.Table.SelectedRecords[0].Record.GetData() as T;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _grid.Table.Records.Count)
                {
                    return null;
                }
                
                return _grid.Table.Records[index].GetData() as T;     
            }
        }

        public IEnumerable<T> Items
        {
            get
            {
                foreach (var r in _grid.Table.Records)
                {
                    yield return r.GetData() as T;
                }
            }
        }

        private void grid_TableControlPrepareViewStyleInfo(object sender, GridTableControlPrepareViewStyleInfoEventArgs e)
        {
            if (!HotTracking)
            {
                return;
            }

            if (e.Inner.RowIndex == _mouseOverIndex)
            {
                e.Inner.Style.BackColor = HotTrackingColor;
            }

            e.Inner.Style.TextColor = Color.Black;
        }

        private void grid_TableControlCellHitTest(object sender, GridTableControlCellHitTestEventArgs e)
        {
            if (!HotTracking)
            {
                return;
            }

            if (e.Inner.RowIndex > 0 && e.Inner.RowIndex != _mouseOverIndex)
            {
                _mouseOverIndex = e.Inner.RowIndex;
                
                _grid.Refresh();
            }
        }

        private void DisplayTooltip()
        {
            if (!ShowSuperTooltips)
            {
                HideToolTip();
                return;
            }

            int rowIndex = GetSelectedRowIndex();
            if (rowIndex == -1)
            {
                return;
            }

            lock (_lastTooltip)
            {
                _lastTooltip.Hide();
                _lastTooltip = new SuperToolTip(_grid);

                int columnCount = _grid.TableDescriptor.Columns.Count;

                var pnt = new Point
                {
                    X = _grid.TableControl.ColIndexToHScrollPixelPos(columnCount),
                    Y = _grid.TableControl.RowIndexToVScrollPixelPos(rowIndex)
                };

                pnt = _grid.PointToScreen(pnt);

                var info = new ToolTipInfo();
                var args = new ToolTipGridEventArgs(info, RowIndexToRecordIndex(rowIndex)); 
                
                FirePrepareTooltip(args);
                if (args.Cancel)
                {
                    _lastTooltip.Hide();
                    return;
                }

                info.Header.Font = new Font(info.Header.Font, FontStyle.Bold);
                _lastTooltip.MaxWidth = ToolTipMaxWidth;
                _lastTooltip.Show(info, pnt, ToolTipDuration);
            }
        }

        public void HideToolTip()
        {
            _lastTooltip.Hide();
        }

        private void FirePrepareTooltip(ToolTipGridEventArgs args)
        {
            var handler = PrepareToolTip;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        public int GetSelectedRecordIndex()
        {
            if (_grid.Table.SelectedRecords.Count == 0)
            {
                return -1;
            }

            return _grid.Table.SelectedRecords[0].GetSourcePosition();
        }

        private int GetSelectedRowIndex()
        {
            var rec = GetSelectedRecord();
            if (rec != null)
            {
                return rec.GetRowIndex();
            }

            return -1;
        }

        private Record GetSelectedRecord()
        {
            if (_grid.Table.SelectedRecords.Count == 0)
            {
                return null;
            }

            return _grid.Table.SelectedRecords[0].Record;
        }

        public GridTableCellStyleInfo GetColumnStyle(int index)
        {
            return _grid.TableDescriptor.Columns[index].Appearance.AnyCell;
        }

        public GridTableCellStyleInfo GetColumnStyle(string columnName)
        {
            return _grid.TableDescriptor.Columns[columnName].Appearance.AnyCell;
        }

        public GridTableCellStyleInfo GetColumnStyle(Expression<Func<T, object>> propertySelector)
        {
            var name = GenericHelper.GetPropertyName(propertySelector);
            if (name != string.Empty)
            {
                return GetColumnStyle(name);
            }

            return null;
        }

        public GridColumnDescriptor GetColumn(Expression<Func<T, object>> propertySelector)
        {
            var name = GenericHelper.GetPropertyName(propertySelector);
            if (name != string.Empty)
            {
                return _grid.TableDescriptor.Columns[name];
            }

            return null;
        }

        public int GetColumnIndex(Expression<Func<T, object>> propertySelector)
        {
             return GetRelativeColumnIndex(propertySelector) + Grid.TableDescriptor.GetColumnIndentCount();
        }

        public int GetRelativeColumnIndex(Expression<Func<T, object>> propertySelector)
        {
            var column = GetColumn(propertySelector);
            if (column != null)
            {
                return column.GetRelativeColumnIndex();
            }

            return -1;
        }

        public void ToggleProperty(Expression<Func<T, bool>> propertySelector)
        {
            var record = GetSelectedRecord();
            if (record != null)
            {
                var expr = propertySelector.Body as MemberExpression;
                if (expr == null)
                {
                    return;
                }

                string propertyName = expr.Member.Name;
                var value = (bool)record.GetValue(propertyName);
                record.SetValue(propertyName, !value);
            }
        }

        public void SetPropertyForEach<TT>(Expression<Func<T, object>> propertySelector, TT value)
        {
            string name = GenericHelper.GetPropertyName(propertySelector);

            foreach (var r in _grid.Table.Records)
            {
                r.SetValue(name, value);
            }
        }

        public void SetProperty(Expression<Func<T, object>> propertySelector, object value)
        {
            var record = GetSelectedRecord();

            if (record != null)
            {
                string name = GenericHelper.GetPropertyName(propertySelector);
                record.SetValue(name, value);
            }
        }

        private void GridSelectedRecordsChanged(object sender, SelectedRecordsChangedEventArgs e)
        {
            DisplayTooltip();
            
            var handler = SelectionChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        public bool ReReadRecord(T item)
        {
            foreach(var r in _grid.Table.Records)
            {
                if (r.GetData() == item)
                {
                    r.ResetValues();
                    return true;
                }
            }

            return false;
        }

        public void SetColumnIcon(Expression<Func<T, object>> propertySelector, Func<T, int> imageSelector)
        {
            string name = GenericHelper.GetPropertyName(propertySelector);
            if (name != string.Empty)
            {
                _iconSelectors.Add(name, imageSelector);
            }
        }

        private void GridQueryCellStyleInfo(object sender, GridTableCellStyleInfoEventArgs e)
        {
            if (e.TableCellIdentity.Column == null || _iconSelectors.Count == 0)
            {
                return;
            }

            int recordIndex = RowIndexToRecordIndex(e.TableCellIdentity.RowIndex);
            if (recordIndex == -1)
            {
                return;
            }

            string name = e.TableCellIdentity.Column.Name;

            Func<T, int> fn;
            if (_iconSelectors.TryGetValue(name, out fn))
            {
                var r = _grid.Table.Records[recordIndex]; 
                if (r != null)
                {
                    e.Style.ImageIndex = fn(r.GetData() as T);
                }
            }
        }

        public void ClearFilter()
        {
            _grid.TableDescriptor.RecordFilters.Clear();
        }

        public void AddFilterLike(Expression<Func<T, string>> propertySelector, string token, FilterLogicalOperator op = FilterLogicalOperator.And)
        {
            if (string.IsNullOrWhiteSpace(token)) return;

            string propertyName = GenericHelper.GetTypedPropertyName(propertySelector);

            var condition = new FilterCondition(FilterCompareOperator.Like, "*" + token + "*");
            
            var desc = new RecordFilterDescriptor(propertyName, op, new[] { condition });
            _grid.TableDescriptor.RecordFilters.Add(desc);
        }

        public void AddFilterMatch<TT>(Expression<Func<T, TT>> propertySelector, TT value,
            FilterLogicalOperator op = FilterLogicalOperator.And)
        {
            string propertyName = GenericHelper.GetTypedPropertyName(propertySelector);

            var condition = new FilterCondition(FilterCompareOperator.Match, value);

            var desc = new RecordFilterDescriptor(propertyName, op, new[] { condition });
            _grid.TableDescriptor.RecordFilters.Add(desc);
        }

        public bool AllowCurrentCell
        {
            get { return _grid.ActivateCurrentCellBehavior == GridCellActivateAction.None; }
            set
            {
                if (!value)
                {
                    _grid.Table.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.None;
                    _grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways;
                    _grid.ActivateCurrentCellBehavior = GridCellActivateAction.None;
                }
                else
                {
                    _grid.Table.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.WhiteCurrentCell;
                    _grid.ActivateCurrentCellBehavior = GridCellActivateAction.SetCurrent;
                    _grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways;
                }
            }
        }

        public void ShowColumn(Expression<Func<T, object>> propertySelector)
        {
            string propertyName = GenericHelper.GetPropertyName(propertySelector);
            _grid.TableDescriptor.VisibleColumns.Add(propertyName);
        }

        public void HideColumns()
        {
            _grid.TableDescriptor.VisibleColumns.Clear();
        }

        
        /// <summary>
        /// Converts row index returned by various events (includes header and grouping rows) to the record index 
        /// (datasource based).
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <remarks>https ://www.syncfusion.com/kb/497/how-do-i-get-the-position-of-a-row-in-datasource-from-the-currentcells-rowindex</remarks>
        public int RowIndexToRecordIndex(int rowIndex)
        {
            var table = _grid.TableControl.Table;

            var el = table.DisplayElements[rowIndex];
            if (el != null && el.ParentRecord != null)
            {
                return table.FilteredRecords.IndexOf(el.ParentRecord);
            }

            return -1;
        }

        public void GroupBy(Expression<Func<T, object>> propertySelector)
        {
            string propertyName = GenericHelper.GetPropertyName(propertySelector);
            _grid.TableDescriptor.GroupedColumns.Add(propertyName);
        }

        public void ClearGrouping()
        {
            _grid.TableDescriptor.GroupedColumns.Clear();
        }

        private void SetComboBox(GridColumnDescriptor cmn)
        {
            // TODO: create a generalized method
            // http ://stackoverflow.com/questions/29750570/setting-row-specific-content-for-a-combobox-in-a-gridgroupingcontrol-cell

            var style = cmn.Appearance.AnyRecordFieldCell;

            //var list = new List<FieldWrapper>()
            //               {
            //                   new FieldWrapper("layer", "field"), 
            //                   new FieldWrapper("more", "another")
            //               };

            style.CellType = GridCellTypeName.ComboBox;

            style.DisplayMember = "LayerName";
            style.ValueMember = "FieldName";
            //style.DataSource = list;

            style.ExclusiveChoiceList = true;
        }
    }
}
