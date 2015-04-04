using System;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Properties;
using MW5.Services.Helpers;
using MW5.UI.Docking;
using Syncfusion.Runtime.Serialization;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Helpers
{
    internal static class DockingHelper
    {
        private const int PanelSize = 300;

        public static void InitDocking(this IAppContext context)
        {
            var panels = context.DockPanels;
            panels.Lock();

            try
            {
                var legendControl = context.Legend as UserControl;
                if (legendControl == null)
                {
                    throw new InvalidCastException("Legend control must inherit from UserControl");
                }

                legendControl.BorderStyle = BorderStyle.None;

                var legend = panels.Add(legendControl, DockPanelKeys.Legend, PluginIdentity.Default);
                legend.Caption = "Legend";
                legend.DockTo(null, DockPanelState.Left, PanelSize);
                legend.SetIcon(Resources.ico_legend);

                var previewPanel = context.Locator.View;
                previewPanel.BorderStyle = BorderStyle.None;

                var preview = panels.Add(previewPanel, DockPanelKeys.Preview, PluginIdentity.Default);
                preview.Caption = "Locator";
                preview.SetIcon(Resources.ico_zoom_to_layer);
                preview.DockTo(legend, DockPanelState.Bottom, PanelSize);
            }
            finally
            {
                panels.Unlock();
            }
        }


        public static void SaveLayout(this DockingManager dockingManager)
        {
            var sr = GetSerializer();
            dockingManager.SaveDockState(sr);
            sr.PersistNow();
        }

        private static AppStateSerializer GetSerializer()
        {
            return new AppStateSerializer(SerializeMode.XMLFile, PathHelper.GetDockingConfigPath());
        }
    }
}
