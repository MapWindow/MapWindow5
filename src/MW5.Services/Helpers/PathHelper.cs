using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Services;

namespace MW5.Services.Helpers
{
    public static class PathHelper
    {
        private const string AppName = "MapWindow5";

        public static string GetConfigPath()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string path = Path.Combine(folder, AppName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        public static string GetConfigFilePath()
        {
            return GetConfigPath() + @"\mwconfig.xml";
        }

        public static string GetDockingConfigPath()
        {
            return GetConfigPath() + @"\dockstate";
        }

        public static void OpenFolderWithExplorer(string path)
        {
            try
            {
                Process.Start(path);
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn("Failed to open folder: " + path + Environment.NewLine + ex.Message);
            }
        }
    }
}
