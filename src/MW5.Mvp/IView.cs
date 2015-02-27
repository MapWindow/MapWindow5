using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Mvp
{
    public interface IView<in TModel>
    {
        void ShowView();
        void Close();
        ToolStripItemCollection[] Menus { get; }
        void UpdateView(TModel model);
    }
}
