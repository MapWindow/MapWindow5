using System;
using System.Diagnostics;
using System.IO;

namespace MW5.Shared
{
    public static class PathHelper
    {
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

        public static String GetFullPathWithoutExtension(String path)
        {
            return Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
        }

        public static void CreateFolder(string filename)
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
                }
            }
        }

        public static void OpenFolderWithExplorer(string path)
        {
            try
            {
                string args = string.Format("/e, /select, \"{0}\"", path);

                ProcessStartInfo info = new ProcessStartInfo {FileName = "explorer", Arguments = args};
                Process.Start(info);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to open folder: " + path, ex);
            }
        }

        // http ://stackoverflow.com/questions/703281/getting-path-relative-to-the-current-working-directory
        public static string GetRelativePath(string basePath, string otherPath)
        {
            Uri pathUri = new Uri(otherPath);

            basePath = Path.GetDirectoryName(basePath);

            if (string.IsNullOrWhiteSpace(basePath))
            {
                return string.Empty;
            }

            basePath += Path.DirectorySeparatorChar;

            Uri folderUri = new Uri(basePath);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }
    }
}
