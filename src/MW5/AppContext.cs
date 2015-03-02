using System;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Helpers;
using MW5.Plugins.Interfaces;
using MW5.UI;

namespace MW5
{
    public class AppContext: IAppContext
    {
        private IMapControl _map;
        private IWin32Window _mainForm;
        private IMenu _menu;
        private IToolbarCollection _toolbars;
        private ILegendControl _legend;

        public void Init(IMainForm form)
        {
            if (form == null)
            {
                throw new NullReferenceException("Main form reference is null.");
            }

            _mainForm = form as IWin32Window;
            
            _map = form.Map;
            CompositionRoot.Container.RegisterInstance(typeof(IMapControl), _map);  // it's a bit ugly; got ideas how to do it better? 

            _legend = form.Legend;

            _menu = UI.Menu.CreateInstance(form.MenuManager);
            _toolbars = ToolbarsCollection.CreateInstance(form.MenuManager);

            // TODO: convert to services
            TilesHelper.Init(_map, Menu.Tiles);
            PluginHelper.InitPlugins(this);
        }

        public IMapControl Map
        {
            get { return _map; }
        }

        public ILegendControl Legend
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
