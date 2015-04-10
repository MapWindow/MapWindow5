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
                    Debug.WriteLine("Failed to create directory: " + path + Environment.NewLine + ex.Message);
                }
            }
        }

        public static void OpenFolderWithExplorer(string path)
        {
            try
            {
                Process.Start(path);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to open folder: " + path + Environment.NewLine + ex.Message);
            }
        }
    }
}
