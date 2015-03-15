using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Services;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Services.Config
{
    public partial class PluginsConfigPage : UserControl, IConfigPage
    {
        private readonly PluginManager _manager;
        private readonly IConfigService _config;

        public PluginsConfigPage(PluginManager manager, IConfigService config)
        {
            if (manager == null) throw new ArgumentNullException("manager");
            if (config == null) throw new ArgumentNullException("config");
            _manager = manager;
            _config = config;

            var provider = new PluginProvider(_manager, config.Config);

            InitializeComponent();

            var grid = gridGroupingControl1;
            grid.DataSource = provider.List.ToList();
            ApplyGridOptions(grid);

            BorderStyle = BorderStyle.None;
        }

        private void ApplyGridOptions(GridGroupingControl grid)
        {
            grid.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro;
            grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            grid.ShowGroupDropArea = false;
            grid.BorderStyle = BorderStyle.None;
            grid.BrowseOnly = false;
            grid.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            grid.TopLevelGroupOptions.ShowCaption = false;
            grid.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle;
            grid.Appearance.AnyCell.Borders.All = new GridBorder(GridBorderStyle.None, Color.White);
            grid.ShowRowHeaders = false;
            grid.ShowColumnHeaders = false;
            grid.Table.TableOptions.ListBoxSelectionMode = SelectionMode.One;
            grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways;
            grid.GridLineColor = Color.White;
            grid.Table.TableOptions.ListBoxSelectionCurrentCellOptions =
                GridListBoxSelectionCurrentCellOptions.HideCurrentCell;

            grid.TableControlCellClick += grid_TableControlCellClick;
            grid.TableControlCellMouseHoverEnter += grid_TableControlCellMouseHoverEnter;
            grid.TableControlCellMouseHoverLeave += grid_TableControlCellMouseHoverLeave;
            //grid.TableControlCurrentCellStartEditing += grid_TableControlCurrentCellStartEditing;
        }

        void grid_TableControlCellMouseHoverLeave(object sender, GridTableControlCellMouseEventArgs e)
        {
            return;
            gridGroupingControl1.Table.SelectedRecords.Clear();
            gridGroupingControl1.TableControl.Selections.Clear();
            gridGroupingControl1.Refresh();
        }

        void grid_TableControlCellMouseHoverEnter(object sender, GridTableControlCellMouseEventArgs e)
        {
            return;
            int rowIndex = e.Inner.RowIndex - 1;
            if (rowIndex >= 0)
            {
                var record = this.gridGroupingControl1.Table.Records[rowIndex];
                gridGroupingControl1.Table.SelectedRecords.Clear();
                gridGroupingControl1.Table.SelectedRecords.Add(record);
                gridGroupingControl1.Refresh();
            }
        }

        void grid_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            int rowIndex = e.Inner.RowIndex;
            var data = gridGroupingControl1.Table.Records[rowIndex - 1].GetData() as PluginProvider.PluginInfo;
            if (data != null)
            {
                data.Selected = !data.Selected;
                gridGroupingControl1.Refresh();
            }
        }

        //void grid_TableControlCurrentCellStartEditing(object sender, GridTableControlCancelEventArgs e)
        //{
        //    if (e.Inner.)
        //    {
        //        e.Inner.Cancel = true;
        //    }
        //}
    }
}
