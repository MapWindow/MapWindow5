using System;
using System.Diagnostics;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Helpers;
using MW5.Menu;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Services;
using MW5.Services.Serialization;
using MW5.Services.Services.Abstract;

namespace MW5.Presenters
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly IAppContext _context;
        private readonly MenuListener _menuListener;
        private readonly MenuGenerator _menuGenerator;
        private readonly MapListener _mapListener;

        public MainPresenter(IAppContext context, IMainView view, IProjectService projectService)
            : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");
            
            _context = context;

            view.Map.Initialize();

            CompositionRoot.Container.RegisterInstance(typeof(IMuteMap), view.Map);

            var appContext = context as AppContext;
            if (appContext == null)
            {
                throw new InvalidCastException("Invalid type of IAppContext instance");
            }
            appContext.Init(view, projectService as IProject);

            var pluginManager = appContext.PluginManager;
            pluginManager.PluginUnloaded += ManagerPluginUnloaded;
            pluginManager.AssemblePlugins();
            
            _menuGenerator = new MenuGenerator(_context, pluginManager, view.MenuManager, view.DockingManager);
            _menuListener = context.Container.GetSingleton<MW5.Menu.MenuListener>();
            _mapListener = new MapListener(_context, pluginManager.Broadcaster, CompositionRoot.Container.Resolve<ILayerService>());
        }

        private void ManagerPluginUnloaded(object sender, PluginEventArgs e)
        {
            _context.Toolbars.RemoveItemsForPlugin(e.Identity);
            _context.Menu.RemoveItemsForPlugin(e.Identity);
        }
    }
}
