using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class DecorationRectangle
    {
        private readonly DrawingRectangle _rect;

        public DecorationRectangle(DrawingRectangle rect)
        {
            if (rect == null) throw new ArgumentNullException("rect");
            _rect = rect;
        }

        public double X
        {
            get { return _rect.x; }
            set { _rect.x = value; }
        }

        public double Y
        {
            get { return _rect.y; }
            set { _rect.y = value; }
        }

        public double Width
        {
            get { return _rect.Width; }
            set { _rect.Width = value; }
        }

        public double Height
        {
            get { return _rect.Height; }
            set { _rect.Height = value; }
        }

        public bool Visible
        {
            get { return _rect.Visible; }
            set { _rect.Visible = value; }
        }

        public DrawReferenceList ReferenceType
        {
            get { return (DrawReferenceList)_rect.ReferenceType; }
            set { _rect.ReferenceType = (tkDrawReferenceList)value; }
        }

        public byte FillTransparency
        {
            get { return _rect.FillTransparency; }
            set { _rect.FillTransparency = value; }
        }

        public Color Color
        {
            get { return ColorHelper.UintToColor(_rect.Color); }
            set { _rect.Color = ColorHelper.ColorToUInt(value); }
        }

        public float LineWidth
        {
            get { return _rect.LineWidth; }
            set { _rect.LineWidth = value; }
        }
    }
}
