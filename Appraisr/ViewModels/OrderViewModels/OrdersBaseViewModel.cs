using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Models;
using Appraisr.Data;
using System.Web.Mvc;

namespace Appraisr.ViewModels.OrderViewModels
{
    public abstract class OrdersBaseViewModel
    {
        public Order Order { get; set; } = new Order();

        public SelectList ClientsSelectListItems { get; set; }
        public SelectList AppraisersSelectListItems { get; set; }
        public SelectList ReportsSelectListItems { get; set; }

        public virtual void Init(Context context)
        {
            ClientsSelectListItems = new SelectList(
                context.Clients.OrderBy(c => c.Name)
                .ToList(), "Id", "Name");

            AppraisersSelectListItems = new SelectList(
                context.Employees.Where(e => e.Role == "Appraiser")
                .OrderBy(a => a.LastName)
                .ThenBy(a => a.FirstName)
                .ToList(), "Id", "PrintName");

            ReportsSelectListItems = new SelectList(
                context.Reports.OrderBy(r => r.Form)
                .ToList(), "Id", "Form");
        }


    }
}