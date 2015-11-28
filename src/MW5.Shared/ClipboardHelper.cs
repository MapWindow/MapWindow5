using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Shared
{
    public static class ClipboardHelper
    {
        public static bool SetText(string text)
        {
            try
            {
                Clipboard.SetText(text);
                return true;
            }
            catch (Exception ex)
            {
                const string msg = "Failed to copy data to the clipboard.";
                Logger.Current.Warn(msg, ex);
                return false;
            }
        }
    }
}
