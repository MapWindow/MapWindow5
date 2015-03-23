using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Helpers
{
    internal class PathHelper
    {
        /// <summary>
        /// Returns path to the default directory with icons
        /// </summary>
        internal static string GetIconsPath()
        {
            return GetStylesPath() + @"Icons\";
        }

        /// <summary>
        /// Returns path to the default directory with icons
        /// </summary>
        internal static string GetTexturesPath()
        {
            return GetStylesPath() + @"Textures\";
        }

        // TODO: woudln't it be better to get this from app context
        private static string GetAppDirectory()
        {
            string filename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Directory.GetParent(filename).FullName;
        }

        internal static string GetStylesPath()
        {
            return GetAppDirectory() + @"\Styles\";
        }

        internal static void CreateFolder(string filename)
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
                    SymbologyPlugin.Msg.Warn("Failed to create directory: " + path + Environment.NewLine + ex.Message);
                }
            }
        }
    }
}
