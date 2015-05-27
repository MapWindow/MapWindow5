using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Properties;
using MW5.Services.Config;
using MW5.UI.Helpers;

namespace MW5.Configuration
{
    public partial class LayerConfigPage : UserControl, IConfigPage
    {
        private readonly IConfigService _configService;

        public LayerConfigPage(IConfigService configService)
        {
            if (configService == null) throw new ArgumentNullException("configService");
            _configService = configService;

            InitializeComponent();

            InitControls();

            Initialize();
        }

        private  void InitControls()
        {
            cboProjectionAbsence.AddItemsFromEnum<ProjectionAbsence>();
            cboProjectionMismatch.AddItemsFromEnum<ProjectionMismatch>();
            cboPyramidCompression.AddItemsFromEnum<TiffCompression>();
            cboPyramidsSampling.AddItemsFromEnum<RasterOverviewSampling>();
        }

        public void Initialize()
        {
            var config = _configService.Config;

            chkCreatePyramids.Checked = config.CreatePyramidsOnOpening;
            chkCreateSpatialIndex.Checked = config.CreateSpatialIndexOnOpening;
            chkProjectionDialog.Checked = !config.NeverShowProjectionDialog;
            chkPyramidsDialog.Checked = !config.NeverShowPyramidDialog;
            chkSpatialIndexDialog.Checked = !config.NeverShowSpatialIndexDialog;

            cboProjectionAbsence.SetValue(config.ProjectionAbsence);
            cboProjectionMismatch.SetValue(config.ProjectionMismatch);
            cboPyramidCompression.SetValue(config.PyramidCompression);
            cboPyramidsSampling.SetValue(config.PyramidSampling);
        }

        public string PageName
        {
            get { return "Layer opening"; }
        }

        public void Save()
        {
            var config = _configService.Config;

            config.CreatePyramidsOnOpening = chkCreatePyramids.Checked;
            config.CreateSpatialIndexOnOpening = chkCreateSpatialIndex.Checked;
            config.NeverShowProjectionDialog = !chkProjectionDialog.Checked;
            config.NeverShowPyramidDialog = !chkPyramidsDialog.Checked;
            config.NeverShowSpatialIndexDialog = !chkSpatialIndexDialog.Checked;

            config.ProjectionAbsence = cboProjectionAbsence.GetValue<ProjectionAbsence>();
            config.ProjectionMismatch = cboProjectionMismatch.GetValue<ProjectionMismatch>();
            config.PyramidCompression = cboPyramidCompression.GetValue<TiffCompression>();
            config.PyramidSampling = cboPyramidsSampling.GetValue<RasterOverviewSampling>();
        }

        public Bitmap Icon
        {
            get { return Resources.img_open_layer32; }
        }

        public bool PluginPage
        {
            get { return false; }
        }

        public ConfigPageType PageTypeType
        {
            get { return ConfigPageType.LayerOpening; }
        }

        public string Description
        {
            get { return "Defines which actions are to be taken on opening a new layer. "; }
        }
    }
}
