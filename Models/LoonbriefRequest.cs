using System;

namespace GeneratieServiceAPI.Models
{
    public class LoonbriefRequest
    {
        public LoonbriefRequest()
        { }

        //elke parameter toevoegen dat moet verwerkt worden. 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Registerkey { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Status { get; set; } //Burgerlijke staat
        public string Dependents { get; set; } //Personen ten laste
    }
}