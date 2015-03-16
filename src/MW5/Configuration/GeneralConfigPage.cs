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
        }

        public string PageName
        {
            get { return "General"; }
        }
    }
}
