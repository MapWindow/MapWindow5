using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace MW5.Shared
{
    /// <summary>
    /// Serializes and deserializes objects with DataContractSerializer.
    /// </summary>
    public static class DataContractSerializationHelper
    {
        private const int MaxStringContentLength = 1048576;

        public static T Deserialize<T>(this string targetString)
        {
            return Deserialize<T>(targetString, null);
        }

        public static T Deserialize<T>(this string xml, IEnumerable<Type> knownTypes)
        {
            return (T)Deserialize(xml, typeof(T), knownTypes);
        }

        public static object Deserialize(this string xml, Type type, IEnumerable<Type> knownTypes)
        {
            Encoding encoding = XmlSerializationHelper.GetXmlDocEncoding(xml);

            using (var stream = new MemoryStream(encoding.GetBytes(xml)))
            {
                var quota = new XmlDictionaryReaderQuotas() { MaxStringContentLength = MaxStringContentLength };
                using (var reader = XmlDictionaryReader.CreateTextReader(stream, quota))
                {
                    var ser = new DataContractSerializer(type, knownTypes, Int32.MaxValue, false, false, null);
                    return ser.ReadObject(reader);
                }
            }
        }

        public static string Serialize<T>(this T target)
        {
            return Serialize(target, null, true);
        }

        public static string Serialize<T>(this T target, bool preserveObjectReferences)
        {
            return Serialize(target, null, preserveObjectReferences);
        }

        public static string Serialize<T>(this T target, IEnumerable<Type> knownTypes, bool preserveObjectReferences)
        {
            using (var writer = new StringWriter())
            {
                using (XmlTextWriter xmlWriter = new XmlTextWriter(writer))
                {
                    xmlWriter.Formatting = Formatting.Indented;
                    var ser = new DataContractSerializer(typeof(T), knownTypes, Int32.MaxValue, false, preserveObjectReferences, null);
                    ser.WriteObject(xmlWriter, target);

                    return writer.ToString();
                }
            }
        }

        public static T DeserializeXmlElement<T>(XmlElement el, IEnumerable<Type> knownTypes)
        {
            XmlReader reader = new XmlNodeReader(el);

            var ser = new DataContractSerializer(typeof(T), knownTypes, Int32.MaxValue, false, false, null);
            var o = ser.ReadObject(reader);
            return (T)o;
        }

        public static XmlElement SerializeToElement<T>(this T target, IEnumerable<Type> knownTypes, bool preserveObjectReferences)
        {
            using (var stream = new MemoryStream())
            {
                var ser = new DataContractSerializer(typeof(T), knownTypes, Int32.MaxValue, false, preserveObjectReferences, null);

                ser.WriteObject(stream, target);
                var doc = new XmlDocument();

                stream.Flush();
                stream.Position = 0;

                doc.Load(stream);
                return doc.DocumentElement;
            }
        }
    }
}
