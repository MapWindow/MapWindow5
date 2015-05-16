using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using MW5.Api.Concrete;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IColorRamp : IEnumerable<ColorInterval>, IComWrapper
    {
        ColorInterval this[int index] { get; set; }
        void Remove(int index);
        void Add(ColorInterval item);
        void Clear();
        int Count { get; }
        Color GetGraduatedColor(double value);
        Color GetRandomColor(double value);
        void SetColors(Color color1, Color color2);
        void SetColors(PredefinedColors ramp);
        void Reverse();
        ColorBlend ColorScheme2ColorBlend();
    }
}
