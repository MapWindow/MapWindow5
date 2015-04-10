using System.Collections.Generic;
using System.Drawing;
using MW5.Api.Concrete;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IColorRamp : IList<ColorInterval>, IComWrapper
    {
        Color GetGraduatedColor(double value);
        Color GetRandomColor(double value);
        void SetColors(Color color1, Color color2);
        void SetColors(PredefinedColors ramp);
    }
}
