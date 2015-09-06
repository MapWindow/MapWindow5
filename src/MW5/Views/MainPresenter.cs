using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using MW5.Api.Concrete;
using MW5.Controls;
using MW5.Helpers;
using MW5.Listeners;
using MW5.Menu;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Shared.Log;
using MW5.Tools.Toolbox;
using MW5.UI.Style;

namespace MW5.Views
{
    /// <summary>
    /// Manages the startup of the application and interaction with main view.
    /// </summary>
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly IAppContext _context;
        private readonly IProjectService _projectService;
        private readonly IConfigService _configService;
        private readonly MenuListener _menuListener;
        private readonly MenuGenerator _menuGenerator;
        private readonly MapListener _mapListener;
        private readonly LegendListener _legendListener;
        private readonly MainPluginListener _mainPluginListener;
        private readonly StatusBarListener _statusBarListener;
        private readonly MenuUpdater _menuUpdater;

        public MainPresenter(IAppContext context, IMainView view, IProjectService projectService,
                             IConfigService configService, LegendPresenter legendPresenter, 
                             ToolboxPresenter toolboxPresenter, IRepository repository)
            : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (projectService == null) throw new ArgumentNullException("projectService");
            if (configService == null) throw new ArgumentNullException("configService");
            if (repository == null) throw new ArgumentNullException("repository");

            _context = context;
            _projectService = projectService;
            _configService = configService;

            ApplicationCallback.Attach(Logger.Current);

            view.Map.Lock();
            try
            {
                var appContext = context as AppContext;
                if (appContext == null)
                {
                    throw new InvalidCastException("Invalid type of IAppContext instance");
                }

                appContext.Init(view, projectService, configService, legendPresenter, toolboxPresenter, repository);
                
                view.Map.Initialize();
                view.Map.ApplyConfig(configService);

                view.ViewClosing += OnViewClosing;
                view.ViewUpdating += OnViewUpdating;
                view.BeforeShow += OnBeforeShow;

                var container = context.Container;
                _statusBarListener = container.GetSingleton<StatusBarListener>();
                _menuGenerator = container.GetSingleton<MenuGenerator>();
                _menuListener = container.GetSingleton<MenuListener>();
                _mapListener = container.GetSingleton<MapListener>();
                _mainPluginListener = container.GetSingleton<MainPluginListener>();
                _legendListener = container.GetSingleton<LegendListener>();
                
                _menuUpdater = new MenuUpdater(_context, PluginIdentity.Default);

                SplashView.Instance.ShowStatus("Loading plugins");
                appContext.InitPlugins(configService); // must be called after docking is initialized

                // this will display progress updates and debug window
                // file based-logger is already working
                Logger.Current.Init(appContext);       
            }
            finally
            {
                view.Map.Unlock();
                context.Legend.Unlock();
            }
        }

        private void OnBeforeShow()
        {
            LoadLastProject();

            if (AppConfig.Instance.ShowWelcomeDialog)
            {
                _menuListener.RunCommand(MenuKeys.Welcome);
            }
        }

        private void LoadLastProject()
        {
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
                    Logger.Current.Warn("Error on project loading: <{0}>", ex, config.LastProjectPath);
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

            if (_context.Tasks.Any(t => !t.IsFinished))
            {
                if (MessageService.Current.Ask("There are unfinished tasks still running. Close anyway?"))
                {
                    _context.Tasks.CancelAll();

                    // TODO: think of the cleaner way to close it
                    // All tasks are run by background threads so they won't obstruct the closing.
                    // However if the task is within unmanaged code or rarely checks the cancellation token, 
                    // it won't be cancelled, which may lead to undefined behavior.
                    // Possible solution may include:
                    // - waiting for cancelled notification (which may take long time);
                    // - calling Thread.Abort (which is generally not recommended);
                    // - probably the best choice is to make sure that all tasks check
                    // cancellation often enough and wait for explicit notifications from them.

                    // at least give them some time to finish, which will work for significant part of them
                    Thread.Sleep(1000);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        public override bool ViewOkClicked()
        {
            return true;    // there is no ok button
        }
    }
}
