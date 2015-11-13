// -------------------------------------------------------------------------------------------
// <copyright file="PathHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;

namespace MW5.Shared
{
    public static class PathHelper
    {
        public static bool CreateFolder(string filename)
        {
            string path = Path.GetDirectoryName(filename);

            if (path != null && !Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception ex)
                {
                    Logger.Current.Warn("Failed to create directory: " + path, ex);
                    return false;
                }
            }

            return true;
        }

        public static string GetAbsolutePath(string name, string basePath)
        {
            if (Path.IsPathRooted(name))
            {
                return name;
            }

            string path = Path.GetDirectoryName(basePath);
            if (!string.IsNullOrWhiteSpace(path))
            {
                return Path.GetFullPath(Path.Combine(path, name));
            }

            return name;
        }

        public static String GetFullPathWithoutExtension(String path)
        {
            return Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
        }

        public static string GetRelativePath(string basePath, string otherPath)
        {
            var pathUri = new Uri(otherPath);

            basePath = Path.GetDirectoryName(basePath);

            if (string.IsNullOrWhiteSpace(basePath))
            {
                return string.Empty;
            }

            basePath += Path.DirectorySeparatorChar;

            var folderUri = new Uri(basePath);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }

        /// <summary>
        /// Checks if folder is immediate parent of filename.
        /// </summary>
        public static bool IsParentOf(string folder, string filename)
        {
            if (folder.Length >= filename.Length)
            {
                return false;
            }

            return Path.GetDirectoryName(filename).EqualsIgnoreCase(folder.ToLower());
        }

        public static void OpenFolderWithExplorer(string path)
        {
            try
            {
                string args = string.Format("/e, /select, \"{0}\"", path);

                var info = new ProcessStartInfo { FileName = "explorer", Arguments = args };
                Process.Start(info);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to open folder: " + path, ex);
            }
        }

        public static void OpenUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                Logger.Current.Warn("Attempt to open an empty link.");
                return;
            }

            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to open link: " + url, ex);
            }
        }
    }
}