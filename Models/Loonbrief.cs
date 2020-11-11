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

        //[XmlIgnore]
        public Guid Id { get; set ; }
        //elke parameter toevoegen dat moet verwerkt worden. 
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
        public string Registerkey { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Status { get; set; } //Burgerlijke staat
        public List<string> Dependents { get; set; } //Personen ten laste

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
                            <div>{Dependents}</div>
                            "
                            // To fix: generate multiple html tags for enumerable types
            };
        }
    }
}