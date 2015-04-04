using System;
using System.Drawing;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
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

        public void SetBounds(double xMin, double xMax, double yMin, double yMax)
        {
            _extents.SetBounds(xMin, yMin, 0.0, xMax, yMax, 0.0);
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

        public override string ToString()
        {
            return _extents.ToDebugString();
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle((int) MinX, (int) MinY, (int) (MaxX - MinX), (int) (MaxY - MinY));
        }

        public IEnvelope Move(double dx, double dy)
        {
            double xMin, xMax, yMin, yMax, zMin, zMax;
            _extents.GetBounds(out xMin, out yMin, out zMin, out xMax, out yMax, out zMax);
            return new Envelope(xMin + dx, xMax + dx, yMin + dy, yMax + dy);
        }

        public double Width
        {
            get { return MaxX - MinX; }
        }

        public double Height
        {
            get { return MaxY - MinY; }
        }

        public ICoordinate Center
        {
            get { return new Coordinate(MinX + Width/2, MinY + Height/2); }
        }

        public IEnvelope Adjust(double xyRatio)
        {
            double ratio = Width/Height;

            if (Math.Abs(ratio - xyRatio) < 10e-8)
            {
                return new Envelope(MinX, MaxX, MinY, MaxY);
            }

            if (ratio > xyRatio)
            {
                double height = Width/xyRatio;
                return new Envelope(MinX, MaxX, Center.Y - height/2, Center.Y + height/2);
            }
            else
            {
                double width = Height * xyRatio;
                return new Envelope(Center.X - width / 2, Center.X + width / 2, MinY, MaxY);
            }
        }

        public bool PointWithin(double x, double y)
        {
            return x >= MinX && 
                   x <= MaxX && 
                   y >= MinY && 
                   y <= MaxY;
        }
    }
}
