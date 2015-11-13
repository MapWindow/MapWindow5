using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Configuration;
using MW5.Helpers;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Services.Helpers;
using MW5.Shared;
using MW5.UI.Helpers;
using MW5.UI.Style;
using MW5.Views.Abstract;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.Views
{
    internal class ConfigPresenter: ComplexPresenter<IConfigView, ConfigCommand, ConfigViewModel>
    {
        private readonly IAppContext _context;
        private readonly IConfigService _configService;
        private readonly IStyleService _styleService;
        private readonly IPluginManager _pluginManger;
        private readonly IMuteMap _map;

        public ConfigPresenter( IAppContext context, IConfigView view, IConfigService configService, 
        IStyleService styleService, IPluginManager pluginManger, IMuteMap map)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (view == null) throw new ArgumentNullException("view");
            if (configService == null) throw new ArgumentNullException("configService");
            if (styleService == null) throw new ArgumentNullException("styleService");
            if (pluginManger == null) throw new ArgumentNullException("pluginManger");
            if (map == null) throw new ArgumentNullException("map");

            _context = context;
            _configService = configService;
            _styleService = styleService;
            _pluginManger = pluginManger;
            _map = map;

            view.PageShown += OnPageShown;
        }

        public override void RunCommand(ConfigCommand command)
        {
            switch (command)
            {
                case ConfigCommand.RestoreToolbars:
                    if (MessageService.Current.Ask("Do you want to restore default location of toolbars?"))
                    {
                        var view = _context.Container.Resolve<IMainView>();
                        var manager = view.MenuManager as MainFrameBarManager;
                        if (manager != null)
                        {
                            manager.RestoreLayout(MainView.SerializationKey, true);
                        }
                    }
                    break;
                case ConfigCommand.RestorePlugins:
                    RestorePlugins();
                    break;
                case ConfigCommand.Save:
                    ApplySettings();

                    bool result = _configService.Save();
                    if (result)
                    {
                        MessageService.Current.Info("Configuration was saved successfully.");
                    }
                    break;
                case ConfigCommand.SetDefaults:
                    if (MessageService.Current.Ask("Do you want to reset default value of all settings?"))
                    {
                        _configService.Config.SetDefaults();
                        foreach (var page in Model.Pages)
                        {
                            page.Initialize();
                        }
                    }

                    ApplySettings();

                    break;
                case ConfigCommand.OpenFolder:
                    string path = _configService.ConfigPath;
                    PathHelper.OpenFolderWithExplorer(path);
                    break;
            }
        }

        private void RestorePlugins()
        {
            if (!MessageService.Current.Ask("Do you want to restore default set of plugins and location of their panels?"))
            {
                return;
            }

            try
            {
                var guids = AppConfig.Instance.DefaultApplicationPlugins;
                _pluginManger.RestoreApplicationPlugins(guids, _context);
                Model.ReloadPage(ConfigPageType.Plugins);

                // restoring layout
                var view = _context.Container.Resolve<IMainView>();
                var manager = view.DockingManager as DockingManager;
                manager.RestoreLayout(MainView.SerializationKey, true);
            }
            catch (Exception ex)
            {
                Logger.Current.Error("Failed to restore dock panel layout.", ex);
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
