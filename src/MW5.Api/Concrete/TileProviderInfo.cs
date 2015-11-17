using System;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class TileProviderInfo
    {
        private readonly TileProviders _providers;
        private readonly int _index;

        internal TileProviderInfo(TileProviders providers, int index)
        {
            _providers = providers;
            _index = index;
            if (providers == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
            if (index < 0 || index >= providers.Count)
            {
                throw new IndexOutOfRangeException("Invalid index of tile provider.");
            }
        }

        public int Id
        {
            get { return _providers.Id[_index]; }
        }

        public string Name
        {
            get { return _providers.Name[_index]; }
            set { _providers.Name[_index] = value; }
        }

        public string UrlPattern
        {
            get { return _providers.UrlPattern[_index]; }
        }

        public TileProjection Projection
        {
            get { return (TileProjection)_providers.Projection[_index]; }
        }

        public int MinZoom
        {
            get { return _providers.MinZoom[_index]; }
        }

        public int MaxZoom
        {
            get { return _providers.MaxZoom[_index]; }
        }

        public string Version
        {
            get { return _providers.Version[_index]; }
            set { _providers.Version[_index] = value; }
        }

        public string Language
        {
            get { return _providers.Language[_index]; }
            set { _providers.Language[_index] = value; }
        }

        public bool Custom
        {
            get { return _providers.IsCustom[_index]; }
        }

        public IEnvelope GeographicBounds
        {
            get
            {
                var box = _providers.GeographicBounds[_index];
                return box != null ? new Envelope(box) : null;
            }

            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _providers.GeographicBounds[_index] = value.GetInternal();
            }
        }
    }
}
