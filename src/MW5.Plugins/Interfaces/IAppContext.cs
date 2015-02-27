using MW5.Api.Interfaces;

namespace MW5.Plugins.Interfaces
{
    public interface IAppContext
    {
        IMapControl Map { get; }
        IMainForm Form { get; }
        IMenu Menu { get; }
        bool Initialized { get; }
        void Init(IMainForm form);
    }
}
