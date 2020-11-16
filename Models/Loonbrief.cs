using System;
using System.IO;
using System.Linq;
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
        private string _status;

        [XmlAttribute("Id")]
        public Guid Id { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                // Must consist of unicode characters starting with an uppercase letter
                if (Regex.IsMatch(value, @"^\p{Lu}\p{Ll}*$"))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("Name is not a correct value.");
                }
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                // Must consist of unicode characters starting with an uppercase letter
                if (Regex.IsMatch(value, @"^\p{Lu}\p{Ll}*$"))
                {
                    _lastName = value;
                }
                else
                {
                    throw new ArgumentException("Lastname is not a correct value.");
                }
            }
        }
        public string Registerkey
        {
            get { return _registerkey; }
            set
            {
                // Must be of format "00.00.00-000.00"
                if (Regex.IsMatch(value, @"\d{2}[.]\d{2}[.]\d{2}[-]\d{3}[.]\d{2}"))
                {
                    _registerkey = value;
                }
                else
                {
                    throw new ArgumentException("Registerkey is not a correct value.");
                }
            }
        }
        public string Street
        {
            get { return _street; }
            set
            {
                // Must consist of unicode characters. May contain spaces.
                if (Regex.IsMatch(value, @"^[\p{L}|\s]*$"))
                {
                    _street = value;
                }
                else
                {
                    throw new ArgumentException("Street is not a correct Value");
                }
            }
        }
        public string Number
        {
            get { return _number; }
            set
            {
                // Must consist of no more than three digits. With optional letter at the end.
                // First digit may not be zero.
                if (Regex.IsMatch(value, "^[1-9][0-9]{0,2}(?:[a-zA-Z]{1}){0,1}$"))
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException("Number is not a correct Value");
                }
            }
        }
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                // Must be a valid Belgian postal code (see: zip-code-belgium)
                using StreamReader r = new StreamReader("Data/zipcode-belgium.json");
                using JsonDocument document = JsonDocument.Parse(r.ReadToEnd());
                foreach (JsonElement el in document.RootElement.EnumerateArray())
                {
                    if (el.TryGetProperty("zip", out JsonElement result))
                    {
                        if (result.ToString() == value)
                        {
                            _postalCode = value;
                            break;
                        }  
                    }
                    else
                        {
                            throw new ArgumentException("Postal code is not a correct Value.");
                        }
                }
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                // Must be a valid Belgian city (see: zip-code-belgium)
                using StreamReader r = new StreamReader("Data/zipcode-belgium.json");
                using JsonDocument document = JsonDocument.Parse(r.ReadToEnd());
                foreach (JsonElement el in document.RootElement.EnumerateArray())
                {
                    if (el.TryGetProperty("city", out JsonElement result))
                    {
                        if (result.ToString() == value)
                        {
                            _city = value;
                            break;
                        }
                    }
                    else
                        {
                            throw new ArgumentException("City name is not a correct Value.");
                        }
                }
            }
        }
        public string Status
        {
            get { return _status; }
            set
            {
                string[] statusen = { "ongehuwd", "gehuwd", "gescheiden", "verweduwd" };
                if (statusen.Contains(value.ToLower()))
                {
                    _status = value;
                }
                else
                {
                    throw new ArgumentException("Status is not a correct Value.");
                }
            }
        }

        public string Dependents { get; set; } //Personen ten laste
        public DateTime DateRegister { get; set; } // Date of registration
    }
}