using MW5.Core.Concrete;

namespace MW5.Core.Interfaces
{
    public interface IAttributeTable: ISerializableComWrapper
    {
        FeatureFieldList Fields { get; }

        bool EditMode { get; }
        bool StartEditing();
        bool StopEditing(bool applyChanges);

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

        //bool Query(string Expression, ref object result, ref string ErrorString);
        //bool ParseExpression(string Expression, ref string ErrorString);
        //bool Calculate(string expression, int rowIndex, out object result, out string errorString);
        //object get_MaxValue(int FieldIndex);
        //double get_MeanValue(int FieldIndex);
        //object get_MinValue(int FieldIndex);
        //double get_StandardDeviation(int FieldIndex);
        //bool TestExpression(string Expression, tkValueType ReturnType, ref string ErrorString);

        FieldJoinCollection Joins { get; }
        //bool IsJoined { get; }
        //bool Join(Table table2, string field1, string field2);
        //bool Join2(Table table2, string field1, string field2, string filenameToReopen, string joinOptions);
        //bool Join3(Table table2, string field1, string field2, string filenameToReopen, string joinOptions, Array fieldList);
        //bool StopJoin(int joinIndex);
        //bool TryJoin(Table table2, string fieldTo, string fieldFrom, out int rowCount, out int joinRowCount);
        //void StopAllJoins();
    }
}
