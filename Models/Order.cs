using System;
using System.Collections.Generic;

namespace GeneratieServiceAPI.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public IEnumerable<string> ItemsIds { get; set; }
    }
}