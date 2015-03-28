
using System.Windows.Forms;

namespace MW5.Plugins.Mvp
{
    public interface IPresenter
    {
        bool Success { get; }
        bool Run(IWin32Window parent = null);
        bool ViewOkClicked();
        IWin32Window ViewHandle { get; }
    }

    public interface IPresenter<in TArg>: IPresenter
    {
        bool Run(TArg argument, IWin32Window parent = null);
        void Init(TArg arg);
    }
}
