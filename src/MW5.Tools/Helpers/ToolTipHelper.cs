using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Model.Parameters;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Helpers
{
    internal static class ToolTipHelper
    {
        public static void AddTooltips(this SuperToolTip tooltip, Panel panel, IEnumerable<BaseParameter> parameters)
        {
            var dict = parameters.ToDictionary(p => p.Name);

            foreach (var ctrl in panel.Controls)
            {
                var pc = ctrl as ParameterControlBase;
                if (pc == null)
                {
                    continue;
                }

                var info = new ToolTipInfo();

                var p = dict[pc.ParameterName];
                if (p != null && !string.IsNullOrWhiteSpace(p.Description))
                {
                    info.BackColor = Color.White;
                    info.Header.Text = p.DisplayName;
                    info.Body.Text = p.Description;

                    info.Body.Text = p.Description;

                    // Syncfusion doesn't taking into account header to determine the width ot tooltip
                    // so let's add some padding
                    const int minTextLength = 75;
                    if (p.Description.Length < minTextLength)
                    {
                        info.Body.Text += new string(' ', minTextLength - p.Description.Length);
                    }

                    tooltip.SetToolTip(pc.ToolTipControl, info);
                }
            }
        }
    }
}
