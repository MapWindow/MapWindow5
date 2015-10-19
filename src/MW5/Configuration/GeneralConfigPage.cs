using System;
using System.Drawing;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Helpers;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Properties;
using MW5.Services.Config;
using MW5.UI.Helpers;

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

            InitControls();

            Initialize();
        }

        private void InitControls()
        {
            cboSymbologyStorage.AddItemsFromEnum<SymbologyStorage>();
        }

        public void Initialize()
        {
            var config = _configService.Config;
            chkLoadLastProject.Checked = config.LoadLastProject;
            chkLoadSymbology.Checked = config.LoadSymbology;
            chkShowWelcomeDialog.Checked = config.ShowWelcomeDialog;
            cboSymbologyStorage.SetValue(config.SymbolobyStorage);
            chkShowPluginInToolTip.Checked = config.ShowPluginInToolTip;
            chkShowMenuToolTips.Checked = config.ShowMenuToolTips;
            chkDynamicVisibilityWarnings.Checked = config.DisplayDynamicVisibilityWarnings;
            chkLocalDocumentation.Checked = config.LocalDocumentation;
            chkNewVersion.Checked = config.UpdaterCheckNewVersion;
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
            config.ShowWelcomeDialog = chkShowWelcomeDialog.Checked;
            config.ShowPluginInToolTip = chkShowPluginInToolTip.Checked;
            config.ShowMenuToolTips = chkShowMenuToolTips.Checked;
            config.DisplayDynamicVisibilityWarnings = chkDynamicVisibilityWarnings.Checked;
            config.SymbolobyStorage = cboSymbologyStorage.GetValue<SymbologyStorage>();
            config.LocalDocumentation = chkLocalDocumentation.Checked;
            config.UpdaterCheckNewVersion = chkNewVersion.Checked;
        }

        public Bitmap Icon
        {
            get { return Resources.img_options; }
        }

        public bool PluginPage
        {
            get { return false; }
        }

        public ConfigPageType PageType
        {
            get { return ConfigPageType.General; }
        }

        public string Description
        {
            get { return "Here is a description of general settings."; }
        }

        public bool VariableHeight
        {
            get { return false; }
        }
    }
}
