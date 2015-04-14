using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Controls
{
    public partial class GridListControl<T> : UserControl, IGridList<T>
        where T: class
    {
        private SuperToolTip _lastTooltip = new SuperToolTip();
        private GridControlBase _grid;
        private int _mouseOverIndex = 0;
        private bool _autoAdjustRowHeights;

        public GridListControl()
        {
            InitializeComponent();

            SetDefaults();

            AttachEvents();
        }

        private void AttachEvents()
        {
            _grid.TableControlCellHitTest += grid_TableControlCellHitTest;
            _grid.TableControlPrepareViewStyleInfo += grid_TableControlPrepareViewStyleInfo;
            _grid.SelectedRecordsChanged += GridSelectedRecordsChanged;

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
            }
        }

        public bool WrapText
        {
            get { return _grid.TableDescriptor.Appearance.AnyCell.WrapText; }
            set { _grid.TableDescriptor.Appearance.AnyCell.WrapText = value; }
        }

        public new BorderStyle BorderStyle
        {
            get { return _grid.BorderStyle; }
            set { _grid.BorderStyle = value; }
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

        public void AdjustRowHeights()
        {
            _grid.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table());
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
            AdjustRowHeights();
        }

        public new event KeyEventHandler KeyDown
        {
            add { _grid.TableControl.KeyDown += value; }
            remove { _grid.TableControl.KeyDown -= value; }
        }

        public object DataSource
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

        public T SelectedItem
        {
            get
            {
                if (_grid.Table.SelectedRecords.Count == 0)
                {
                    Logger.Current.Warn("GridListControl: Invalid invalid index");
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
                    Logger.Current.Warn("GridListControl: Invalid invalid index");
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
                
                Refresh();
            }
        }

        private void DisplayTooltip()
        {
            if (!ShowSuperTooltips)
            {
                HideToolTip();
                return;
            }

            int rowIndex = GetSelectedIndex();
            if (rowIndex == -1)
            {
                return;
            }

            lock (_lastTooltip)
            {
                _lastTooltip.Hide();
                _lastTooltip = new SuperToolTip(this);

                int columnCount = _grid.TableDescriptor.Columns.Count;

                var pnt = new Point
                {
                    X = _grid.TableControl.ColIndexToHScrollPixelPos(columnCount),
                    Y = _grid.TableControl.RowIndexToVScrollPixelPos(rowIndex + RowOffset)
                };

                pnt = PointToScreen(pnt);

                var info = new ToolTipInfo();
                var args = new ToolTipGridEventArgs(info, rowIndex); 
                
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

        private int GetSelectedIndex()
        {
            if (_grid.Table.SelectedRecords.Count == 0)
            {
                return -1;
            }

            return _grid.Table.SelectedRecords[0].GetSourcePosition();
        }

        private Record GetSelectedRecord()
        {
            if (_grid.Table.SelectedRecords.Count == 0)
            {
                return null;
            }

            return _grid.Table.SelectedRecords[0].Record;
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

        private void GridSelectedRecordsChanged(object sender, SelectedRecordsChangedEventArgs e)
        {
            DisplayTooltip();
            
            var handler = SelectionChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private int RowOffset
        {
            get { return 2; }
        }
    }
}
