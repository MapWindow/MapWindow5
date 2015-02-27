using System;
using System.ComponentModel.Composition;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Mef
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property), MetadataAttribute]
    public class PluginExportAttribute : ExportAttribute, IPluginMetadata
    {
        public PluginExportAttribute(string name)
            : base(typeof(IPlugin))
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Plugin requires a name.");
            }

            Name = name;
        }
        public string Name { get; private set; }
    }
}
