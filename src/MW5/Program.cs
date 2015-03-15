using System;
using System.Windows.Forms;
using MW5.Api.Static;
using MW5.DI.Ninject;
//using MW5.DI.Castle;
//using MW5.DI.LightInject;
//using MW5.DI.Ninject;
//using MW5.DI.Unity;
using MW5.Helpers;
using MW5.Menu;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Presenters;
using MW5.Services.Helpers;
using MW5.Views;

namespace MW5
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            EnumConverters.Init();
            CommandBarHelper.InitMenuColors();

            InitConfig();

            var container = CreateContainer();
            CompositionRoot.Compose(container);

            container.Run<MainPresenter>();
        }

        private static IApplicationContainer CreateContainer()
        {
            // Switch the class here and change the using directive above to use another one
            // LightInjectContainer
            // NinjectContainer
            // WindsorCastleContainer
            // UnityApplicationContainer
            return  new NinjectContainer();
        }

        private static void InitConfig()
        {
            Configuration.ZoomToFirstLayer = true;
            Configuration.AllowLayersWithoutProjections = true;
            Configuration.AllowProjectionMismatch = false;
            Configuration.ReprojectLayersOnAdding = false;
            Configuration.OgrLayerForceUpdateMode = true;
            Configuration.LoadSymbologyOnAddLayer = true;
        }
    }
}
