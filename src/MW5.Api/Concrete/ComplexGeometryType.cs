using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;

namespace MW5.Api.Concrete
{
    public class ComplexGeometryType
    {
        private ShpfileType _shpType;

        internal ComplexGeometryType(ShpfileType shpType)
        {
            _shpType = shpType;
        }

        public ComplexGeometryType(GeometryType type, ZValueType zValue = Enums.ZValueType.None)
        {
            _shpType = GeometryHelper.GeometryType2ShpType(GeometryType, ZValueType);
        }

        internal ShpfileType ShapeType
        {
            get { return _shpType; }
        }

        public GeometryType GeometryType
        {
            get { return GeometryHelper.ShapeType2GeometryType(_shpType); }
        }

        public ZValueType ZValueType
        {
            get { return GeometryHelper.ShapeType2ZValueType(_shpType); }
        }
    }
}
