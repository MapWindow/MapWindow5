using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Style
{
    public class ControlStyleSettings
    {
        public ControlStyleSettings()
        {
#if STYLE2010                
            ButtonAppearance = ButtonAppearance.Office2010;
            VisualStyle = VisualStyle.Office2010;
            TextboxTheme = TextBoxExt.theme.Office2010;
            CheckboxStyle = CheckBoxAdvStyle.Office2010;
            RadioButtonStyle = RadioButtonAdvStyle.Office2010;
#else
            ButtonAppearance = ButtonAppearance.Classic;
            VisualStyle = VisualStyle.Metro;
            TextboxTheme = TextBoxExt.theme.Metro;
            CheckboxStyle = CheckBoxAdvStyle.Metro;
            RadioButtonStyle = RadioButtonAdvStyle.Metro;
#endif
        }

        public RadioButtonAdvStyle RadioButtonStyle { get; set; }
        public TextBoxExt.theme TextboxTheme { get; set; }
        public ButtonAppearance ButtonAppearance { get; set; }
        public VisualStyle VisualStyle { get; set; }
        public CheckBoxAdvStyle CheckboxStyle { get; set; }
    }
}
