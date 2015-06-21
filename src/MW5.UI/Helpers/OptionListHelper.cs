using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.UI.Forms;

namespace MW5.UI.Helpers
{
    public static class OptionListHelper
    {
        public static bool Select<T>(IEnumerable<T> list, ref T item, string message, IWin32Window parent)
            where T: struct, IConvertible
        {
            var form = new TypedOptionsForm<T>(list, message) { SelectedItem = item };

            if (form.ShowDialog(parent) == DialogResult.OK)
            {
                item = form.SelectedItem;
                return true;
            }

            return false;
        }
    }
}
