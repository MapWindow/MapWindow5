using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using MW5.Plugins.Services;

namespace MW5.Services.Concrete
{
    internal class ErrorService: IErrorService
    {
        public void Report(Exception ex)
        {
            if (ex is ReflectionTypeLoadException)
            {
                ReportReflectionException(ex as ReflectionTypeLoadException);
            }
        }

        private void ReportReflectionException(ReflectionTypeLoadException ex)
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
