using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.UI.Controls
{
    public abstract class StronglyTypedGrid<T> : GridGroupingControl
            where T : class
    {
        public GridAdapter<T> Adapter { get; protected set; }

        protected StronglyTypedGrid()
        {
            InitStyle();

            InitGroupOptions();

            InitRowSelection();

            Adapter = new GridAdapter<T>(this);
        }

        public bool AllowCurrentCell
        {
            get { return ActivateCurrentCellBehavior == GridCellActivateAction.None; }
            set
            {
                if (!value)
                {
                    Table.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.None;
                    ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways;
                    ActivateCurrentCellBehavior = GridCellActivateAction.None;
                }
                else
                {
                    Table.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.WhiteCurrentCell;
                    ActivateCurrentCellBehavior = GridCellActivateAction.SetCurrent;
                    ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways;
                }
            }
        }

        public Color SelectionBackColor
        {
            get { return TableOptions.SelectionBackColor; }
            set { TableOptions.SelectionBackColor = value; }
        }

        private void InitStyle()
        {
            Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle;
            Appearance.AnyCell.Borders.All = new GridBorder(GridBorderStyle.None, Color.White);
            GridLineColor = Color.White;
            BrowseOnly = false;
            ShowRowHeaders = false;
            ShowColumnHeaders = true;
            AllowCurrentCell = false;
        }

        private void InitGroupOptions()
        {
            ShowGroupDropArea = false;
            TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            TopLevelGroupOptions.ShowCaption = false;
        }

        private void InitRowSelection()
        {
            TableOptions.ListBoxSelectionMode = SelectionMode.One;
            SelectionBackColor = Color.FromArgb(64, 51, 153, 255);
            TableOptions.SelectionTextColor = Color.Black;
            TableOptions.ListBoxSelectionColorOptions = GridListBoxSelectionColorOptions.ApplySelectionColor;

            // any option other than None will disable SelectedRecordsChanged event
            // http ://www.syncfusion.com/forums/46745/grid-grouping-control-selection-color
            TableOptions.AllowSelection = GridSelectionFlags.None;
        }
    }
}
