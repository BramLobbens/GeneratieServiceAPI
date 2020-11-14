using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace GeneratieServiceAPI.Models
{
    public class Loonbrief
    {
        private string _name;
        private string _lastName;
        private string _city;
        private int _postalCode;
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
                    throw new ArgumentException("No correct Value");
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
                    throw new ArgumentException("No correct Value");
                }
            }
        }
        public string Registerkey { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int PostalCode
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
                            if (el.TryGetProperty("city", out JsonElement result))
                            {
                                if (Int32.Parse(result.ToString()) == value)
                                {
                                    _postalCode = value;
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
                                }
                            }
                        }
                    }
                }
            }
        }
        public string Status { get; set; } //Burgerlijke staat
        public List<string> Dependents { get; set; } //Personen ten laste
    }
}