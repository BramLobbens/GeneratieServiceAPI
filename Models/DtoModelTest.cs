using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GeneratieServiceAPI.Models
{
    [XmlRoot(ElementName = "Envelope")]
    public class DtoModelTest
    {
        [XmlElement(DataType = "string", ElementName = "Sender")]
        public string Sender { get; set; }
        [XmlElement(DataType = "string", ElementName = "Payload")]
        public string Payload { get; set; }
    }
}