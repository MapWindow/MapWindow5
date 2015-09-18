using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Helper class to deal with the standard ToolView tab control.
    /// </summary>
    internal static class TabControlHelper
    {
        public static TabPageAdv AddTab(this TabControlAdv tabControl, TabPageAdv page, string caption, Bitmap icon)
        {
            // Also can try to do initialization of properties within tab.SuspendLayout, tab.ResumeLayout calls
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

            int index = tabControl.TabPages.IndexOf(page);

            // insert before the help page
            tabControl.TabPages.Insert(index, tab);

            return tab;
        }

        /// <summary>
        /// Adds additional tab page.
        /// </summary>
        public static TabPageAdv AddTab(this TabControlAdv tabControl, string caption, Bitmap icon)
        {
            var page = tabControl.TabPages[tabControl.TabPages.Count - 1];
            return AddTab(tabControl, page, caption, icon);
        }

        /// <summary>
        /// Gets panel within the tab page.
        /// </summary>
        public static Panel GetPanel(this TabPageAdv tab)
        {
            return tab.Controls[0] as Panel;
        }
    }
}
