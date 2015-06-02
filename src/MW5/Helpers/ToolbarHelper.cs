using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Helpers;
using MW5.Plugins.Services;
using MW5.Shared;
using Syncfusion.Runtime.Serialization;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.Helpers
{
    public static class ToolbarHelper
    {
        public static void SaveLayout(this MainFrameBarManager manager, bool startup)
        {
            var sr = GetSerializer(startup);
            manager.SaveBarState(sr);
            sr.PersistNow();
        }

        public static void RestoreLayout(this MainFrameBarManager manager, bool startup)
        {
            var sr = GetSerializer(startup);

            string path = sr.GetPath();

            if (startup && !File.Exists(path))
            {
                MessageService.Current.Warn("File with initial state of toolbars wasn't found: " + path);
                return;
            }

            manager.LoadBarState(sr);
        }

        private static AppStateSerializer GetSerializer(bool startup)
        {
            string path = ConfigPathHelper.GetToolbarConfigPath();

            if (startup)
            {
                path += "_startup";
            }

            return new AppStateSerializer(SerializeMode.XMLFile, path);
        }
    }
}
