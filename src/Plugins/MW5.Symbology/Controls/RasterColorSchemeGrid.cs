using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Plugins.Mvp;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class RasterColorSchemeGrid : GridListControl<GridColorInterval>
    {
        public const string ModelName = "ColorModel";
        public const int RowHeight = 20;
        public const int ColorColumnWidth = 70;

        public RasterColorSchemeGrid()
        {
            InitializeComponent();

            Grid.BorderStyle = BorderStyle.None;
            Grid.Table.DefaultRecordRowHeight = RowHeight;
            Grid.AllowCurrentCell = true;

            var model = new GridCellColorModel(Grid.TableControl.Model);
            Grid.TableControl.Model.CellModels.Add(ModelName, model);

            Grid.TableControlCellDoubleClick += Grid_TableControlCellDoubleClick;
        }

        public override object DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                base.DataSource = value;

                var cmn = GetColumn(item => item.LowColor);
                if (cmn != null)
                {
                    cmn.Appearance.AnyRecordFieldCell.CellType = ModelName;
                    cmn.Width = ColorColumnWidth;
                }
            }
        }

        public void ShowDropDowns(bool value)
        {
            var model = Grid.TableControl.Model.CellModels[ModelName] as GridCellColorModel;
            if (model != null)
            {
                model.ShowDropDowns = value;
            }
        }

        public void RefreshGrid()
        {
            Grid.Refresh();
        }

        private void Grid_TableControlCellDoubleClick(object sender, GridTableControlCellClickEventArgs e)
        {
            int columnIndex = GetColumnIndex(item => item.LowColor);
            if (e.Inner.ColIndex != columnIndex)
            {
                return;
            }

            var interval = this[e.Inner.RowIndex];

            using (var dialog = new ColorDialog())
            {
                dialog.Color = interval.LowColor;
                dialog.FullOpen = true;
                dialog.AnyColor = true;
                if (dialog.ShowDialog(AppViewFactory.Instance.MainForm) == DialogResult.OK)
                {
                    SetProperty(item => item.LowColor, dialog.Color);
                    Grid.Refresh();
                }
            }
        }
    }
}
