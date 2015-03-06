using System;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Syncfusion
{
    public class SyncfusionStyleService
    {
        private readonly ControlStyleSettings _settings;

        public SyncfusionStyleService(ControlStyleSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            _settings = settings;
        }

        public void ApplyStyle(MetroForm form)
        {
            ApplyStyle(form.Controls);
        }

        private void ApplyStyle(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                var btn = control as ButtonAdv;
                if (btn != null)
                {
                    btn.Appearance = _settings.ButtonAppearance;
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
                }

                var rad = control as RadioButtonAdv;
                if (rad != null)
                {
                    rad.Style = _settings.RadioButtonStyle;
                }

                ApplyStyle(control.Controls);
            }
        }
    }
}
