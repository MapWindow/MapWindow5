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
using MW5.Shared;
using MW5.UI.Helpers;

namespace MW5.Configuration
{
    public partial class RasterConfigPage : UserControl, IConfigPage
    {
        private readonly IConfigService _configService;

        public RasterConfigPage(IConfigService configService)
        {
            if (configService == null) throw new ArgumentNullException("configService");
            _configService = configService;

            InitializeComponent();

            InitControls();

            Initialize();
        }

        private  void InitControls()
        {
            cboDownsampling.AddItemsFromEnum<InterpolationType>();
            cboUpsampling.AddItemsFromEnum<InterpolationType>();
            cboDefaultColorScheme.AddItemsFromEnum<PredefinedColors>();
        }

        public void Initialize()
        {
            var config = _configService.Config;
            cboUpsampling.SetValue(config.RasterUpsamplingMode);
            cboDownsampling.SetValue(config.RasterDownsamplingMode);
            cboDefaultColorScheme.SetValue(config.RasterDefaultColorScheme);

            chkRandomColorScheme.Checked = config.RasterRandomColorScheme;
            chkCreateColorScheme.Checked = config.RasterCreateColorScheme;
        }

        public void Save()
        {
            var config = _configService.Config;

            config.RasterUpsamplingMode = cboUpsampling.GetValue<InterpolationType>();
            config.RasterDownsamplingMode = cboDownsampling.GetValue<InterpolationType>();
            config.RasterDefaultColorScheme = cboDefaultColorScheme.GetValue<PredefinedColors>();

            config.RasterRandomColorScheme = chkRandomColorScheme.Checked;
            config.RasterCreateColorScheme = chkCreateColorScheme.Checked;
        }

        public string PageName
        {
            get { return "Raster"; }
        }

        public Bitmap Icon
        {
            get { return Resources.img_raster; }
        }

        public bool PluginPage
        {
            get { return false; }
        }

        public ConfigPageType PageType
        {
            get { return ConfigPageType.LayerOpening; }
        }

        public string Description
        {
            get { return "Defines default settings for raster display and opening."; }
        }
    }
}
