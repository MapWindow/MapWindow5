using System;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
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

            var container = CompositionRoot.Container;
            CompositionRoot.Compose(container);

            container.Run<MainPresenter>();
        }
    }
}
