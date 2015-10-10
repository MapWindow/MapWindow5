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
using MW5.Shared;

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
            string requestUrl = GetRequestUrl(url);

            using (var stream = GetRemoteXmlStream(new Uri(requestUrl)))
            {
                return new WmsCapabilities(stream);
            }
        }

        /// <summary>
        /// Creates MapWinGIS WMS provider based GetCapabilities definition and layers selected by user.
        /// </summary>
        public static WmsProviderDef CreateProvider(
            this WmsCapabilities capabilities,
            IEnumerable<BruTile.Wms.Layer> layers)
        {
            string layersCsv = StringHelper.Join(layers.Select(l => l.Name), ",");
            
            // TODO: provide id and name in the UI
            var provider = new WmsProviderDef(5000, "Custom WMS provider") { LayersCsv = layersCsv };

            // TODO: add other parameters
            return provider;
        }
    }
}
