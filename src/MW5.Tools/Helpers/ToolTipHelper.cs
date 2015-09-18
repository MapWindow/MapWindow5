// -------------------------------------------------------------------------------------------
// <copyright file="ToolTipHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;
using MW5.Tools.Model.Parameters;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Extension methods to add tooltips for tool parameters controls.
    /// </summary>
    internal static class ToolTipHelper
    {
        /// <summary>
        /// Adds tooltips to the parameter controls based on BaseParameter.Description property.
        /// </summary>
        public static void AddTooltips(this SuperToolTip tooltip, IEnumerable<BaseParameter> parameters)
        {
            foreach (var p in parameters)
            {
                if (string.IsNullOrWhiteSpace(p.Description) || p.Control == null)
                {
                    continue;
                }

                var info = new ToolTipInfo { BackColor = Color.White };

                info.Header.Text = p.DisplayName;
                info.Body.Text = p.Description;

                // Syncfusion doesn't take into account header to determine the width of tooltip,
                // so let's add some padding
                const int minTextLength = 75;
                if (p.Description.Length < minTextLength)
                {
                    info.Body.Text += new string(' ', minTextLength - p.Description.Length);
                }

                tooltip.SetToolTip(p.Control.ToolTipControl, info);
            }
        }
    }
}