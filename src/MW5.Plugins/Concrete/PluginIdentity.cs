using System;
using MW5.Api.Concrete;

namespace MW5.Plugins.Concrete
{
    public class PluginIdentity: CompareByValueBase, IEquatable<PluginIdentity>
    {
        private string _name;
        private string _author;
        private Guid _guid;

        internal static PluginIdentity Default
        {
            get
            {
                return new PluginIdentity("MapWindow Core App", "MapWindow Open Source Team",
                    new Guid("F6D7BB9C-8E9E-4A8A-89BA-D4E1665825B3"), true);
            }
        }

        public string GetUniqueKey(string key)
        {
            return key + Guid;
        }

        internal PluginIdentity(bool loadOnStartup)
        {
            LoadOnStartup = loadOnStartup;
        }

        internal PluginIdentity(string name, string author, Guid guid, bool loadOnStartup)
        {
            _name = name;
            _author = author;
            _guid = guid;
            LoadOnStartup = loadOnStartup;
        }

        public Guid Guid
        {
            get { return _guid; }
        }

        public string Name
        {
            get { return _name; } 
        }

        public string Author
        {
            get { return _author; }
        }

        public bool LoadOnStartup { get; private set; }

        public bool Equals(PluginIdentity other)
        {
            return Guid == other.Guid;
        }

        public override bool Equals(object obj)
        {
            return Guid == ((PluginIdentity)obj).Guid;
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} : {1}", Name, Guid);
        }
    }
}
