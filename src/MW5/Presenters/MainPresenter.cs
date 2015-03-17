using System;
using System.ComponentModel;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Helpers;
using MW5.Listeners;
using MW5.Menu;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;

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
        private readonly LegendListener _legendListener;
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

            var pluginManager = appContext.PluginManager;
            pluginManager.PluginUnloaded += ManagerPluginUnloaded;
            pluginManager.AssemblePlugins();

            var container = context.Container;
            
            _menuGenerator = container.GetSingleton<MenuGenerator>();
            _menuListener = container.GetSingleton<MenuListener>();
            _mapListener = container.GetSingleton<MapListener>();
            _legendListener = container.GetSingleton<LegendListener>(); 
        }

        private void OnViewUpdating(object sender, EventArgs e)
        {
            var appContext = _context as AppContext;
            if (appContext != null)
            {
                appContext.Broadcaster.BroadcastEvent(p => p.ViewUpdating_, sender, e);
            }
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
            _context.DockPanels.RemoveItemsForPlugin(e.Identity);
        }
    }
}
