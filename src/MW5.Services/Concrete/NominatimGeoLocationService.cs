// -------------------------------------------------------------------------------------------
// <copyright file="GeoLocationService.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Services.Concrete
{
    internal class NominatimGeoLocationService : IGeoLocationService
    {
        private static string _license = "";

        public string License
        {
            get { return _license; }
        }

        public IEnvelope FindLocation(string query)
        {
            string json = ResquestLocation(query);
            return ParseResult(json);
        }

        private IEnvelope ParseResult(string result)
        {
            try
            {
                var serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
                dynamic obj = serializer.Deserialize(result, typeof(object));

                var box = ParseBoundingBox(obj);

                UpdateLicense(obj);

                return box;
            }
            catch
            {
                throw new ApplicationException("Failed to find coordinates of location.");
            }
        }

        private IEnvelope ParseBoundingBox(dynamic obj)
        {
            var numbers = new List<double>();

            for (int i = 0; i < 4; i++)
            {
                numbers.Add(double.Parse(obj[0].boundingbox[i], CultureInfo.InvariantCulture));
            }

            IEnvelope box = null;
            if (numbers.Count == 4)
            {
                double lat1 = numbers[0];
                double lat2 = numbers[1];
                double lng1 = numbers[2];
                double lng2 = numbers[3];
                box = new Envelope();
                box.SetBounds(lng1, lng2, lat1, lat2);
            }

            return box;
        }

        private void UpdateLicense(dynamic obj)
        {
            try
            {
                _license = obj[0].licence;
            }
            catch
            {
            }
        }

        private string ResquestLocation(string query)
        {
            var url = string.Format("http://nominatim.openstreetmap.org/search/{0}?format=json&limit=1", query);
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Referer = "mapwindow5.codeplex.com";
            request.UserAgent =
                "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1.7) Gecko/20091221 Firefox/3.5.7";
            request.Timeout = 5000;
            request.ReadWriteTimeout = request.Timeout * 6;
            request.Accept = "*/*";
            string result = "";

            try
            {
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            using (var responseStream = response.GetResponseStream())
                            {
                                if (responseStream != null)
                                {
                                    using (var read = new StreamReader(responseStream, Encoding.UTF8))
                                    {
                                        result = read.ReadToEnd();
                                    }
                                }
                            }
                        }
                        response.Close();
                    }
                }
            }
            catch
            {
                throw new ApplicationException("Failed to run HTTP request.");
            }
            return result;
        }
    }
}