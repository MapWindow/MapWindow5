using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Plugins.Mvp
{
    public interface IViewInternal
    {
        void ShowView(IWin32Window parent = null);
        void Close();
        bool Visible { get; }
        event Action OkClicked;
        ViewStyle Style { get; }
        void BeforeClose();
        void UpdateView();
    }

    public interface IViewInternal<TModel>: IViewInternal
    {
        void InitInternal(TModel model);
        TModel Model { get; }
    }
}
