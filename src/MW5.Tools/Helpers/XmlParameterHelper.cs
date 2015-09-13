using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MW5.Api.Concrete;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Performs serialization / deserialization of XML parameters.
    /// </summary>
    public static class XmlParameterHelper
    {
        /// <summary>
        /// An implementation IXmlSerializable interface for a list of parameters.
        /// </summary>
        public static void WriteParameters(this XmlWriter writer, IEnumerable<BaseParameter> parameters)
        {
            foreach (var p in parameters.Where(p => p.Serializable))
            {
                var xml = p as IXmlSerializable;
                if (xml != null)
                {
                    writer.WriteStartElement(p.Name);
                    xml.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }
        }

        /// <summary>
        /// An implementation IXmlSerializable interface for a list of parameters.
        /// </summary>
        public static void ReadParameters(this XmlReader reader, IEnumerable<BaseParameter> parameters)
        {
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element)
                {
                    continue;
                }

                string name = reader.LocalName;

                var item = parameters.FirstOrDefault(p => p.Name.EqualsIgnoreCase(name));
                if (item != null && item.Serializable)
                {
                    var xml = item as IXmlSerializable;
                    if (xml != null)
                    {
                        xml.ReadXml(reader);
                    }
                }
            }
        }

        /// <summary>
        /// Gets path of the file with configuration info for the driver.
        /// </summary>
        private static string GetConfigPath(this DatasourceDriver driver)
        {
            return ConfigPathHelper.GetDriversConfigPath() + driver.Name + ".xml";
        }

        /// <summary>
        /// Saves configuration of the tool.
        /// </summary>
        public static void SaveConfig(this DatasourceDriver driver, IEnumerable<BaseParameter> parameters)
        {
            try
            {
                string xml = Serialize(parameters);

                string filename = GetConfigPath(driver);

                PathHelper.CreateFolder(filename);

                File.WriteAllText(filename, xml);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to serialize tool settings.", ex);
            }
        }

        /// <summary>
        /// Restores last used parameters of the tool from the disk based config file.
        /// </summary>
        public static void RestoreConfig(this DatasourceDriver driver, IEnumerable<BaseParameter> parameters)
        {
            string filename = driver.GetConfigPath();

            if (!File.Exists(filename))
            {
                return;
            }

            try
            {
                using (var reader = new StreamReader(filename))
                {
                    using (var xmlReader = new XmlTextReader(reader))
                    {
                        xmlReader.ReadStartElement();

                        xmlReader.ReadParameters(parameters);

                        foreach (var p in parameters)
                        {
                            p.DefaultValue = p.PreviousValue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to deserialize tool settings.", ex);
            }
        }

        private static string Serialize(IEnumerable<BaseParameter> parameters)
        {
            using (var writer = new StringWriter())
            {
                using (XmlTextWriter xmlWriter = new XmlTextWriter(writer))
                {
                    xmlWriter.Formatting = Formatting.Indented;

                    xmlWriter.WriteStartElement("Driver");
                    xmlWriter.WriteParameters(parameters);
                    xmlWriter.WriteEndElement();

                    return writer.ToString();
                }
            }
        }
    }
}
