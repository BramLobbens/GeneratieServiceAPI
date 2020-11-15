using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace GeneratieServiceAPI.Extensions
{
    public static class XmlExtensions
    {
        public static ContentResult Serialize<T>(this T dataToSerialize)
        {
            if (dataToSerialize == null) return null;
            using var writer = new StringWriter();
            var serializer = new XmlSerializer(dataToSerialize.GetType());
            serializer.Serialize(writer, dataToSerialize);

            return new ContentResult
            {
                ContentType = "application/xml",
                StatusCode = 201,
                Content = writer.ToString()
            };
        }
    }
}