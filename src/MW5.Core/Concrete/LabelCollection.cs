using System;
using System.Collections;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class LabelCollection: IEnumerable<IGeoLabel>
    {
        private readonly Labels _labels;

        internal LabelCollection(Labels labels)
        {
            _labels = labels;
            if (labels == null)
            {
                throw new NullReferenceException("Internal reference is null");
            }
        }

        public IEnumerator<IGeoLabel> GetEnumerator()
        {
            for (int i = 0; i < _labels.Count; i++)
            {
                yield return new GeoLabel(_labels.Label[i, 0]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count
        {
            get { return _labels.Count; }
        }

        public void Clear()
        {
            _labels.Clear();
        }

        public void Add(string text, double x, double y, double rotation = 0, int category = -1)
        {
            _labels.AddLabel(text, x, y, rotation, category);
        }

        public GeoLabel this[int index]
        {
            get { return new GeoLabel(_labels.Label[index, 0]); }
        }

        public bool Insert(int index, string text, double x, double y, double rotation = 0, int category = -1)
        {
            return _labels.InsertLabel(index, text, x, y, rotation, category);
        }

        public bool Remove(int index)
        {
            return _labels.RemoveLabel(index);
        }

        public void AddPart(int index, string text, double x, double y, double rotation = 0, int category = -1)
        {
            _labels.AddPart(index, text, x, y, rotation, category);
        }

        public bool InsertPart(int index, int part, string text, double x, double y, double rotation = 0,
            int category = -1)
        {
            return _labels.InsertPart(index, part, text, x, y, rotation, category);
        }

        public bool RemovePart(int index, int part)
        {
            return _labels.RemovePart(index, part);
        }

        public GeoLabel this[int index, int partIndex]
        {
            get { return new GeoLabel(_labels.Label[index, partIndex]); }
        }

        public int NumParts(int index)
        {
            return _labels.NumParts[index];
        }
    }
}
