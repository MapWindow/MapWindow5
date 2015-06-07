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
        private const string FileExtensionAlt = ".mwsymb";
        private const string FileExtensionAlt2 = ".mwleg";

        private static IEnumerable<string> Extensions
        {
            get
            {
                yield return FileExtension;
                yield return FileExtensionAlt;
                yield return FileExtensionAlt2;
            }
        }

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

        public static void RemoveSettings(ILegendLayer layer, bool silent)
        {
            if (!CheckFilename(layer.Filename)) return;

            bool existed = false;

            foreach (var ext in Extensions)
            {
                string filename = layer.Filename + ext;

                if (!File.Exists(filename)) continue;

                existed = true;

                try
                {
                    File.Delete(filename);
                }
                catch (Exception ex)
                {
                    Logger.Current.Info("Failed to remove style for layer.", ex);

                    if (!silent)
                    {
                        MessageService.Current.Warn("Failed to remove style: " + filename);
                    }

                    return;
                }
            }

            if (existed)
            {
                MessageService.Current.Info("Layer style was removed.");
            }
            else
            {
                DisplayStylesNotFound(layer);
            }
        }

        private static void DisplayStylesNotFound(ILegendLayer layer)
        {
            string msg = "No styles were found for the datasource." + Environment.NewLine + Environment.NewLine +
                         "Filenames checked: " + Environment.NewLine;

            foreach (var ext in Extensions)
            {
                msg += layer.Filename + ext + Environment.NewLine;
            }

            MessageService.Current.Info(msg);
        }

        public static bool LoadSettings(ILegendLayer layer, IBroadcasterService broadcaster, bool silent)
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
                    xmlLayer.RestoreLayer(layer, broadcaster);
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
