using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using Syncfusion.Drawing;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Controls
{
    public class GridCellColorRenderer : GridDropDownCellRenderer
    {
        private ColorUIControl _colorPicker;

        public bool ShowDropDownButton
        {
            get { return DropDownButton != null; }

            set
            {
                if (value == (DropDownButton == null))
                {
                    DropDownButton = value ? new GridCellComboBoxButton(this) : null;
                }
            }
        }

        public GridCellColorRenderer(Syncfusion.Windows.Forms.Grid.GridControlBase grid, GridCellModelBase cellModel)
            : base(grid, cellModel)
        {
            TextBox.Visible = false;

            DropDownPart.InitFocusEditPart = false;
            DropDownPart.IgnoreFocus = true;

            DropDownContainer.BorderStyle = BorderStyle.None;
        }

        protected override void InitializeDropDownContainer()
        {
            base.InitializeDropDownContainer();
            _colorPicker = new ColorUIControl {Dock = DockStyle.Fill, Visible = true};

            _colorPicker.ColorSelected += ColorUiColorSelected;

            _colorPicker.BorderStyle = BorderStyle.None;
            DropDownContainer.Controls.Add(_colorPicker);
        }

        protected override void OnDraw(Graphics g, Rectangle clientRectangle, int rowIndex, int colIndex, GridStyleInfo style)
        {
            if (rowIndex < 2)
            {
                //OnDraw(g, clientRectangle, rowIndex, colIndex, style);
                return;
            }

            bool showDropDowns = ((GridCellColorModel)Model).ShowDropDowns;
            ShowDropDownButton = showDropDowns;

            var r = new Rectangle(clientRectangle.X + 5, clientRectangle.Y + 2, clientRectangle.Width - 10, clientRectangle.Height - 4);
            g.FillRectangle(new SolidBrush(GetValue(rowIndex, colIndex)), r);
        }

        public Color GetValue(int rowIndex, int colIndex)
        {
            return (Color) Grid.Model[rowIndex, colIndex].CellValue;
        }

        public void SetValue(int rowIndex, int colIndex, Color color)
        {
            Grid.Model[rowIndex, colIndex].CellValue = color;
            Grid.CurrentCell.IsModified = true;
        }

        protected override bool OnSaveChanges()
        {
            return CurrentCell.IsModified;
        }

        public override void DropDownContainerShowingDropDown(object sender, CancelEventArgs e)
        {
            DropDownContainer.Size = new Size(500, 500);
            Color clrselected = GetValue(RowIndex, ColIndex);
            
            _colorPicker.Start(clrselected);
            Size size = new Size(208, 230);
            var gridCurrentCellShowingDropDownEventArgs = new GridCurrentCellShowingDropDownEventArgs(size);
            Grid.RaiseCurrentCellShowingDropDown(gridCurrentCellShowingDropDownEventArgs);
            
            if (gridCurrentCellShowingDropDownEventArgs.Cancel)
            {
                e.Cancel = true;
                return;
            }

            DropDownContainer.Size = gridCurrentCellShowingDropDownEventArgs.Size;
        }

        public override void ChildClosing(IPopupChild childUi, PopupCloseType popupCloseType)
        {
            if (popupCloseType == PopupCloseType.Done && !IsReadOnly())
            {
                if (!NotifyCurrentCellChanging())
                {
                    return;
                }

                SetValue(RowIndex, ColIndex, _colorPicker.SelectedColor);

                Grid.InvalidateRange(GridRangeInfo.Cell(RowIndex, ColIndex));
                NotifyCurrentCellChanged();
            }
            DropDownContainerCloseDropDown(childUi, new PopupClosedEventArgs(popupCloseType));
        }

        public override void DropDownContainerShowedDropDown(object sender, EventArgs e)
        {
            DropDownContainer.FocusParent();
            NotifyShowedDropDown();
        }

        private void ColorUiColorSelected(object sender, EventArgs e)
        {
            CurrentCell.CloseDropDown(PopupCloseType.Done);
        }
    }
}
