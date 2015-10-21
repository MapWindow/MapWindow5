using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BruTile.Extensions;
using BruTile.Wms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Shared;
using Layer = BruTile.Wms.Layer;

namespace MW5.Tiles.Helpers
{
    internal static class BruTileHelper
    {
        private static string GetRequestUrl(string url)
        {
            return string.Format("{0}?REQUEST=GetCapabilities&SERVICE=WMS", url);   //&VERSION=1.1.1
        }

        private static Stream GetRemoteXmlStream(Uri uri)
        {
            var myRequest = (HttpWebRequest)WebRequest.Create(uri);
            var myResponse = myRequest.GetSyncResponse(30000);
            var stream = myResponse.GetResponseStream();
            return stream;
        }

        public static WmsCapabilities GetWmsCapabilities(string url)
        {
            using (var stream = GetWmsCapabilitiesStream(url))
            {
                return new WmsCapabilities(stream);
            }
        }

        public static Stream GetWmsCapabilitiesStream(string url)
        {
            string requestUrl = GetRequestUrl(url);

            return GetRemoteXmlStream(new Uri(requestUrl));
        }

        /// <summary>
        /// Creates MapWinGIS WMS provider based GetCapabilities definition and layers selected by user.
        /// </summary>
        public static WmsSource CreateWmsLayer(this WmsCapabilities capabilities, IEnumerable<Layer> layers, string serverUrl)
        {
            var layer = layers.FirstOrDefault();
            if (layer == null)
            {
                return null;
            }
            
            var provider = new WmsSource("WMS provider")
            {
                Layers = GetLayers(layers),
                Epsg = layer.GetEpsg(),
                BoundingBox = layer.GetBoundingBox(),
                BaseUrl = serverUrl,
                Format = capabilities.GetFormat()
            };

            return provider;
        }

        private static string GetFormat(this WmsCapabilities capabilities)
        {
            var list = capabilities.Capability.Request.GetMap.Format;
            if (list.Count > 2)
            {
                return list[2];
            }

            return list.FirstOrDefault();
        }

        private static string GetLayers(this IEnumerable<Layer> layers)
        {
            return StringHelper.Join(layers.Select(l => l.Name), ",");
        }

        private static IEnvelope GetBoundingBox(this Layer layer)
        {
            var box = layer.BoundingBox.FirstOrDefault();
            if (box == null)
            {
                return null;
            }

            return new Envelope(box.MinX, box.MaxX, box.MinY, box.MaxY);
        }

        private static int GetEpsg(this Layer layer)
        {
            int epsg = -1;
            var crs = layer.SRS.FirstOrDefault();

            if (ParseEpsg(crs, ref epsg))
            {
                return epsg;
            }

            var box = layer.BoundingBox.FirstOrDefault();
            if (box != null)
            {
                if (ParseEpsg(box.CRS, ref epsg))
                {
                    return epsg;
                }
            }

            return epsg;
        }

        private static bool ParseEpsg(string crs, ref int epsg)
        {
            epsg = -1;

            if (!string.IsNullOrWhiteSpace(crs) && crs.Length > 5)
            {
                crs = crs.Substring(5);
                if (Int32.TryParse(crs, out epsg))
                {
                    return true;                    
                }
            }

            return false;
        }
    }
}
