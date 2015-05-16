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
    internal class ConfigPresenter: BasePresenter<IConfigView>
    {
        private readonly IAppContext _context;
        private readonly IConfigView _view;
        private readonly IConfigService _configService;
        private readonly IPluginManager _manager;
        private readonly IStyleService _styleService;

        public ConfigPresenter(IAppContext context, IConfigView view, IConfigService configService, IPluginManager manager,
                                IStyleService styleService)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (view == null) throw new ArgumentNullException("view");
            if (configService == null) throw new ArgumentNullException("configService");
            if (manager == null) throw new ArgumentNullException("manager");
            if (styleService == null) throw new ArgumentNullException("styleService");

            _context = context;
            _view = view;
            _configService = configService;
            _manager = manager;
            _styleService = styleService;

            InitPages();

            _view.Initialize();

            view.OpenFolderClicked += view_OpenFolderClicked;
            view.SaveClicked += view_SaveClicked;
        }

        private void view_SaveClicked()
        {
            ApplySettings();
            bool result = _configService.Save();
            if (result)
            {
                MessageService.Current.Info("Configuration was saved successfully.");
            }
        }

        private void view_OpenFolderClicked()
        {
            string path = _configService.ConfigPath;
            PathHelper.OpenFolderWithExplorer(path);
        }

        private void ApplySettings()
        {
            foreach (var page in _view.Pages)
            {
                page.Save();
            }
        }

        private void InitPages()
        {
            _view.Pages.Add(new GeneralConfigPage(_configService, _context.Map));
            _view.Pages.Add(new PluginsConfigPage(_manager, _context));

            foreach (var page in _view.Pages)
            {
                _styleService.ApplyStyle(page as Control);
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
