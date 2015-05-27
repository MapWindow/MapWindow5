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
    public partial class GeneralConfigPage : UserControl, IConfigPage
    {
        private readonly IConfigService _configService;
        private readonly IMuteMap _map;

        public GeneralConfigPage(IConfigService configService, IMuteMap map)
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
            chkLoadLastProject.Checked = config.LoadLastProject;
            chkLoadSymbology.Checked = config.LoadSymbology;
        }

        public string PageName
        {
            get { return "General"; }
        }

        public void Save()
        {
            var config = _configService.Config;
            config.LoadLastProject = chkLoadLastProject.Checked;
            config.LoadSymbology = chkLoadSymbology.Checked;

            _map.ApplyConfig(_configService);
        }

        public Bitmap Icon
        {
            get { return Resources.img_options; }
        }

        public bool PluginPage
        {
            get { return false; }
        }

        public ConfigPageType PageTypeType
        {
            get { return ConfigPageType.General; }
        }

        public string Description
        {
            get { return "Here is a description of general settings."; }
        }
    }
}
