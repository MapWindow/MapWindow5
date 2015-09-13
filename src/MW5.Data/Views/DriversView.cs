using System;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Data.Enums;
using MW5.Data.Views.Abstract;
using MW5.Plugins.Mvp;
using MW5.UI.Controls;
using MW5.UI.Forms;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Views
{
    public partial class DriversView : DriversViewBase, IDriversView
    {
        private const int DescriptionColumnWidth = 310;

        public DriversView()
        {
            InitializeComponent();

            cboFilter.AddItemsFromEnum<DriverFilter>();
            cboFilter.SetValue(DriverFilter.All);

            cboFilter.SelectedIndexChanged += (s, e) =>
            {
                driversTreeView1.Filter(txtSearch.Text, DriverFilter);
            };
        }

        public void Initialize()
        {
            driversTreeView1.Initialize(Model);
            driversTreeView1.HideSelection = false;

            if (Model.SelectedDriver != null)
            {
                lblCount.Visible = false;
                Text = "Driver information: " + Model.SelectedDriver.Name;
            }
            else
            {
                int rasterCount = Model.Count(item => item.IsRaster);
                int vectorCount = Model.Count(item => item.IsVector);
                lblCount.Text = string.Format("Raster formats: {0}. Vector formats: {1}.", rasterCount, vectorCount);
            }
        }

        public DriverFilter DriverFilter
        {
            get { return cboFilter.GetValue<DriverFilter>(); }
        }

        public override ViewStyle Style
        {
            get
            {
                return new ViewStyle()
                {
                    Modal = true,
                    Sizable = true
                };
            }
        }

        public ButtonBase OkButton
        {
            get { return btnClose; }
        }

        private void DriverAfterSelect(object sender, EventArgs e)
        {
            var driver = driversTreeView1.SelectedDriver;
            
            if (driver == null)
            {
                _driverMetadataGrid1.DataSource = null;
                return;
            }

            ShowDriverMetadata(driver);

            ShowOptions(driver, GdalDriverMetadata.CreationOptionList, gridCreationOptions, tabCreationOptions);

            ShowOptions(driver, GdalDriverMetadata.OpenOptionList, gridOpenOptions, tabOpenOptions);

            ShowOptions(driver, GdalDriverMetadata.LayerCreationOptionList, gridLayerOptions, tabLayerOptions);
        }

        private void ShowOptions(DatasourceDriver driver, GdalDriverMetadata metadata, 
                                StronglyTypedGrid<DriverOption> grid, TabPageAdv tabPage)
        {
            string options = driver.get_Metadata(metadata);
            bool hasOptions = !string.IsNullOrWhiteSpace(options);

            if (hasOptions)
            {
                var list = DriverMetadata.ParseOptionList(options).OrderBy(o => o.Name).ToList();
                hasOptions = list.Any();
                grid.DataSource = list;

                var cmn = grid.Adapter.GetColumn(item => item.UserDescription);
                if (cmn != null)
                {
                    cmn.Width = 0;      // to make it shrink
                }

                grid.AdjustColumnWidths();

                if (cmn != null && cmn.Width > DescriptionColumnWidth)
                {
                    cmn.Width = DescriptionColumnWidth;
                }

                grid.AdjustRowHeights();
            }

            tabPage.TabVisible = hasOptions;
        }

        private void ShowDriverMetadata(DatasourceDriver driver)
        {
            var items = driver.Where(item => item.Type != GdalDriverMetadata.LayerCreationOptionList &&
                                           item.Type != GdalDriverMetadata.CreationOptionList &&
                                           item.Type != GdalDriverMetadata.OpenOptionList).ToList();

            _driverMetadataGrid1.DataSource = items;
            _driverMetadataGrid1.AdjustRowHeights();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            driversTreeView1.Filter(txtSearch.Text, DriverFilter);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                driversTreeView1.Filter(txtSearch.Text, DriverFilter);
            }
        }
    }

    public class DriversViewBase : MapWindowView<DriverManager> { }
}
