using System;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Interfaces
{
    public interface IPlugin
    {
        string Description { get; }

        void Initialize(IAppContext context);

        void Terminate();
    }
}
