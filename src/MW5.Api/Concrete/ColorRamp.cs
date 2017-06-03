using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class ColorRamp: IColorRamp
    {
        private readonly ColorScheme _scheme;

        public ColorRamp()
        {
            _scheme = new ColorScheme();
        }

        public ColorRamp(Color color1, Color color2)
        {
            _scheme = new ColorScheme();
            SetColors(color1, color2);
        }

        internal ColorRamp(ColorScheme scheme)
        {
            if (scheme == null)
            {
                throw new NullReferenceException("Internal object reference is null.");
            }
            _scheme = scheme;
        }

        public IEnumerator<ColorInterval> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public ColorInterval this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    // var color = ColorHelper.UintToColor(_scheme.BreakColor[index]);
                    return new ColorInterval(_scheme, index);
                }
                return null;
            }
            set
            {
                throw new InvalidOperationException("Set accessor isn't supported.");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ColorInterval item)
        {
            _scheme.AddBreak(item.Value, ColorHelper.ColorToUInt(item.Color));
        }

        public void Clear()
        {
            _scheme.Clear();
        }

        public int Count
        {
            get { return _scheme.NumBreaks; }
        }

        public void Remove(int index)
        {
            _scheme.Remove(index);
        }

        public object InternalObject
        {
            get { return _scheme; }
        }

        public string LastError
        {
            get { return _scheme.ErrorMsg[_scheme.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _scheme.Key; }
            set { _scheme.Key = value; }
        }

        public Color GetGraduatedColor(double value)
        {
            return ColorHelper.UintToColor(_scheme.GraduatedColor[value]);
        }

        public Color GetRandomColor(double value)
        {
            return ColorHelper.UintToColor(_scheme.RandomColor[value]);
        }

        public void SetColors(Color color1, Color color2)
        {
            _scheme.SetColors(ColorHelper.ColorToUInt(color1), ColorHelper.ColorToUInt(color2));
        }

        public void SetColors(PredefinedColors ramp)
        {
            _scheme.SetColors4((PredefinedColorScheme)ramp);
        }

        public void Reverse()
        {
            _scheme.Reverse();
        }

        public ColorBlend ColorScheme2ColorBlend()
        {
            if (Count == 0)
            {
                return null;
            }

            var blend = new ColorBlend(Count);

            for (int i = 0; i < Count; i++)
            {
                blend.Positions[i] = (float)this[i].Value;
                blend.Colors[i] = this[i].Color;
            }
            return blend;
        }
    }
}
