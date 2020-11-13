using System;
using System.IO;
using System.Xml.Serialization;

namespace GeneratieServiceAPI.Extensions
{
    public static class XmlExtensions
    {
        public static string Serialize<T>(T dataToSerialize)
        {
            if (dataToSerialize == null) return null;
            using (var writer = new StringWriter())
            {
                var serializer = new XmlSerializer(dataToSerialize.GetType());
                serializer.Serialize(writer, dataToSerialize);
                return writer.ToString();
            }
        }

        public static T Deserialize<T>(string xmlText)
        {
            if (String.IsNullOrWhiteSpace(xmlText)) return default(T);

            using (var reader = new StringReader(xmlText))
            {
                var serializer = new XmlSerializer(xmlText.GetType());
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}