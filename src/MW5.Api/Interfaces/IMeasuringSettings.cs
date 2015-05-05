using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IMeasuringSettings
    {
        bool ShowBearing { get; set; }
        BearingType BearingType { get; set; }
        bool ShowLength { get; set; }
        LengthDisplay LengthUnits { get; set; }
        AreaDisplay AreaUnits { get; set; }
        AngleFormat AngleFormat { get; set; }
        int AnglePrecision { get; set; }
        int AreaPrecision { get; set; }
        int LengthPrecision { get; set; }
        bool PointsVisible { get; set; }
        Color LineColor { get; set; }
        Color FillColor { get; set; }
        byte FillTransparency { get; set; }
        float LineWidth { get; set; }
        DashStyle LineStyle { get; set; }
        bool PointLabelsVisible { get; set; }
        bool ShowTotalLength { get; set; }
    }
}
