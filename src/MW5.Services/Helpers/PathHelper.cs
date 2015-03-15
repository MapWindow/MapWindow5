using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Services.Helpers
{
    public static class PathHelper
    {
        private const string AppName = "MapWindow5";

        public static string GetSettingsPath()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string path = Path.Combine(folder, AppName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        public static string GetSettingsFile()
        {
            return GetSettingsPath() + @"\settings.xml";
        }

        public static string GetDockingConfigFilename()
        {
            return GetSettingsPath() + @"\dockstate.xml";
        }
    }
}
