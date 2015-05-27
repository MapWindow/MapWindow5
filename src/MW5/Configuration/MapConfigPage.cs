using System;
using System.Drawing;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Helpers;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Properties;
using MW5.Services.Config;

namespace MW5.Configuration
{
    public partial class MapConfigPage : UserControl, IConfigPage
    {
        private readonly IConfigService _configService;
        private readonly IMuteMap _map;

        public MapConfigPage(IConfigService configService, IMuteMap map)
        {
            if (configService == null) throw new ArgumentNullException("configService");
            if (map == null) throw new ArgumentNullException("map");

            _configService = configService;
            _map = map;

            InitializeComponent();

            Init();
        }

        private void Init()
        {
            var config = _configService.Config;
            chkShowRedrawTime.Checked = config.ShowRedrawTime;
        }

        public string PageName
        {
            get { return "Map"; }
        }

        public void Save()
        {
            var config = _configService.Config;
            config.ShowRedrawTime = chkShowRedrawTime.Checked;

            _map.ApplyConfig(_configService);
        }

        public Bitmap Icon
        {
            get { return Resources.img_globe32; }
        }

        public bool PluginPage
        {
            get { return false; }
        }

        public ConfigPageType PageTypeType
        {
            get { return ConfigPageType.Map; }
        }

        public string Description
        {
            get { return "Here is a description of map settings."; }
        }
    }
}
