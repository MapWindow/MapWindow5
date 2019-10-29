using System.ComponentModel;

namespace MW5.Plugins.Mef
{
    public interface IPluginMetadata
    {
        string Name { get; }
        string Author { get; }
        string Guid { get; }
        bool Empty { get; }
        bool LoadOnStartUp { get; }

        [DefaultValue(new string[] { })]
        string[] Before { get; }

        [DefaultValue(new string[] { })]
        string[] After { get; }
    }
}
