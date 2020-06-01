using System;
using System.ComponentModel.Composition;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Mef
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property), MetadataAttribute]
    public class MapWindowPluginAttribute : ExportAttribute, IPluginMetadata
    {

        public MapWindowPluginAttribute()
            : base(typeof(IPlugin))
        {
            Empty = true;
        }

        public MapWindowPluginAttribute(bool loadOnStartUp)
            : base(typeof(IPlugin))
        {
            Empty = true;
            LoadOnStartUp = loadOnStartUp;
        }

        public MapWindowPluginAttribute(string name, string author, string guid)
            : base(typeof(IPlugin))
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Plugin requires a name.");
            }
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Plugin author is not specified.");
            }

            try
            {
                var temp = new Guid(guid);
            }
            catch (Exception)
            {
                throw new ApplicationException("Invalid Guid value.");
            }

            Empty = false;
            Author = author;
            Name = name;
            Guid = guid;
        }

        public bool Empty { get; }

        public string Name { get; }

        public string Author { get; }

        public string Guid { get; }

        public bool LoadOnStartUp { get; } = false;

        public string[] Before { get; set; } = new string[] { };
        public string[] After { get; set; } = new string[] { };
    }
}
