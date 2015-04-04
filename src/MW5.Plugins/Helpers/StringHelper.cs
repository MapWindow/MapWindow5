using System;

namespace MW5.Plugins.Helpers
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
    }
}
