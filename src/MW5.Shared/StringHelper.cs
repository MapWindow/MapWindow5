using System;
using System.Collections.Generic;
using System.Linq;

namespace MW5.Shared
{
    public static class StringHelper
    {
        public static bool EqualsIgnoreCase(this string s1, string s2)
        {
            return string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase);
        }

        public static bool ContainsIgnoreCase(this string s1, string s2)
        {
            return s1.ToLower().Contains(s2.ToLower());
        }

        public static bool StartsWithIgnoreCase(this string s1, string s2)
        {
            return s1.ToLower().StartsWith(s2.ToLower());
        }

        // just as a memo, for not forgeting it
        public static string Join(IEnumerable<string> list, string separator)
        {
            return String.Join(separator, list.ToArray());
        }

        public static string Fill(string pattern, int count)
        {
            return Enumerable.Range(0, count).Aggregate(string.Empty, (current, item) => current + pattern);
        }
    }
}
