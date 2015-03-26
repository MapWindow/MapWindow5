namespace MW5.Plugins.Mvp
{
    public interface IPresenter
    {
        void Run(bool dialog = true);
    }

    public interface IPresenter<in TArg>
    {
        void Run(TArg argument, bool dialog = true);
    }
}
