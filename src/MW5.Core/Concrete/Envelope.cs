using System;
using MapWinGIS;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class Envelope: IEnvelope
    {
        private readonly Extents _extents;

        public Envelope()
        {
            _extents = new Extents();    // initialized with zeroes
        }

        public Envelope(double xMin, double xMax, double yMin, double yMax)
        {
            _extents = new Extents();
            _extents.SetBounds(xMin, yMin, 0.0, xMax, yMax, 0.0);
        }

        internal Envelope(Extents extents)
        {
            _extents = extents;
        }

        public double MinX
        {
            get { return _extents.xMin; }
        }

        public double MinY
        {
            get { return _extents.yMin; }
        }

        public double MinZ
        {
            get { return _extents.zMin; }
        }

        public double MinM
        {
            get { return _extents.mMin; }
        }

        public double MaxX
        {
            get { return _extents.xMax; }
        }

        public double MaxY
        {
            get { return _extents.yMax; }
        }

        public double MaxZ
        {
            get { return _extents.zMax; }
        }

        public double MaxM
        {
            get { return _extents.mMax; }
        }

        public object InternalObject
        {
            get { return _extents; }
        }

        public string LastError
        {
            get { return ErrorHelper.NO_ERROR; }   // it's not defined in ocx
        }

        public string Tag
        {
            get
            {
                return "";
                //throw new NotSupportedException(); 
            }
            set
            {
                //throw new NotSupportedException();

            }
        }
    }
}
