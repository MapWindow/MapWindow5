using System.Windows.Forms;

namespace MW5.UI.Style
{
    public interface IStyleService
    {
        void ApplyStyle(Form form);
        void ApplyStyle(Control control);
    }
}
