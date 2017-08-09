using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appraisr.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Display(Name = "Address Line 1"), Required]
        public string Line1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string Line2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Display(Name = "Zip Code"), Required]
        public string ZipCode { get; set; }
    }
}