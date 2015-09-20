using System;
using System.Collections;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class FieldOperationList : IComWrapper, IEnumerable<FieldOperation>
    {
        private FieldStatOperations _operations;
        
        internal FieldOperationList(FieldStatOperations operations)
        {
            _operations = operations;
            if (operations == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public FieldOperationList()
        {
            _operations = new FieldStatOperations();
        }

        public object InternalObject
        {
            get { return _operations; }
        }

        public string LastError
        {
            get { return _operations.ErrorMsg[_operations.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _operations.Key; }
            set { _operations.Key = value; }
        }

        public void AddFieldIndex(int fieldIndex, GroupOperation operation)
        {
            _operations.AddFieldIndex(fieldIndex, (tkFieldStatOperation)operation);
        }

        public bool Remove(int operationIndex)
        {
            return _operations.Remove(operationIndex);
        }

        public void Clear()
        {
            _operations.Clear();
        }

        public void AddFieldName(string fieldName, GroupOperation operation)
        {
            _operations.AddFieldName(fieldName, (tkFieldStatOperation)operation);
        }

        public bool Validate(IFeatureSet featureSet)
        {
            var sf = featureSet.GetInternal();
            return _operations.Validate(sf);
        }

        public int Count
        {
            get { return _operations.Count; }
        }

        public IEnumerator<FieldOperation> GetEnumerator()
        {
            for (int i = 0; i < _operations.Count; i++)
            {
                yield return new FieldOperation(_operations, i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
