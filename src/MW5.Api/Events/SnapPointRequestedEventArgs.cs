using AxMapWinGIS;
using MapWinGIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Events
{
    public class SnapPointRequestedEventArgs : EventArgs
    {
        private readonly _DMapEvents_SnapPointRequestedEvent _args;

        public SnapPointRequestedEventArgs(double pointX, double pointY, double snappedX, double snappedY, bool isFound, bool isFinal)
            : this(new _DMapEvents_SnapPointRequestedEvent(pointX, pointY, snappedX, snappedY, isFound ? tkMwBoolean.blnTrue : tkMwBoolean.blnFalse, isFinal ? tkMwBoolean.blnTrue : tkMwBoolean.blnFalse))
        {
        }

        internal SnapPointRequestedEventArgs(_DMapEvents_SnapPointRequestedEvent args)
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

        public bool IsFinal
        {
            get { return _args.isFinal == tkMwBoolean.blnTrue ? true : false; }
            set { _args.isFinal = value ? tkMwBoolean.blnTrue : tkMwBoolean.blnFalse; }
        }

        public bool IsFound
        {
            get { return _args.isFound == tkMwBoolean.blnTrue ? true : false; }
            set { _args.isFound = value ? tkMwBoolean.blnTrue : tkMwBoolean.blnFalse; }
        }
    }
}
