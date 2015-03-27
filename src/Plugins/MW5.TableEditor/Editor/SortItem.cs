using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.TableEditor.Editor
{
    public class SortItem<T>: IComparable<T>, IComparable
        where T: IComparable
    {
        public SortItem(T value, int realIndex)
        {
            Value = value;
            RealIndex = realIndex;
        }
        
        public T Value;
        public int RealIndex;
        
        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }

        public int CompareTo(object obj)
        {
            var item = (SortItem<T>) obj;
            return Value.CompareTo(item.Value);
        }
    }
}
