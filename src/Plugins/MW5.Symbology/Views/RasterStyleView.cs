using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Views
{
    public partial class RasterStyleView: RasterStyleViewBase, IRasterStyleView
    {
        private IImageSource _imageSource;
        private RasterColorScheme _colorScheme;

        public RasterStyleView()
        {
            InitializeComponent();

            InitControls();
        }

        private void InitControls()
        {
            cboDownsampling.AddItemsFromEnum<InterpolationType>();
            cboUpsampling.AddItemsFromEnum<InterpolationType>();
            cboOverviewSampling.AddItemsFromEnum<RasterOverviewSampling>();
            cboOverviewType.AddItemsFromEnum<RasterOverviewType>();
            cboDynamicScaleMode.AddItemsFromEnum<DynamicVisibilityMode>();
            
            cboOverviewType.SetValue(RasterOverviewType.External);
            cboOverviewSampling.SetValue(RasterOverviewSampling.Nearest);
            cboDynamicScaleMode.SetValue(DynamicVisibilityMode.ZoomLevels);

            colorSchemeCombo1.SelectedIndex = 0;
        }

        public IRasterSource Raster
        {
            get  { return _imageSource as IRasterSource;}
        }

        /// <summary>
        /// It's called internally before the view is shown. The UI should be populated here from this.Model property.
        /// </summary>
        public void Initialize()
        {
            _imageSource = Model.ImageSource;

            if (Raster != null)
            {
                InitRenderMode(Raster);

                FillGrid(Raster);

                FillBandCombo(Raster);
            }

            ModelToUi();

            txtGdalInfo.Text = GdalUtils.GdalInfo(Model.Filename, "");

            rasterInfoTreeView1.Initialize(_imageSource as IRasterSource);
        }

        /// <summary>
        /// Fills the band combo.
        /// </summary>
        private void FillBandCombo(IRasterSource raster)
        {
            cboSelectedBand.Items.Clear();

            for (int i = 1; i <= raster.Bands.Count; i++)
            {
                var band = raster.Bands[i];
                string bandName = "Band " + i + " (" + band.ColorInterpretation + ")";
                cboSelectedBand.Items.Add(bandName);
            }

            if (cboSelectedBand.Items.Count > 0)
            {
                cboSelectedBand.SelectedIndex = 0;
            }
        }

        public int SelectedPredefinedColorScheme
        {
            get { return colorSchemeCombo1.SelectedIndex; }
        }

        public int ActiveBandIndex
        {
            get { return cboSelectedBand.SelectedIndex + 1; }
        }

        public RasterColorScheme ColorScheme
        {
            get { return _colorScheme; }
            set
            {
                if (value != null)
                {
                    _colorScheme = value;
                    rasterColorSchemeGrid1.DataSource = value.ToList();
                    rasterColorSchemeGrid1.ShowDropDowns(true);
                }
            }
        }

        /// <summary>
        /// Sets datasource for color scheme grid.
        /// </summary>
        private void FillGrid(IRasterSource raster)
        {
            var table = raster.Bands[1].ColorTable;
            ColorScheme = table;
        }

        /// <summary>
        /// Initializes the rendering mode combo box.
        /// </summary>
        private void InitRenderMode(IRasterSource raster)
        {
            var list = new List<RasterRendering> {RasterRendering.SingleBand};

            if (raster.NumBands > 1)
            {
                list.Add(RasterRendering.MultiBand);
            }

            list.Add(RasterRendering.PsuedoColors);

            if (raster.HasBuiltInColorTable)
            {
                list.Add(RasterRendering.BuiltInColorTable);
            }

            cboRasterRendering.Items.AddRange(ComboBoxHelper.GetComboItems(list).ToArray<object>());

            cboRasterRendering.SelectedIndex = 0;
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public IEnumerable<ToolStripItemCollection> Toolstrips
        {
            get { yield break; }
        }

        public IEnumerable<Control> Buttons
        {
            get
            {
                var items = new[]
                {
                    btnProjectionDetails,
                    btnBuildOverviews,
                    btnClearOverviews,
                    btnGenerateColorScheme,
                    btnCalculateMinMax,
                    btnApply
                };
                
                foreach(var item in items)
                {
                    yield return item;
                }
            }
        }

        private void ModelToUi()
        {
            ModelToUiBitmap();

            ModelToUiRaster();
        }

        private void ModelToUiBitmap()
        {
            txtLayerName.Text = Model.Name;
            txtDatasourceName.Text = Model.Filename;
            txtProjection.Text = _imageSource.Projection.Name;

            const string format = "{0} × {1} pixels; {2} bands; rendered as {3}";
            txtBriefInfo.Text = string.Format(format, _imageSource.Width, _imageSource.Height, _imageSource.NumBands, "unknown");

            cboDownsampling.SetValue(_imageSource.DownsamplingMode);
            cboUpsampling.SetValue(_imageSource.UpsamplingMode);
        }

        private void ModelToUiRaster()
        {
            var raster = _imageSource as IRasterSource;
            if (raster == null)
            {
                return;
            }

            chkUseHistogram.Checked = raster.UseHistogram;
        }

        public void UiToModel()
        {
            UiToModelBitmap();

            UiToModelRaster();
        }

        public double BandMinValue
        {
            get { return txtMinimum.DoubleValue; }
        }

        public double BandMaxValue
        {
            get { return txtMaximum.DoubleValue; }
        }



        private void UiToModelBitmap()
        {
            _imageSource.DownsamplingMode = cboDownsampling.GetValue<InterpolationType>();
            _imageSource.UpsamplingMode = cboUpsampling.GetValue<InterpolationType>();
        }

        private void UiToModelRaster()
        {
            var raster = _imageSource as IRasterSource;
            if (raster == null)
            {
                return;
            }

            raster.UseHistogram = chkUseHistogram.Checked;
        }

        public void UpdateView()
        {

        }

        private void cboSelectedBand_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bandIndex = cboSelectedBand.SelectedIndex + 1;
            if (bandIndex >= 1)
            {
                var band = Raster.Bands[bandIndex];
                txtMinimum.DoubleValue = band.Minimum;
                txtMaximum.DoubleValue = band.Maximum;
            }
        }
    }

    public class RasterStyleViewBase : MapWindowView<ILayer> { }
}
