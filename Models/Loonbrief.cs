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
        private string _street;
        private string _number;
        private string _city;
        private string _postalCode;
        private string _registerkey;
        //private int _postalCode;
        private string _status; 
        private string _dependents;

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
        public string Registerkey {  get { return _registerkey; }
            set
            {
                if (Regex.IsMatch(value, @"\d{2}[.]\d{2}[.]\d{2}[-]\d{3}[.]\d{2}"))
                {
                    _registerkey = value;
                }
                else
                {
                    throw new ArgumentException("No correct value.");
                }
            } }//00.00.00 - 000.00 dit is de vorm dit het zou moeten hebben  lengte is 14 karakter waarvan 2,5,12 een Punt en 8 - 
        public string Street { get { return _street; }
            set
            {
                if (Regex.IsMatch(value, @"^\p{Lu}\p{Ll}*$"))
                {
                    _street = value;
                }
                else
                {
                    throw new ArgumentException("No correct Value");
                }
            } 
        }
        public string Number
        {
            get { return _number; }
            set
            {
                if (Regex.IsMatch(value, @"/^(a|A)([0-9])$/"))//check on numbers and 1 letter 
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException("No correct Value");
                }
            }
        }
        //public int PostalCode
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
        public string Status { get { return _status; }
            set
            {
                //kijken of het enkel bestaat uit tekst en of het een van de geldige value zijn. 
                if (Regex.IsMatch(value, @"^\p{Lu}\p{Ll}*$") && (value == "Ongehuwd" || value == "Gehuwd" || value == "Gescheiden" || value == "Verweduwd"))
                {
                    _status = value;
                }
                else
                {
                    throw new ArgumentException("No correct Value");
                }
            } } //Burgerlijke staat : Ongehuwd,Gehuwd,Gescheiden,Verweduwd

        public string Dependents { get; set; } //Personen ten laste
        public DateTime DateRegister {get; set;} //datum laten genereren wanneer de loonbrief binnen komt. 
    }
}