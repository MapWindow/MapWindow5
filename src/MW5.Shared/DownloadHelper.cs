// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DownloadHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the DownloadHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MW5.Shared
{
    public static class DownloadHelper
    {
        /// <summary>
        /// Downloads the binary asynchronously.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="filename">The filename.</param>
        /// <returns>The task</returns>
        public static async Task DownloadBinaryAsync(string url, string filename)
        {
            Logger.Current.Debug("Start downloading new installer");
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    using (var streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        using (Stream streamToWriteTo = File.Open(filename, FileMode.Create))
                        {
                            await streamToReadFrom.CopyToAsync(streamToWriteTo);
                            Logger.Current.Info("New installer is downloaded and saved as " + filename);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Downloads the serialized json data asynchronous.
        /// </summary>
        /// <typeparam name="T">The type of output we expect our JSON data to be deserialized into</typeparam>
        /// <param name="url">The URL.</param>
        /// <remarks>http://www.constantinosorphanides.com/950/asynchronous-json-downloader-and-serializer-class-for-c-sharp/</remarks>
        /// <returns>The deserialized object</returns>
        public static async Task<T> DownloadSerializedJSONDataAsync<T>(string url) where T : new()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string jsonData;
                try
                {
                    jsonData = await httpClient.GetStringAsync(url);
                }
                catch (Exception ex)
                {
                    Logger.Current.Debug("Exception in DownloadSerializedJSONDataAsync: " + ex.Message);
                    return default(T);
                }

                return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : default(T);
            }
        }
    }
}