// -------------------------------------------------------------------------------------------
// <copyright file="TabControlHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Extension method to deal with the standard ToolView tab control.
    /// </summary>
    internal static class TabControlHelper
    {
        /// <summary>
        /// Adds new tab page to the control.
        /// </summary>
        public static TabPageAdv AddTab(this TabControlAdv tabControl, string caption, Bitmap icon)
        {
            var page = tabControl.TabPages[tabControl.TabPages.Count - 1];
            return AddTab(tabControl, caption, icon, page);
        }

        /// <summary>
        /// Gets panel within the tab page.
        /// </summary>
        public static Panel GetPanel(this TabPageAdv tab)
        {
            return tab.Controls[0] as Panel;
        }

        /// <summary>
        /// Adds new tab page to the control and adds it before specified page.
        /// </summary>
        private static TabPageAdv AddTab(
            this TabControlAdv tabControl,
            string caption,
            Bitmap icon,
            TabPageAdv insertBefore)
        {
            var tab = new TabPageAdv(caption)
                          {
                              Image = icon,
                              ImageSize = new Size(24, 24),
                              Location = new Point(123, 1),
                              ShowCloseButton = true,
                              ThemesEnabled = false
                          };

            // insert panel with autoscrolling, which will serve as a container for controls
            var panel = new Panel
                            {
                                AutoScroll = true,
                                Dock = DockStyle.Fill,
                                Location = new Point(0, 0),
                                Padding = new Padding(20, 10, 20, 25),
                                Size = new Size(425, 387),
                            };

            tab.Controls.Add(panel);

            int index = tabControl.TabPages.IndexOf(insertBefore);

            // insert before the help page
            tabControl.TabPages.Insert(index, tab);

            return tab;
        }
    }
}