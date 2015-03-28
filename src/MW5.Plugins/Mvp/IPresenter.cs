
namespace MW5.Plugins.Mvp
{
    public interface IPresenter
    {
        bool Success { get; }
        bool Run(bool modal = true);
        bool ViewOkClicked();
    }

    public interface IPresenter<in TArg>: IPresenter
    {
        bool Run(TArg argument, bool modal = true);
        void Init(TArg arg);
    }
}
