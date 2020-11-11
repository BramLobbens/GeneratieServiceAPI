using System;
using System.Collections;
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
        [XmlElement(ElementName = "GenerateDocument")]
        public GenerateDocumentDto  GenerateDocument { get; set; }
    }

    public class GenerateDocumentDto
    {
        [XmlElement(DataType = "string", ElementName = "OutputType")]
        public string OutputType { get; set; }
        [XmlArray(ElementName = "Parameters", IsNullable = true)]
        [XmlArrayItem(ElementName = "Parameter", IsNullable = true)]
        public Parameter[] Parameters { get; set; }
    }

    public class Parameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}