using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.UI.Syncfusion
{
    public interface IStyleService
    {
        void ApplyStyle(Form form);
        void ApplyStyle(Control control);
    }
}
