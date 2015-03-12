using System.Windows.Forms;
using Syncfusion.Runtime.Serialization;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Helpers
{
    internal static class DockingHelper
    {
        public static void InitDocking(this DockingManager dockingManager, UserControl legend, TreeViewAdv preview, Form parent)
        {
            // designer support of docking in VS2013 with MetroForm is buggy
            // so better to et layout at runtime

            legend.BorderStyle = BorderStyle.None;
            preview.BorderStyle = BorderStyle.None;

            // border was set to make them visible during design time
            dockingManager.LockHostFormUpdate();

            dockingManager.SetEnableDocking(legend, true);
            dockingManager.SetEnableDocking(preview, true);

            dockingManager.DockControl(legend, parent, DockingStyle.Left, 300);
            dockingManager.DockControl(preview, legend, DockingStyle.Bottom, 300);

            dockingManager.SetDockLabel(legend, "Legend");
            dockingManager.SetDockLabel(preview, "Preview");

            dockingManager.UnlockHostFormUpdate();

            var sr = GetSerializer();
            //dockingManager.LoadDockState(sr);
        }

        public static void SaveLayout(this DockingManager dockingManager)
        {
            var sr = GetSerializer();
            dockingManager.SaveDockState(sr);
            sr.PersistNow();
        }

        private static AppStateSerializer GetSerializer()
        {
            //  TODO: change the location
            return new AppStateSerializer(SerializeMode.XMLFile, @"d:\dockstate.xml");
        }
    }
}
