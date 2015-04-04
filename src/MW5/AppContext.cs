using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Controls;
using MW5.Helpers;
using MW5.Menu;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Projections.BL;
using MW5.Services;
using MW5.Services.Serialization;
using MW5.UI;
using MW5.UI.Docking;
using MW5.UI.Menu;
using MW5.UI.Syncfusion;
using Syncfusion.Windows.Forms;

namespace MW5
{
    /// <summary>
    /// Central class storing all the resource avaialable for plugins.
    /// </summary>
    public class AppContext: ISerializableContext
    {
        private readonly IApplicationContainer _container;
        private readonly IProjectionDatabase _projectionDatabase;
        private readonly IStyleService _styleService;
        private IMap _map;
        private IMenu _menu;
        private IAppView _view;
        private IMainView _mainView;
        private IProjectService _project;
        private IMuteLegend _legend;
        private IToolbarCollection _toolbars;
        private IPluginManager _pluginManager;
        private IBroadcasterService _broadcaster;
        private IStatusBar _statusBar;
        private IDockPanelCollection _dockPanelCollection;
        private IConfigService _configService;
        private LocatorPresenter _locator;
        
        public AppContext(IApplicationContainer container, IProjectionDatabase projectionDatabase, IStyleService styleService)
        {
            if (container == null) throw new ArgumentNullException("container");
            if (styleService == null) throw new ArgumentNullException("styleService");
            _container = container;
            _projectionDatabase = projectionDatabase;
            _styleService = styleService;
        }

        /// <summary>
        /// Sets all the necessary references from the main view. 
        /// </summary>
        /// <remarks>We don't use contructor injection here since most of other services use this one as a parameter.
        /// Perhaps property injection can be used.</remarks>
        internal void Init(IMainView mainView, IProjectService project, IConfigService configService)
        {
            if (mainView == null) throw new ArgumentNullException("mainView");
            if (project == null) throw new ArgumentNullException("project");

            _pluginManager = _container.GetSingleton<IPluginManager>();
            _broadcaster = _container.GetSingleton<IBroadcasterService>();
            _container.RegisterInstance<IMuteMap>(mainView.Map);

            _mainView = mainView;
            _view = new AppView(mainView, _styleService);
            _project = project;
            _map = mainView.Map;
            _legend = mainView.Legend;
            _configService = configService;
            _legend.Lock();

            _dockPanelCollection = new DockPanelCollection(mainView.DockingManager, mainView as Form, _broadcaster);
            _menu = MenuFactory.CreateInstance(mainView.MenuManager);
            _toolbars = MenuFactory.CreateToolbars(mainView.MenuManager);
            _statusBar = MenuFactory.CreateStatusBar(mainView.StatusBar, PluginIdentity.Default);

            _projectionDatabase.ReadFromExecutablePath(Application.ExecutablePath);

            _locator = new LocatorPresenter(_map);

            this.InitDocking();
        }

        internal void InitPlugins(IConfigService configService)
        {
            var pluginManager = PluginManager;
            pluginManager.PluginUnloaded += ManagerPluginUnloaded;
            pluginManager.AssemblePlugins();

            if (configService.ApplicationPlugins != null)
            {
                var dict = configService.ApplicationPlugins.ToDictionary(p => p, p => p);
                foreach (var p in pluginManager.AllPlugins)
                {
                    bool active = dict.ContainsKey(p.Identity.Guid);
                    p.SetApplicationPlugin(active);
                    if (active)
                    {
                        pluginManager.LoadPlugin(p.Identity, this);
                    }
                }
            }
        }

        private void ManagerPluginUnloaded(object sender, PluginEventArgs e)
        {
            Toolbars.RemoveItemsForPlugin(e.Identity);
            Menu.RemoveItemsForPlugin(e.Identity);
            DockPanels.RemoveItemsForPlugin(e.Identity);
        }

        public IApplicationContainer Container
        {
            get { return _container; }
        }

        public IProject Project
        {
            get { return _project as IProject; }
        }
        
        public IAppView View
        {
            get { return _view; }
        }

        public IMuteMap Map
        {
            get { return _map; }
        }

        public IMuteLegend Legend
        {
            get { return _legend; }
        }

        public IStatusBar StatusBar
        {
            get { return _statusBar; }
        }

        public IMenu Menu
        {
            get { return _menu; }
        }

        public IToolbarCollection Toolbars
        {
            get { return _toolbars; }
        }

        public ILegendLayerCollection<ILayer> Layers
        {
            get { return _map.Layers; }
        }

        public IDockPanelCollection DockPanels
        {
            get { return _dockPanelCollection; }
        }

        public IProjectionDatabase Projections
        {
            get { return _projectionDatabase; }
        }

        public AppConfig Config
        {
            get { return _configService.Config; }
        }

        public void SetMapProjection(ISpatialReference projection)
        {
            this.SetProjection(projection);
        }

        public ILocator Locator
        {
            get { return _locator; }
        }

        public IPluginManager PluginManager
        {
            get { return _pluginManager; }
        }

        public IBroadcasterService Broadcaster
        {
            get { return _broadcaster; }
        }

        public void Close()
        {
            // TODO: save application settings
            // TODO: save toolbar positions
            _mainView.Close();
        }


    }
}
