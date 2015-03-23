using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class CompositeLine: ISerializableComWrapper, IEnumerable<SimpleLine>
    {
        private readonly LinePattern _pattern;

        public CompositeLine()
        {
            _pattern = new LinePattern();
        }

        internal CompositeLine(LinePattern pattern)
        {
            _pattern = pattern;
            if (pattern == null)
            {
                throw new NullReferenceException("Internal reference is null");
            }
        }

        public object InternalObject
        {
            get { return _pattern; }
        }

        public string LastError
        {
            get { return _pattern.ErrorMsg[_pattern.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _pattern.Key; }
            set { _pattern.Key = value; }
        }

        public void AddLine(Color color, float width, DashStyle style)
        {
            _pattern.AddLine(ColorHelper.ColorToUInt(color), width, (tkDashStyle) style);
        }

        public bool InsertLine(int index, Color color, float width, tkDashStyle style)
        {
            return _pattern.InsertLine(index, ColorHelper.ColorToUInt(color), width, (tkDashStyle)style);
        }

        public SimpleLine AddMarker(VectorMarker marker)
        {
            return new SimpleLine(_pattern.AddMarker((tkDefaultPointSymbol) marker));
        }

        public SimpleLine InsertMarker(int index, VectorMarker marker)
        {
            return new SimpleLine(_pattern.InsertMarker(index, (tkDefaultPointSymbol) marker));
        }

        public bool RemoveLine(int index)
        {
            return _pattern.RemoveItem(index);
        }

        public void Clear()
        {
            _pattern.Clear();
        }

        public string Serialize()
        {
            return _pattern.Serialize();
        }

        public bool Deserialize(string newVal)
        {
            _pattern.Deserialize(newVal);
            return true;
        }

        public SimpleLine this[int index]
        {
            get
            {
                var line = _pattern.Line[index];
                return line != null ? new SimpleLine(line) : null;
            }
        }

        public void set_Line(int index, SimpleLine line)
        {
            _pattern.Line[index] = line.GetInternal();
        }

        public int Count
        {
            get { return _pattern.Count; }
        }

        public byte AlphaTransparency
        {
            get { return _pattern.Transparency; }
            set { _pattern.Transparency = value; }
        }

        public IEnumerator<SimpleLine> GetEnumerator()
        {
            for (int i = 0; i < _pattern.Count; i++)
            {
                yield return new SimpleLine(_pattern.Line[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Draw(IntPtr hdc, float x, float y, int clipWidth, int clipHeight, Color? backColor = null)
        {
            return _pattern.Draw(hdc, x, y, clipWidth, clipHeight, backColor.ToUInt());
        }

        public bool Draw(Graphics g, float x, float y, int clipWidth, int clipHeight, Color? backColor = null)
        {
            var hdc = g.GetHdc();
            bool result = _pattern.Draw(hdc, x, y, clipWidth, clipHeight, backColor.ToUInt());
            g.ReleaseHdc(hdc);
            return result;
        }
    }
}
