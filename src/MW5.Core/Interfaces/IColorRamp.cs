using System.Collections.Generic;
using System.Drawing;
using MW5.Core.Concrete;

namespace MW5.Core.Interfaces
{
    public interface IColorRamp : IList<ColorBreak>, IComWrapper
    {
        Color GetGraduatedColor(double value);
        Color GetRandomColor(double value);
        void SetColors(Color color1, Color color2);
        void SetColors(PredefinedColorRamp ramp);
    }
}
