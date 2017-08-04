using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Models;
using Appraisr.Data;
using System.Web.Mvc;

namespace Appraisr.ViewModels.EmployeeViewModels
{
    public abstract class EmployeesBaseViewModel
    {
        public Employee Employee { get; set; } = new Employee();

        public SelectList OfficesSelectListItems { get; set; }

        public virtual void Init(Context context)
        {
            OfficesSelectListItems = new SelectList(
                context.Offices.OrderBy(o => o.City)
                .ToList(), "Id", "City");
        }
    }
}