using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Shared
{
    public static class RichTextBoxHelper
    {
        public static void MakeFirstLineBold(this RichTextBox box)
        {
            var text = box.Text;
            int pos = text.IndexOf("\n", StringComparison.Ordinal);

            if (pos != -1)
            {
                box.Select(0, pos + 1);
                box.SelectionFont = new Font(box.Font, FontStyle.Bold);
            }
        }
    }
}
