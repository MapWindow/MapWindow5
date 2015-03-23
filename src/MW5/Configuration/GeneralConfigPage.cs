using System;
using System.Windows.Forms;
using MW5.Plugins.Services;
using MW5.Services.Config;

namespace MW5.Configuration
{
    public partial class GeneralConfigPage : UserControl, IConfigPage
    {
        private readonly IConfigService _configService;

        public GeneralConfigPage(IConfigService configService)
        {
            if (configService == null) throw new ArgumentNullException("configService");
            _configService = configService;
            
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
        }
    }
}
