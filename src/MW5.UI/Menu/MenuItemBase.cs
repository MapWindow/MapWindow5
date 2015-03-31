using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.UI.Menu
{
    internal abstract class MenuItemBase
    {
        public string Key
        {
            get { return Metadata.Key; }
        }

        public object Tag
        {
            get { return Metadata.Tag; }
            set { Metadata.Tag = value; }
        }


        public PluginIdentity PluginIdentity
        {
            get
            {
                return Metadata.PluginIdentity;
            }
        }

        public bool BeginGroup
        {
            get { return Metadata.BeginGroup; }
            set { Metadata.BeginGroup = value; }
        }

        public string Description
        {
            get { return Metadata.Description; }
            set { Metadata.Description = value; }
        }

        public string UniqueKey
        {
            get { return Key + PluginIdentity.Guid; }
        }

        protected abstract MenuItemMetadata Metadata { get; }
    }
}
