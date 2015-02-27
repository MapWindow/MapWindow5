using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace MW5.Plugins.Services
{
    internal static class ErrorService
    {
        public static void Report(ReflectionTypeLoadException ex)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Exception exSub in ex.LoaderExceptions)
            {
                sb.AppendLine(exSub.Message);
                if (exSub is FileNotFoundException)
                {
                    FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                    if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                    {
                        sb.AppendLine("Fusion Log:");
                        sb.AppendLine(exFileNotFound.FusionLog);
                    }
                }
                sb.AppendLine();
            }
            Debug.Print(sb.ToString());
        }
    }
}
