using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace GeneratieServiceAPI.Models
{
    public class Loonbrief
    {
        public Loonbrief()
        { }

        public Guid Id { get; set ; }
        //elke parameter toevoegen dat moet verwerkt worden. 
        public string Name { get; set; } = null;
        public string LastName { get; set; } = null;
        public string Registerkey { get; set; } = null;
        public string Street { get; set; } = null;
        public int Number { get; set; } = 0;
        public int PostalCode { get; set; } = 0;
        public string City { get; set; } = null;
        public string Status { get; set; } = null; //Burgerlijke staat
        public List<string> Dependents { get; set; } = null; //Personen ten laste

        public ContentResult GenerateHTML()
        {
            return new ContentResult 
            {
                ContentType = "text/html",
                Content = $@"<div>{Id}</div>
                            <div>{Name}</div>
                            <div>{LastName}</div>
                            <div>{Registerkey}</div>
                            <div>{Street}</div>
                            <div>{Number}</div>
                            <div>{PostalCode}</div>
                            <div>{City}</div>
                            <div>{Status}</div>
                            <div>{Dependents}</div>n
                            "
                            // To fix: generate multiple html tags for enumerable types
            };
        }
    }
}