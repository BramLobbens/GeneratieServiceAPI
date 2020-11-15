using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace GeneratieServiceAPI.Extensions
{
    public static class HtmlExtensions
    {
        public static ContentResult GenerateHTML<T>(this T obj)
        {
            if (obj == null) return null;

            var sb = new StringBuilder();
            var htmlBegin = $@"<!DOCTYPE html><html lang='en'><head><meta charset='UTF-8'><title>{obj.GetType().Name}</title></head><body>";
            var htmlEnd = @"</div></body></html>";

            sb.Append(htmlBegin);

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                var attributeTag = SetHTMLAttributes(prop.Name);
                var beginTag = $"<p {attributeTag}>";
                var endTag = "</p>";

                if (prop.Name == "Id")
                {
                    sb.Append("<div id='").Append(prop.GetValue(obj, null)).Append("'>");
                }
                else
                {
                    sb.Append(beginTag).Append(prop.GetValue(obj, null)).Append(endTag);
                }
            }

            sb.Append(htmlEnd);

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 201,
                Content = sb.ToString()
            };
        }

        // Set html tag attribute for each value
        public static string SetHTMLAttributes(this string value)
        {
            return value switch
            {
                "Name" => "class='class-example' id='id-example'",
                "LastName" => "class='class-example'",
                // ... etc. Can be expanded upon as per requirements.
                _ => "" // Default
            };
        }
    }
}