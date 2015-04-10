using System;
using MapWinGIS;
using MW5.Api.Enums;

namespace MW5.Api.Concrete
{
    public class FieldOperation
    {
        private readonly FieldStatOperations _operations;
        private readonly int _index;

        public FieldOperation(FieldStatOperations operations, int index)
        {
            _operations = operations;
            _index = index;
            if (operations == null)
            {
                throw new NullReferenceException("Internal reference is null");
            }
            if (index < 0 || index >= operations.Count)
            {
                throw new IndexOutOfRangeException("Invalid field operation index.");
            }
        }

        public GroupOperation Operation
        {
            get { return (GroupOperation)_operations.Operation[_index]; }
        }

        public int FieldIndex
        {
            get { return _operations.FieldIndex[_index];}
        }

        public string FieldName
        {
            get { return _operations.FieldName[_index];}
        }

        public bool OperationIsValid
        {
            get { return _operations.OperationIsValid[_index];}
        }

        public FieldOperationValidity OperationIsValidReason
        {
            get { return (FieldOperationValidity) _operations.OperationIsValidReason[_index]; }
        }

       
    }
}
