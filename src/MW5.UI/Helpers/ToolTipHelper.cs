// -------------------------------------------------------------------------------------------
// <copyright file="ToolTipHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Helpers
{
    public static class ToolTipHelper
    {
        private static SuperToolTip _toolTipManager;

        public static void Init(SuperToolTip toolTipManager)
        {
            Logger.Current.Debug("In ToolTipHelper.Init()");
            if (toolTipManager == null) throw new ArgumentNullException("toolTipManager");
            _toolTipManager = toolTipManager;
        }

        public static void SetStyle(SuperToolTip tooltip)
        {
            tooltip.VisualStyle = SuperToolTip.Appearance.Default;
            tooltip.MetroColor = Color.White;
            tooltip.UseFading = SuperToolTip.FadingType.System;
        }

        public static void UpdateTooltip(object sender)
        {
            if (_toolTipManager == null)
            {
                return;
            }

            var item = sender as IMenuItem;
            if (item == null)
            {
                return;
            }

            var dropDown = item as IDropDownMenuItem;
            if (dropDown != null)
            {
                return; // the tooltip would interfere with dropdown main function
            }

            var comp = item.GetInternalObject() as Component;

            var info = _toolTipManager.GetToolTip(comp);
            bool hasToolTip = info != null;

            if (info == null)
            {
                info = new ToolTipInfo();
            }

            info.Header.Text = item.Text;

            if (!hasToolTip)
            {
                info.Header.Font = new Font(info.Header.Font, FontStyle.Bold);
            }

            info.Body.Text = string.IsNullOrWhiteSpace(item.Description)
                                 ? "There is no description for the item."
                                 : item.Description;

            if (AppConfig.Instance.ShowPluginInToolTip && item.PluginIdentity != PluginIdentity.Default)
            {
                info.Footer.Text = "Plugin: " + item.PluginIdentity.Name;
                info.Separator = false;
            }

            if (!hasToolTip)
            {
                _toolTipManager.SetToolTip(comp, info);
            }
        }
    }
}