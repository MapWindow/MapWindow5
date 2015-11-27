// -------------------------------------------------------------------------------------------
// <copyright file="TemplateNameResolver.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.IO;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Variables that can be used in tempalted names for outputs of GIS tools.
    /// </summary>
    internal static class TemplateNameResolver
    {
        internal const string Input = "{input}";
        private const string InputFolder = "{input_folder}";
        internal const string Extension = "{ext}";

        public static string Resolve(string inputFilename, string templateName, bool memoryLayer)
        {
            if (memoryLayer)
            {
                string name = templateName.Replace(Input, Path.GetFileNameWithoutExtension(inputFilename));
                return Path.GetFileNameWithoutExtension(name);
            }
            else
            {
                string name = templateName.Replace(Input, Shared.PathHelper.GetFullPathWithoutExtension(inputFilename));
                name = name.Replace(InputFolder + @"\", Path.GetDirectoryName(inputFilename));
                string ext = Path.GetExtension(inputFilename);
                name = name.Replace("." + Extension, ext);
                return name;
            }
        }
    }
}