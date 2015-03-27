namespace MW5.Plugins.Mvp
{
    public interface IPresenter
    {
        bool Run(bool modal = true);
    }

    public interface IPresenter<in TArg>
    {
        bool Run(TArg argument, bool modal = true);
    }
}
