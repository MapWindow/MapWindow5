using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Services.Helpers
{
    public static class StringHelper
    {
        public static bool EqualsIgnoreCase(this string s1, string s2)
        {
            return string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase);
        }
    }
}
