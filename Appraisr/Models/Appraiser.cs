using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appraisr.Models
{
    public class Appraiser : Employee
    {
        public bool IsLicensed { get; set; }
        public string LicenseType { get; set; }
        public string LicenseNo { get; set; }
        public DateTime LicenseExp { get; set; }
        public bool FhaApproved { get; set; }
        public bool VaApproved { get; set; }
        public Employee Supervisor { get; set; }
        public int WorkloadLimit { get; set; }
        public int PayPercent { get; set; }
    }
}