using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class WmsProviderCollection: IComWrapper
    {
        private readonly WmsProviders _providers;

        internal WmsProviderCollection(WmsProviders providers)
        {
            if (providers == null) throw new ArgumentNullException("providers");
            _providers = providers;
        }

        public object InternalObject
        {
            get { return _providers; }
        }

        public string LastError
        {
            get { return _providers.ErrorMsg[_providers.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _providers.Key; }
            set { _providers.Key = value; }
        }

        public void Add(WmsProviderDef provider)
        {
            if (provider == null) throw new ArgumentException("provider");

            _providers.Add(provider.GetInternal());
        }

        public void Clear()
        {
            _providers.Clear();
        }

        public bool Remove(int providerId)
        {
            return _providers.Remove(providerId);
        }

        public int Count
        {
            get { return _providers.Count; }
        }

        public WmsProviderDef get_Item(int Index)
        {
            var p = _providers.Item[Index];
            return p != null ? new WmsProviderDef(p) : null;
        }
    }
}
