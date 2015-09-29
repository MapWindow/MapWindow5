using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Projections.Enums;

namespace MW5.Projections.BL
{
    public class ProjectionDialect
    {
        public ProjectionDialect(string proj)
        {
            Definition = proj;

            var projTest = new SpatialReference();
            Format = projTest.ImportFromProj4(Definition) ? DialectFormat.Proj4 : DialectFormat.WKT;
        }

        public string Definition { get; set; }

        public DialectFormat Format { get; set; }
    }
}
