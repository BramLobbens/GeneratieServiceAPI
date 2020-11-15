using System;
using System.Xml.Serialization;

namespace GeneratieServiceAPI.Models
{
    public class LoonbriefRequest
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [XmlElement("RegisterKey")]
        public string Registerkey { get; set; }
        [XmlElement("Street")]
        public string Street { get; set; }
        [XmlElement("Number")]
        public string Number { get; set; }
        [XmlElement("PostalCode")]
        public string PostalCode { get; set; }
        [XmlElement("City")]
        public string City { get; set; }
        [XmlElement("Status")]
        public string Status { get; set; }
        [XmlElement("Dependents")]
        public string Dependents { get; set; }
    }
}