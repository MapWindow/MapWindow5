using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Shared
{
    public class ControlHelper
    {
        public static void MakeSameSize(Control source, Control target)
        {
            target.Left = source.Left;
            target.Top = source.Top;
            target.Width = source.Width;
            target.Height = source.Height;
        }
    }
}
