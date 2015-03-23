using System;
using MapWinGIS;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class AttributeTable: IAttributeTable
    {
        private readonly Table _table;

        public AttributeTable(string dbfFilename)
        {
            _table = new Table();
            if (!_table.Open(dbfFilename))
            {
                throw new ApplicationException("Failed to open dbf table: " + _table.ErrorMsg[_table.LastErrorCode]);
            }
        }

        internal AttributeTable(Table table)
        {
            _table = table;
            if (table == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        #region IComWrapper members

        public object InternalObject
        {
            get { return _table; }
        }

        public string LastError
        {
            get { return _table.ErrorMsg[_table.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _table.Key; }
            set { _table.Key = value; }
        }

        public string Serialize()
        {
            return _table.Serialize();
        }

        public bool Deserialize(string state)
        {
            _table.Deserialize(state);
            return true;
        }

        #endregion

        public FeatureFieldList Fields
        {
            get { return new FeatureFieldList(_table); }
        }

        public bool Calculate(string expression, int rowIndex, out object result, out string errorString)
        {
            return _table.Calculate(expression, rowIndex, out result, out errorString);
        }

        public bool TestExpression(string expression, TableValueType returnType, ref string errorString)
        {
            return _table.TestExpression(expression, (tkValueType)returnType, ref errorString);
        }

        public bool ParseExpression(string expression, ref string errorString)
        {
            return _table.ParseExpression(expression, ref errorString);
        }

        public bool Query(string expression, ref object result, ref string errorString)
        {
            return _table.Query(expression, ref result, ref errorString);
        }

        public FieldJoinCollection Joins
        {
            get { return new FieldJoinCollection(_table); }
        }

        public bool EditMode
        {
            get { return _table.EditingTable; }
        }

        public bool StartEditing()
        {
            return _table.StartEditingTable();
        }

        public bool StopEditing(bool applyChanges)
        {
            return _table.StopEditingTable(applyChanges);
        }

        public int NumRows
        {
            get { return _table.NumRows; }
        }

        public bool EditCellValue(int fieldIndex, int rowIndex, object newVal)
        {
            return _table.EditCellValue(fieldIndex, rowIndex, newVal);
        }

        public void EditClear()
        {
            _table.EditClear();
        }

        public bool EditDeleteRow(int rowIndex)
        {
            return _table.EditDeleteRow(rowIndex);
        }

        public bool EditInsertRow(ref int rowIndex)
        {
            return _table.EditInsertRow(ref rowIndex);
        }

        public object CellValue(int fieldIndex, int rowIndex)
        {
            return _table.CellValue[fieldIndex, rowIndex];
        }

        public void Close()
        {
            _table.Close();
        }

        public bool Dump(string dbfFilename)
        {
            return _table.Dump(dbfFilename);
        }

        public bool Save()
        {
            return _table.Save();
        }

        public bool SaveAs(string dbfFilename)
        {
            return _table.SaveAs(dbfFilename);
        }
    }
}
