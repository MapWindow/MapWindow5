using System;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class TileManager: ISerializableComWrapper
    {
        private readonly Tiles _tiles;

        internal TileManager(Tiles tiles)
        {
            _tiles = tiles;
            if (tiles == null)
            {
                throw new NullReferenceException("Internal style reference is null.");
            }
        }

        public void ClearCache(CacheType cacheType)
        {
            _tiles.ClearCache((tkCacheType)cacheType);
        }

        public void ClearCache2(CacheType cacheType, int provider, int fromScale = 0, int toScale = 100)
        {
            _tiles.ClearCache2((tkCacheType)cacheType, provider, fromScale, toScale);
        }

        public bool SetProxy(string address, int port)
        {
            return _tiles.SetProxy(address, port);
        }

        public bool AutodetectProxy()
        {
            return _tiles.AutodetectProxy();
        }

        public int GetDiskCacheCount(int provider, int zoom, int minX, int maxX, int minY, int maxY)
        {
            return _tiles.get_DiskCacheCount(provider, zoom, minX, maxX, minY, maxY);
        }

        public bool CheckConnection(string url)
        {
            return _tiles.CheckConnection(url);
        }

        public bool SetProxyAuthentication(string username, string password, string domain)
        {
            return _tiles.SetProxyAuthentication(username, password, domain);
        }

        public void ClearProxyAuthorization()
        {
            _tiles.ClearProxyAuthorization();
        }

        public bool Visible
        {
            get { return _tiles.Visible; }
            set { _tiles.Visible = value; }
        }

        public TileProvider Provider
        {
            get { return (TileProvider)_tiles.Provider; }
            set { _tiles.Provider = (tkTileProvider)value; }
        }

        public bool GridLinesVisible
        {
            get { return _tiles.GridLinesVisible; }
            set { _tiles.GridLinesVisible = value; }
        }

        public bool get_IsCaching(CacheType cacheType)
        {
            return _tiles.DoCaching[(tkCacheType)cacheType];
        }

        public void set_IsCaching(CacheType cacheType, bool isCaching)
        {
            _tiles.DoCaching[(tkCacheType)cacheType] = isCaching;
        }

        public bool get_UseCache(CacheType cacheType)
        {
            return _tiles.UseCache[(tkCacheType)cacheType];
        }

        public void set_UseCache(CacheType cacheType, bool useCache)
        {
            _tiles.UseCache[(tkCacheType)cacheType] = useCache;
        }

        public bool UseServer
        {
            get { return _tiles.UseServer; }
            set { _tiles.UseServer = value; }
        }

        public double get_MaxCacheSize(CacheType cacheType)
        {
            return _tiles.MaxCacheSize[(tkCacheType) cacheType];
        }

        public void set_MaxCacheSize(CacheType cacheType, double maxSize)
        {
            _tiles.MaxCacheSize[(tkCacheType)cacheType] = maxSize;
        }

        public double get_CacheSize(CacheType cacheType, int provider = -1, int scale = -1)
        {
            return _tiles.CacheSize2[(tkCacheType) cacheType, provider, scale];
        }

        public string Proxy
        {
            get { return _tiles.Proxy; }
        }

        public string DiskCacheFilename
        {
            get { return _tiles.DiskCacheFilename; }
            set { _tiles.DiskCacheFilename = value; }
        }

        public TileProviderList Providers
        {
            get { return new TileProviderList(_tiles.Providers); }
        }

        public int ProviderId
        {
            get { return _tiles.ProviderId; }
        }

        public string ProviderName
        {
            get { return _tiles.ProviderName; }
        }

        public int CurrentZoom
        {
            get { return _tiles.CurrentZoom; }
        }

        public int MaxZoom
        {
            get { return _tiles.MaxZoom; }
        }

        public int MinZoom
        {
            get { return _tiles.MinZoom; }
        }

        public ISpatialReference ServerProjection
        {
            get
            {
                var gp = _tiles.ServerProjection; 
                return gp != null ?  new SpatialReference(gp) : null;
            }
        }

        public TileProjectionStatus ProjectionStatus
        {
            get { return (TileProjectionStatus)_tiles.ProjectionStatus; }
        }

        public ProxyAuthentication ProxyAuthenticationScheme
        {
            get { return (ProxyAuthentication)_tiles.ProxyAuthenticationScheme; }
            set { _tiles.ProxyAuthenticationScheme = (tkProxyAuthentication)value; }
        }

        public object InternalObject
        {
            get { return _tiles; }
        }

        public string LastError
        {
            get { return _tiles.ErrorMsg[_tiles.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _tiles.Key; }
            set { _tiles.Key = value; }
        }

        public string Serialize()
        {
            return _tiles.Serialize();
        }

        public bool Deserialize(string state)
        {
            _tiles.Deserialize(state);
            return true;
        }

        #region Prefetching ( not immediately needed )

        //public IEnvelope GetTilesIndices(IEnvelope boundsDegrees, int zoom, int providerId)
        //{
        //    return new Envelope(_tiles.GetTilesIndices(boundsDegrees.GetInternal(), zoom, providerId));
        //}

        //public IEnvelope GetTileBounds(int providerId, int zoom, int tileX, int tileY)
        //{
        //    return new Envelope(_tiles.GetTileBounds(providerId, zoom, tileX, tileY));
        //}

        // TODO: convert IStopExecution interface
        // TODO: perhaps add overloads with Envelope
        //public int Prefetch(double minLat, double maxLat, double minLng, double maxLng, int zoom, int providerId, IStopExecution stop)
        //{
        //    return _tiles.Prefetch(minLat, maxLat, minLng, maxLng, zoom, providerId, stop);
        //}

        //public int Prefetch(int minX, int maxX, int minY, int maxY, int zoom, int providerId, IStopExecution stop)
        //{
        //    return _tiles.Prefetch2(minX, maxX, minY, maxY, zoom, providerId, stop);
        //}

        //public int PrefetchToFolder(IEnvelope bounds, int zoom, int providerId, string savePath, string fileExtension,
        //    IStopExecution stop)
        //{
        //    throw new NotImplementedException();
        //}

        //public void ClearPrefetchErrors()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool StartLogRequests(string Filename, bool errorsOnly = false)
        //{
        //    throw new NotImplementedException();
        //}

        //public void StopLogRequests()
        //{
        //    throw new NotImplementedException();
        //}
        //public int MinScaleToCache
        //{
        //    get { throw new NotImplementedException(); }
        //    set { throw new NotImplementedException(); }
        //}

        //public int MaxScaleToCache
        //{
        //    get { throw new NotImplementedException(); }
        //    set { throw new NotImplementedException(); }
        //}

        //public int PrefetchErrorCount
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public int PrefetchTotalCount
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public int SleepBeforeRequestTimeout
        //{
        //    get { throw new NotImplementedException(); }
        //    set { throw new NotImplementedException(); }
        //}

        //public string LogFilename
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public bool LogIsOpened
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public bool LogErrorsOnly
        //{
        //    get { throw new NotImplementedException(); }
        //    set { throw new NotImplementedException(); }
        //}

        
        // int TilesAreInCache(Extents extents, int width, tkTileProvider provider);
        #endregion
    }
}
