using System;
using System.Windows.Forms;
using MW5.Api.Interfaces;
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

        public void Init(IMainForm form)
        {
            _mainForm = form as IWin32Window;
            _map = form.Map;
            _menu = UI.Menu.CreateInstance(form.MenuManager);
            _toolbars = ToolbarsCollection.CreateInstance(form.MenuManager);
            TilesHelper.Init(Menu.Tiles);
            PluginHelper.InitPlugins(this);
        }

        public IMapControl Map
        {
            get { return _map; }
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
