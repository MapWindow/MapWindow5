using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Shared
{
    public static class NumericUpDownHelper
    {
        /// <summary>
        /// Sets the value of NumericUpDown control. The range of input value is checked.
        /// </summary>
        public static void SetValue(this NumericUpDown control, double value)
        {
            if (control == null)
            {
                return;
            }

            if (value <= (double)control.Minimum)
            {
                control.Value = control.Minimum;
            }
            else if (value >= (double) control.Maximum)
            {
                control.Value = control.Maximum;
            }
            else
            {
                control.Value = (decimal) value;
            }
        }
    }
}
