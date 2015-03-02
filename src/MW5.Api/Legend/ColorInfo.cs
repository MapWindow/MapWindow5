using System.Drawing;

namespace MW5.Api.Legend
{
    internal struct ColorInfo
    {
        public string Caption;
        public Color EndColor;
        public bool IsTransparent;
        public Color StartColor;

        public ColorInfo(Color start, Color end, string caption, bool transparent)
        {
            StartColor = start;
            EndColor = end;
            Caption = caption;
            IsTransparent = transparent;
        }

        public ColorInfo(Color start, Color end, string caption)
        {
            StartColor = start;
            EndColor = end;
            Caption = caption;
            IsTransparent = false;
        }
    }
}