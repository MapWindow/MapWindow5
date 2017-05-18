using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MW5.UI.Forms;

namespace MW5.UI.Helpers
{
    public static class OptionListHelper
    {
        public static bool Select<T>(IEnumerable<T> list, ref T item, string message, ref Color selectedColor, IWin32Window parent)
            where T: struct, IConvertible
        {
            var form = new TypedOptionsForm<T>(list, message) { SelectedItem = item, SelectedColor = selectedColor };

            if (form.ShowDialog(parent) == DialogResult.OK)
            {
                item = form.SelectedItem;
                selectedColor = form.SelectedColor;
                return true;
            }

            return false;
        }
    }
}
