using System;
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
                // mental note: if prop is of certain type allocate different html tag
                html += $"<div>{prop.GetValue(obj, null)}</div>";
            }

            return new ContentResult
            {
                ContentType = "text/html",
                Content = html
            };
        }
    }
}