using System;
using System.Collections;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class FeatureFieldList: IList<IFeatureField>
    {
        private readonly Table _table;

        internal FeatureFieldList(Table table)
        {
            _table = table;
            if (table == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        #region IList members

        public int Count
        {
            get { return _table.NumFields; }
        }

        public bool IsReadOnly
        {
            get { return _table.EditingTable; }
        }

        public IFeatureField this[int index]
        {
            get
            {
                if (index >= 0 && index < _table.NumFields)
                {
                    return new FeatureField(_table.Field[index]);
                }
                return null;
            }

            set { _table.EditReplaceField(index, value.GetInternal()); }
        }

        public IEnumerator<IFeatureField> GetEnumerator()
        {
            return ListHelper.GetEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IFeatureField item)
        {
            _table.EditInsertField(item.GetInternal(), _table.NumFields);
        }

        public void Clear()
        {
            for (int i = _table.NumFields - 1; i >= 0; i--)
            {
                _table.EditDeleteField(i);
            }
        }

        public bool Contains(IFeatureField item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(IFeatureField[] array, int arrayIndex)
        {
            ArrayHelper.CheckCopyTo(array, arrayIndex, _table.NumFields);
            for (int i = 0; i < _table.NumFields; i++)
            {
                array[arrayIndex + i] = new FeatureField(_table.Field[i]);
            }
        }

        public bool Remove(IFeatureField item)
        {
            return _table.EditDeleteField(IndexOf(item));
        }

        public int IndexOf(IFeatureField item)
        {
            var field = item.GetInternal();
            for (int i = 0; i < _table.NumFields; i++)
            {
                if (_table.Field[i] == field)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, IFeatureField item)
        {
            _table.EditInsertField(item.GetInternal(), index);
        }

        public void RemoveAt(int index)
        {
            _table.EditDeleteField(index);
        }

        #endregion

        public int IndexByName(string fieldName)
        {
            return _table.FieldIndexByName[fieldName];
        }
        
        public bool FieldIsJoined(int fieldIndex)
        {
            return _table.FieldIsJoined[fieldIndex];
        }

        public int FieldJoinIndex(int fieldIndex)
        {
            return _table.FieldJoinIndex[fieldIndex];
        }

        #region Shapefile members

        //int EditAddField(string Name, FieldType Type, int Precision, int Width);
        //int EditDeleteField(int fieldIndex);
        //bool EditCellValue(int FieldIndex, int ShapeIndex, object newVal);
        //bool EditInsertField(Field NewField, ref int FieldIndex, ICallback cBack = null);
        //object get_CellValue(int FieldIndex, int ShapeIndex);
        //Field get_Field(int FieldIndex);
        //Field get_FieldByName(string FieldName);
        //int get_FieldIndexByName(string FieldName);

        #endregion
    }
}
