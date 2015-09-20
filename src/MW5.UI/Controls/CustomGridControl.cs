using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Services;
using MW5.Shared;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.UI.Controls
{
    public class CustomGridControl: GridGroupingControl
    {
        protected CustomGridControl()
        {
            InitStyle();

            InitGroupOptions();

            UdpateSelectionMode();

            WrapWithPanel = true;

            TableControl.CurrentCellValidating += TableControl_CurrentCellValidating;
            
            TableControlCellClick += OnTableControlCellClick;

            TableControl.CurrentCellShowingDropDown += OnCurrentCellShowingDropDown;
            //TableControl.CurrentCell.ShowErrorIcon = false;
            //TableControl.CurrentCell.ShowErrorMessageBox = false;
        }

        /// <summary>
        /// Displaying larger combobox list.
        /// </summary>
        private void OnCurrentCellShowingDropDown(object sender, GridCurrentCellShowingDropDownEventArgs e)
        {
            var renderer = TableControl.Model.CurrentCellRenderer as GridComboBoxCellRenderer;
            if (renderer != null)
            {
                var listbox = renderer.ListBoxPart as GridComboBoxListBoxPart;
                if (listbox != null)
                {
                    listbox.DropDownRows = 20;
                }
            }
        }

        [Browsable(false)]
        public bool WrapWithPanel { get; set; }

        /// <summary>
        /// Toggling checkbox checked state by clicking on cell outside it.
        /// </summary>
        private void OnTableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            var model = Table.TableModel[e.Inner.RowIndex, e.Inner.ColIndex];
            if (model == null)
            {
                return;
            }

            if (model.ReadOnly)
            {
                e.Inner.Cancel = true;
                return;
            }

            var cellType = model.CellType;
            if (!string.IsNullOrWhiteSpace(cellType) && cellType.EqualsIgnoreCase("CheckBox"))
            {
                model.CellValue = !(bool)(model.CellValue);
            }
        }

        /// <summary>
        /// Checks if the values typed in double and integer columns are numbers.
        /// </summary>
        /// <remarks>http ://www.syncfusion.com/kb/619/where-can-i-validate-changes-made-to-a-grid-cell</remarks>
        private void TableControl_CurrentCellValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var type = GetCurrentColumnFieldType();
            if (type == null) return;

            string text = TableControl.CurrentCell.Renderer.ControlText;
                
            if (type == typeof (double))
            {
                double val;
                if (!Double.TryParse(text, out val))
                {
                    e.Cancel = true;
                    TableControl.CurrentCell.CancelEdit();
                    MessageService.Current.Warn("Invalid double value.");
                }
            }
            else if (type == typeof (int))
            {
                int val;
                if (!Int32.TryParse(text, out val))
                {
                    e.Cancel = true;
                    TableControl.CurrentCell.CancelEdit();
                    MessageService.Current.Warn("Invalid integer value.");
                }
            }
        }

        private Type GetCurrentColumnFieldType()
        {
            int index = TableDescriptor.ColIndexToField(TableControl.CurrentCell.ColIndex);
            var cmn = TableDescriptor.VisibleColumns[index];
            if (cmn != null)
            {
                var fld = TableDescriptor.Fields[cmn.Name];
                if (fld != null)
                {
                    return fld.FieldPropertyType;
                }
            }

            return null;
        }

        private void InitStyle()
        {
            Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle;
            Appearance.AnyCell.Borders.All = new GridBorder(GridBorderStyle.None, Color.White);
            GridLineColor = Color.White;
            BrowseOnly = false;
            ShowRowHeaders = false;
            ShowColumnHeaders = true;
        }

        private void InitGroupOptions()
        {
            ShowGroupDropArea = false;
            TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            TopLevelGroupOptions.ShowCaption = false;
        }

        public void UdpateSelectionMode()
        {
            TableOptions.ListBoxSelectionMode = SelectionMode.One;
            TableOptions.SelectionBackColor = Color.FromArgb(64, 51, 153, 255);
            TableOptions.SelectionTextColor = Color.Black;
            TableOptions.ListBoxSelectionColorOptions = GridListBoxSelectionColorOptions.ApplySelectionColor;

            // any option other than None will disable SelectedRecordsChanged event
            // http ://www.syncfusion.com/forums/46745/grid-grouping-control-selection-color
            TableOptions.AllowSelection = GridSelectionFlags.None;
        }

        public void ForceImmediateSaveValue()
        {
            foreach (FieldDescriptor t in TableDescriptor.Fields)
            {
                t.ForceImmediateSaveValue = true;
            }
        }
    }
}
