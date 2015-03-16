using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Abstract;
using MW5.Configuration;
using MW5.Plugins;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Services.Config;

namespace MW5.Presenters
{
    internal class ConfigPresenter: BasePresenter<IConfigView>
    {
        private readonly IConfigView _view;
        private readonly IConfigService _configService;
        private readonly PluginManager _manager;
        private PluginProvider _pluginProvider;

        public ConfigPresenter(IConfigView view, IConfigService configService, PluginManager manager) : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (configService == null) throw new ArgumentNullException("configService");
            if (manager == null) throw new ArgumentNullException("manager");
            
            _view = view;
            _configService = configService;
            _manager = manager;

            InitPages();

            _view.Initialize();

            view.OkClicked += view_OkClicked;
        }

        private void view_OkClicked()
        {
            foreach (var p in _pluginProvider.List)
            {
                // TODO: save in in the app config
            }
        }

        private void InitPages()
        {
            _view.Pages.Add(new GeneralConfigPage(_configService));
            _pluginProvider = new PluginProvider(_configService.Config, _manager);
            _view.Pages.Add(new PluginsConfigPage(_pluginProvider));
        }
    }
}
