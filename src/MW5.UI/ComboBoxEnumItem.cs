using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.UI
{
    public class ComboBoxEnumItem<T> where T : struct, IConvertible
    {
        private readonly T _item;
        private readonly Func<T, string> _toString;

        public ComboBoxEnumItem(T item, Func<T, string> toString)
        {
            _item = item;
            _toString = toString;
        }

        public T GetValue()
        {
            return _item;
        }

        public override string ToString()
        {
            return _toString(_item);
        }
    }
}
