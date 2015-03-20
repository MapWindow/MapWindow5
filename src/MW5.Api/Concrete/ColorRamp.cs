using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

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

        #region IList implementation

        public IEnumerator<ColorInterval> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                var cb = this[i];
                if (cb == null)
                {
                    break;
                }
                yield return cb;
            }
        }

        public ColorInterval this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    var color = ColorHelper.UintToColor(_scheme.BreakColor[index]);
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

        public bool Contains(ColorInterval item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(ColorInterval[] array, int arrayIndex)
        {
            ArrayHelper.CheckCopyTo(array, arrayIndex, _scheme.NumBreaks);
            for (int i = 0; i < _scheme.NumBreaks; i++)
            {
                array[arrayIndex + i] = this[i];
            }
        }

        public bool Remove(ColorInterval item)
        {
            return _scheme.Remove(IndexOf(item));
        }

        public int Count
        {
            get { return _scheme.NumBreaks; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int IndexOf(ColorInterval item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, ColorInterval item)
        {
            throw new NotSupportedException("ColorBreakCollection.Insert method isn't supported");
        }

        public void RemoveAt(int index)
        {
            _scheme.Remove(index);
        }

        #endregion

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
    }
}
