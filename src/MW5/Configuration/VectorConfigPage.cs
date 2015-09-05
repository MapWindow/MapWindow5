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
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Properties;
using MW5.Services.Config;
using MW5.Shared;
using MW5.UI.Helpers;

namespace MW5.Configuration
{
    public partial class VectorConfigPage : UserControl, IConfigPage
    {
        private readonly IConfigService _configService;

        public VectorConfigPage(IConfigService configService)
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
        }

        public void Initialize()
        {
            var config = _configService.Config;
            
            chkCreateSpatialIndex.Checked = config.CreateSpatialIndexOnOpening;
            chkSpatialIndexDialog.Checked = config.ShowSpatialIndexDialog;

            udSpatialIndexCount.SetValue(config.SpatialIndexFeatureCount);
        }

        public string PageName
        {
            get { return "Vector"; }
        }

        public void Save()
        {
            var config = _configService.Config;

            config.CreateSpatialIndexOnOpening = chkCreateSpatialIndex.Checked;
            config.ShowSpatialIndexDialog = chkSpatialIndexDialog.Checked;

            config.SpatialIndexFeatureCount = (int)udSpatialIndexCount.Value;
        }

        public Bitmap Icon
        {
            get { return Resources.img_vector32; }
        }

        public bool PluginPage
        {
            get { return false; }
        }

        public ConfigPageType PageType
        {
            get { return ConfigPageType.Projections; }
        }

        public string Description
        {
            get { return "Settings related to vector datasources."; }
        }

        public bool VariableHeight
        {
            get { return false; }
        }
    }
}
