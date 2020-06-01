using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Forms.Integration;
using System.IO;
using System.ComponentModel;

namespace MW5.Plugins.AdvancedSnapping.Views
{

    public static class WindowExtensions
    {

        public static IntPtr MainWindowHandle { get; set; }

        public static void GetAndSetOwner(this Window wpfDialogWindow)
        {
            // WPF App;
            if (MainWindowHandle == IntPtr.Zero)
            {
                wpfDialogWindow.Owner = System.Windows.Application.Current.MainWindow;
            }
            else // Winforms app:
            {
                EnsureApplicationResources();
                var helper = new WindowInteropHelper(wpfDialogWindow)
                {
                    Owner = MainWindowHandle
                };
                ElementHost.EnableModelessKeyboardInterop(wpfDialogWindow);
            }

        }

        public static void EnsureApplicationResources()
        {
            if (null == System.Windows.Application.Current)
            {
                var app = new Application();
                app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                /*app.Resources.MergedDictionaries.Add(
                    Application.LoadComponent(
                        new Uri("namespace;component/View/axamlfilename.xaml",
                        UriKind.Relative)) as ResourceDictionary);*/
            }
        }
    }
}