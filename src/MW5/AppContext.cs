using System;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Helpers;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Services.Services.Abstract;
using MW5.UI;
using MW5.UI.Syncfusion;
using Syncfusion.Windows.Forms;

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
        private IView _view;

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

        public ILayerCollection<ILegendLayer> Layers
        {
            get { return _legend.Layers; }
        }

        public bool Initialized
        {
            get { return _map != null; }
        }
    }
}
