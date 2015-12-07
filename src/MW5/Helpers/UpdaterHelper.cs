// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdaterHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the UpdaterHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using MW5.Plugins.Concrete;
using MW5.Shared;

namespace MW5.Helpers
{
    public static class UpdaterHelper
    {
        private static bool _isx64;

        /// <summary>
        /// Downloads the latest version, if it exists.
        /// </summary>
        public static void GetLatestVersion()
        {
            var config = AppConfig.Instance;

            if (!config.UpdaterCheckNewVersion)
            {
                return;
            }

            // TODO: Add interval
            if (config.UpdaterLastChecked.Date.CompareTo(DateTime.Now.Date) == 0)
            {
                Logger.Current.Debug("Already checked today. Will check next time again.");
                config.UpdaterIsDownloading = false;
                return;
            }

            DownloadNewerVersion();
            config.UpdaterLastChecked = DateTime.Now;
            Logger.Current.Debug("New Last checked: " + config.UpdaterLastChecked);
        }

        /// <summary>
        /// Checks if a new version is available to download
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="isx64">Is the current assembly x64.</param>
        /// <param name="type">The type, stable or beta</param>
        /// <param name="fileVersionInfo">The file version information.</param>
        /// <param name="downloadUrl">The download URL.</param>
        /// <param name="installerName">Name of the installer.</param>
        /// <returns>True when a new version is available</returns>
        private static bool CheckVersions(
            IReadOnlyDictionary<string, InstallerInfo> result, 
            bool isx64, 
            string type, 
            FileVersionInfo fileVersionInfo, 
            out string downloadUrl,
            out string installerName)
        {
            var key = isx64 ? type + "-x64" : type + "-x86";
            Version latestVersion;
            try
            {
                latestVersion = result[key].Versionnumber;
                downloadUrl = result[key].DownloadUrl;
                installerName = result[key].Name;
            }
            catch (Exception ex)
            {
                Logger.Current.Debug("Warning in CheckVersions: " + ex.Message);
                downloadUrl = string.Empty;
                installerName = string.Empty;
                return false;
            }

            Logger.Current.Debug("Latest {0} version: {1}", type, latestVersion);
            if (latestVersion.Major >= fileVersionInfo.ProductMajorPart && latestVersion.Minor >= fileVersionInfo.ProductMinorPart
                && latestVersion.Build >= fileVersionInfo.ProductBuildPart && latestVersion.Revision > fileVersionInfo.ProductPrivatePart)
            {
                Logger.Current.Debug("New {0} version [{1}] available at {2}", type, latestVersion, downloadUrl);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Start method to download a possible newer version
        /// </summary>
        private static async void DownloadNewerVersion()
        {
            Logger.Current.Debug("Checking for new version");
            var assembly = Assembly.GetExecutingAssembly();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            Logger.Current.Debug("File version: {0}", fileVersionInfo.FileVersion);
            var processorArchitecture = assembly.GetName().ProcessorArchitecture;
            if (processorArchitecture == ProcessorArchitecture.Amd64 || processorArchitecture == ProcessorArchitecture.IA64)
            {
                _isx64 = true;
                Logger.Current.Debug("x64 version");
            }

            // Download json-file which will hold the version numbers and download url of the available versions.
            const string JsonLocation = @"http://www.mapwindow.org/mw5-update.json";
            var result = await DownloadHelper.DownloadSerializedJSONDataAsync<Dictionary<string, InstallerInfo>>(JsonLocation);
            if (result.Count == 0)
            {
                Logger.Current.Debug("Couldn't get mw5-update.json");
                return;
            }

            string downloadUrl;
            string installerName;

            // Check stable version:
            if (CheckVersions(result, _isx64, "Stable", fileVersionInfo, out downloadUrl, out installerName))
            {
                // Download installer
                var filename = Path.Combine(Path.GetTempPath(), installerName);
                AppConfig.Instance.UpdaterInstallername = filename;
                AppConfig.Instance.UpdaterIsDownloading = true;
                await DownloadHelper.DownloadBinaryAsync(downloadUrl, filename);
                AppConfig.Instance.UpdaterIsDownloading = false;

                // Set install flag
                AppConfig.Instance.UpdaterHasNewInstaller = true;

                // Got newest stable version, stop looking for beta installer;
                return;
            }

            // Check beta version:
            if (CheckVersions(result, _isx64, "Beta", fileVersionInfo, out downloadUrl, out installerName))
            {
                // Download installer
                var filename = Path.Combine(Path.GetTempPath(), installerName);
                AppConfig.Instance.UpdaterInstallername = filename;
                AppConfig.Instance.UpdaterIsDownloading = true;
                await DownloadHelper.DownloadBinaryAsync(downloadUrl, filename);
                AppConfig.Instance.UpdaterIsDownloading = false;

                // Set install flag
                AppConfig.Instance.UpdaterHasNewInstaller = true;
                return;
            }

            Logger.Current.Debug("No new installers available");
        }

        /// <summary>
        /// Structure to deserialize the json file
        /// </summary>
        public struct InstallerInfo
        {
            public string Cpu { get; set; }

            public string Description { get; set; }

            public string DownloadUrl { get; set; }

            public string Name { get; set; }

            public Version Versionnumber { get; set; }
        }
    }
}