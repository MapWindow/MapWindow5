// -------------------------------------------------------------------------------------------
// <copyright file="GeneralTypeConverter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;

namespace MW5.Plugins.Printing.Services
{
    /// <summary>
    /// PropertyGridTypeConverter
    /// </summary>
    public class GeneralTypeConverter : StringConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }

        public override object ConvertTo(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value,
            Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value == null ? "[Empty]" : "[Edit...]";
            }
            return null;
        }
    }
}