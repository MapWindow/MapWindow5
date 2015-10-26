// -------------------------------------------------------------------------------------------
// <copyright file="RowData.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace MW5.Plugins.Printing.Model.Table
{
    /// <summary>
    /// Holds data for a row
    /// </summary>
    public class RowData : List<string>
    {
        public RowData()
        {
        }

        public RowData(IEnumerable<string> collection)
            : base(collection)
        {
        }

        public object[] ToObjectArray()
        {
            // ReSharper disable once CoVariantArrayConversion
            return ToArray();
        }
    }
}