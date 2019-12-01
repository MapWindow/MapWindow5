// -------------------------------------------------------------------------------------------
// <copyright file="AppContext.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Controls;
using MW5.Helpers;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Projections.Helpers;
using MW5.Services.Serialization;
using MW5.Shared;
using MW5.Tools.Toolbox;
using MW5.UI.Docking;
using MW5.UI.Forms;
using MW5.UI.Menu;
using MW5.UI.Style;

namespace MW5
{
    /// <summary>
    /// Central class storing all the resource avaialable for plugins.
    /// </summary>
    public class AppContext : ISecureContext
    {
        private readonly IApplicationContainer _container;
        private readonly IProjectionDatabase _projectionDatabase;
        private readonly IStyleService _styleService;
        private readonly ITaskCollection _tasks;
        private IConfigService _configService;

        private LegendPresenter _legendPresenter;
        private LocatorPresenter _locator;
        private IMainView _mainView;

        private IMap _map;
        private IProjectService _project;
        private ToolboxPresenter _toolboxPresenter;

        public AppContext(
            IApplicationContainer container,
            IProjectionDatabase projectionDatabase,
            IStyleService styleService,
            ITaskCollection tasks)
        {
            Logger.Current.Trace("In AppContext");
            if (container == null) throw new ArgumentNullException("container");
            if (styleService == null) throw new ArgumentNullException("styleService");
            if (tasks == null) throw new ArgumentNullException("tasks");

            _container = container;
            _projectionDatabase = projectionDatabase;
            _styleService = styleService;
            _tasks = tasks;
        }

        public IBroadcasterService Broadcaster { get; private set; }

        public IApplicationContainer Container
        {
            get { return _container; }
        }

        public IProject Project
        {
            get { return _project as IProject; }
        }

        public IAppView View { get; private set; }

        public IMuteMap Map
        {
            get { return _map; }
        }

        public IMuteLegend Legend
        {
            get { return _legendPresenter.Legend; }
        }

        public IStatusBar StatusBar { get; private set; }

        public IMenu Menu { get; private set; }

        public IToolbarCollection Toolbars { get; private set; }

        public ILayerCollection<ILayer> Layers
        {
            get { return _map.Layers; }
        }

        public IDockPanelCollection DockPanels { get; private set; }

        public IProjectionDatabase Projections
        {
            get { return _projectionDatabase; }
        }

        public AppConfig Config
        {
            get { return _configService.Config; }
        }

        public ITaskCollection Tasks
        {
            get { return _tasks; }
        }

        public IRepository Repository { get; private set; }

        public SynchronizationContext SynchronizationContext { get; private set; }

        public void SetMapProjection(ISpatialReference projection)
        {
            this.SetProjection(projection);
            Map.Redraw();
            View.Update();
        }

        public bool Initialized { get; private set; }

        public ILocator Locator
        {
            get { return _locator; }
        }

        public IToolbox Toolbox
        {
            get { return _toolboxPresenter.View; }
        }

        public IPluginManager PluginManager { get; private set; }

        public Control GetDockPanelObject(DefaultDockPanel panel)
        {
            switch (panel)
            {
                case DefaultDockPanel.Legend:
                    return _legendPresenter.Legend as Control;
                case DefaultDockPanel.Toolbox:
                    return _toolboxPresenter.View;
                case DefaultDockPanel.Locator:
                    return _locator != null ? _locator.GetInternalObject() : null;
                default:
                    throw new ArgumentOutOfRangeException("panel");
            }
        }

        public void Close()
        {
            _mainView.Close();
        }

        /// <summary>
        /// Sets all the necessary references from the main view. 
        /// </summary>
        /// <remarks>We don't use contructor injection here since most of other services use this one as a parameter.
        /// Perhaps property injection can be used.</remarks>
        internal void Init(
            IMainView mainView,
            IProjectService project,
            IConfigService configService,
            LegendPresenter legendPresenter,
            ToolboxPresenter toolboxPresenter,
            IRepository repository)
        {
            Logger.Current.Trace("Start AppContext.Init()");
            if (mainView == null) throw new ArgumentNullException("mainView");
            if (project == null) throw new ArgumentNullException("project");
            if (legendPresenter == null) throw new ArgumentNullException("legendPresenter");
            if (toolboxPresenter == null) throw new ArgumentNullException("toolboxPresenter");

            _toolboxPresenter = toolboxPresenter;
            _legendPresenter = legendPresenter;
            var legend = _legendPresenter.Legend;
            mainView.Map.Legend = legend;
            legend.Map = mainView.Map;

            // it's expected here that we are on the UI thread
            SynchronizationContext = SynchronizationContext.Current;

            PluginManager = _container.GetSingleton<IPluginManager>();
            Broadcaster = _container.GetSingleton<IBroadcasterService>();
            _container.RegisterInstance<IMuteMap>(mainView.Map);

            _mainView = mainView;
            View = new AppView(mainView, _styleService);
            _project = project;
            _map = mainView.Map;
            _configService = configService;
            Repository = repository;

            Legend.Lock();

            DockPanels = new DockPanelCollection(mainView.DockingManager, mainView as Form, Broadcaster, _styleService);
            Menu = MenuFactory.CreateMainMenu(mainView.MenuManager);
            Toolbars = MenuFactory.CreateMainToolbars(mainView.MenuManager);
            StatusBar = MenuFactory.CreateStatusBar(mainView.StatusBar, PluginIdentity.Default);

            _projectionDatabase.ReadFromExecutablePath(Application.ExecutablePath);

            Repository.Initialize(this);

            // comment this line to prevent locator loading            
            // may be useful for ocx debugging to not create additional 
            // instance of map
            _locator = new LocatorPresenter(_map);

            this.InitDocking();

            Initialized = true;
            Logger.Current.Trace("End AppContext.Init()");
        }

        internal void InitPlugins(IConfigService configService, Action<PluginIdentity> pluginLoadingCallback)
        {
            var pluginManager = PluginManager;
            pluginManager.PluginUnloaded += ManagerPluginUnloaded;
            pluginManager.AssemblePlugins();

            var guids = configService.Config.ApplicationPlugins;
            if (guids != null)
            {
                PluginManager.RestoreApplicationPlugins(guids, this, pluginLoadingCallback);
            }
        }

        private void ManagerPluginUnloaded(object sender, PluginEventArgs e)
        {
            Toolbars.RemoveItemsForPlugin(e.Identity);
            Menu.RemoveItemsForPlugin(e.Identity);
            DockPanels.RemoveItemsForPlugin(e.Identity);
            Toolbox.RemoveItemsForPlugin(e.Identity);
            StatusBar.RemoveItemsForPlugin(e.Identity);
        }
    }
}