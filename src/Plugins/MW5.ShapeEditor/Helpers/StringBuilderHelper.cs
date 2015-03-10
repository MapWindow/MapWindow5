using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.ShapeEditor.Helpers
{
    public static class StringBuilderHelper
    {
        public static void RemoveFromEnd(this StringBuilder sb, string token)
        {
            int length = token.Length;
            sb.Remove(sb.Length - length, length);
        }
    }
}
