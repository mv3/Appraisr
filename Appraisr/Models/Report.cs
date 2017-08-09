using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appraisr.Models
{
    public class Report
    {
        public int Id { get; set; }
        [Required]
        public string Form { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Fee { get; set; }
        [Display(Name = "FHA Certification Required")]
        public bool FhaCert { get; set; }
        [Display(Name = "VA Certification Required")]
        public bool VaCert { get; set; }
    }
}