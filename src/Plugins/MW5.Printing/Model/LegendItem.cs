// -------------------------------------------------------------------------------------------
// <copyright file="LegendItem.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;

namespace MW5.Plugins.Printing.Model
{
    internal class LegendItem
    {
        public ILegendLayer Layer { get; set; }
        public string Name { get; set; }
        public IGeometryStyle Options { get; set; }
        public RasterInterval RasterBreak { get; set; }
    }
}