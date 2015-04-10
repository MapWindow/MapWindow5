using System;
using System.Windows.Forms;
using MW5.Api.Static;
using MW5.DI.Castle;
// using MW5.DI.LightInject;
// using MW5.DI.Ninject;
// using MW5.DI.Unity;
using MW5.Helpers;
using MW5.Menu;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Services.Helpers;
using MW5.UI.Helpers;
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

            InitMapConfig();
            
            var container = CreateContainer();
            CompositionRoot.Compose(container);
            var configService = container.GetSingleton<IConfigService>();
            configService.Load();

            container.Run<MainPresenter>();

            //configService.Save();   // it's saved on closing ConfigView
        }

        private static IApplicationContainer CreateContainer()
        {
            // Switch the class here and change the using directive above to use another one
            // Also switch references.

            // LightInjectContainer
            // NinjectContainer
            // UnityApplicationContainer
            // return  new NinjectContainer();
            return new WindsorCastleContainer();
        }

        private static void InitMapConfig()
        {
            Config.ZoomToFirstLayer = true;
            Config.AllowLayersWithoutProjections = true;
            Config.AllowProjectionMismatch = false;
            Config.ReprojectLayersOnAdding = false;
            Config.OgrLayerForceUpdateMode = true;
            Config.LoadSymbologyOnAddLayer = true;
        }
    }
}
