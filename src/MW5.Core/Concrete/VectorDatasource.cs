using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class VectorDatasource: IVectorDatasource
    {
        private readonly OgrDatasource _datasource;

        internal VectorDatasource(OgrDatasource datasource)
        {
            _datasource = datasource;
            if (datasource == null)
            {
                throw new NullReferenceException("Internal style reference is null.");
            }
        }

        public object InternalObject
        {
            get { return _datasource; }
        }

        public string LastError
        {
            get { return _datasource.ErrorMsg[_datasource.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _datasource.Key; }
            set { _datasource.Key = value; }
        }


        public string Filename
        {
            get
            {
                // TODO: implement in ocx
                //return _datasource.ConnectionString;
                throw new NotImplementedException();
            }
        }

        public void Close()
        {
            _datasource.Close();
        }

        public string OpenDialogFilter
        {
            get { return GeoSourceManager.VectorFilter; }
        }
    }
}
