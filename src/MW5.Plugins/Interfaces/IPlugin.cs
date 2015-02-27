namespace MW5.Plugins.Interfaces
{
    public interface IPlugin
    {
        string Author { get; }

        string Description { get; }

        string Name { get; }

        void Initialize(IAppContext context);

        void Terminate();
    }
}
