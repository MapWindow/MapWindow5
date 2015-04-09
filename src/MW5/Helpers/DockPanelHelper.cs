using System;
using System.Drawing;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Properties;
using MW5.Services.Helpers;
using MW5.Services.Serialization;
using MW5.UI.Docking;
using Syncfusion.Runtime.Serialization;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Helpers
{
    internal static class DockPanelHelper
    {
        private const int PanelSize = 300;

        public static void InitDocking(this ISerializableContext context)
        {
            var panels = context.DockPanels;
            panels.Lock();

            try
            {
                InitLegend(context);

                InitLocator(context);

                InitToolbox(context);

                InitRepository(context);
            }
            finally
            {
                panels.Unlock();
            }

            context.DockPanels.Legend.TabPosition = 0;
        }

        private static void InitLegend(ISerializableContext context)
        {
            var legendControl = context.GetDockPanelObject(DefaultDockPanel.Legend);

            var legend = context.DockPanels.Add(legendControl, DockPanelKeys.Legend, PluginIdentity.Default);
            legend.Caption = "Legend";
            legend.DockTo(null, DockPanelState.Left, PanelSize);
            legend.SetIcon(Resources.ico_legend);
        }

        private static void InitToolbox(ISerializableContext context)
        {
            var toolboControl = context.GetDockPanelObject(DefaultDockPanel.Toolbox);

            var toolbox = context.DockPanels.Add(toolboControl, DockPanelKeys.Toolbox, PluginIdentity.Default);
            toolbox.Caption = "GIS Toolbox";
            toolbox.DockTo(context.DockPanels.Legend, DockPanelState.Tabbed, PanelSize);
            toolbox.SetIcon(Resources.ico_tools);
        }

        private static void InitLocator(ISerializableContext context)
        {
            var toolboControl = context.GetDockPanelObject(DefaultDockPanel.Locator);

            var locator = context.DockPanels.Add(toolboControl, DockPanelKeys.Preview, PluginIdentity.Default);
            locator.Caption = "Locator";
            locator.SetIcon(Resources.ico_zoom_to_layer);
            locator.DockTo(context.DockPanels.Legend, DockPanelState.Bottom, PanelSize);

            var size = locator.Size;
            locator.Size = new Size(size.Width, 250);
        }

        private static void InitRepository(ISerializableContext context)
        {
            var repoControl = context.GetDockPanelObject(DefaultDockPanel.Repository);

            var legend = context.DockPanels.Add(repoControl, DockPanelKeys.Repository, PluginIdentity.Default);
            legend.Caption = "Repository";
            legend.DockTo(null, DockPanelState.Right, PanelSize);
            legend.SetIcon(Resources.ico_legend);
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
