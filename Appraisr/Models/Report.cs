using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appraisr.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Form { get; set; }
        public string Description { get; set; }
        public decimal Fee { get; set; }
        public bool FhaCert { get; set; }
        public bool VaCert { get; set; }
    }
}