using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appraisr.Models
{    
    public class Employee
    {
        public Employee()
        {
            //HireDate = DateTime.Today;
            //TerminationDate = DateTime.MinValue;
        }

        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Cell Phone")]
        public string PhoneCell { get; set; }
        [Display(Name = "Ext")]
        public string PhoneExt { get; set; }
        public string Email { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        [Display(Name = "Termination Date")]
        public DateTime TerminationDate { get; set; }
        [Display(Name = "Reason For Termination")]
        public string TerminationReason { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        [Display(Name = "Status")]
        public bool Active { get; set; }

        [Display(Name = "Office Phone")]
        public string OfficePhone
        {
            get
            {
                return $"{Office.Phone} Ext. {PhoneExt}";
            }
        }
    }   
}