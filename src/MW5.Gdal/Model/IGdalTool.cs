// -------------------------------------------------------------------------------------------
// <copyright file="IGdalTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Tools.Model.Parameters;

namespace MW5.Gdal.Model
{
    public interface IGdalTool
    {
        string AdditionalOptions { get; set; }

        string GetOptions(bool mainOnly = false);

        bool SupportDriverCreationOptions { get; }
    }
}