using System;
using System.Diagnostics;
using System.Windows.Forms;
using MW5.Configuration;
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
    internal class ConfigPresenter: BasePresenter<IConfigView, ConfigViewModel>
    {
        private readonly IConfigService _configService;
        private readonly IStyleService _styleService;

        public ConfigPresenter( IConfigView view, IConfigService configService, IStyleService styleService)
            : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (configService == null) throw new ArgumentNullException("configService");
            if (styleService == null) throw new ArgumentNullException("styleService");

            _configService = configService;
            _styleService = styleService;

            view.OpenFolderClicked += OnOpenFolderClicked;
            view.SaveClicked += OnSaveClicked;
            view.PageShown += OnPageShown;
        }

        private void OnPageShown()
        {
            _styleService.ApplyStyle(View as Form);
        }

        private void OnSaveClicked()
        {
            ApplySettings();
            bool result = _configService.Save();
            if (result)
            {
                MessageService.Current.Info("Configuration was saved successfully.");
            }
        }

        private void OnOpenFolderClicked()
        {
            string path = _configService.ConfigPath;
            PathHelper.OpenFolderWithExplorer(path);
        }

        private void ApplySettings()
        {
            foreach (var page in Model.Pages)
            {
                page.Save();
            }
        }

        public override bool ViewOkClicked()
        {
            ApplySettings();
            _configService.Save();
            return true;
        }
    }
}
