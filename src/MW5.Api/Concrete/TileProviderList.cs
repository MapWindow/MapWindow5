using System;
using System.Collections;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class TileProviderList: IEnumerable<TileProviderInfo>, IComWrapper
    {
        private readonly TileProviders _providers;

        public TileProviderList(TileProviders providers)
        {
            _providers = providers;
            if (providers == null)
            {
                throw new NullReferenceException("Internal style reference is null.");
            }
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
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public IEnumerator<TileProviderInfo> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                var l = this[i];
                if (l == null)
                {
                    break;
                }
                yield return l;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TileProviderInfo this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return new TileProviderInfo(_providers, index);
                }
                return null;
            }
        }

        public bool Remove(int providerId, bool clearCache)
        {
            return _providers.Remove(providerId, clearCache);
        }

        public void Clear(bool clearCache)
        {
            _providers.Clear(clearCache);
        }

        public bool AddCustom(int id, string name, string urlPattern, TileProjection projection, int minZoom = 0, int maxZoom = 17)
        {
            return _providers.Add(id, name, urlPattern, (tkTileProjection)projection, minZoom, maxZoom);
        }

        public int Count
        {
            get { return _providers.Count; }
        }

        public int get_IndexByProvider(TileProvider provider)
        {
            return _providers.IndexByProvider[(tkTileProvider)provider];
        }

        public int get_IndexByProviderId(int providerId)
        {
            return _providers.IndexByProviderId[providerId];
        }
    }
}
