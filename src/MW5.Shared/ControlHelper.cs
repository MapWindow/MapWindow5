using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Shared
{
    public static class ControlHelper
    {
        public static void MakeSameSize(this Control target, Control source)
        {
            target.Left = source.Left;
            target.Top = source.Top;
            target.Width = source.Width;
            target.Height = source.Height;
        }

        public static void MakeSameLocation(this Control target , Control source)
        {
            target.Left = source.Left;
            target.Top = source.Top;
        }
    }
}
