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
using MW5.Plugins.Services;
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
            string requestUrl = GetRequestUrl(url);

            return GetRemoteXmlStream(new Uri(requestUrl));
        }

        /// <summary>
        /// Creates MapWinGIS WMS provider based GetCapabilities definition and layers selected by user.
        /// </summary>
        public static WmsSource CreateWmsLayer(this WmsCapabilities capabilities, IEnumerable<Layer> layers, string serverUrl, ISpatialReference mapProjection)
        {
            var layer = layers.FirstOrDefault();
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

            int epsg = -1;
            if (!ParseEpsg(box.CRS, ref epsg))
            {
                MessageService.Current.Info("Failed to determine coordinate system for the layer.");
                return null;
            }

            var provider = new WmsSource("WMS provider")
            {
                Layers = GetLayers(layers),
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

            if (mapProjection != null)
            {
                foreach (var box in layer.BoundingBox)
                {
                    if (IsSameProjection(box, mapProjection))
                    {
                        return box;
                    }
                }
            }

            return layer.BoundingBox.FirstOrDefault();
        }

        private static bool IsSameProjection(BoundingBox box, ISpatialReference mapProjection)
        {
            int epsg = -1;
            if (ParseEpsg(box.CRS, ref epsg))
            {
                var sr = new SpatialReference();
                if (sr.ImportFromEpsg(epsg))
                {
                    if (sr.IsSame(mapProjection))
                    {
                        return true;
                    }
                }
            }

            return false;
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
