using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Windows.Threading;
using MW5.Api.Concrete;
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
using MW5.Services.Concrete;
using MW5.Services.Helpers;
using MW5.Shared;
using MW5.Shared.Log;
using MW5.UI.Helpers;
using MW5.Views;

namespace MW5
{
    static class Program
    {
        public static Stopwatch Timer = new Stopwatch();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            ExceptionHandler.Attach();

            //DumpFormats();

            var logger = new LoggingService();
            logger.Info("APPLICATION STARTUP");

            ShowSplashScreen();

            Timer.Start();

            var container = CreateContainer();
            CompositionRoot.Compose(container);

            SplashView.Instance.ShowStatus("Loading config");
            LoadConfig(container);

            SplashView.Instance.ShowStatus("Running application");
            container.Run<MainPresenter>();
        }

        private static void DumpFormats()
        {
            var manager = new DriverManager();
            manager.DumpExtensions(true);

            manager.DumpExtensions(false);
        }

        private static void ShowSplashScreen()
        {
            var splashScreen = SplashView.Instance;
            splashScreen.ShowStatus("Composing DI container");
            splashScreen.Show();
            Application.DoEvents();
        }

        private static void LoadConfig(IApplicationContainer container)
        {
            MapInitializer.InitMapConfig();

            var configService = container.GetSingleton<IConfigService>();
            configService.Load();
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
    }
}
