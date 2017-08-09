using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appraisr.Models
{
    public class Office
    {
        public Office()
        {

        }

        public int Id { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City"), Required]
        public string City { get; set; }
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }
        [Display(Name = "Phone"), Required]
        public string Phone { get; set; }

        [Display(Name = "Office")]
        public string OfficeName
        {
            get
            {
                return $"{City} Office";
            }            
        }


        public ICollection<Employee> Employees { get; set; }
    }
}