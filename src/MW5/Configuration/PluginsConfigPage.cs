using System;
using System.Drawing;
using System.Windows.Forms;
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

            var grid = gridGroupingControl1;
            grid.DataSource = pluginProvider.List;
            ApplyGridOptions(grid);
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
            grid.TopLevelGroupOptions.CaptionText = "Application plugins:";
            
            grid.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            grid.Table.TableOptions.ListBoxSelectionColorOptions = GridListBoxSelectionColorOptions.None;
            grid.Table.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.None;
            grid.Table.TableOptions.ListBoxSelectionMode = SelectionMode.None;
            
            grid.TableControlCellClick += grid_TableControlCellClick;
            grid.TableControlCellHitTest += grid_TableControlCellHitTest;
            grid.TableControlPrepareViewStyleInfo += grid_TableControlPrepareViewStyleInfo;
            grid.TableControl.MouseLeave += TableControl_MouseLeave;
            //grid.FocusOnMouseDown = false;
        }

        private void TableControl_MouseLeave(object sender, EventArgs e)
        {
            _mouseOver = 0;
            gridGroupingControl1.Refresh();
        }
       
        private void grid_TableControlPrepareViewStyleInfo(object sender, GridTableControlPrepareViewStyleInfoEventArgs e)
        {
            if (e.Inner.RowIndex == _mouseOver)
            {
                e.Inner.Style.BackColor = Color.FromArgb(64, 51, 153, 255);
                e.Inner.Style.TextColor = Color.Black;
            }
        }

        private void grid_TableControlCellHitTest(object sender, GridTableControlCellHitTestEventArgs e)
        {
            if (e.Inner.RowIndex > 0 && e.Inner.RowIndex != _mouseOver)
            {
                var record = GetRecord(e.Inner.RowIndex);
                if (record != null)
                {
                    var info = record.GetData() as PluginInfo;
                    if (info != null)
                    {
                        lblDescription.Text = info.Description;
                        lblDescription.Refresh();
                    }
                }
                
                _mouseOver = e.Inner.RowIndex;
                gridGroupingControl1.Refresh();
            }
        }

        void grid_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            if (e.Inner.RowIndex <= 1)
            {
                return;
            }

            var record = GetRecord(e.Inner.RowIndex);
            if (record != null)
            {
                var value = (bool)record.GetValue(SELECTED_PROPERTY);
                record.SetValue(SELECTED_PROPERTY, !value);
            }
        }

        private Record GetRecord(int rowIndex)
        {
            int index = rowIndex - 2;
            if (index >= 0 && index < gridGroupingControl1.Table.Records.Count)
            {
                return gridGroupingControl1.Table.Records[index];
            }
            return null;
        }

        public string PageName
        {
            get { return "Plugins"; }
        }
    }
}
