using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.UI.Forms;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Chart;

namespace MW5.Plugins.Symbology.Views
{
    public partial class RasterStyleView: RasterStyleViewBase, IRasterStyleView
    {
        private readonly IAppContext _context;
        private IImageSource _imageSource;
        private static int _lastTabIndex = 0;

        public RasterStyleView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
            InitializeComponent();

            InitControls();

            tabControlAdv1.SelectedIndex = _lastTabIndex;

            FormClosed += (s, e) => _lastTabIndex = tabControlAdv1.SelectedIndex;
        }

        private void InitControls()
        {
            cboDownsampling.AddItemsFromEnum<InterpolationType>();
            cboUpsampling.AddItemsFromEnum<InterpolationType>();
            cboDynamicScaleMode.SetValue(DynamicVisibilityMode.Zoom);

            panelColorize.DataBindings.Add("Enabled", chkColorize, "Checked");
        }

        /// <summary>
        /// It's called internally before the view is shown. The UI should be populated here from this.Model property.
        /// </summary>
        public void Initialize()
        {
            _imageSource = Model.ImageSource;

            _dynamicVisibilityControl1.Initialize(Model, _context.Map.CurrentZoom, _context.Map.CurrentScale);

            _colorSchemeControl.Initialize(Raster);

            ModelToUi();

            txtGdalInfo.Text = GdalUtils.GdalInfo(Model.Filename, "");

            rasterInfoTreeView1.Initialize(_imageSource as IRasterSource);

            histogramControl1.Initialize(_context.Container, Raster);

            _overviewControl1.Initialize(Raster);
        }

        public IRasterColorSchemeView Colors
        {
            get { return _colorSchemeControl; }
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
                yield return btnApply;
                yield return btnClearColorAdjustments;
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
            
            tbrBrightness.SetValue(_imageSource.Brightness * 20.0f);
            tbrConstrast.SetValue(_imageSource.Contrast * 20.0f);
            tbrSaturation.SetValue(_imageSource.Saturation * 20.0f);
            tbrHue.SetValue(_imageSource.Hue);
            tbrGamma.SetValue(_imageSource.Gamma * 20.0f);
            tbrColorizeIntensity.SetValue(_imageSource.ColorizeIntensity * 100.0f);

            clpColorize.Color = _imageSource.ColorizeColor;
            chkGreyScale.Checked = _imageSource.Greyscale;
            chkColorize.Checked = _imageSource.ColorizeIntensity > 0.0f;
        }

        private void ModelToUiRaster()
        {
            if (Raster == null)
            {
                return;
            }

            _colorSchemeControl.ModelToUiRaster();
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
            _imageSource.Brightness = tbrBrightness.Value/20.0f;
            _imageSource.Contrast = tbrConstrast.Value / 20.0f;
            _imageSource.Saturation = tbrSaturation.Value / 20.0f;
            _imageSource.Hue = tbrHue.Value;
            _imageSource.Gamma = tbrGamma.Value / 20.0f;
            _imageSource.ColorizeColor = clpColorize.Color;
            _imageSource.ColorizeIntensity = chkColorize.Checked ? tbrColorizeIntensity.Value / 100.0f : 0.0f;
            _imageSource.Greyscale = chkGreyScale.Checked;

            _dynamicVisibilityControl1.ApplyChanges();

            Model.Visible = chkLayerVisible.Checked;
        }

        public void ClearColorAdjustments()
        {
            tbrBrightness.Value = 0;
            tbrConstrast.Value = 20;
            tbrSaturation.Value = 20;
            tbrHue.Value = 0;
            tbrGamma.Value = 20;
            tbrColorizeIntensity.Value = 0;
            chkColorize.Checked = false;
            chkGreyScale.Checked = false;
        }

        private void UiToModelRaster()
        {
            if (Raster == null)
            {
                return;
            }

            _colorSchemeControl.UiToModelRaster();
        }
    }

    public class RasterStyleViewBase : MapWindowView<ILayer> { }
}
