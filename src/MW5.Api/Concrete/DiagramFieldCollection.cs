using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class DiagramFieldCollection : IEnumerable<DiagramField>
    {
        private readonly Charts _charts;

        internal DiagramFieldCollection(Charts charts)
        {
            _charts = charts;
            if (charts == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public IEnumerator<DiagramField> GetEnumerator()
        {
            for (int i = 0; i < _charts.NumFields; i++)
            {
                yield return new DiagramField(_charts.Field[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(int fieldIndex, Color color)
        {
            _charts.AddField2(fieldIndex, ColorHelper.ColorToUInt(color));
        }

        public bool InsertField(int index, int fieldIndex, Color color)
        {
            return _charts.InsertField2(index, fieldIndex, ColorHelper.ColorToUInt(color));
        }

        public bool RemoveField(int index)
        {
            return _charts.RemoveField(index);
        }

        public void Clear()
        {
            _charts.ClearFields();
        }

        public bool MoveField(int oldIndex, int newIndex)
        {
            return _charts.MoveField(oldIndex, newIndex);
        }

        public bool Add(DiagramField field)
        {
            return _charts.AddField(field.GetInternal());
        }

        public bool InsertField(int index, DiagramField field)
        {
            return _charts.InsertField(index, field.GetInternal());
        }

        public DiagramField this[int fieldIndex]
        {
            get
            {
                var field = _charts.Field[fieldIndex];
                return field != null ? new DiagramField(field) : null;
            }
        }

        public int Count
        {
            get { return _charts.NumFields; }
        }
    }
}
