using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BruTile.Wms;
using MW5.Plugins.Helpers;
using MW5.Shared;
using Exception = System.Exception;

namespace MW5.Tiles.Helpers
{
    /// <summary>
    /// Saves results of GetCapabilities requests locally.
    /// </summary>
    internal static class WmsCapabilitiesCache
    {
        private static string GetXmlPath(string url)
        {
            url = System.Uri.UnescapeDataString(url.Replace('/', '_').Replace(':', '_').Replace('?', '_'));
            return ConfigPathHelper.GetWmsCachePath() + url + ".xml";
        }

        public static bool Save(string url, Stream stream)
        {
            string path = GetXmlPath(url);

            try
            {
                PathHelper.CreateFolder(path);

                using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to save WMS capabilities to the disk: {0}", ex, path);
            }

            return false;
        }

        public static WmsCapabilities Load(string url)
        {
            string path = GetXmlPath(url);

            if (File.Exists(path))
            {
                try
                {
                    using (var stream = File.OpenRead(path))
                    {
                        return new WmsCapabilities(stream);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Current.Warn("Failed to load WMS capabilities from the disk: {0}", ex, path);
                }
            }

            return null;
        }
    }
}
