using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Views
{
    public partial class RasterStyleView: RasterStyleViewBase, IRasterStyleView
    {
        private readonly IAppContext _context;
        private readonly RasterRenderingPresenter _renderingPresenter;
        private IImageSource _imageSource;
        private static int _lastTabIndex = 0;

        public RasterStyleView(IAppContext context, RasterRenderingPresenter renderingPresenter)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (renderingPresenter == null) throw new ArgumentNullException("renderingPresenter");
            
            InitializeComponent();

            _context = context;
            _renderingPresenter = renderingPresenter;

            renderingPresenter.View.Dock = DockStyle.Fill;
            tabPageColors.Controls.Add(renderingPresenter.View);

            InitControls();

            rasterInfoTreeView1.CreateColumns();

            toolStyle.Tag = 0;      // to not attach onclick handler to it
            
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

            if (Raster != null)
            {
                _renderingPresenter.Initialize(Raster);

                rasterInfoTreeView1.Initialize(_imageSource as IRasterSource);

                histogramControl1.Initialize(_context.Container, Raster);

                _overviewControl1.Initialize(Raster);

                richTextBox1.Visible = false;
            }
            else
            {
                tabControlAdv1.TabPages.Remove(tabPageColors);
                tabControlAdv1.TabPages.Remove(tabPageHistogram);
                tabControlAdv1.TabPages.Remove(tabPagePyramids);

                richTextBox1.Visible = true;

                richTextBox1.Text = GdalUtils.GdalInfo(Model.Filename, "");
            }

            ModelToUi();
        }

        public RasterRenderingPresenter RenderingPresenter
        {
            get { return _renderingPresenter; }
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
            get { yield return toolStripEx1.Items; }
        }

        public IEnumerable<Control> Buttons
        {
            get
            {
                yield return btnProjectionDetails;
                yield return btnApply;
                yield return btnClearColorAdjustments;
                yield return btnOpenFolder;
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

            const string format = "{0} × {1} pixels; bands: {2}; {3} data type";

            txtBriefInfo.Text = string.Format(format, _imageSource.Width, _imageSource.Height,
                                _imageSource.NumBands, _imageSource.DataType);

            cboDownsampling.SetValue(_imageSource.DownsamplingMode);
            cboUpsampling.SetValue(_imageSource.UpsamplingMode);
            
            tbrBrightness.SetValue(_imageSource.Brightness * 20.0f);
            tbrConstrast.SetValue(_imageSource.Contrast * 20.0f);
            tbrSaturation.SetValue(_imageSource.Saturation * 20.0f);
            tbrHue.SetValue(_imageSource.Hue);
            tbrGamma.SetValue(_imageSource.Gamma * 20.0f);
            tbrColorizeIntensity.SetValue(_imageSource.ColorizeIntensity * 100.0f);
            tbrTransparency.SetValue((float)(_imageSource.Transparency * 255.0f));

            clpTransparent.Color = _imageSource.TransparentColorFrom;
            clpColorize.Color = _imageSource.ColorizeColor;
            chkGreyScale.Checked = _imageSource.Greyscale;
            chkColorize.Checked = _imageSource.ColorizeIntensity > 0.0f;
            chkUseTransparentColor.Checked = _imageSource.UseTransparentColor;
        }

        private void ModelToUiRaster()
        {
            if (Raster == null)
            {
                return;
            }

            _renderingPresenter.View.ModelToUiRaster();
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
            _imageSource.Transparency = tbrTransparency.Value/255.0;
            _imageSource.Hue = tbrHue.Value;
            _imageSource.Gamma = tbrGamma.Value / 20.0f;
            _imageSource.ColorizeColor = clpColorize.Color;
            _imageSource.ColorizeIntensity = chkColorize.Checked ? tbrColorizeIntensity.Value / 100.0f : 0.0f;
            _imageSource.Greyscale = chkGreyScale.Checked;

            if (chkUseTransparentColor.Checked)
            {
                _imageSource.TransparentColorFrom = clpTransparent.Color;
                _imageSource.TransparentColorTo = clpTransparent.Color;
                _imageSource.UseTransparentColor = true;
            }
            else
            {
                _imageSource.UseTransparentColor = false;
            }

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
            tbrTransparency.Value = 255;
            chkColorize.Checked = false;
            chkGreyScale.Checked = false;
        }

        private void UiToModelRaster()
        {
            if (Raster == null)
            {
                return;
            }

            _renderingPresenter.View.UiToModelRaster();
        }
    }

    public class RasterStyleViewBase : MapWindowView<ILayer> { }
}
