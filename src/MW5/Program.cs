using System;
using System.Windows.Forms;
using System.Windows.Threading;
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
using MW5.Shared;
using MW5.Shared.Log;
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

            // TODO: need to initialize logger without application container
            var container = CreateContainer();
            CompositionRoot.Compose(container);
            var logger = container.Resolve<ILoggingService>();      // this will initialize Logger.Current
            logger.Info("APPLICATION STARUP");

            AttachExceptionHandler();

            LoadConfig(container);

            container.Run<MainPresenter>();

            //configService.Save();   // it's saved on closing ConfigView
        }

        private static void AttachExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            // Occurs when a thread exception is thrown and uncaught during execution of a delegate by way of Invoke or BeginInvoke.
            //Dispatcher.CurrentDispatcher.UnhandledException += CurrentDispatcher_UnhandledException;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Current.Error("AppDoman unhandled exception", e.ExceptionObject as Exception, "");
            var ex = e.ExceptionObject as Exception;
            string s = ex != null ? ex.Message : "not a System.Exception";
            MessageBox.Show("Unhandled exception : " + s);
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
