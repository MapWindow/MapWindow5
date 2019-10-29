using AxMapWinGIS;
using MapWinGIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Events
{
    public class SnapPointFoundEventArgs : EventArgs
    {
        private readonly _DMapEvents_SnapPointFoundEvent _args;

        public SnapPointFoundEventArgs(double pointX, double pointY, double snappedX, double snappedY)
            : this(new _DMapEvents_SnapPointFoundEvent(pointX, pointY, snappedX, snappedY))
        {
        }

        internal SnapPointFoundEventArgs(_DMapEvents_SnapPointFoundEvent args)
        {
            _args = args;
            if (args == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public double PointX
        {
            get { return _args.pointX; }
            set { _args.pointX = value; }
        }

        public double PointY
        {
            get { return _args.pointY; }
            set { _args.pointY = value; }
        }


        public double SnappedX
        {
            get { return _args.snappedX; }
            set { _args.snappedX = value; }
        }

        public double SnappedY
        {
            get { return _args.snappedY; }
            set { _args.snappedY = value; }
        }
    }
}
