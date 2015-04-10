using System;
using System.Drawing;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class GridColorInterval: IComWrapper
    {
        private readonly GridColorBreak _colorBreak;

        internal GridColorInterval(GridColorBreak colorBreak)
        {
            _colorBreak = colorBreak;
            if (colorBreak == null)
            {
                throw new NullReferenceException("Internal reference is null");
            }
        }

        public object InternalObject
        {
            get { return _colorBreak; }
        }

        public string LastError
        {
            get { return _colorBreak.ErrorMsg[_colorBreak.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _colorBreak.Key; }
            set { _colorBreak.Key = value; }
        }

        public Color HighColor
        {
            get { return ColorHelper.UintToColor(_colorBreak.HighColor); }
            set { _colorBreak.HighColor = ColorHelper.ColorToUInt(value); }
        }

        public Color LowColor
        {
            get { return ColorHelper.UintToColor(_colorBreak.LowColor); }
            set { _colorBreak.LowColor = ColorHelper.ColorToUInt(value); }
        }

        public double HighValue
        {
            get { return _colorBreak.HighColor; }
            set { _colorBreak.HighValue = value; }
        }

        public double LowValue
        {
            get { return _colorBreak.LowValue; }
            set { _colorBreak.LowValue = value; }
        }

        public GridColoringType ColoringType
        {
            get { return (GridColoringType)_colorBreak.ColoringType; }
            set { _colorBreak.ColoringType = (ColoringType)value; }
        }

        public GridGradientModel GradientModel
        {
            get { return (GridGradientModel)_colorBreak.GradientModel; }
            set { _colorBreak.GradientModel = (GradientModel)value; }
        }

        public string Caption
        {
            get { return _colorBreak.Caption; }
            set { _colorBreak.Caption = value; }
        }
    }
}
