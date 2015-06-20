using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class AttributeFieldList: IEnumerable<IAttributeField>
    {
        private readonly Table _table;

        internal AttributeFieldList(Table table)
        {
            _table = table;
            if (table == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public int Count
        {
            get { return _table.NumFields; }
        }

        public IAttributeField this[int index]
        {
            get
            {
                if (index >= 0 && index < _table.NumFields)
                {
                    return new AttributeField(_table.Field[index], index);
                }
                return null;
            }

            set { _table.EditReplaceField(index, value.GetInternal()); }
        }

        public IAttributeField this[string name]
        {
            get
            {
                return this.FirstOrDefault(f => string.Equals(f.Name, name, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public IEnumerator<IAttributeField> GetEnumerator()
        {
            for (int i = 0; i < _table.NumFields; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IAttributeField item)
        {
            _table.EditInsertField(item.GetInternal(), _table.NumFields);
        }

        public int Add(string name, AttributeType type, int precision, int width)
        {
            return _table.EditAddField(name, (FieldType)type, precision, width);
        }

        public void Clear()
        {
            for (int i = _table.NumFields - 1; i >= 0; i--)
            {
                _table.EditDeleteField(i);
            }
        }

        public bool Remove(int index)
        {
            return _table.EditDeleteField(index);
        }

        public int IndexOf(IAttributeField item)
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

        public void Insert(int index, IAttributeField item)
        {
            _table.EditInsertField(item.GetInternal(), index);
        }

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
