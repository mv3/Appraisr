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
            Employee.TerminationDate = new DateTime(1900, 1, 1);
            Employee.Active = true;
        }

        public override void Init(Context context)
        {
            base.Init(context);
        }
    }    
}