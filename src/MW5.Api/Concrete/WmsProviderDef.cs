using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MapWinGIS;

namespace MW5.Api.Concrete
{
    public class WmsProviderDef: IComWrapper
    {
        private readonly WmsProvider _provider;

        public WmsProviderDef(int id, string name)
        {
            _provider = new WmsProvider() { Id = id, Name = name };
        }

        internal WmsProviderDef(WmsProvider provider)
        {
            if (provider == null) throw new ArgumentNullException("provider");
            _provider = provider;
        }

        public object InternalObject
        {
            get { return _provider; }
        }

        public string LastError
        {
            get { return _provider.ErrorMsg[_provider.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _provider.Key;  }
            set { _provider.Key = value; }
        }

        public string Name
        {
            get { return _provider.Name; }
            set { _provider.Name = value; }
        }

        public IEnvelope BoundingBox
        {
            get
            {
                return new Envelope(_provider.BoundingBox);
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                var box = value.GetInternal();
                _provider.BoundingBox = box;
            }
        }

        public int CrsEpsg
        {
            get { return _provider.CrsEpsg; }
            set { _provider.CrsEpsg = value; }
        }

        public string LayersCsv
        {
            get { return _provider.LayersCsv; }
            set { _provider.LayersCsv = value; }
        }

        public string BaseUrl
        {
            get { return _provider.BaseUrl; }
            set { _provider.BaseUrl = value; }
        }

        public int Id
        {
            get { return _provider.Id; }
            set { _provider.Id = value; }
        }
    }
}
