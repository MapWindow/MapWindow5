using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class IdentifierSettings: IComWrapper
    {
        private readonly Identifier _identifier;

        public IdentifierSettings(Identifier identifier)
        {
            _identifier = identifier;
            if (identifier == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public object InternalObject
        {
            get { return _identifier; }
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

        public bool HotTracking
        {
            get { return _identifier.HotTracking; }
            set { _identifier.HotTracking = value; }
        }

        public IdentifierMode IdentifierMode
        {
            get { return (IdentifierMode)_identifier.IdentifierMode; }
            set { _identifier.IdentifierMode = (tkIdentifierMode)value; }
        }

        public Color OutlineColor
        {
            get { return ColorHelper.UintToColor(_identifier.OutlineColor); }
            set { _identifier.OutlineColor = ColorHelper.ColorToUInt(value); }
        }

        public int ActiveLayer
        {
            get { return _identifier.ActiveLayer; }
            set { _identifier.ActiveLayer = value; }
        }
    }
}
