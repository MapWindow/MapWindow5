using System;
using System.Diagnostics;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Configuration;
using MW5.Helpers;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Services.Helpers;
using MW5.Shared;
using MW5.UI.Style;
using MW5.Views.Abstract;

namespace MW5.Views
{
    internal class ConfigPresenter: ComplexPresenter<IConfigView, ConfigCommand, ConfigViewModel>
    {
        private readonly IConfigService _configService;
        private readonly IStyleService _styleService;
        private readonly IMuteMap _map;

        public ConfigPresenter( IConfigView view, IConfigService configService, IStyleService styleService, IMuteMap map)
            : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (configService == null) throw new ArgumentNullException("configService");
            if (styleService == null) throw new ArgumentNullException("styleService");
            if (map == null) throw new ArgumentNullException("map");

            _configService = configService;
            _styleService = styleService;
            _map = map;

            view.PageShown += OnPageShown;
        }

        public override void Initialize()
        {
            
        }

        public override void RunCommand(ConfigCommand command)
        {
            switch (command)
            {
                case ConfigCommand.Save:
                    ApplySettings();

                    bool result = _configService.Save();
                    if (result)
                    {
                        MessageService.Current.Info("Configuration was saved successfully.");
                    }
                    break;
                case ConfigCommand.SetDefaults:
                    if (MessageService.Current.Ask("Do you want to reset default value for all settings?"))
                    {
                        _configService.Config.SetDefaults();
                        foreach (var page in Model.Pages)
                        {
                            page.Initialize();
                        }
                    }
                    break;
                case ConfigCommand.OpenFolder:
                    string path = _configService.ConfigPath;
                    PathHelper.OpenFolderWithExplorer(path);
                    break;
            }
        }

        private void OnPageShown()
        {
            _styleService.ApplyStyle(View as Form);
        }

        private void ApplySettings()
        {
            foreach (var page in Model.Pages)
            {
                page.Save();
            }

            _map.ApplyConfig(_configService);
        }

        public override bool ViewOkClicked()
        {
            ApplySettings();
            _configService.Save();
            return true;
        }
    }
}
