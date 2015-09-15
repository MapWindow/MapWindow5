// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManualHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Methods for showing the manual, remotely or local
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Shared;

namespace MW5.Tools.Helpers
{
    public static class ManualHelper
    {
        private const bool UseLocalHelpOnly = true;

        /// <summary>
        /// Gets the default manual text.
        /// </summary>
        /// <param name="tool">The tool.</param>
        /// <returns>The manual text letting the user know the manual is not yet written</returns>
        public static string GetDefaultText(this ITool tool)
        {
            var url = new Uri(GetUrl(tool));
            var localPath = GetLocalPath(tool);
            return string.Format(
                "<h1>{2}</h1>Documentation for this tool is missing. <br /><p style='font-size: 0.7em'>Searched locations: <br />{0}</br>{1}</p>", 
                url, 
                localPath, 
                tool.Name);
        }

        /// <summary>
        /// Gets the manual URI
        /// </summary>
        /// <param name="tool">The tool.</param>
        /// <returns>The remote or local URI to the manual</returns>
        public static Uri GetManualUri(this ITool tool)
        {
            // First check if the remote version is available/accessible:
            var url = new Uri(GetUrl(tool));
            if (RemoteUriExists(url))
            {
                return url;
            }

            // Remote file doesn't exist or no internet connection, try local file:
            var localPath = GetLocalPath(tool);
            if (File.Exists(localPath))
            {
                return new Uri(string.Format("file:///{0}", localPath.Replace(@"\", @"/")));
            }

            // No manual has been made yet:
            Logger.Current.Warn(string.Format("Documentation for this tool is missing. Searched locations: {0} and {1}", url, localPath));
            return null;
        }

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

            return "Documentation for this tool is missing. <br />" + "<p style='font-size: 0.7em'>Searched locations: <br />" + url + "</br>" + path + "</p>";
        }

        /// <summary>
        /// Gets the local path of the manual for this tool.
        /// </summary>
        /// <param name="tool">The tool.</param>
        /// <returns>The path of the file</returns>
        private static string GetLocalPath(ITool tool)
        {
            return Application.StartupPath + @"\Manuals\" + tool.GetType().Name + ".html";
        }

        /// <summary>
        /// Gets the remote URL of the manual for this tool.
        /// </summary>
        /// <param name="tool">The tool.</param>
        /// <returns>The url</returns>
        private static string GetUrl(ITool tool)
        {
            return "http://www.mapwindow.org/Manuals/" + tool.GetType().Name + ".html";
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
            catch
            {
            }

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
            catch
            {
            }

            return false;
        }

        /// <summary>
        /// Check if the remote uri exists and accessible
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>True on success</returns>
        private static bool RemoteUriExists(Uri uri)
        {
            using (var wc = new WebClient())
            {
                try
                {
                    wc.DownloadString(uri);
                    return true;
                }
                // ReSharper disable once EmptyGeneralCatchClause
                catch
                {
                }
            }

            return false;
        }
    }
}