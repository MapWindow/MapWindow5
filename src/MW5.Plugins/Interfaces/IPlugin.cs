using System;

namespace MW5.Plugins.Interfaces
{
    public interface IPlugin
    {
        string Description { get; }

        void Initialize(IAppContext context);

        void Terminate();

        //string Author { get; }
        //Guid Guid { get; }
        //string Name { get; }
    }
}
