// -------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.DI.Castle;
using MW5.Helpers;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Services.Concrete;
using MW5.Shared;
using MW5.Views;
// using MW5.DI.LightInject;
// using MW5.DI.Ninject;
// using MW5.DI.Unity;

namespace MW5
{
    internal static class Program
    {
        public static Stopwatch Timer = new Stopwatch();

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

        private static void DumpFormats()
        {
            var manager = new DriverManager();
            manager.DumpExtensions(true);

            manager.DumpExtensions(false);
        }

        private static void LoadConfig(IApplicationContainer container)
        {
            Logger.Current.Debug("Start LoadConfig");
            MapInitializer.InitMapConfig();

            Logger.Current.Debug("Before container.GetSingleton");
            var configService = container.GetSingleton<IConfigService>();
            Logger.Current.Debug("After container.GetSingleton");

            configService.LoadAll();
            Logger.Current.Debug("End LoadConfig");
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
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

        private static void ShowSplashScreen()
        {
            var splashScreen = SplashView.Instance;
            splashScreen.ShowStatus("Composing DI container");
            splashScreen.Show();
            Application.DoEvents();
        }
    }
}