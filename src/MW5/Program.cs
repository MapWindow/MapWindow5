using System;
using System.Windows.Forms;
using MW5.Abstract;
using MW5.Core.Services;
using MW5.Core.Services.Abstract;
using MW5.DI.Castle;
using MW5.Mvp.DI;
using MW5.Plugins.Interfaces;
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

            var controller = new WindsorCastleContainer();
            CompositionRoot.Compose(controller);

            controller.Run<MainPresenter>();
        }
    }
}
