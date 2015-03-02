using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;

namespace MW5.Mvp
{
    public interface IView
    {
        void ShowView();
        void Close();
        void UpdateView();
    }

    public interface IComplexView: IView
    {
        IEnumerable<IToolbar> Toolbars { get; }
    }
}
