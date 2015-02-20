using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class DiagramField: IComWrapper
    {
        private readonly ChartField _field;

        internal DiagramField(ChartField field)
        {
            _field = field;
            if (field == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public object InternalObject
        {
            get { return _field; }
        }

        public string LastError
        {
            get { return ErrorHelper.NO_ERROR; }
        }

        public string Tag
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public int Index
        {
            get { return _field.Index; }
            set { _field.Index = value; }
        }

        public Color Color
        {
            get { return ColorHelper.UintToColor(_field.Color); }
            set { _field.Color = ColorHelper.ColorToUInt(value); }
        }

        public string Name
        {
            get { return _field.Name; }
            set { _field.Name = value; }
        }
    }
}
