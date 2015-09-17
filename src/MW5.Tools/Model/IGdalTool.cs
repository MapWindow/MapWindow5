// -------------------------------------------------------------------------------------------
// <copyright file="IGdalTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

namespace MW5.Tools.Model
{
    public interface IGdalTool
    {
        string EffectiveOptions { get; }

        bool OverrideOptions { get; set; }

        string AdditionalOptions { get; set; }

        string GetOptions(bool mainOnly = false);

        bool SupportDriverCreationOptions { get; }
    }
}