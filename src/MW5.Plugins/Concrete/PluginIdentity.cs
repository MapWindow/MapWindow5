using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Concrete
{
    public class PluginIdentity: IEquatable<PluginIdentity>
    {
        private string _name;
        private string _author;
        private Guid _guid;

        internal static PluginIdentity Default
        {
            get
            {
                return new PluginIdentity("MapWindow Core App", "MapWindow Open Source Team",
                    new Guid("F6D7BB9C-8E9E-4A8A-89BA-D4E1665825B3"));
            }
        }

        internal PluginIdentity(string name, string author, Guid guid)
        {
            _name = name;
            _author = author;
            _guid = guid;
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

        public static bool operator ==(PluginIdentity id1, PluginIdentity id2)
        {
            bool null1 = ReferenceEquals(id1, null);
            bool null2 = ReferenceEquals(id2, null);
            if (null1 && null2)
            {
                return true;
            }
            if (null1 != null2)
            {
                return false;
            }
            return id1.Equals(id2);
        }

        public static bool operator !=(PluginIdentity id1, PluginIdentity id2)
        {
            bool null1 = ReferenceEquals(id1, null);
            bool null2 = ReferenceEquals(id2, null);
            if (null1 && null2)
            {
                return false;
            }
            if (null1 != null2)
            {
                return true;
            }
            return !id1.Equals(id2);
        }
    }
}
