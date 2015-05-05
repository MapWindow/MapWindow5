using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class MeasurerSettings : IMeasuringSettings
    {
        private readonly IMeasuring _measuring;

        public MeasurerSettings(IMeasuring measuring)
        {
            _measuring = measuring;
        }

        public double Length
        {
            get { return _measuring.Length; }
        }

        public double Area
        {
            get { return _measuring.Area; }
        }

        public bool ShowBearing
        {
            get { return _measuring.ShowBearing; }
            set { _measuring.ShowBearing = value; }
        }

        public BearingType BearingType
        {
            get { return (BearingType)_measuring.BearingType; }
            set { _measuring.BearingType = (tkBearingType)value; }
        }

        public bool ShowLength
        {
            get { return _measuring.ShowLength; }
            set { _measuring.ShowLength = value; }
        }

        public LengthDisplay LengthUnits
        {
            get { return (LengthDisplay)_measuring.LengthUnits; }
            set { _measuring.LengthUnits = (tkLengthDisplayMode)value; }
        }

        public AreaDisplay AreaUnits
        {
            get { return (AreaDisplay)_measuring.AreaUnits; }
            set { _measuring.AreaUnits = (tkAreaDisplayMode)value; }
        }

        public AngleFormat AngleFormat
        {
            get { return (AngleFormat)_measuring.AngleFormat; }
            set { _measuring.AngleFormat = (tkAngleFormat)value; }
        }

        public int AnglePrecision
        {
            get { return _measuring.AnglePrecision; }
            set { _measuring.AnglePrecision = value; }
        }

        public int AreaPrecision
        {
            get { return _measuring.AreaPrecision; }
            set { _measuring.AreaPrecision = value; }
        }

        public int LengthPrecision
        {
            get { return _measuring.LengthPrecision; }
            set { _measuring.LengthPrecision = value; }
        }

        public bool PointsVisible
        {
            get { return _measuring.PointsVisible; }
            set { _measuring.PointsVisible = value; }
        }

        public Color LineColor
        {
            get { return ColorHelper.UintToColor(_measuring.LineColor); }
            set { _measuring.LineColor = ColorHelper.ColorToUInt(value); }
        }

        public Color FillColor
        {
            get { return ColorHelper.UintToColor(_measuring.FillColor); }
            set { _measuring.FillColor = ColorHelper.ColorToUInt(value); }
        }

        public byte FillTransparency
        {
            get { return _measuring.FillTransparency; }
            set { _measuring.FillTransparency = value; }
        }

        public float LineWidth
        {
            get { return _measuring.LineWidth; }
            set { _measuring.LineWidth = value; }
        }

        public DashStyle LineStyle
        {
            get { return (DashStyle)_measuring.LineStyle; }
            set { _measuring.LineStyle = (tkDashStyle)value; }
        }

        public bool PointLabelsVisible
        {
            get { return _measuring.PointLabelsVisible; }
            set { _measuring.PointLabelsVisible = value; }
        }

        public bool ShowTotalLength
        {
            get { return _measuring.ShowTotalLength; }
            set { _measuring.ShowTotalLength = value; }
        }
    }
}
