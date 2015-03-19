using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MW5.Configuration.Plugins;
using MW5.Services.Config;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Configuration
{
    internal partial class PluginsConfigPage : UserControl, IConfigPage
    {
        private const string SELECTED_PROPERTY = "Selected";
        private int _mouseOver = 0;

        public PluginsConfigPage(PluginProvider pluginProvider)
        {
            if (pluginProvider == null) throw new ArgumentNullException("pluginProvider");

            InitializeComponent();

            _grid.DataSource = pluginProvider.List;
            ApplyGridOptions(_grid);
            lblDescription.Text = "";
        }

        // TODO: extract to application level styles
        private void ApplyGridOptions(GridGroupingControl grid)
        {
            grid.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro;
            grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;

            grid.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle;
            grid.Appearance.AnyCell.Borders.All = new GridBorder(GridBorderStyle.None, Color.White);

            grid.BrowseOnly = false;
            grid.ShowRowHeaders = false;
            grid.ShowColumnHeaders = true;
            grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways;
            grid.GridLineColor = Color.White;
            grid.ShowGroupDropArea = false;
            
            grid.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            grid.TopLevelGroupOptions.ShowCaption = false;
            
            grid.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            
            grid.Table.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell;
            grid.TableOptions.ListBoxSelectionMode = SelectionMode.One;
            grid.TableOptions.SelectionBackColor = Color.FromArgb(64, 51, 153, 255);
            grid.TableOptions.SelectionTextColor = Color.Black;
            grid.TableOptions.ListBoxSelectionColorOptions = GridListBoxSelectionColorOptions.ApplySelectionColor;

            // any option other than None will disable SelectedRecordsChanged event
            // http ://www.syncfusion.com/forums/46745/grid-grouping-control-selection-color
            grid.TableOptions.AllowSelection = GridSelectionFlags.None;         

            grid.TableControlCellClick += grid_TableControlCellClick;
            grid.TableControlCheckBoxClick += grid_TableControlCellClick;
            grid.TableControlCellHitTest += grid_TableControlCellHitTest;
            grid.TableControlPrepareViewStyleInfo += grid_TableControlPrepareViewStyleInfo;
            grid.SelectedRecordsChanged += grid_SelectedRecordsChanged;
            grid.TableControlKeyDown += grid_TableControlKeyDown;
        }

        void grid_TableControlKeyDown(object sender, GridTableControlKeyEventArgs e)
        {
            if (e.Inner.KeyCode == Keys.Space || e.Inner.KeyCode == Keys.Enter)
            {
                if (_grid.Table.SelectedRecords.Count > 0)
                {
                    var rec = _grid.Table.SelectedRecords[0].Record;
                    ToggleRecordState(rec);
                }
            }
        }

        private void grid_SelectedRecordsChanged(object sender, SelectedRecordsChangedEventArgs e)
        {
            if (e.SelectedRecord == null || e.SelectedRecord.Record == null)
            {
                return;
            }
            
            // displaying description
            var record = e.SelectedRecord.Record;
            if (record != null)
            {
                var info = record.GetData() as PluginInfo;
                if (info != null)
                {
                    lblDescription.Text = info.BasePlugin.Description;
                    lblDescription.Refresh();
                }
            }
        }

        private void grid_TableControlPrepareViewStyleInfo(object sender, GridTableControlPrepareViewStyleInfoEventArgs e)
        {
            if (e.Inner.RowIndex == _mouseOver)
            {
                // uncomment to turn on hot tracking
                // e.Inner.Style.BackColor = Color.FromArgb(64, 51, 153, 255);
            }
            e.Inner.Style.TextColor = Color.Black;
        }

        private void grid_TableControlCellHitTest(object sender, GridTableControlCellHitTestEventArgs e)
        {
            if (e.Inner.RowIndex > 0 && e.Inner.RowIndex != _mouseOver)
            {
                _mouseOver = e.Inner.RowIndex;
                _grid.Refresh();
            }
        }

        private void grid_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            if (e.Inner.RowIndex <= 1)
            {
                return;
            }

            var rec = GetRecord(e.Inner.RowIndex);
            ToggleRecordState(rec);
        }

        private void ToggleRecordState(Record record)
        {
            if (record != null)
            {
                var value = (bool)record.GetValue(SELECTED_PROPERTY);
                record.SetValue(SELECTED_PROPERTY, !value);
            }
        }

        private Record GetRecord(int rowIndex)
        {
            int index = rowIndex - 2;
            if (index >= 0 && index < _grid.Table.Records.Count)
            {
                return _grid.Table.Records[index];
            }
            return null;
        }

        public string PageName
        {
            get { return "Application Plugins"; }
        }
    }
}
