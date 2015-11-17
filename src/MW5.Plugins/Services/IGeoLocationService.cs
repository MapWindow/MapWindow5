// -------------------------------------------------------------------------------------------
// <copyright file="IGeoLocationService.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Interfaces;

namespace MW5.Plugins.Services
{
    public interface IGeoLocationService
    {
        string License { get; }

        IEnvelope FindLocation(string query);
    }
}