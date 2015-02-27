using System;
using MapWinGIS;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class GeoMeasurer: IComWrapper
    {
        private readonly Measuring _measuring;

        public GeoMeasurer(Measuring measuring)
        {
            _measuring = measuring;
            if (measuring == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public object InternalObject
        {
            get { return _measuring; }
        }

        public string LastError
        {
            get { return _measuring.ErrorMsg[_measuring.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _measuring.Key; }
            set { _measuring.Key = value; }
        }

        public bool UndoPoint()
        {
            return _measuring.UndoPoint();
        }

        public ICoordinate GetPoint(int pointIndex)
        {
            double x, y;
            if (_measuring.get_PointXY(pointIndex, out x, out y))
            {
                return new Coordinate(x, y);
            }
            return null;
        }

        public double get_AreaWithClosingVertex(double lastPointProjX, double lastPointProjY)
        {
            return _measuring.get_AreaWithClosingVertex(lastPointProjX, lastPointProjY);
        }

        public void FinishMeasuring()
        {
            _measuring.FinishMeasuring();
        }

        public void Clear()
        {
            _measuring.Clear();
        }

        public double Length
        {
            get { return _measuring.Length; }
        }

        public int PointCount
        {
            get { return _measuring.PointCount; }
        }

        public MeasuringType MeasuringType
        {
            get { return (MeasuringType)_measuring.MeasuringType; }
            set { _measuring.MeasuringType = (tkMeasuringType)value; }
        }

        public double Area
        {
            get { return _measuring.Area; }
        }

        public bool IsStopped
        {
            get { return _measuring.IsStopped; }
        }

        public bool Persistent
        {
            get { return _measuring.Persistent; }
            set { _measuring.Persistent = value; }
        }

        public bool DisplayAngles
        {
            get { return _measuring.DisplayAngles; }
            set { _measuring.DisplayAngles = value; }
        }

        public bool IsUsingEllipsoid
        {
            get { return _measuring.IsUsingEllipsoid; }
        }

        public bool IsEmpty
        {
            get { return _measuring.IsEmpty; }
        }
    }
}
