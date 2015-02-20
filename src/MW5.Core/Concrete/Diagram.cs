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
