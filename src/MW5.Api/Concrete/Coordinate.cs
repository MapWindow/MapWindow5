using System;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class Coordinate : ICoordinate
    {
        private readonly Point _point;

        public Coordinate(double x, double y)
        {
            _point = new Point {x = x, y = y};
        }

        internal Coordinate(Point point)
        {
            _point = point;
        }

        public double X
        {
            get { return _point.x; }
            set { _point.x = value; }
        }

        public double Y
        {
            get { return _point.y; }
            set { _point.y = value; }
        }

        public double Z
        {
            get { return _point.Z; }
            set { _point.Z = value; }
        }

        public double M
        {
            get { return _point.M; }
            set { _point.M = value; }
        }

        public object InternalObject
        {
            get { return _point; }
        }

        public string LastError
        {
            get { return ErrorHelper.NO_ERROR; }   // it's not defined in ocx
        }

        public string Tag
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }
    }
}