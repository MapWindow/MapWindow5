using System;
using System.ComponentModel;
using System.Globalization;
using AxMapWinGIS;
using MapWinGIS;

namespace MW5.Api.Concrete
{
    [TypeConverter(typeof(ZoomBarSettingsTypeConverter))]
    public class ZoomBarSettings
    {
        private readonly AxMap _map;

        public ZoomBarSettings(AxMap map)
        {
            _map = map;
            if (map == null)
            {
                throw new NullReferenceException("Inner reference is null");
            }
        }

        public int MaxZoom
        {
            get { return _map.ZoomBarMaxZoom; }
            set { _map.ZoomBarMaxZoom = value; }
        }

        public int MinZoom
        {
            get { return _map.ZoomBarMinZoom; }
            set { _map.ZoomBarMinZoom = value; }
        }

        public ZoomBarVerbosity Verbosity
        {
            get { return (ZoomBarVerbosity)_map.ZoomBarVerbosity; }
            set { _map.ZoomBarVerbosity = (tkZoomBarVerbosity)value; }
        }

        public bool Visible
        {
            get { return _map.ShowZoomBar; }
            set { _map.ShowZoomBar = value; }
        }
    }

    public class ZoomBarSettingsTypeConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return "<settings>";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(ZoomBarSettings), attributes).Sort(new [] {"MinZoom", "MaxZoom", "Verbosity", "Visible"});
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
