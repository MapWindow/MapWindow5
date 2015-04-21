﻿using System;
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
            for (int i = controls.Count - 1; i >= 0; i--)
            {
                var control = controls[i];

                var lbl = control as Label;
                if (lbl != null)
                {
                    lbl.BackColor = Color.Transparent;
                }

                var btn = control as ButtonAdv;
                if (btn != null)
                {
                    btn.KeepFocusRectangle = false;
#if STYLE2010   
                    btn.Appearance = ButtonAppearance.Office2010;
                    btn.UseVisualStyle = true;
#else
                    btn.Appearance= ButtonAppearance.Classic;
                    btn.UseVisualStyle = false;
                    btn.UseVisualStyleBackColor = true;
                    btn.ForeColor = Color.Black;
#endif
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

                ApplyTabStyle(control);

                ApplyStyle(control.Controls);
            }
        }

        private void ApplyTabStyle(Control control)
        {
            var tab = control as TabControlAdv;
            if (tab != null)
            {
#if STYLE2010
                    tab.TabStyle = typeof(TabRendererOffice2007);
#else
                // it seems there is no way to set decent looking border for TabControlAdv
                // so let's insert gradient panel
                var panel = new GradientPanel
                {
                    BorderColor = Color.LightGray,
                    BorderStyle = BorderStyle.FixedSingle,
                    Left = tab.Left,
                    Top = tab.Top,
                    Width = tab.Width,
                    Height = tab.Height
                };

                tab.Parent.Controls.Add(panel);
                tab.Parent.Controls.Remove(tab);
                panel.Controls.Add(tab);
                tab.Dock = DockStyle.Fill;

                tab.PersistTabState = false;
                tab.BorderStyle = BorderStyle.None;
                tab.BorderVisible = false;
                tab.FocusOnTabClick = false;
                tab.RotateTextWhenVertical = true;
                tab.TabStyle = typeof(TabRendererMetro);

                if (tab.Alignment == TabAlignment.Left)
                {
                    tab.TextLineAlignment = StringAlignment.Near;
                    tab.ActiveTabFont = tab.Font;
                    tab.Padding = new Point(7, 10);
                    tab.ActiveTabColor = Color.FromKnownColor(KnownColor.Control);         // 200
                    tab.TabPanelBackColor = Color.Gray;      //112; 141
                    tab.InactiveTabColor = Color.Gray;
                }
                else
                {
                    tab.Padding = new Point(10, 5);
                    //tab.TabPanelBackColor = Color.FromArgb(141, 141, 141);
                    //tab.InactiveTabColor = Color.FromArgb(141, 141, 141);
                }

                tab.FixedSingleBorderColor = _metroColor;
#endif
            }
        }
    }
}