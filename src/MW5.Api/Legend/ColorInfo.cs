namespace MW5.Api.Legend
{
    using System.Drawing;

    internal struct ColorInfo
    {
        public string Caption;

        public Color EndColor;

        public bool IsTransparent;

        public Color StartColor;

        public ColorInfo(Color start, Color end, string caption, bool transparent)
        {
            this.StartColor = start;
            this.EndColor = end;
            this.Caption = caption;
            this.IsTransparent = transparent;
        }

        public ColorInfo(Color start, Color end, string caption)
        {
            this.StartColor = start;
            this.EndColor = end;
            this.Caption = caption;
            this.IsTransparent = false;
        }
    }
}