using System;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Helpers;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Services.Abstract;
using MW5.UI;

namespace MW5
{
    // Lifetime should be singleton
    public class AppContext: IAppContext
    {
        private IMap _map;
        private IWin32Window _mainForm;
        private IMenu _menu;
        private IToolbarCollection _toolbars;
        private IMuteLegend _legend;
        private readonly PluginManager _manager = new PluginManager();
        private MapListener _mapListener;

        public void Init(IMainForm form)
        {
            if (form == null)
            {
                throw new NullReferenceException("Main form reference is null.");
            }

            _mainForm = form as IWin32Window;
            
            _map = form.Map;
            _map.Initialize();

            CompositionRoot.Container.RegisterInstance(typeof(IMuteMap), _map);  // it's a bit ugly; got ideas how to do it better? 

            _legend = form.Legend;

            _menu = UI.Menu.CreateInstance(form.MenuManager);
            _toolbars = ToolbarsCollection.CreateInstance(form.MenuManager);

            // TODO: convert to service
            TilesHelper.Init(_map, Menu.Tiles);

            _manager.AssemblePlugins();
            PluginMenuHelper.InitPlugins(this, _manager);

            // TODO: temporary only, use injection            
            var layerService = CompositionRoot.Container.Resolve<ILayerService>();
            _mapListener = new MapListener(_map, this, _manager.Broadcaster, layerService);
        }

        public IMuteMap Map
        {
            get { return _map; }
        }

        public IMuteLegend Legend
        {
            get { return _legend; }
        }

        public IWin32Window MainWindow
        {
            get { return _mainForm; }
        }

        public IMenu Menu
        {
            get { return _menu; }
        }

        public IToolbarCollection Toolbars
        {
            get { return _toolbars; }
        }

        public bool Initialized
        {
            get { return _map != null; }
        }
    }
}
