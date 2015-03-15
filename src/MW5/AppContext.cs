using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
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
using MW5.UI;
using MW5.UI.Syncfusion;
using Syncfusion.Windows.Forms;

namespace MW5
{
    /// <summary>
    /// Central class storing all the resource avaialable for plugins.
    /// </summary>
    public class AppContext: ISerializableContext
    {
        private IMap _map;
        private IMenu _menu;
        private IAppView _view;
        private IMainView _mainView;
        private IProjectService _project;
        private IMuteLegend _legend;
        private IToolbarCollection _toolbars;
        private PluginManager _pluginManager;
        private IStatusBar _statusBar;

        /// <summary>
        /// Sets all the necessary references from the main view. 
        /// </summary>
        /// <remarks>We don't use contructor injection here since most of other services use this one as a parameter.
        /// Perhaps property injection can be used.</remarks>
        internal void Init(IMainView mainView, IProjectService project)
        {
            if (mainView == null) throw new ArgumentNullException("mainView");
            if (project == null) throw new ArgumentNullException("project");

            _pluginManager = PluginManager.Instance;

            _mainView = mainView;
            _view = new AppView(mainView);
            _project = project;
            _map = mainView.Map;
            _legend = mainView.Legend;

            _menu = MenuFactory.CreateInstance(mainView.MenuManager);
            _toolbars = ToolbarsCollection.CreateInstance(mainView.MenuManager);
            _statusBar = new UI.StatusBar(mainView.StatusBar);
        }

        public IApplicationContainer Container
        {
            get { return CompositionRoot.Container; }
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

        public LegendLayerCollection<ILayer> Layers
        {
            get { return _map.Layers; }
        }

        public PluginManager PluginManager
        {
            get { return _pluginManager; }
        }

        public void Close()
        {
            // TODO: save application settings
            // TODO: save toolbar positions
            _mainView.Close();
        }
    }
}
