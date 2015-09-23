using System;
using System.Drawing;
using System.Windows.Forms;
using MW5.Shared;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;

namespace MW5.UI.Style
{
    public class SyncfusionStyleService : IStyleService
    {
        private readonly Color _metroColor = Color.FromArgb(22, 165, 220);
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

        private void ApplyStyle(Control.ControlCollection controls)
        {
            for (int i = controls.Count - 1; i >= 0; i--)
            {
                var control = controls[i];

                ApplyStyle(control);
            }
        }

        public void ApplyStyle(Control control)
        {
            ApplyLabelStyle(control);

            ApplyButtonStyle(control);

            ApplyGradientPanelStyle(control);

            ApplyComboBoxStyle(control);

            ApplyTextBoxStyle(control);

            ApplyCheckboxStyle(control);

            ApplyRadioButtonStyle(control);

            ApplyTreeViewStyle(control);

            ApplySplitterStyle(control);

            ApplyMultiColumnTreeViewStyle(control);

            ApplyTrackBarStyle(control);

            ApplyNumericUpDownStyle(control);

            ApplyTabStyle(control);

            ApplyGridStyle(control);

            ApplySplitButtonStyle(control);

            ApplyDoubleTextBoxStyle(control);

            if (control is ComboBoxAdv)
            {
                // it will apply style to inner textbox otherwise which doesn't look good
            }
            else
            {
                ApplyStyle(control.Controls);
            }
        }

        private void ApplyDoubleTextBoxStyle(Control control)
        {
            var txt = control as DoubleTextBox;
            if (txt != null)
            {
                txt.NegativeColor = Color.Black;
            }
        }

        private void ApplySplitButtonStyle(Control control)
        {
            var btn = control as SplitButton;
            if (btn != null)
            {
                btn.Style = SplitButtonVisualStyle.Default;
                //btn.BackColor = Color.Gray;
            }
        }

        private void ApplyLabelStyle(Control control)
        {
            var lbl = control as Label;
            if (lbl != null)
            {
                lbl.BackColor = Color.Transparent;
            }
        }

        private void ApplyButtonStyle(Control control)
        {
            var btn = control as ButtonAdv;
            if (btn != null)
            {
                btn.KeepFocusRectangle = false;
#if STYLE2010   
                    btn.Appearance = ButtonAppearance.Office2010;
                    btn.UseVisualStyle = true;
#else
                btn.Appearance = ButtonAppearance.Classic;
                btn.UseVisualStyle = false;
                btn.UseVisualStyleBackColor = true;
                btn.ForeColor = Color.Black;
#endif
            }
        }

        private void ApplyGradientPanelStyle(Control control)
        {
            var panel = control as GradientPanel;
            if (panel != null)
            {
                //panel.BorderStyle = BorderStyle.None;
                //panel.BorderStyle = BorderStyle.FixedSingle;
                //panel.BorderColor = Color.LightGray;
            }
        }

        private void ApplyComboBoxStyle(Control control)
        {
            var cbo = control as ComboBoxAdv;
            if (cbo != null)
            {
                cbo.Style = _settings.VisualStyle;
            }
        }

        private void ApplyTextBoxStyle(Control control)
        {
            var txt = control as TextBoxExt;
            if (txt != null)
            {
                txt.Style = _settings.TextboxTheme;
            }
        }

        private void ApplyCheckboxStyle(Control control)
        {
            var chk = control as CheckBoxAdv;
            if (chk != null)
            {
                chk.Style = _settings.CheckboxStyle;
                chk.MetroColor = Color.Black;
            }
        }

        private void ApplyRadioButtonStyle(Control control)
        {
            var rad = control as RadioButtonAdv;
            if (rad != null)
            {
                rad.Style = _settings.RadioButtonStyle;
            }
        }

        private void ApplyTreeViewStyle(Control control)
        {
            var tree = control as TreeViewAdv;
            if (tree != null)
            {
                tree.MetroColor = _metroColor;
                tree.BorderColor = Color.LightGray;
                tree.BorderStyle = BorderStyle.FixedSingle;

                if (tree is TreeViewBase && !(tree as TreeViewBase).ApplyStyle)
                {
                    return;
                }

#if STYLE2010
                tree.Style = TreeStyle.Office2010;
#else
                tree.Style = TreeStyle.Metro;
#endif
            }
        }

        private void ApplySplitterStyle(Control control)
        {
            var splitter = control as SplitContainerAdv;
            if (splitter != null)
            {
#if STYLE2010
                    splitter.Style = global::Syncfusion.Windows.Forms.Tools.Enums.Style.Office2007Blue;
#else
                splitter.Style = Syncfusion.Windows.Forms.Tools.Enums.Style.Mozilla;
#endif
            }
        }

        private void ApplyMultiColumnTreeViewStyle(Control control)
        {
            var multiTreeView = control as MultiColumnTreeView;
            if (multiTreeView != null)
            {
                multiTreeView.Style = MultiColumnVisualStyle.Default;
            }
        }

        private void ApplyTrackBarStyle(Control control)
        {
            var trackBar = control as TrackBarEx;
            if (trackBar != null)
            {
                trackBar.Style = TrackBarEx.Theme.Metro;
                trackBar.ChannelHeight = 6;
                trackBar.ForeColor = Color.DimGray;
            }
        }

        private void ApplyNumericUpDownStyle(Control control)
        {
            var upDown = control as NumericUpDownExt;
            if (upDown != null)
            {
#if STYLE2010
                upDown.VisualStyle = VisualStyle.VS2010;
#else
                upDown.VisualStyle = VisualStyle.Metro;
#endif
            }
        }

        private void ApplyGridStyle(Control control)
        {
            var grid = control as CustomGridControl;
            if (grid != null)
            {
                if (grid.WrapWithPanel)
                {
                    WrapByGradientPanel(grid);
                }

                grid.BorderStyle = BorderStyle.None;

#if STYLE2010   
                grid.GridOfficeScrollBars = OfficeScrollBars.Office2010;
                grid.GridVisualStyles = GridVisualStyles.Office2010Blue;
#else
                grid.GridOfficeScrollBars = OfficeScrollBars.Metro;
                grid.GridVisualStyles = GridVisualStyles.Custom;
                grid.TableOptions.GridVisualStyles = GridVisualStyles.Custom;
#endif
            }
        }

        private void WrapByGradientPanel(Control control)
        {
            if (control.Parent is GradientPanel)
            {
                return;     // no need to apply it twice     
            }
            
            // it seems there is no way to set decent looking border for TabControlAdv
            // so let's insert gradient panel
            var panel = new GradientPanel
            {
                BorderColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = control.Anchor,
                Dock = control.Dock
            };

            if (panel.Dock == DockStyle.Fill)
            {
                panel.BringToFront();
            }

            panel.MakeSameSize(control);

            if (control.Parent != null)
            {
                control.Parent.Controls.Add(panel);
                control.Parent.Controls.Remove(control);
            }

            panel.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void ApplyTabStyle(Control control)
        {
            var tab = control as TabControlAdv;
            if (tab != null)
            {
                WrapByGradientPanel(tab);

#if STYLE2010
                tab.TabStyle = typeof(TabRendererOffice2007);
#else

                tab.PersistTabState = false;
                tab.BorderStyle = BorderStyle.None;
                tab.BorderVisible = false;
                tab.FocusOnTabClick = false;
                tab.RotateTextWhenVertical = true;

                if (tab.Alignment == TabAlignment.Left)
                {
                    tab.TabStyle = typeof(TabRendererMetro);
                    tab.TextLineAlignment = StringAlignment.Near;
                    tab.ActiveTabFont = tab.Font;
                    tab.Padding = new Point(7, 10);
                    tab.ActiveTabColor = Color.FromKnownColor(KnownColor.Control); 
                    tab.TabPanelBackColor = Color.Gray; 
                    tab.InactiveTabColor = Color.Gray;
                }
                else
                {
                    tab.Padding = new Point(10, 5);
                    tab.TabStyle = typeof(TabRendererBlendDark);
                }

                tab.FixedSingleBorderColor = _metroColor;
#endif
            }
        }
    }
}
