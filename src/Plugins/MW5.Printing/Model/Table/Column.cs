// -------------------------------------------------------------------------------------------
// <copyright file="Column.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Drawing;
using MW5.Plugins.Printing.Enums;

namespace MW5.Plugins.Printing.Model.Table
{
    public class Column
    {
        public Column(string name)
        {
            ActualWidth = 100;
            Alignment = StringAlignment.Near;
            RelWidth = 20;
            Width = 100;
            WidthType = ColumnWidthType.Auto;
            Name = name;
        }

        public float ActualWidth { get; set; }

        public StringAlignment Alignment { get; set; }

        public bool HalfCellOffset { get; set; }

        public string Name { get; set; }

        public int RelWidth { get; set; }

        public int Width { get; set; }

        public ColumnWidthType WidthType { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}