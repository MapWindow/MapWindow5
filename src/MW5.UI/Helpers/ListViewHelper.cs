using System.Windows.Forms;

namespace MW5.UI.Helpers
{
    public static class ListViewHelper
    {
        /// <summary>
        /// Resizes columns by both header and content
        /// Probably it's possible to do without additional codeing, but I haven't found how
        /// </summary>
        public static void AutoResizeColumns(ListView listView1)
        {
            foreach (ColumnHeader cmn in listView1.Columns)
            {
                int cmnIndex = cmn.Index;
                int maxLength = 0;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    int length = listView1.Items[i].SubItems[cmnIndex].Text.Length;
                    if (length > maxLength)
                    {
                        maxLength = length;
                    }
                }

                ColumnHeaderAutoResizeStyle style = maxLength > cmn.Text.Length ? ColumnHeaderAutoResizeStyle.ColumnContent : ColumnHeaderAutoResizeStyle.HeaderSize;
                cmn.AutoResize(style);
            }
        }
    }
}
