using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;

namespace MW5.Tiles.Model
{
    internal class TmsProvider
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TileProjection Projection { get; set; }

        public string Url { get; set; }
    }
}
