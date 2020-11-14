using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GeneratieServiceAPI.Models
{
    public class Loonbrief
    {
        private string _name; 
        public Guid Id { get; set ; }
        //elke parameter toevoegen dat moet verwerkt worden. 
        public string Name { 
            get{ 
                return _name;
            } 
            set{ 
                if(Regex.IsMatch(value, @"^\p{Lu}\p{Ll}*$"))
                {
                    _name = value ;
                    Console.WriteLine("het is correct");
                }
                else 
                {
                    _name = "Not Valid";
                    throw new ArgumentException("No correct Value");
                   //Console.WriteLine("het is niet correct");
                }
            }
         }
        public string LastName { get; set; }
        public string Registerkey { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Status { get; set; } //Burgerlijke staat
        public List<string> Dependents { get; set; } //Personen ten laste
    }
}