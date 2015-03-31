using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using MW5.Api.Concrete;
using MW5.Helpers;
using MW5.Listeners;
using MW5.Menu;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;

namespace MW5.Views
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly IAppContext _context;
        private readonly IProjectService _projectService;
        private readonly IConfigService _configService;
        private readonly MenuListener _menuListener;
        private readonly MenuGenerator _menuGenerator;
        private readonly MapListener _mapListener;
        private readonly LegendListener _legendListener;
        private readonly StatusBarListener _statusBarListener;
        private readonly MenuUpdater _menuUpdater;

        public MainPresenter(IAppContext context, IMainView view, IProjectService projectService, ILoggingService loggingService, 
                            IConfigService configService)
            : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (projectService == null) throw new ArgumentNullException("projectService");
            if (loggingService == null) throw new ArgumentNullException("loggingService");
            if (configService == null) throw new ArgumentNullException("configService");

            _context = context;
            _projectService = projectService;
            _configService = configService;

            ApplicationCallback.Attach(loggingService);

            var appContext = context as AppContext;
            if (appContext == null)
            {
                throw new InvalidCastException("Invalid type of IAppContext instance");
            }
            appContext.Init(view, projectService, configService);
            view.InitDocking();                          // must be called when context is initialized

            view.Map.Initialize();
            view.ViewClosing += OnViewClosing;
            view.ViewUpdating += OnViewUpdating;

            var container = context.Container;
            _menuGenerator = container.GetSingleton<MenuGenerator>();
            _menuListener = container.GetSingleton<MenuListener>();
            _mapListener = container.GetSingleton<MapListener>();
            _legendListener = container.GetSingleton<LegendListener>();
            _statusBarListener = container.GetSingleton<StatusBarListener>();
            _menuUpdater = new MenuUpdater(_context, appContext.Map, PluginIdentity.Default);

            appContext.InitPlugins(configService);      // must be called after docking is initialized

            // for development only
            var config = _configService.Config;
            if (config.LoadLastProject && File.Exists(config.LastProjectPath))
            {
                try
                {
                    _projectService.Open(config.LastProjectPath, true);
                }
                catch (Exception ex)
                {
                    Debug.Print("Error on project loading: " + ex.Message);
                }
            }
        }

        private void OnViewUpdating(object sender, RenderedEventArgs e)
        {
            _menuUpdater.Update(e.Rendered);

            _statusBarListener.Update();

            var appContext = _context as AppContext;
            if (appContext != null)
            {
                appContext.Broadcaster.BroadcastEvent(p => p.ViewUpdating_, sender, e);
            }
        }

        private void OnViewClosing(object sender, CancelEventArgs e)
        {
            _configService.Config.LastProjectPath = _projectService.Filename;
            _configService.Save();

            if (!_projectService.TryClose())
            {
                e.Cancel = true;
            }
        }

        public override bool ViewOkClicked()
        {
            return true;    // there is no ok button
        }
    }
}
