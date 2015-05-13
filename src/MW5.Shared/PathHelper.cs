using System;
using System.Diagnostics;
using System.IO;

namespace MW5.Shared
{
    public static class PathHelper
    {
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
    }
}
