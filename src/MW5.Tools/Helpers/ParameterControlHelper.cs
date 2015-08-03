using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Views.Controls;

namespace MW5.Tools.Helpers
{
    internal static class ParameterControlHelper
    {
        public static void SetCaption(this IParameterControl ctrl, string caption)
        {
            ctrl.Caption = caption;

            if (ctrl is BooleanParameterControl)
            {
                // do nothing
            }
            else
            {
                if (!ctrl.Caption.Trim().EndsWith(":"))
                {
                    ctrl.Caption += ":";
                }
            }
        }
    }
}
