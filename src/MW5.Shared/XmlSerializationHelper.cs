// -------------------------------------------------------------------------------------------
// <copyright file="XmlSerializationHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MW5.Shared
{
    /// <summary>
    /// Serializes and deserializes objects with XmlSerializer.
    /// </summary>
    public static class XmlSerializationHelper
    {
        public static T DeserializeFromXml<T>(this string targetString)
        {
            return DeserializeFromXml<T>(targetString, null);
        }

        public static T DeserializeFromXml<T>(this string targetString, IEnumerable<Type> knownTypes)
        {
            var encoding = GetXmlDocEncoding(targetString);

            using (var stream = new MemoryStream(encoding.GetBytes(targetString)))
            {
                var xmlDict = new XmlDictionaryReaderQuotas { MaxStringContentLength = 285192 };

                using (var reader = XmlDictionaryReader.CreateTextReader(stream, xmlDict))
                {
                    var ser = new XmlSerializer(typeof(T));

                    return (T)ser.Deserialize(reader);
                }
            }
        }

        public static T DeserializeXmlElement<T>(XmlElement el)
        {
            XmlReader reader = new XmlNodeReader(el);

            var ser = new XmlSerializer(typeof(T));
            var o = ser.Deserialize(reader);
            return (T)o;
        }

        public static XmlElement SerializeToElement<T>(this T target)
        {
            using (var stream = new MemoryStream())
            {
                var ser = new XmlSerializer(target.GetType());

                var ns = new XmlSerializerNamespaces();
                ns.Add(String.Empty, String.Empty);

                ser.Serialize(stream, target, ns);
                var doc = new XmlDocument();

                stream.Flush();
                stream.Position = 0;

                doc.Load(stream);
                return doc.DocumentElement;
            }
        }

        public static string SerializeToXml<T>(this T target)
        {
            return SerializeToXml(target, null);
        }

        public static string SerializeToXml<T>(this T target, IEnumerable<Type> knownTypes)
        {
            using (var stream = new MemoryStream())
            {
                var encoding = Encoding.UTF8;
                using (var xmlWriter = new XmlTextWriter(stream, encoding))
                {
                    xmlWriter.Formatting = Formatting.Indented;

                    // create an empty namespace for output
                    var ns = new XmlSerializerNamespaces();
                    ns.Add(String.Empty, String.Empty);

                    var ser = new XmlSerializer(typeof(T));

                    ser.Serialize(xmlWriter, target, ns);

                    stream.Flush();
                    stream.Position = 0;
                    var sr = new StreamReader(stream);
                    string result = sr.ReadToEnd();
                    return result;
                }
            }
        }

        public static string SerializeToXml(XmlDocument doc)
        {
            var sb = new StringBuilder();
            var settings = new XmlWriterSettings
                               {
                                   Indent = true,
                                   IndentChars = @"    ",
                                   NewLineChars = Environment.NewLine,
                                   NewLineHandling = NewLineHandling.Replace,
                               };

            using (var writer = XmlWriter.Create(sb, settings))
            {
                if (doc.ChildNodes[0] is XmlProcessingInstruction)
                {
                    doc.RemoveChild(doc.ChildNodes[0]);
                }

                doc.Save(writer);
                return sb.ToString();
            }
        }

        internal static Encoding GetXmlDocEncoding(string targetString)
        {
            var encoding = Encoding.UTF8;

            using (var reader = new XmlTextReader(new StringReader(targetString)))
            {
                reader.Read();
                if (reader.LocalName.Equals("xml", StringComparison.InvariantCultureIgnoreCase))
                {
                    while (reader.MoveToNextAttribute())
                    {
                        if (reader.Name.Equals("encoding", StringComparison.InvariantCultureIgnoreCase))
                        {
                            encoding = Encoding.GetEncoding(reader.Value);
                        }
                    }
                }
            }
            return encoding;
        }
    }
}