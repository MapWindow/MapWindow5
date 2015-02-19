using System.Collections.Generic;
using System.Linq;

namespace MW5.Core.Helpers
{
    public static class ListHelper
    {
        public static IEnumerator<T> GetEnumerator<T>(this IList<T> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                yield return list[i];
            }
        }
    }
}
