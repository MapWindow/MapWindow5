using System;
using System.Globalization;

namespace MW5.UI.Helpers
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
            if (_toString != null)
            {
                return _toString(_item);
            }

            return _item.ToString(CultureInfo.InvariantCulture);
        }
    }
}
