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
        private int _mouseOver = 0;

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
        }

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
            grid.TopLevelGroupOptions.ShowCaption = true;
            grid.TopLevelGroupOptions.CaptionText = "Application plugins";
            
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
            if (e.Inner.RowIndex > 0)
            {
                _mouseOver = e.Inner.RowIndex;
                gridGroupingControl1.Refresh();
            }
        }

        void grid_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            int rowIndex = e.Inner.RowIndex;
            if (e.Inner.RowIndex <= 1)
            {
                return;
            }

            var record = gridGroupingControl1.Table.Records[rowIndex - 3];
            if (record != null)
            {
                var value = (bool)record.GetValue("Selected");
                record.SetValue("Selected", !value);
            }
        }
    }
}
