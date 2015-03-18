using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Helpers
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
    }
}
