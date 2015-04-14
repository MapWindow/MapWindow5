using System;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Style
{
    public class SyncfusionStyleService : IStyleService
    {
        private Color _metroColor = Color.FromArgb(22, 165, 220);
        private readonly ControlStyleSettings _settings;

        public SyncfusionStyleService(ControlStyleSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            _settings = settings;
        }

        public void ApplyStyle(Form form)
        {
            ApplyStyle(form.Controls);
        }

        public void ApplyStyle(Control control)
        {
            ApplyStyle(control.Controls);
        }

        private void ApplyStyle(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                var lbl = control as Label;
                if (lbl != null)
                {
                    lbl.BackColor = Color.Transparent;
                }

                var btn = control as ButtonAdv;
                if (btn != null)
                {
                    btn.Appearance = _settings.ButtonAppearance;
                    btn.UseVisualStyle = true;
                }

                var cbo = control as ComboBoxAdv;
                if (cbo != null)
                {
                    cbo.Style = _settings.VisualStyle;
                }

                var txt = control as TextBoxExt;
                if (txt != null)
                {
                    txt.Style = _settings.TextboxTheme;
                }

                var chk = control as CheckBoxAdv;
                if (chk != null)
                {
                    chk.Style = _settings.CheckboxStyle;
                    chk.MetroColor = Color.DimGray;
                }

                var rad = control as RadioButtonAdv;
                if (rad != null)
                {
                    rad.Style = _settings.RadioButtonStyle;
                }

                var grid = control as GridGroupingControl;
                if (grid != null)
                {
#if STYLE2010   
                    grid.GridOfficeScrollBars = OfficeScrollBars.Office2010;
                    grid.GridVisualStyles = GridVisualStyles.Office2010Blue;
#else
                    grid.GridOfficeScrollBars = OfficeScrollBars.Metro;
                    grid.GridVisualStyles = GridVisualStyles.Custom;
                    grid.TableOptions.GridVisualStyles = GridVisualStyles.Custom;
#endif
                }

                var tree = control as TreeViewAdv;
                if (tree != null)
                {
                    tree.MetroColor = _metroColor;
#if STYLE2010
                    tree.Style = TreeStyle.Office2010;
#else
                    tree.Style = TreeStyle.Metro;
#endif
                }

                var tab = control as TabControlAdv;
                if (tab != null)
                {
//#if STYLE2010
//                    tab.TabStyle = typeof(TabRendererOffice2007);
//#else
//                    if (tab.Alignment == TabAlignment.Top)
//                    {
//                        tab.TabStyle = typeof (TabRendererMetro);
//                    }
//                    else
//                    {
//                        tab.TabStyle = typeof (TabRendererDockingVS2012);
//                    }
//#endif
                }

                ApplyStyle(control.Controls);
            }
        }
    }
}
