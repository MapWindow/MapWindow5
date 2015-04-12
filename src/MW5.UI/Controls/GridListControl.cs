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
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Controls
{
    public class GridListControl<T>: UserControl, IGridList<T>
        where T: class
    {
        private readonly GridGroupingControl _grid;
        private SuperToolTip _lastTooltip = new SuperToolTip();
        private int _mouseOverIndex = 0;

        public event EventHandler<ToolTipGridEventArgs> PrepareToolTip;
        
        public event EventHandler<EventArgs> SelectionChanged;
        
        public new event KeyEventHandler KeyDown
        {
            add { _grid.TableControl.KeyDown += value; }
            remove { _grid.TableControl.KeyDown -= value; }
        }

        public GridListControl()
        {
            _grid = new GridControlBase {Dock = DockStyle.Fill, BorderStyle = BorderStyle.None};
            Controls.Add(_grid);

            ToolTipDuration = 3000;

            _grid.TableControlCellHitTest += grid_TableControlCellHitTest;
            _grid.TableControlPrepareViewStyleInfo += grid_TableControlPrepareViewStyleInfo;
            _grid.SelectedRecordsChanged += GridSelectedRecordsChanged;

            _grid.TableControl.MouseLeave += (s, e) => HideToolTip();
            _grid.TableControl.LostFocus += (s, e) => HideToolTip();
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
                    return null;    // TODO: log it
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
                e.Inner.Style.BackColor = Color.FromArgb(24, 51, 153, 255);
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

                var pnt = new Point
                {
                    X = _grid.TableControl.ColIndexToHScrollPixelPos(3),        // TODO: make parameter
                    Y = _grid.TableControl.RowIndexToVScrollPixelPos(rowIndex + 2)
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
                _lastTooltip.MaxWidth = 450;
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
    }
}
