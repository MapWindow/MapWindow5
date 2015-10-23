using System.IO;
using System.Reflection;
using MW5.Shared;

namespace MW5.Plugins.Helpers
{
    public class ResourcePathHelper
    {
        /// <summary>
        /// Returns path to the default directory with icons
        /// </summary>
        public static string GetIconsPath()
        {
            return GetStylesPath() + @"Icons\";
        }

        /// <summary>
        /// Returns path to the default directory with icons
        /// </summary>
        public static string GetTexturesPath()
        {
            return GetStylesPath() + @"Textures\";
        }

        /// <summary>
        /// Gets path of the styles folder.
        /// </summary>
        /// <returns></returns>
        public static string GetStylesPath()
        {
            return AssemblyHelper.GetAppFolder() + @"\Styles\";
        }
    }
}
