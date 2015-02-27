using System;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class Diagram: IComWrapper
    {
        private readonly Chart _chart;

        public Diagram(Chart chart)
        {
            _chart = chart;
            if (chart == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public object InternalObject
        {
            get { return _chart; }
        }

        public string LastError
        {
            get { return ErrorHelper.NO_ERROR; }
        }

        public string Tag
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public double PositionX
        {
            get { return _chart.PositionX; }
            set { _chart.PositionX = value; }
        }

        public double PositionY
        {
            get { return _chart.PositionY; }
            set { _chart.PositionY = value; }
        }

        public bool Visible
        {
            get { return _chart.Visible; }
            set { _chart.Visible = value; }
        }

        public bool IsDrawn
        {
            get { return _chart.IsDrawn; }
        }

        public IEnvelope ScreenExtents
        {
            get { return new Envelope(_chart.ScreenExtents); }
        }
    }
}
