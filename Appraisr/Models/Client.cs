using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appraisr.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        //public int AddressId { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        [Display(Name = "Special Instructions")]
        public string SpecialInstructions { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}