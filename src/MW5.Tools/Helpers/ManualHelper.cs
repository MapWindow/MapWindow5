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

        public static string LoadManual(this ITool tool)
        {
            string html;

            string url = GetUrl(tool);

            if (!UseLocalHelpOnly)
            {
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
                   "<p style='font-size: 0.7em'>Searched locations: <br />" + url + "</br>" + path + "</p>";
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

        private static string GetUrl(ITool tool)
        {
            // TODO: use real path
            return "http://www.mapwindow.org/Manuals/" + tool.GetType().Name + ".html";
        }

        private static string GetLocalPath(ITool tool)
        {
            return Application.StartupPath + @"\Manuals\" + tool.GetType().Name + ".html";
        }
    }
}
