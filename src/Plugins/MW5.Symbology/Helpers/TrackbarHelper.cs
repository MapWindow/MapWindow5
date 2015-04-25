using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Plugins.Symbology.Helpers
{
    public static class TrackbarHelper
    {
        public static void SetValue(this TrackBar tbr, float value)
        {
            SetValue(tbr, Convert.ToInt32(value));
        }

        public static void SetValue(this TrackBar tbr, int value)
        {
            if (value < tbr.Minimum)
            {
                tbr.Value = tbr.Minimum;
                return;
            }

            if (value > tbr.Maximum)
            {
                tbr.Value = tbr.Maximum;
                return;
            }

            tbr.Value = value;
        }
    }
}
