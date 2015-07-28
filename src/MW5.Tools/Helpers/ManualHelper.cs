using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Shared;

namespace MW5.Tools.Helpers
{
    public static class ManualHelper
    {
        private static bool UseLocalHelpOnly = true;

        public static string LoadManual(this IGisTool tool)
        {
            string html;

            if (!UseLocalHelpOnly)
            {
                string url = GetUrl(tool);
                if (LoadFromUrl(url, out html))
                {
                    return html;
                }
            }

            string path = GetLocalPath(tool);
            if (LoadFromFile(path, out html))
            {
                return html;
            }

            return "Documentation for this tool is missing. <br />" +
                   "<p style='font-size: 0.7em'>Searched locations: " + path + "</p>";
        }

        private static bool LoadFromFile(string path, out string html)
        {
            html = string.Empty;

            if (!File.Exists(path))
            {
                Logger.Current.Warn("Failed to find manual for the tool: " + path);
                return false;
            }

            try
            {
                html = File.ReadAllText(path);
                return true;
            }
            catch { }

            return false;
        }

        private static bool LoadFromUrl(string url, out string html)
        {
            html = string.Empty;

            // we don't bother about string encoding right now,
            // it's expected to be ASCII English
            var wc = new WebClient();    
            try
            {
                wc.DownloadString(url);
                return true;
            }
            catch { }

            return false;
        }

        private static string GetUrl(IGisTool tool)
        {
            // TODO: use real path
            return "http://www.mapwindow.org/Manuals/" + tool.GetType().Name + ".html";
        }

        private static string GetLocalPath(IGisTool tool)
        {
            return Application.StartupPath + @"\Manuals\" + tool.GetType().Name + ".html";
        }
    }
}
