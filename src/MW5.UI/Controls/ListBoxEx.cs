using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.UI.Controls
{
    public class ListBoxEx: ListBox
    {
        private StringFormat _format = new StringFormat() { LineAlignment = StringAlignment.Center };

        public ListBoxEx()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DrawItem += ListBoxColumnsDrawItem;    
        }

        public StringAlignment Alignment
        {
            get { return _format.LineAlignment; }
            set { _format.LineAlignment = value; }
        }

        private void ListBoxColumnsDrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.State == DrawItemState.Focus)
            {
                e.DrawFocusRectangle();
            }

            var index = e.Index;
            if (index < 0 || index >= Items.Count)
            {
                return;
            }

            var item = Items[index];
            string text = (item == null) ? "(null)" : item.ToString();

            using (var brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                e.Graphics.DrawString(text, e.Font, brush, e.Bounds, _format);
            }
        }
    }
}
