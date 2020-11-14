using System;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace GeneratieServiceAPI.Extensions
{
    public static class HtmlExtensions
    {
        public static ContentResult GenerateHTML<T>(T obj)
        {
            if (obj == null) return null;

            var html = "";
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                // expand on different html tags used
                html += $"<div>{prop.GetValue(obj, null)}</div>";
            }

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 201,
                Content = html
            };
        }
    }
}