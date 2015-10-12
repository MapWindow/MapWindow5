using System;
using System.Diagnostics;
using System.IO;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins.Helpers
{
    public static class ConfigPathHelper
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

        public static string GetToolbarConfigPath()
        {
            return GetConfigPath() + @"\toolbars";
        }

        public static string GetToolsConfigPath()
        {
            return GetConfigPath() + @"\Tools\";
        }

        public static string GetDriversConfigPath()
        {
            return GetConfigPath() + @"\Drivers\";
        }

        public static string GetWmsCachePath()
        {
            return GetConfigPath() + @"\WMS\";
        }
    }
}
