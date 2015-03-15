using System;
using System.Windows.Forms;
using MW5.Api.Static;
using MW5.Helpers;
using MW5.Menu;
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
            CommandBarHelper.InitMenuColors();

            InitConfig();

            var container = CompositionRoot.Container;
            CompositionRoot.Compose(container);

            container.Run<MainPresenter>();
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
