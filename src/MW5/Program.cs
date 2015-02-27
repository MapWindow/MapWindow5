using System;
using System.Windows.Forms;
using MW5.Mvp.DI;
using MW5.Presenters;
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

            var controller = new ApplicationController(new LightInjectAdapter())
              .RegisterView<IMainView, MainView, MainViewModel>()
              .RegisterInstance(new ApplicationContext());

            controller.Run<MainPresenter, MainViewModel>(new MainViewModel());
        }
    }
}
