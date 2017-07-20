using System;
using System.ComponentModel.Composition;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Mef
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property), MetadataAttribute]
    public class MapWindowPluginAttribute : ExportAttribute, IPluginMetadata
    {
        private string _name;
        private string _author;
        private string _guid;
        private bool _empty;
        private bool _loadOnStartUp = false;

        public MapWindowPluginAttribute()
            : base(typeof(IPlugin))
        {
            _empty = true;
        }

        public MapWindowPluginAttribute(bool loadOnStartUp)
            : base(typeof(IPlugin))
        {
            _empty = true;
            _loadOnStartUp = loadOnStartUp;
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

            _empty = false;
            _author = author;
            _name = name;
            _guid = guid;
        }

        public bool Empty
        {
            get { return _empty; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Author
        {
            get { return _author; }
        }

        public string Guid
        {
            get { return _guid; }
        }

        public bool LoadOnStartUp
        {
            get { return _loadOnStartUp; }
        }
    }
}
