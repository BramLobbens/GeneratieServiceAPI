﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GeneratieServiceAPI.Models
{
    public class Loonbrief
    {
        public Guid Id { get; set ; }
        //elke parameter toevoegen dat moet verwerkt worden. 
        public string Name { 
            get{ 
                return this.Name;
            } 
            set{ 
                if(Regex.IsMatch(this.Name, "^\\s*9\\s*1\\s*1") == true)
                {
                    this.Name =this.Name ;
                    Console.WriteLine("het is correct");
                }
                else 
                {
                    this.Name = "Not Valid";
                    Console.WriteLine("het is niet correct");
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