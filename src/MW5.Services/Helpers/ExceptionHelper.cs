using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace MW5.Services.Helpers
{
    internal static class ExceptionHelper
    {
        internal static string Report(Exception ex)
        {
            if (ex is ReflectionTypeLoadException)
            {
                return ReportReflectionException(ex as ReflectionTypeLoadException);
            }

            return string.Empty;
        }

        private static string ReportReflectionException(ReflectionTypeLoadException ex)
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

            return sb.ToString();
        }
    }
}
