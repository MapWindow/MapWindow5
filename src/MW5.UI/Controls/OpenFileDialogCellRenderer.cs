using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                try
                {
                    string s = Grid.Model[rowIndex, colIndex].Text;
                    string path = Path.GetDirectoryName(s);
                    _dialog.InitialDirectory = path;
                    _dialog.FileName = Path.GetFileName(s);
                    _dialog.Filter = "Custom|*" + Path.GetExtension(s);
                }
                catch {}   // ignore

                if (_dialog.ShowDialog() == DialogResult.OK)
                {
                    Grid.Model[rowIndex, colIndex].Text = _dialog.FileName;
                }

                Grid.Model.ColWidths.ResizeToFit(GridRangeInfo.Col(colIndex), GridResizeToFitOptions.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected override Rectangle OnLayout(int rowIndex, int colIndex, GridStyleInfo style, Rectangle innerBounds, Rectangle[] buttonsBounds)
        {
            TraceUtil.TraceCurrentMethodInfo(rowIndex, colIndex, style, innerBounds, buttonsBounds);
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
