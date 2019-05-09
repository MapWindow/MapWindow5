using AxMapWinGIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Events
{
    public class BeforeVertexDigitizedEventArgs : EventArgs
    {
        private readonly _DMapEvents_BeforeVertexDigitizedEvent _args;

        public BeforeVertexDigitizedEventArgs(double pointX, double pointY)
            : this(new _DMapEvents_BeforeVertexDigitizedEvent(pointX, pointY))
        {
        }

        internal BeforeVertexDigitizedEventArgs(_DMapEvents_BeforeVertexDigitizedEvent args)
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
    }
}
