using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appraisr.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Display(Name = "Order Number"), Required]
        public int OrderNumber { get; set; }
        [Display(Name = "Date Ordered")]
        public DateTime DateOrdered { get; set; }
        [Display(Name = "Date Inspected")]
        public DateTime? DateInspected { get; set; }
        [Display(Name = "Date Completed")]
        public DateTime? DateCompleted { get; set; }
        [Display(Name = "Date Due")]
        public DateTime? DateDue { get; set; }
        [Display(Name = "Date Delivered")]
        public DateTime? DateDelivered { get; set; }
        [Display(Name = "Date Invoiced")]
        public DateTime? DateInvoiced { get; set; }
        [Display(Name = "Date Paid")]
        public DateTime? DatePaid { get; set; }
        public Address Address { get; set; }
        [Display(Name = "Appraised Value")]
        public decimal AppraisedValue { get; set; }
        [Display(Name = "Client"), Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [Display(Name = "Appraiser")]
        public int AppraiserId { get; set; }
        public Employee Appraiser { get; set; }
        [Display(Name = "Report")]
        public int ReportId { get; set; }
        public Report Report { get; set; }
    }
}