using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appraisr.ViewModels.EmployeeViewModels
{
    public class EmployeesEditViewModel : EmployeesBaseViewModel
    {
        public int Id
        {
            get { return Employee.Id; }
            set { Employee.Id = value; }
        }
        
    }
}