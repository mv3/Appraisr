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
        [Display(Name = "First Name"), Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name"), Required]
        public string LastName { get; set; }
        [Display(Name = "Cell Phone")]
        public string PhoneCell { get; set; }
        [Display(Name = "Ext")]
        public string PhoneExt { get; set; }
        public string Email { get; set; }
        [Display(Name = "Hire Date"), Required]
        public DateTime HireDate { get; set; }
        [Display(Name = "Termination Date")]
        public DateTime? TerminationDate { get; set; }
        [Display(Name = "Reason For Termination")]
        public string TerminationReason { get; set; }
        [Display(Name = "Office"), Required]
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        [Display(Name = "Status")]
        public bool Active { get; set; }
        [Display(Name = "Licencsed")]
        public bool IsLicensed { get; set; }
        [Display(Name = "License Type")]
        public string LicenseType { get; set; }
        [Display(Name = "License Number")]
        public string LicenseNo { get; set; }
        [Display(Name = "FHA Approved")]
        public bool FhaApproved { get; set; }
        [Display(Name = "VA Approved")]
        public bool VaApproved { get; set; }
        //public Employee Supervisor { get; set; }
        [Display(Name = "Workload Limit")]
        public int WorkloadLimit { get; set; }
        [Display(Name = "Pay %"), Range(0,100), Required]
        public int PayPercent { get; set; }
        [Required]
        public string Role { get; set; }

        public ICollection<Order> Orders { get; set; }

        [Display(Name = "Name")]
        public string PrintName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        
    }   
}