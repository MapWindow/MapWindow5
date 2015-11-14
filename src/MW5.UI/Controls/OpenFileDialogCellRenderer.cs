using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Shared;
using Syncfusion.Diagnostics;
using Syncfusion.GridHelperClasses;
using Syncfusion.Windows.Forms.Grid;

namespace MW5.UI.Controls
{
    public class OpenFileDialogCellRenderer : GridTextBoxCellRenderer
    {
        private readonly OpenFileDialog _dialog;

        public OpenFileDialogCellRenderer(GridControlBase grid, GridTextBoxCellModel cellModel) : base(grid, cellModel)
        {
            var btn = new GridCellComboBoxButton(this);
            AddButton(btn);

            _dialog = new OpenFileDialog();
        }

        public override void OnPrepareViewStyleInfo(GridPrepareViewStyleInfoEventArgs e)
        {
            e.Style.ShowButtons = GridShowButtons.Show;
            e.Style.Clickable = true;
            e.Style.TextAlign = GridTextAlign.Left;
            e.Style.VerticalAlignment = GridVerticalAlignment.Middle;
            e.Style.WrapText = false;
        }

        protected override void OnButtonClicked(int rowIndex, int colIndex, int button)
        {
            base.OnButtonClicked(rowIndex, colIndex, button);

            try
            {
                string s = Grid.Model[rowIndex, colIndex].Text;
                InitDialog(s);

                if (_dialog.ShowDialog() == DialogResult.OK)
                {
                    Grid.Model[rowIndex, colIndex].Text = _dialog.FileName;
                }

                Grid.Model.ColWidths.ResizeToFit(GridRangeInfo.Col(colIndex), GridResizeToFitOptions.None);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("OpenFileDialogCellRenderer: failed to edit datasource path.", ex);
            }
        }

        private void InitDialog(string filename)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(filename))
                {
                    string path = Path.GetDirectoryName(filename);
                    _dialog.InitialDirectory = path;
                    _dialog.FileName = Path.GetFileName(filename);
                    string filter = "*" + Path.GetExtension(filename);
                    _dialog.Filter = filter + "|" + filter;
                }
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to open file selection dialog.", ex);
            }  
        }

        protected override Rectangle OnLayout(int rowIndex, int colIndex, GridStyleInfo style, Rectangle innerBounds, Rectangle[] buttonsBounds)
        {
            Rectangle rightArea;

            if (Grid.IsRightToLeft())
            {
                rightArea = Rectangle.FromLTRB(innerBounds.Left, innerBounds.Top, innerBounds.Left + 20,
                    innerBounds.Bottom);
                innerBounds.X += 20;
            }
            else
            {
                rightArea = Rectangle.FromLTRB(innerBounds.Right - 20, innerBounds.Top, innerBounds.Right,
                    innerBounds.Bottom);
            }

            innerBounds.Width -= 20;
            buttonsBounds[0] = GridUtil.CenterInRect(rightArea, new Size(20, 20));

            return innerBounds;
        }
    }
}
