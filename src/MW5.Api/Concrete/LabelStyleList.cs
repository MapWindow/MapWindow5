using System;
using System.Collections;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class LabelStyleList : IList<ILabelStyle>
    {
        private readonly Labels _labels;

        internal LabelStyleList(Labels labels)
        {
            _labels = labels;
            if (labels == null)
            {
                throw new NullReferenceException("Internal reference is null");
            }
        }

        #region IList Members

        public int Count
        {
            get { return _labels.NumCategories; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public ILabelStyle this[int index]
        {
            get
            {
                if (index >= 0 && index < _labels.NumCategories)
                {
                    return new LabelStyle(_labels.Category[index]);
                }
                return null;
            }

            set { _labels.Category[index] = value.GetInternal(); }
        }

        public IEnumerator<ILabelStyle> GetEnumerator()
        {
            return ListHelper.GetEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ILabelStyle item)
        {
            _labels.AddCategory("");
            _labels.Category[_labels.NumCategories - 1] = item.GetInternal();   // TODO: implement directly in MapWinGIS
        }

        public void Clear()
        {
            _labels.ClearCategories();
        }

        public bool Contains(ILabelStyle item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(ILabelStyle[] array, int arrayIndex)
        {
            ArrayHelper.CheckCopyTo(array, arrayIndex, _labels.NumCategories);
            for (int i = 0; i < _labels.NumCategories; i++)
            {
                array[arrayIndex + i] = new LabelStyle(_labels.Category[i]);
            }
        }

        public bool Remove(ILabelStyle item)
        {
            return _labels.RemoveCategory(IndexOf(item));
        }

        public int IndexOf(ILabelStyle item)
        {
            var category = item.GetInternal();
            for (int i = 0; i < _labels.NumCategories; i++)
            {
                if (_labels.Category[i] == category)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, ILabelStyle item)
        {
            _labels.InsertCategory(index, "");
            _labels.Category[index] = item.GetInternal();   // TODO: implement directly in MapWinGIS
        }

        public void RemoveAt(int index)
        {
            _labels.RemoveCategory(index);
        }

        #endregion

        public bool MoveCategoryDown(int index)
        {
            return _labels.MoveCategoryDown(index);
        }

        public bool MoveCategoryUp(int index)
        {
            return _labels.MoveCategoryUp(index);
        }

        public bool Generate(int fieldIndex, Classification classification, int numClasses)
        {
            return _labels.GenerateCategories(fieldIndex, (tkClassificationType) classification, numClasses);
        }

        public void ApplyColors(SchemeType coloringType, ColorRamp colors)
        {
            _labels.ApplyColorScheme((tkColorSchemeType) coloringType, colors.GetInternal());
        }

        // TODO: implement
        //void ApplyColors(tkColorSchemeType Type, ColorScheme ColorScheme, tkLabelElements Element);
        //void ApplyColors(tkColorSchemeType Type, ColorScheme ColorScheme, tkLabelElements Element, int CategoryStartIndex, int CategoryEndIndex);

        public void Apply()
        {
            _labels.ApplyCategories();
        }
    }
}
