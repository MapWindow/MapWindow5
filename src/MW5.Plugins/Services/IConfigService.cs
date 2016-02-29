// -------------------------------------------------------------------------------------------
// <copyright file="IConfigService.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Plugins.Concrete;

namespace MW5.Plugins.Services
{
    public interface IConfigService
    {
        AppConfig Config { get; }

        string ConfigPath { get; }

        void LoadAll();

        bool LoadConfig();

        void SaveAll();

        bool SaveConfig();
    }
}