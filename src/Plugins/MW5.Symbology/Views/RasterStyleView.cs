using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.UI.Forms;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.Symbology.Views
{
    public partial class RasterStyleView: RasterStyleViewBase, IRasterStyleView
    {
        private IImageSource _imageSource;

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
        }

        /// <summary>
        /// It's called internally before the view is shown. The UI should be populated here from this.Model property.
        /// </summary>
        public void Initialize()
        {
            _imageSource = Model.ImageSource;

            ModelToUi();

            txtGdalInfo.Text = GdalUtils.GdalInfo(Model.Filename, "");

            rasterInfoTreeView1.Initialize(_imageSource as IRasterSource);
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
                yield return btnProjectionDetails;
                yield return btnBuildOverviews;
                yield return btnClearOverviews;
            }
        }

        private void ModelToUi()
        {
            txtLayerName.Text = Model.Name;
            txtDatasourceName.Text = Model.Filename;
            txtProjection.Text = _imageSource.Projection.Name;
            
            const string format = "{0} × {1} pixels; {2} bands; rendered as {3}";
            txtBriefInfo.Text = string.Format(format, _imageSource.Width, _imageSource.Height, _imageSource.NumBands, "unknown");

            cboDownsampling.SetValue(_imageSource.DownsamplingMode);
            cboUpsampling.SetValue(_imageSource.UpsamplingMode);
        }

        public void UpdateView()
        {

        }
    }

    public class RasterStyleViewBase : MapWindowView<ILayer> { }
}
