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
    public partial class RasterColorSchemeGrid : StronglyTypedGrid<RasterInterval>
    {
        public const string ModelName = "ColorModel";
        public const int RowHeight = 20;
        public const int ColorColumnWidth = 70;

        public RasterColorSchemeGrid()
        {
            InitializeComponent();

            Extended = false;

            Table.DefaultRecordRowHeight = RowHeight;

            var model = new GridCellColorModel(TableControl.Model);
            TableControl.Model.CellModels.Add(ModelName, model);

            TableControlCellDoubleClick += Grid_TableControlCellDoubleClick;
        }

        public bool Extended { get; set; }

        public new object DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                base.DataSource = value;

                Adapter.AdjustColumnWidths();

                GridColumnDescriptor[] columns = 
                {
                    Adapter.GetColumn(item => item.LowColor),
                    Adapter.GetColumn(item => item.HighColor)
                };

                foreach (var cmn in columns.Where(cmn => cmn != null))
                {
                    cmn.Appearance.AnyRecordFieldCell.CellType = ModelName;
                    cmn.Width = Adapter.ReadOnly ? 40 : 70;
                }

                UpdateColumnVisibility();
            }
        }

        private void UpdateColumnVisibility()
        {
            var columns = TableDescriptor.VisibleColumns;
            columns.Clear();

            if (!Extended)
            {
                columns.Add("LowColor");        // use reflection
                columns.Add("HighColor");
                columns.Add("Range");
            }
            else
            {
                columns.Add("LowColor");        // use reflection
                columns.Add("HighColor");
                columns.Add("LowValue");
                columns.Add("HighValue");
                columns.Add("Caption");
            }
        }

        public void ShowDropDowns(bool value)
        {
            var model = TableControl.Model.CellModels[ModelName] as GridCellColorModel;
            if (model != null)
            {
                model.ShowDropDowns = value;
            }
        }

        public void RefreshGrid()
        {
            Refresh();
        }

        private void Grid_TableControlCellDoubleClick(object sender, GridTableControlCellClickEventArgs e)
        {
            if (Adapter.ReadOnly)
            {
                return;
            }

            int columnIndex = Adapter.GetColumnIndex(item => item.LowColor);
            if (e.Inner.ColIndex != columnIndex)
            {
                return;
            }

            var interval = Adapter[e.Inner.RowIndex - 2];       // TODO: don't use constant

            using (var dialog = new ColorDialog())
            {
                dialog.Color = interval.LowColor;
                dialog.FullOpen = true;
                dialog.AnyColor = true;
                if (dialog.ShowDialog(AppViewFactory.Instance.MainForm) == DialogResult.OK)
                {
                    Adapter.SetProperty(item => item.LowColor, dialog.Color);
                    Refresh();
                }
            }
        }
    }
}
