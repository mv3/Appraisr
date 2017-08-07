using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appraisr.Models
{
    public class Client
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string SpecialInstructions { get; set; }
    }
}