using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MW5.Shared
{
    public static class AssemblyHelper
    {
        public static T GetAttribute<T>(this ICustomAttributeProvider assembly, bool inherit = false)
            where T : Attribute
        {
            return assembly
                .GetCustomAttributes(typeof(T), inherit)
                .OfType<T>()
                .FirstOrDefault();
        }

        public static FileVersionInfo GetAssemblyInfo(this Type type)
        {
            return FileVersionInfo.GetVersionInfo(type.Assembly.Location);
        }

        public static string GetAppFolder()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //return Directory.GetParent(filename).FullName;
        }
    }
}
