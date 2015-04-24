using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Views
{
    public partial class RasterStyleView: RasterStyleViewBase, IRasterStyleView
    {
        private readonly IAppContext _context;
        private IImageSource _imageSource;

        public RasterStyleView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
            InitializeComponent();

            InitControls();
        }

        private void InitControls()
        {
            cboDownsampling.AddItemsFromEnum<InterpolationType>();
            cboUpsampling.AddItemsFromEnum<InterpolationType>();
            cboOverviewSampling.AddItemsFromEnum<RasterOverviewSampling>();
            cboOverviewType.AddItemsFromEnum<RasterOverviewType>();
            
            cboOverviewType.SetValue(RasterOverviewType.External);
            cboOverviewSampling.SetValue(RasterOverviewSampling.Nearest);
            cboDynamicScaleMode.SetValue(DynamicVisibilityMode.Zoom);
        }

        /// <summary>
        /// It's called internally before the view is shown. The UI should be populated here from this.Model property.
        /// </summary>
        public void Initialize()
        {
            _imageSource = Model.ImageSource;

            dynamicVisibilityControl1.Initialize(Model, _context.Map.CurrentZoom, _context.Map.CurrentScale);

            rasterColorSchemeView.Initialize(Raster);

            ModelToUi();

            txtGdalInfo.Text = GdalUtils.GdalInfo(Model.Filename, "");

            rasterInfoTreeView1.Initialize(_imageSource as IRasterSource);
        }

        public IRasterColorSchemeView Colors
        {
            get { return rasterColorSchemeView; }
        }

        public IRasterSource Raster
        {
            get { return _imageSource as IRasterSource; }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield break; }
        }

        public IEnumerable<Control> Buttons
        {
            get
            {
                yield return btnProjectionDetails;
                yield return btnBuildOverviews;
                yield return btnClearOverviews;
                yield return btnApply;
                foreach (var btn in rasterColorSchemeView.Buttons)
                {
                    yield return btn;
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
            chkLayerVisible.Checked = Model.Visible;

            txtLayerName.Text = Model.Name;
            txtDatasourceName.Text = Model.Filename;

            string projName = _imageSource.Projection.Name;
            if (string.IsNullOrWhiteSpace(projName))
            {
                projName = "<not defined>";
            }
            txtProjection.Text =  projName;

            const string format = "{0} × {1} pixels; bands: {2}; {3} data type; rendered as {4}";

            txtBriefInfo.Text = string.Format(format, _imageSource.Width, _imageSource.Height, 
                                _imageSource.NumBands, _imageSource.DataType,  "unknown");

            cboDownsampling.SetValue(_imageSource.DownsamplingMode);
            cboUpsampling.SetValue(_imageSource.UpsamplingMode);
        }

        private void ModelToUiRaster()
        {
            if (Raster == null)
            {
                return;
            }

            rasterColorSchemeView.ModelToUiRaster();
        }

        public void UiToModel()
        {
            UiToModelBitmap();

            UiToModelRaster();
        }

        private void UiToModelBitmap()
        {
            _imageSource.DownsamplingMode = cboDownsampling.GetValue<InterpolationType>();
            _imageSource.UpsamplingMode = cboUpsampling.GetValue<InterpolationType>();

            dynamicVisibilityControl1.ApplyChanges();

            Model.Visible = chkLayerVisible.Checked;
        }

        private void UiToModelRaster()
        {
            if (Raster == null)
            {
                return;
            }

            rasterColorSchemeView.UiToModelRaster();
        }

        public void UpdateView()
        {

        }
    }

    public class RasterStyleViewBase : MapWindowView<ILayer> { }
}
