using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class GridSourceHeader: IComWrapper
    {
        private readonly GridHeader _header;

        internal GridSourceHeader(GridHeader header)
        {
            _header = header;
            if (header != null)
            {
                throw new NullReferenceException("Internal reference is null");
            }
        }

        public object InternalObject
        {
            get { return _header; }
        }

        public string LastError
        {
            get { return _header.ErrorMsg[_header.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _header.Key; }
            set { _header.Key = value; }
        }

        public void CopyFrom(GridSourceHeader header)
        {
            _header.CopyFrom(header.GetInternal());
        }

        public int NumberCols
        {
            get { return _header.NumberCols; }
            set { _header.NumberCols = value; }
        }

        public int NumberRows
        {
            get { return _header.NumberRows; }
            set { _header.NumberRows = value; }
        }

        public object NodataValue
        {
            get { return _header.NodataValue; }
            set { _header.NodataValue = value; }
        }

        public double Dx
        {
            get { return _header.dX; }
            set { _header.dX = value; }
        }

        public double Dy
        {
            get { return _header.dY; }
            set { _header.dY = value; }
        }

        public double XllCenter
        {
            get { return _header.XllCenter; }
            set { _header.XllCenter = value; }
        }

        public double YllCenter
        {
            get { return _header.YllCenter; }
            set { _header.YllCenter = value; }
        }

        public string Notes
        {
            get { return _header.Notes; }
            set { _header.Notes = value; }
        }

        public string ColorTable
        {
            get { return _header.ColorTable; }
            set { _header.ColorTable = value; }
        }

        public ISpatialReference GeoProjection
        {
            get { return new SpatialReference(_header.GeoProjection); }
            set { _header.GeoProjection = value.GetInternal(); }
        }

        #region Not implemented

        public string Projection
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion
    }
}
