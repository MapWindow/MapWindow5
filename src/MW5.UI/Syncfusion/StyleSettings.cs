using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Syncfusion
{
    public class ControlStyleSettings
    {
        private static ControlStyleSettings _instance;

        public static ControlStyleSettings Instance
        {
            get
            {
                return _instance ?? (_instance = new ControlStyleSettings()
                {
                    ButtonAppearance = ButtonAppearance.Metro,
                    VisualStyle = VisualStyle.Metro,
                    TextboxTheme = TextBoxExt.theme.Metro,
                    CheckboxStyle = CheckBoxAdvStyle.Metro,
                    RadioButtonStyle = RadioButtonAdvStyle.Metro,
                });
            }
        }

        public RadioButtonAdvStyle RadioButtonStyle { get; set; }
        public TextBoxExt.theme TextboxTheme { get; set; }
        public ButtonAppearance ButtonAppearance { get; set; }
        public VisualStyle VisualStyle { get; set; }
        public CheckBoxAdvStyle CheckboxStyle { get; set; }
    }
}
