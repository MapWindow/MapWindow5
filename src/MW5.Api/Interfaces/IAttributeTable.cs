using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IAttributeTable: ISerializableComWrapper
    {
        FeatureFieldList Fields { get; }

        bool EditMode { get; }
        bool StartEditing();
        bool StopEditing(bool applyChanges = true);

        int NumRows { get; }
        bool EditCellValue(int fieldIndex, int rowIndex, object newVal);
        void EditClear();
        bool EditDeleteRow(int rowIndex);
        bool EditInsertRow(ref int rowIndex);
        object CellValue(int fieldIndex, int rowIndex);

        void Close();
        bool Dump(string dbfFilename);
        bool Save();
        bool SaveAs(string dbfFilename);

        bool Calculate(string expression, int rowIndex, out object result, out string errorString);
        bool TestExpression(string expression, TableValueType returnType, ref string errorString);
        bool ParseExpression(string expression, ref string errorString);
        bool Query(string expression, ref object result, ref string errorString);

        FieldJoinCollection Joins { get; }

        #region Not implemented
        
        //object get_MaxValue(int FieldIndex);
        //double get_MeanValue(int FieldIndex);
        //object get_MinValue(int FieldIndex);
        //double get_StandardDeviation(int FieldIndex);
        
        //bool IsJoined { get; }
        //bool Join(Table table2, string field1, string field2);
        //bool Join2(Table table2, string field1, string field2, string filenameToReopen, string joinOptions);
        //bool Join3(Table table2, string field1, string field2, string filenameToReopen, string joinOptions, Array fieldList);
        //bool StopJoin(int joinIndex);
        //bool TryJoin(Table table2, string fieldTo, string fieldFrom, out int rowCount, out int joinRowCount);
        //void StopAllJoins();

        #endregion
    }
}
