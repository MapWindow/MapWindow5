using System;
using System.Drawing;
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
    internal static class DockPanelHelper
    {
        private const int PanelSize = 300;

        public static void InitDocking(this IAppContext context)
        {
            var panels = context.DockPanels;
            panels.Lock();

            try
            {
                InitLegend(context);

                InitLocator(context);

                InitToolbox(context);

                context.DockPanels.Legend.TabPosition = 0;
            }
            finally
            {
                panels.Unlock();
            }
        }
        
        private static void InitLegend(IAppContext context)
        {
            var legendControl = context.Legend as UserControl;
            if (legendControl == null)
            {
                throw new InvalidCastException("Legend control must inherit from UserControl");
            }

            legendControl.BorderStyle = BorderStyle.None;

            var legend = context.DockPanels.Add(legendControl, DockPanelKeys.Legend, PluginIdentity.Default);
            legend.Caption = "Legend";
            legend.DockTo(null, DockPanelState.Left, PanelSize);
            legend.SetIcon(Resources.ico_legend);
        }

        private static void InitToolbox(IAppContext context)
        {
            var panels = context.DockPanels;

            var toolboxPanel = context.Toolbox as Control;
            if (toolboxPanel == null)
            {
                throw new InvalidCastException("Toolbox control must inherit from Control");
            }

            var toolbox = context.DockPanels.Add(toolboxPanel, DockPanelKeys.Toolbox, PluginIdentity.Default);
            toolbox.Caption = "GIS Toolbox";
            toolbox.DockTo(panels.Legend, DockPanelState.Tabbed, PanelSize);
            toolbox.SetIcon(Resources.ico_tools);
        }

        private static void InitLocator(IAppContext context)
        {
            var panels = context.DockPanels;

            var locatorPanel = context.Locator.GetInternalObject() as UserControl;
            if (locatorPanel == null)
            {
                throw new InvalidCastException("Locator control must inherit from UserControl");
            }

            locatorPanel.BorderStyle = BorderStyle.None;
            var locator = panels.Add(locatorPanel, DockPanelKeys.Preview, PluginIdentity.Default);
            locator.Caption = "Locator";
            locator.SetIcon(Resources.ico_zoom_to_layer);
            locator.DockTo(panels.Legend, DockPanelState.Bottom, PanelSize);

            var size = locator.Size;
            locator.Size = new Size(size.Width, 250);
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
