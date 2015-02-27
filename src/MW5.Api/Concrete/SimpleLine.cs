using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class SimpleLine: IComWrapper
    {
        private readonly LineSegment _segment;

        internal SimpleLine(LineSegment segment)
        {
            _segment = segment;
            if (segment == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public object InternalObject
        {
            get { return _segment; }
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

        public Color Color
        {
            get { return ColorHelper.UintToColor(_segment.Color); }
            set { _segment.Color = ColorHelper.ColorToUInt(value); }
        }

        public float LineWidth
        {
            get { return _segment.LineWidth; }
            set { _segment.LineWidth = value; }
        }

        public DashStyle LineStyle
        {
            get { return (DashStyle)_segment.LineStyle; }
            set { _segment.LineStyle = (tkDashStyle)value; }
        }

        public LineType LineType
        {
            get { return (LineType)_segment.LineType; }
            set { _segment.LineType = (tkLineType)value; }
        }

        public VectorMarker Marker
        {
            get { return (VectorMarker)_segment.Marker; }
            set { _segment.Marker = (tkDefaultPointSymbol)value; }
        }

        public float MarkerSize
        {
            get { return _segment.MarkerSize; }
            set { _segment.MarkerSize = value; }
        }

        public float MarkerInterval
        {
            get { return _segment.MarkerInterval; }
            set { _segment.MarkerInterval = value; }
        }

        public LabelOrientation MarkerOrientation
        {
            get { return (LabelOrientation)_segment.MarkerOrientation; }
            set { _segment.MarkerOrientation = (tkLineLabelOrientation)value; }
        }

        public bool MarkerFlipFirst
        {
            get { return _segment.MarkerFlipFirst; }
            set { _segment.MarkerFlipFirst = value; }
        }

        public float MarkerOffset
        {
            get { return _segment.MarkerOffset; }
            set { _segment.MarkerOffset = value; }
        }

        public Color MarkerOutlineColor
        {
            get { return ColorHelper.UintToColor(_segment.MarkerOutlineColor); }
            set { _segment.MarkerOutlineColor = ColorHelper.ColorToUInt(value); }
        }

        #region Not implemented

        //public bool Draw(IntPtr hDC, float x, float y, int clipWidth, int clipHeight, uint backColor = 16777215)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool DrawVB(int hDC, float x, float y, int clipWidth, int clipHeight, uint backColor = 16777215)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }
}
