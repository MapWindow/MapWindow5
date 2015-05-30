using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Concrete;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Services.Serialization
{
    /// <summary>
    /// Saves / loads entire layer settings (ocx, legend and plugin state).
    /// </summary>
    public static class LayerSerializationHelper
    {
        private const string FileExtension = ".mwlayer";

        public static bool SaveSettings(ILegendLayer layer)
        {
            if (!CheckFilename(layer.Filename)) return false;

            var xml = new XmlLayer(layer);
            string state = xml.Serialize(false);

            try
            {
                string filename = layer.Filename + FileExtension;

                using (var writer = new StreamWriter(filename))
                {
                    writer.Write(state);
                    writer.Flush();
                    MessageService.Current.Info("Layer settings were saved: " + filename);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn("Failed to save project: " + ex.Message);
            }

            return false;
        }

        public static bool LoadSettings(ILegendLayer layer, bool silent)
        {
            if (!CheckFilename(layer.Filename)) return false;

            string filename = layer.Filename + FileExtension;
            if (!File.Exists(filename))
            {
                return false;       // nothing to load
            }

            try
            {

                using (var reader = new StreamReader(filename))
                {
                    string xml = reader.ReadToEnd();
                    var xmlLayer = xml.Deserialize<XmlLayer>();
                    xmlLayer.RestoreLayer(layer);
                    return true;
                }
            }
            catch (Exception ex)
            {
                const string msg = "Failed to deserialize layer";
                Logger.Current.Warn(msg, ex);
                
                if (!silent)
                {
                    MessageService.Current.Warn(msg + ": " + ex.Message);
                }
            }

            return false;
        }

        private static bool CheckFilename(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename))
            {
                Logger.Current.Info("Can't save settings for non disk-based layer");
                return false;
            }

            return true;
        }
    }
}
