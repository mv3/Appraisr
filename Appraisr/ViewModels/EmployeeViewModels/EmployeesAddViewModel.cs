using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Models;
using Appraisr.Data;

namespace Appraisr.ViewModels.EmployeeViewModels
{
    public class EmployeesAddViewModel : EmployeesBaseViewModel
    {
        public EmployeesAddViewModel()
        {
            Employee.HireDate = DateTime.Today;
            Employee.Active = true;
        }

        public bool IsAppraiser { get; set; }

        public override void Init(Context context)
        {
            base.Init(context);
        }
    }    
}