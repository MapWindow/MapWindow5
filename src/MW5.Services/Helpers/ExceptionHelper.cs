using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace MW5.Services.Helpers
{
    internal static class ExceptionHelper
    {
        public static string ExceptionToString(this Exception ex)
        {
            string msg = string.Empty;
            ExceptionToString(ex, ref msg);
            return msg;
        }

        public static string ExceptionToLogString(this Exception ex)
        {
            string msg = string.Empty;
            ExceptionToLogString(ex, 0, ref msg);
            return msg;
        }
        
        private static void ExceptionToLogString(this Exception ex, int level, ref string msg)
        {
            if (!string.IsNullOrWhiteSpace(msg))
            {
                msg += Environment.NewLine + Environment.NewLine;
            }

            msg += level == 0 ? "Exception: " : "Inner exception: " + ex.Message + Environment.NewLine;
            msg += "Stack trace: " + Environment.NewLine + ex.StackTrace;

            if (ex.InnerException != null)
            {
                ExceptionToLogString(ex.InnerException, ++level, ref msg);
            }
        }

        private static void ExceptionToString(Exception ex, ref string msg)
        {
            if (!string.IsNullOrWhiteSpace(msg))
            {
                msg += Environment.NewLine + Environment.NewLine;
            }

            msg += "Description: " + ex.Message.ToUpper() + Environment.NewLine + Environment.NewLine;
            msg += "Stack trace: " + Environment.NewLine + ex.StackTrace;

            if (ex.InnerException != null)
            {
                ExceptionToString(ex.InnerException, ref msg);
            }
        }
        
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
