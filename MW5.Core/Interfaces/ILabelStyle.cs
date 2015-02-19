using System.Drawing;
using System.Drawing.Drawing2D;

namespace MW5.Core.Interfaces
{
    public interface ILabelStyle: ISerializableComWrapper
    {
        LabelAlignment Alignment { get; set; }
        LabelAlignment InboxAlignment { get; set; }
        LabelOrientation Orientation { get; set; }
        bool FontBold { get; set; }
        Color FontColor { get; set; }
        Color FontColor2 { get; set; }
        LinearGradient FontGradientMode { get; set; }
        bool FontItalic { get; set; }
        string FontName { get; set; }
        Color FontOutlineColor { get; set; }
        bool FontOutlineVisible { get; set; }
        int FontOutlineWidth { get; set; }
        int FontSize { get; set; }
        bool FontStrikeOut { get; set; }
        byte FontAlphaTransparency { get; set; }
        bool FontUnderline { get; set; }
        Color FrameBackColor { get; set; }
        Color FrameBackColor2 { get; set; }
        LinearGradient FrameGradientMode { get; set; }
        Color FrameOutlineColor { get; set; }
        DashStyle FrameOutlineStyle { get; set; }
        int FrameOutlineWidth { get; set; }
        int FramePaddingX { get; set; }
        int FramePaddingY { get; set; }
        byte FrameAlphaTransparency { get; set; }
        FrameType FrameType { get; set; }
        bool FrameVisible { get; set; }
        Color HaloColor { get; set; }
        int HaloSize { get; set; }
        bool HaloVisible { get; set; }
        Color ShadowColor { get; set; }
        int ShadowOffsetX { get; set; }
        int ShadowOffsetY { get; set; }
        bool ShadowVisible { get; set; }
    }
}
