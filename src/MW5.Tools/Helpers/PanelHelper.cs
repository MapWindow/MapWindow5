using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Tools.Controls.Parameters;

namespace MW5.Tools.Helpers
{
    internal static class PanelHelper
    {
        /// <summary>
        /// Adds the vertical padding for controls within tab page of a standard GIS tool UI.
        /// </summary>
        /// <param name="panel">The panel.</param>
        public static void AddVerticalPadding(this Panel panel)
        {
            foreach (var ctrl in panel.Controls.Cast<Control>().Where(c => !(c is BooleanParameterControl)))
            {
                ctrl.Height += 10;
                ctrl.Padding = new Padding(0, 10, 0, 0);
            }

            if (panel.Controls.Count > 0)
            {
                // add padding at the bottom, the order of controls is reversed
                // so we take the 0 index
                var ctrl = panel.Controls[0];
                ctrl.Height += 20;
                ctrl.Padding = new Padding(0, ctrl.Padding.Top, 0, ctrl.Padding.Bottom + 20);
            }
        }
    }
}
