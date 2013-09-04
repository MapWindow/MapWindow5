using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace BL.Utilities
{
    public static class SerializationExtensions
    {
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


        public static string SerializeXml<T>(this T target)
        {
            return SerializeXml<T>(target, null);
        }


        public static string SerializeXml<T>(this T target, IEnumerable<Type> knownTypes)
        {
            using (var stream = new MemoryStream())
            {
                Encoding encoding = Encoding.UTF8;
                using (XmlTextWriter xmlWriter = new XmlTextWriter(stream, encoding))
                {
                    xmlWriter.Formatting = Formatting.Indented;

                    // Create our own namespaces for the output
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                    // Add an empty namespace and empty value
                    ns.Add(String.Empty, String.Empty);

                    var ser = new XmlSerializer(typeof(T));

                    ser.Serialize(xmlWriter, target, ns);

                    stream.Flush();
                    stream.Position = 0;
                    StreamReader sr = new StreamReader(stream);
                    string result = sr.ReadToEnd();
                    return result;
                }
            }
        }


        public static T Deserialize<T>(this string targetString)
        {
            return Deserialize<T>(targetString, null);
        }


        public static T Deserialize<T>(this string targetString, IEnumerable<Type> knownTypes)
        {
            Encoding encoding = GetXmlDocEncoding(targetString);

            using (var stream = new MemoryStream(encoding.GetBytes(targetString)))
            {
                using (var reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas()))
                {
                    var ser = new DataContractSerializer(typeof(T), knownTypes, Int32.MaxValue, false, true, null);

                    // Deserialize the data and read it from the instance.
                    return (T)ser.ReadObject(reader);
                }
            }
        }

        private static Encoding GetXmlDocEncoding(string targetString)
        {
            Encoding encoding = Encoding.UTF8;

            using (XmlTextReader reader = new XmlTextReader(new StringReader(targetString)))
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


        public static T DeserializeXml<T>(this string targetString)
        {
            return DeserializeXml<T>(targetString, null);
        }


        public static T DeserializeXml<T>(this string targetString, IEnumerable<Type> knownTypes)
        {
            Encoding encoding = GetXmlDocEncoding(targetString);

            using (var stream = new MemoryStream(encoding.GetBytes(targetString)))
            {

                XmlDictionaryReaderQuotas xmlDict = new XmlDictionaryReaderQuotas();
                xmlDict.MaxStringContentLength = 285192;

                using (var reader = XmlDictionaryReader.CreateTextReader(stream, xmlDict))
                {
                    //MaxStringContentLength 

                    var ser = new XmlSerializer(typeof(T));

                    // Deserialize the data and read it from the instance.
                    return (T)ser.Deserialize(reader);
                }
            }
        }

        public static string SerializeXml(XmlDocument doc)
        {
            var sb = new StringBuilder();
            var settings =
                new XmlWriterSettings
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
    }
}
