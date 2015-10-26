// -------------------------------------------------------------------------------------------
// <copyright file="TileLoadingTask.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Plugins.Printing.Model
{
    public class TileLoadingTask
    {
        public IEnvelope Extents { get; set; }

        public string Guid { get; set; }

        public TileProvider TileProvider { get; set; }

        public int Width { get; set; }
    }
}