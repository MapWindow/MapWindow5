using System;
using System.Drawing;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
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

        public IdentifierMode Mode
        {
            get { return (IdentifierMode)_identifier.IdentifierMode; }
            set { _identifier.IdentifierMode = (tkIdentifierMode)value; }
        }

        public Color OutlineColor
        {
            get { return ColorHelper.UintToColor(_identifier.OutlineColor); }
            set { _identifier.OutlineColor = ColorHelper.ColorToUInt(value); }
        }
    }
}
