// -------------------------------------------------------------------------------------------
// <copyright file="DocumentationHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Shared;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Extensions methods to load documentation for the GIS tool.
    /// </summary>
    public static class DocumentationHelper
    {
        /// <summary>
        /// Gets remote or local URI to the manual.
        /// </summary>
        public static async Task<Uri> GetDocumentationUri(this ITool tool)
        {
            // First check if the remote version is available/accessible:
            var url = new Uri(GetUrl(tool));

            // Allow to turn it off in config, to avoid exceptions when debugging
            if (!AppConfig.Instance.LocalDocumentation)
            {
                try
                {
                    await RemoteUriExists(url);
                    return url;
                    
                }
                    // ReSharper disable once EmptyGeneralCatchClause
                catch { }
            }

            // Try local documentation
            var localPath = GetLocalPath(tool);
            if (File.Exists(localPath))
            {
                return new Uri(string.Format("file:///{0}", localPath.Replace(@"\", @"/")));
            }

            // No manual has been made yet:
            string msg = string.Format("Documentation for this tool is missing. Searched locations: {0} and {1}", url, localPath);

            Logger.Current.Warn(msg);

            return null;
        }

        /// <summary>
        /// Gets the manual text letting the user know the manual is not yet written.
        /// </summary>
        public static string GetMissingNotice(this ITool tool)
        {
            var url = new Uri(GetUrl(tool));
            var localPath = GetLocalPath(tool);

            return
                string.Format(
                    "<h1>{2}</h1>Documentation for this tool is missing. <br /><p style='font-size: 0.7em'>Searched locations: <br />{0}</br>{1}</p>",
                    url, localPath, tool.Name);
        }

        /// <summary>
        /// Gets the local path of the manual for this tool.
        /// </summary>
        private static string GetLocalPath(ITool tool)
        {
            return Application.StartupPath + @"\Manuals\" + tool.GetType().Name + ".html";
        }

        /// <summary>
        /// Gets the remote URL of the manual for this tool.
        /// </summary>
        private static string GetUrl(ITool tool)
        {
            return "http://www.mapwindow.org/Manuals/ToolBox/" + tool.GetType().Name + ".html?utm_source=MW5&utm_medium=cpc&utm_campaign=Manual";
        }

        /// <summary>
        /// Check if the remote uri exists and accessible.
        /// </summary>
        private static async Task<bool> RemoteUriExists(Uri uri)
        {
            using (var wc = new WebClientEx())
            {
                wc.HeadOnly = true;

                await wc.DownloadStringTaskAsync(uri);

                return true;
            }
        }
    }
}