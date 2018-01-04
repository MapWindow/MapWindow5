using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using BruTile.Wms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using Layer = BruTile.Wms.Layer;

namespace MW5.Tiles.Helpers
{
    internal static class BruTileHelper
    {
        private static string GetRequestUrl(string url)
        {
            var argumentDivider = url.Contains("?") ? "&" : "?";
            return $"{url}{argumentDivider}REQUEST=GetCapabilities&SERVICE=WMS"; 
        }

        private static Stream GetRemoteXmlStream(Uri uri)
        {
            var myRequest = (HttpWebRequest)WebRequest.Create(uri);
            var myResponse = myRequest.GetResponse();
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
            var requestUrl = GetRequestUrl(url);
            return GetRemoteXmlStream(new Uri(requestUrl));
        }

        /// <summary>
        /// Creates MapWinGIS WMS provider based GetCapabilities definition and layers selected by user.
        /// </summary>
        public static WmsSource CreateWmsLayer(this WmsCapabilities capabilities, IEnumerable<Layer> layers, string serverUrl, ISpatialReference mapProjection)
        {
            var layersArray = layers as Layer[] ?? layers.ToArray();
            var layer = layersArray.FirstOrDefault();
            if (layer == null)
            {
                return null;
            }

            var box = layer.ChooseBoundingBox(mapProjection);
            if (box == null)
            {
                MessageService.Current.Info("Failed to determine bounds of the layer.");
                return null;
            }

            var epsg = -1;
            if (!ParseEpsg(box.CRS, ref epsg))
            {
                MessageService.Current.Info("Failed to determine coordinate system for the layer.");
                return null;
            }

            var provider = new WmsSource("WMS provider")
            {
                Layers = GetLayers(layersArray),
                Epsg = epsg,
                BoundingBox = new Envelope(box.MinX, box.MaxX, box.MinY, box.MaxY),
                BaseUrl = serverUrl,
                Format = capabilities.GetFormat()
            };

            return provider;
        }

        private static string GetFormat(this WmsCapabilities capabilities)
        {
            var list = capabilities.Capability.Request.GetMap.Format;
            return list.Count > 2 ? list[2] : list.FirstOrDefault();
        }

        private static string GetLayers(this IEnumerable<Layer> layers)
        {
            return StringHelper.Join(layers.Select(l => l.Name), ",");
        }

        private static BoundingBox ChooseBoundingBox(this Layer layer, ISpatialReference mapProjection)
        {
            // can be used to double check, but there is little use of it we don't have bounds in particular projection
            //foreach (var crs in layer.SRS)
            //{
            //    if (ParseEpsg(crs, ref epsg))
            //    {
            //        yield return epsg;
            //    }
            //}

            if (mapProjection == null) return layer.BoundingBox.FirstOrDefault();

            foreach (var box in layer.BoundingBox)
            {
                if (IsSameProjection(box, mapProjection))
                {
                    return box;
                }
            }

            return layer.BoundingBox.FirstOrDefault();
        }

        private static bool IsSameProjection(BoundingBox box, ISpatialReference mapProjection)
        {
            var epsg = -1;
            if (!ParseEpsg(box.CRS, ref epsg)) return false;

            var sr = new SpatialReference();
            return sr.ImportFromEpsg(epsg) && sr.IsSame(mapProjection);
        }

        private static bool ParseEpsg(string crs, ref int epsg)
        {
            if (string.IsNullOrWhiteSpace(crs) || crs.Length <= 5) return false;
            crs = crs.Substring(5);
            return int.TryParse(crs, out epsg);
        }
    }
}
