using System;
using MW5.Api.Interfaces;
using MW5.Helpers;
using MW5.Plugins.Interfaces;
using MW5.UI;

namespace MW5
{
    public class AppContext: IAppContext
    {
        private readonly IMainForm _mainForm;
        private Menu _menu;

        public static AppContext _instance;

        internal static void Init(IMainForm form)
        {
            var context = new AppContext(form);
            _instance = context;
            PluginHelper.InitPlugins(_instance);
        }

        public static IAppContext Instance
        {
            get
            {
                if (_instance == null || !_instance.Initialized)
                {
                    throw new ApplicationException("Application context is not initialized");
                }
                return _instance;
            }
        }

        private AppContext(IMainForm form)
        {
            _mainForm = form;
            _menu = new Menu(form.MenuManager);
        }

        public IMapControl Map
        {
            get { return _mainForm.Map; }
        }

        public IMainForm Form
        {
            get { return _mainForm; }
        }

        public IMenu Menu
        {
            get { return _menu; }
        }

        public bool Initialized
        {
            get { return _mainForm != null && _mainForm.Map != null; }
        }
    }
}
