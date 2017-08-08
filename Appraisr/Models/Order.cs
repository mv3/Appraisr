using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appraisr.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime? DateInspected { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime? DateDue { get; set; }
        public DateTime? DateDelivered { get; set; }
        public DateTime? DateInvoiced { get; set; }
        public DateTime? DatePaid { get; set; }
        public Address Address { get; set; }
        public decimal AppraisedValue { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int AppraiserId { get; set; }
        public Appraiser Appraiser { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }
    }
}