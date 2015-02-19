using System;
using System.Collections;
using System.Collections.Generic;
using MapWinGIS;

namespace MW5.Core.Concrete
{
    public class FieldJoinCollection : IEnumerable<FieldJoin>
    {
        private readonly Table _table;

        public FieldJoinCollection(Table table)
        {
            _table = table;
            if (table == null)
            {
                throw new NullReferenceException("Internal reference is empty.");
            }
        }

        public IEnumerator<FieldJoin> GetEnumerator()
        {
            for (int i = 0; i < _table.JoinCount; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public FieldJoin this[int position]
        {
            get
            {
                if (position >= 0 && position < _table.JoinCount)
                {
                    return new FieldJoin(_table, position);
                }
                return null;
            }
        }
    }
}
