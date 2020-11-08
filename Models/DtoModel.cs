using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GeneratieServiceAPI.Models
{
    [XmlRoot(ElementName = "Envelope")]
    public class DtoModel
    {
        [XmlElement(ElementName = "Sender")]
        public SenderDto Sender { get; set; }
        [XmlElement(ElementName = "Payload")]
        public PayloadDto Payload { get; set; }
    }

    public class SenderDto
    {
        [XmlElement(DataType = "string", ElementName = "Application")]
        public string Application { get; set; }
        [XmlElement(DataType = "string", ElementName = "Name")]
        public string Name { get; set; }
    }
    
    public class PayloadDto
    {
        [XmlElement(DataType = "string", ElementName = "OutputType")]
        public string OutputType { get; set; }
        [XmlElement(ElementName = "Parameters")]
        public ParameterDto Parameters { get; set; }
    }

    public class ParameterDto
    {
        [XmlElement(DataType = "string", ElementName = "Parameter")]
        public IEnumerable<string> Paramer { get; set; }
    }
}