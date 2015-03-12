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
    // must be a singleton
    public class AppContext: ISerializableContext
    {
        private IMap _map;
        private IWin32Window _mainForm;
        private IMenu _menu;
        private IToolbarCollection _toolbars;
        private IMuteLegend _legend;
        private readonly PluginManager _pluginManager;
        private MapListener _mapListener;
        private IView _view;

        private static AppContext _instance;

        public static AppContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new ApplicationException("Application context isn't yet initialized");
                }
                return _instance;
            }
        }

        public AppContext()
        {
            _pluginManager = PluginManager.Instance;
            _instance = this;
        }

        public void Init(IMainForm form)
        {
            if (form == null)
            {
                throw new NullReferenceException("Main form reference is null.");
            }

            _mainForm = form as IWin32Window;
            _view = form.View;

            _map = form.Map;
            _map.Initialize();

            CompositionRoot.Container.RegisterInstance(typeof(IWin32Window), form);
            CompositionRoot.Container.RegisterInstance(typeof(IMuteMap), _map);  // it's a bit ugly; got ideas how to do it better?

            _legend = form.Legend;

            _menu = MenuFactory.CreateInstance(form.MenuManager);
            _toolbars = ToolbarsCollection.CreateInstance(form.MenuManager);

            _pluginManager.PluginUnloaded += ManagerPluginUnloaded;
            _pluginManager.AssemblePlugins();

            var menus = new MenuGenerator(this, _pluginManager, form.MenuManager, form.DockingManager);
            menus.Init();

            _mapListener = new MapListener(this, _pluginManager.Broadcaster, CompositionRoot.Container.Resolve<ILayerService>());
        }

        private void ManagerPluginUnloaded(object sender, PluginEventArgs e)
        {
            Toolbars.RemoveItemsForPlugin(e.Identity);
            Menu.RemoveItemsForPlugin(e.Identity);
        }

        public IApplicationContainer Container
        {
            get { return CompositionRoot.Container; }
        }

        public DialogResult ShowDialog(Form form)
        {
            if (form == null)
            {
                throw new ArgumentNullException("form");
            }
            
            if (form is MetroForm)
            {
                // TODO: use injection
                var service = new SyncfusionStyleService(ControlStyleSettings.Instance);
                service.ApplyStyle(form as MetroForm);
            }

            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.StartPosition = FormStartPosition.CenterScreen;        // TODO: make parameter
            return form.ShowDialog(_mainForm);
        }

        public IView View
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

        public bool Initialized
        {
            get { return _map != null; }
        }

        public PluginManager PluginManager
        {
            get { return _pluginManager; }
        }
    }
}
