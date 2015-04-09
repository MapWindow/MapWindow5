using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Api.Helpers
{
    public static class MapHelper
    {
        public static IEnumerable<string> GetFilenames(this IMuteMap map)
        {
            foreach (var layer in map.Layers)
            {
                yield return layer.Filename;
            }
        }
    }
}
