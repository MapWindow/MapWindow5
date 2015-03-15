using System;
using System.ComponentModel;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Helpers;
using MW5.Menu;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Services.Services.Abstract;

namespace MW5.Presenters
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly IAppContext _context;
        private readonly IProjectService _projectService;
        private readonly ILoggingService _loggingService;
        private readonly MenuListener _menuListener;
        private readonly MenuGenerator _menuGenerator;
        private readonly MapListener _mapListener;
        private PluginManager _pluginManager;

        public MainPresenter(IAppContext context, IMainView view, IProjectService projectService, ILoggingService loggingService)
            : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (projectService == null) throw new ArgumentNullException("projectService");
            if (loggingService == null) throw new ArgumentNullException("loggingService");

            _context = context;
            _projectService = projectService;
            _loggingService = loggingService;

            ApplicationCallback.Attach(_loggingService);

            var appContext = context as AppContext;
            if (appContext == null)
            {
                throw new InvalidCastException("Invalid type of IAppContext instance");
            }
            appContext.Init(view, projectService);

            view.Map.Initialize();
            view.ViewClosing += OnViewClosing;
            view.ViewUpdating += OnViewUpdating;

            _pluginManager = appContext.PluginManager;
            _pluginManager.PluginUnloaded += ManagerPluginUnloaded;
            _pluginManager.AssemblePlugins();

            _context.Container.RegisterInstance<IMuteMap>(view.Map);
            _context.Container.RegisterInstance<PluginBroadcaster>(_pluginManager.Broadcaster);

            _menuGenerator = new MenuGenerator(_context, _pluginManager, view.MenuManager, view.DockingManager);
            _menuListener = context.Container.GetSingleton<MenuListener>();
            _mapListener = context.Container.GetSingleton<MapListener>(); 
        }

        private void OnViewUpdating(object sender, EventArgs e)
        {
            _pluginManager.Broadcaster.BroadcastEvent(p => p.ViewUpdating_, sender, e);
        }

        private void OnViewClosing(object sender, CancelEventArgs e)
        {
            if (!_projectService.TryClose())
            {
                e.Cancel = true;
            }
        }

        private void ManagerPluginUnloaded(object sender, PluginEventArgs e)
        {
            _context.Toolbars.RemoveItemsForPlugin(e.Identity);
            _context.Menu.RemoveItemsForPlugin(e.Identity);
        }
    }
}
