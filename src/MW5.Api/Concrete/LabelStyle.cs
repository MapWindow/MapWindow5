using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class LabelStyle: ILabelStyle
    {
        private readonly LabelCategory _category;

        internal LabelStyle(LabelCategory category)
        {
            _category = category;
            if (category == null)
            {
                throw new NullReferenceException("Internal reference is null");
            }
        }

        public object InternalObject
        {
            get { return _category; }
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

        public string Serialize()
        {
            return _category.Serialize();
        }

        public bool Deserialize(string state)
        {
            _category.Deserialize(state);
            return true;
        }

        public LabelAlignment Alignment
        {
            get { return (LabelAlignment)_category.Alignment; }
            set { _category.Alignment = (tkLabelAlignment)value; }
        }

        public LabelAlignment InboxAlignment
        {
            get { return (LabelAlignment)_category.InboxAlignment; }
            set { _category.InboxAlignment = (tkLabelAlignment)value; }
        }

        public LabelOrientation Orientation
        {
            get { return (LabelOrientation)_category.LineOrientation; }
            set { _category.LineOrientation = (tkLineLabelOrientation)value; }
        }

        public bool FontBold
        {
            get { return _category.FontBold; }
            set { _category.FontBold = value; }
        }

        public Color FontColor
        {
            get { return ColorHelper.UintToColor(_category.FontColor); }
            set { _category.FontColor = ColorHelper.ColorToUInt(value); }
        }

        public Color FontColor2
        {
            get { return ColorHelper.UintToColor(_category.FontColor2); }
            set { _category.FontColor2 = ColorHelper.ColorToUInt(value); }
        }

        public LinearGradient FontGradientMode
        {
            get { return (LinearGradient)_category.FontGradientMode; }
            set { _category.FontGradientMode = (tkLinearGradientMode)value; }
        }

        public bool FontItalic
        {
            get { return _category.FontItalic; }
            set { _category.FontItalic = value; }
        }

        public string FontName
        {
            get { return _category.FontName; }
            set { _category.FontName = value; }
        }

        public Color FontOutlineColor
        {
            get { return ColorHelper.UintToColor(_category.FontOutlineColor); }
            set { _category.FontOutlineColor = ColorHelper.ColorToUInt(value); }
        }

        public bool FontOutlineVisible
        {
            get { return _category.FontOutlineVisible; }
            set { _category.FontOutlineVisible = value; }
        }

        public int FontOutlineWidth
        {
            get { return _category.FontOutlineWidth; }
            set { _category.FontOutlineWidth = value; }
        }

        public int FontSize
        {
            get { return _category.FontSize; }
            set { _category.FontSize = value; }
        }

        public bool FontStrikeOut
        {
            get { return _category.FontStrikeOut; }
            set { _category.FontStrikeOut = value; }
        }

        public byte FontTransparency
        {
            get { return (byte)_category.FontTransparency; }
            set { _category.FontTransparency = value; }
        }

        public bool FontUnderline
        {
            get { return _category.FontUnderline; }
            set { _category.FontUnderline = value; }
        }

        public Color FrameBackColor
        {
            get { return ColorHelper.UintToColor(_category.FrameBackColor); }
            set { _category.FrameBackColor = ColorHelper.ColorToUInt(value); }
        }

        public Color FrameBackColor2
        {
            get { return ColorHelper.UintToColor(_category.FrameBackColor2); }
            set { _category.FrameBackColor2 = ColorHelper.ColorToUInt(value); }
        }

        public LinearGradient FrameGradientMode
        {
            get { return (LinearGradient)_category.FrameGradientMode; }
            set { _category.FrameGradientMode = (tkLinearGradientMode)value; }
        }

        public Color FrameOutlineColor
        {
            get { return ColorHelper.UintToColor(_category.FrameOutlineColor); }
            set { _category.FrameOutlineColor = ColorHelper.ColorToUInt(value); }
        }

        public DashStyle FrameOutlineStyle
        {
            get { return (DashStyle)_category.FrameOutlineStyle; }
            set { _category.FrameOutlineStyle = (tkDashStyle)value; }
        }

        public int FrameOutlineWidth
        {
            get { return _category.FrameOutlineWidth; }
            set { _category.FrameOutlineWidth = value; }
        }

        public int FramePaddingX
        {
            get { return _category.FramePaddingX; }
            set { _category.FramePaddingX = value; }
        }

        public int FramePaddingY
        {
            get { return _category.FramePaddingY; }
            set { _category.FramePaddingY = value; }
        }

        public byte FrameTransparency
        {
            get { return (byte)_category.FrameTransparency; }
            set { _category.FrameTransparency = value; }
        }

        public FrameType FrameType
        {
            get { return (FrameType)_category.FrameType; }
            set { _category.FrameType = (tkLabelFrameType)value; }
        }

        public bool FrameVisible
        {
            get { return _category.FrameVisible; }
            set { _category.FrameVisible = value; }
        }

        public Color HaloColor
        {
            get { return ColorHelper.UintToColor(_category.HaloColor); }
            set { _category.HaloColor = ColorHelper.ColorToUInt(value); }
        }

        public int HaloSize
        {
            get { return _category.HaloSize; }
            set { _category.HaloSize = value; }
        }

        public bool HaloVisible
        {
            get { return _category.HaloVisible; }
            set { _category.HaloVisible = value; }
        }

        public Color ShadowColor
        {
            get { return ColorHelper.UintToColor(_category.ShadowColor); }
            set { _category.ShadowColor = ColorHelper.ColorToUInt(value); }
        }

        public int ShadowOffsetX
        {
            get { return _category.ShadowOffsetX; }
            set { _category.ShadowOffsetX = value; }
        }

        public int ShadowOffsetY
        {
            get { return _category.ShadowOffsetY; }
            set { _category.ShadowOffsetY = value; }
        }

        public bool ShadowVisible
        {
            get { return _category.ShadowVisible; }
            set { _category.ShadowVisible = value; }
        }

        public bool Visible
        {
            get { return _category.Visible; }
            set { _category.Visible = value; }
        }

        public double OffsetX
        {
            get { return _category.OffsetX; }
            set { _category.OffsetX = value; }
        }

        public double OffsetY
        {
            get { return _category.OffsetY; }
            set { _category.OffsetY = value; }
        }
    }
}
