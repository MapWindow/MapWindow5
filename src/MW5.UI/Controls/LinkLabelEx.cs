using System.Windows.Forms;

namespace MW5.UI.Controls
{
    public class LinkLabelEx: LinkLabel
    {
        public new string Text 
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                LinkArea = new LinkArea(0, Text.Length);
            }
        }

        public void SetText(string text, int startUnderlingIndex, int endUnderlineIndex)
        {
            base.Text = text;
            LinkArea = new LinkArea(startUnderlingIndex, endUnderlineIndex);
        }
    }
}
