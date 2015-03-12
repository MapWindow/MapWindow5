using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace MW5.Services.Serialization.Utility
{
    public static class DataContractSerializationHelper
    {
        public static T Deserialize<T>(this string targetString)
        {
            return Deserialize<T>(targetString, null);
        }


        public static T Deserialize<T>(this string targetString, IEnumerable<Type> knownTypes)
        {
            Encoding encoding = XmlSerializationHelper.GetXmlDocEncoding(targetString);

            using (var stream = new MemoryStream(encoding.GetBytes(targetString)))
            {
                using (var reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas()))
                {
                    var ser = new DataContractSerializer(typeof(T), knownTypes, Int32.MaxValue, false, false, null);
                    return (T)ser.ReadObject(reader);
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
    }
}
