using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace GeneratieServiceAPI.Models
{
    public class Loonbrief
    {
        private string _name;
        private string _lastName;
        private string _city;
        private string _postalCode;
        [XmlAttribute("Id")]
        public Guid Id { get; set; }
        //elke parameter toevoegen dat moet verwerkt worden. 
        public string Name
        {
            get { return _name; }
            set
            {
                if (Regex.IsMatch(value, @"^\p{Lu}\p{Ll}*$"))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("No correct value.");
                }
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (Regex.IsMatch(value, @"^\p{Lu}\p{Ll}*$"))
                {
                    _lastName = value;
                }
                else
                {
                    throw new ArgumentException("No correct value.");
                }
            }
        }
        public string Registerkey { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                // if value is in zipcode-belgium
                using (StreamReader r = new StreamReader(@"Data\zipcode-belgium.json"))
                {
                    using (JsonDocument document = JsonDocument.Parse(r.ReadToEnd()))
                    {
                        foreach (JsonElement el in document.RootElement.EnumerateArray())
                        {
                            if (el.TryGetProperty("zip", out JsonElement result))
                            {
                                if (result.ToString() == value)
                                {
                                    _postalCode = value;
                                    break;
                                }
                                else
                                {
                                    throw new ArgumentException("Postal code not valid.");
                                }
                            }

                        }
                    }
                }
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                // if value is in zipcode-belgium
                using (StreamReader r = new StreamReader(@"Data\zipcode-belgium.json"))
                {
                    using (JsonDocument document = JsonDocument.Parse(r.ReadToEnd()))
                    {
                        foreach (JsonElement el in document.RootElement.EnumerateArray())
                        {
                            if (el.TryGetProperty("city", out JsonElement result))
                            {
                                if (result.ToString() == value)
                                {
                                    _city = value;
                                    break;
                                }
                                else
                                {
                                    throw new ArgumentException("City name not valid.");
                                }
                            }

                        }
                    }
                }
            }
        }
        public string Status { get; set; } //Burgerlijke staat
        public string Dependents { get; set; } //Personen ten laste
    }
}