namespace MW5.Plugins.Mef
{
    public interface IPluginMetadata
    {
        string Name { get; }
        string Author { get; }
        string Guid { get; }
        bool Empty { get; }
        bool LoadOnStartUp { get; }
    }
}
