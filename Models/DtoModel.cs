using System;
using System.Collections.Generic;

namespace GeneratieServiceAPI.Models
{
    public class DtoModel
    {
        public SenderDto Sender { get; set; }
        public PayloadDto Payload { get; set; }
    }

    public class SenderDto
    {
        public string Application { get; set; }
        public string Name { get; set; }
    }
    
    public class PayloadDto
    {
        public string OutputType { get; set; }
        public IEnumerable<string> Parameters { get; set; }
    }
}