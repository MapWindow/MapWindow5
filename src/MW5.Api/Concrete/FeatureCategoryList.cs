using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class FeatureCategoryList : IFeatureCategoryList
    {
        private ShapefileCategories _categories;

        internal FeatureCategoryList(ShapefileCategories categories)
        {
            if (categories == null)
            {
                throw new NullReferenceException("Internal categories reference is null.");
            }
            _categories = categories;
        }

        #region IFeatureCategoryList Members

        public int Count
        {
            get { return _categories.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public IFeatureCategory this[int index]
        {
            get
            {
                if (index >= 0 && index < _categories.Count)
                {
                    return new FeatureCategory(_categories.Item[index]);    
                }
                return null;
            }

            set { _categories.Item[index] = value.GetInternal(); }
        }

        public IEnumerator<IFeatureCategory> GetEnumerator()
        {
            for (int i = 0; i < _categories.Count; i++)
            {
                yield return new FeatureCategory(_categories.Item[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IFeatureCategory Add(string name)
        {
            var ct = _categories.Add(name);
            return new FeatureCategory(ct);
        }

        public void Add(IFeatureCategory item)
        {
            _categories.Add2(item.GetInternal());
        }

        public void Clear()
        {
            _categories.Clear();
        }

        public bool Contains(IFeatureCategory item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(IFeatureCategory[] array, int arrayIndex)
        {
            ArrayHelper.CheckCopyTo(array, arrayIndex, _categories.Count);
            for (int i = 0; i < _categories.Count; i++)
            {
                array[arrayIndex + i] = new FeatureCategory(_categories.Item[i]);
            }
        }

        public bool Remove(IFeatureCategory item)
        {
            return _categories.Remove(IndexOf(item));
        }

        public int IndexOf(IFeatureCategory item)
        {
            var category = item.GetInternal();
            for (int i = 0; i < _categories.Count; i++)
            {
                if (_categories.Item[i] == category)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, IFeatureCategory item)
        {
            _categories.Insert2(index, item.GetInternal());
        }

        public void RemoveAt(int index)
        {
            _categories.Remove(index);
        }

        #endregion

        public int IndexByName(string categoryName)
        {
            return _categories.CategoryIndexByName[categoryName];
        }

        public string Caption
        {
            get { return _categories.Caption; }
            set { _categories.Caption = value; }
        }

        public string ClassificationField
        {
            get
            {
                var fld = _categories.Shapefile.Field[_categories.ClassificationField];
                return fld.Name ?? "";
            }
            set { _categories.ClassificationField = _categories.Shapefile.FieldIndexByName[value]; }
        }

        public bool AddRange(int fieldIndex, Classification classification, int numClasses, object minValue, object maxValue)
        {
            return _categories.AddRange(fieldIndex, (tkClassificationType)classification, numClasses, minValue, maxValue);
        }

        public void ApplyColorScheme(ColorRampType type, ColorRamp colorRamp)
        {
            _categories.ApplyColorScheme((tkColorSchemeType) type, colorRamp.GetInternal());
        }

        public void ApplyColorScheme(ColorRampType type, ColorRamp colorRamp, StyleElement shapeElement)
        {
            _categories.ApplyColorScheme2((tkColorSchemeType) type, colorRamp.GetInternal(), (tkShapeElements)shapeElement);
        }

        public void ApplyColorScheme(ColorRampType type, ColorRamp colorRamp, StyleElement shapeElement, int categoryStartIndex,
            int categoryEndIndex)
        {
            _categories.ApplyColorScheme3((tkColorSchemeType)type, colorRamp.GetInternal(), (tkShapeElements)shapeElement,
                categoryStartIndex, categoryEndIndex);
        }

        public void ApplyExpression(int categoryIndex)
        {
            _categories.ApplyExpression(categoryIndex);
        }

        public void ApplyExpressions()
        {
            _categories.ApplyExpressions();
        }

        public bool Generate(int fieldIndex, Classification classification, int numClasses)
        {
            return _categories.Generate(fieldIndex, (tkClassificationType) classification, numClasses);
        }

        public bool Generate(string fieldName, Classification classification, int numClasses)
        {
            return _categories.Generate2(fieldName, (tkClassificationType)classification, numClasses);
        }

        public bool GenerateUniqueValues(string fieldName)
        {
            return _categories.Generate2(fieldName, tkClassificationType.ctUniqueValues, 0);
        }

        public bool GenerateUniqueValues(int fieldIndex)
        {
            return _categories.Generate(fieldIndex, tkClassificationType.ctUniqueValues, 0);
        }

        public bool GeneratePolygonColors(ColorRamp colorRamp = null)
        {
            ColorScheme scheme = null;
            if (colorRamp != null)
            {
                scheme = colorRamp.GetInternal();
            }
            return _categories.GeneratePolygonColors(scheme);
        }

        public bool MoveDown(int index)
        {
            return _categories.MoveDown(index);
        }

        public bool MoveUp(int index)
        {
            return _categories.MoveUp(index);
        }

        public bool Deserialize(string newVal)
        {
            _categories.Deserialize(newVal);
            return true;
        }

        public string Serialize()
        {
            return _categories.Serialize();
        }

        public object InternalObject
        {
            get { return _categories; }
        }

        public string LastError
        {
            get { return _categories.ErrorMsg[_categories.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _categories.Key; }
            set { _categories.Key = value; }
        }

        public bool LoadFromFile(string filename)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            if (xmlDoc.DocumentElement == null)
            {
                return false;
            }

            var docEl = xmlDoc.DocumentElement;
            if (!docEl.HasAttribute("FileVersion") || !docEl.HasAttribute("FileType"))
            {
                return false;
            }

            var s = docEl.Attributes["FileType"].InnerText;
            if ((s.ToLower() == "shapefilecategories"))
            {
                XmlElement xel = xmlDoc.DocumentElement["Categories"];
                if (xel != null)
                {
                    _categories.Deserialize(xel.InnerXml);
                    return true;
                }
            }
            return false;
        }

        public bool SaveToFile(string filename)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<MapWindow version= '" + "'></MapWindow>");

            var xelRoot = xmlDoc.DocumentElement;
            
            XmlAttribute attr = xmlDoc.CreateAttribute("FileType");
            attr.InnerText = "ShapefileCategories";
            xelRoot.Attributes.Append(attr);

            attr = xmlDoc.CreateAttribute("FileVersion");
            attr.InnerText = "0";
            xelRoot.Attributes.Append(attr);

            var xel = xmlDoc.CreateElement("Categories");
            string s = _categories.Serialize();
            xel.InnerXml = s;
            xelRoot.AppendChild(xel);

            xmlDoc.Save(filename);
            return true;
        }
    }
}