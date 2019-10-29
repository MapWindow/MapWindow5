using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.UI.Menu
{
    internal abstract class MenuItemBase
    {
        public abstract bool HasKey { get; }

        public string Key
        {
            get { return Metadata?.Key; }
        }

        public object Tag
        {
            get { return Metadata?.Tag; }
            set { Metadata.Tag = value; }
        }

        public PluginIdentity PluginIdentity
        {
            get
            {
                return Metadata?.PluginIdentity;
            }
        }

        public bool BeginGroup
        {
            get { return Metadata?.BeginGroup ?? false; }
            set { Metadata.BeginGroup = value; }
        }

        public string Description
        {
            get { return Metadata?.Description; }
            set
            {
                Metadata.Description = value;
                FireItemChanged();
            }
        }

        public string UniqueKey
        {
            get { return Key + PluginIdentity?.Guid; }
        }

        protected abstract MenuItemMetadata Metadata { get; }

        protected void FireItemChanged([CallerMemberName] string propertyName = null)
        {
            ItemChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event EventHandler<PropertyChangedEventArgs> ItemChanged;
    }
}
