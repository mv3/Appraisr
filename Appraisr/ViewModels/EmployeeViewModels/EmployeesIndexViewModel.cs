using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Models;
using Appraisr.Data;

namespace Appraisr.ViewModels.EmployeeViewModels
{
    public class EmployeesIndexViewModel
    {
        public EmployeesIndexViewModel()
        {

        }

        public IList<Employee> Employees { get; set; } = new List<Employee>();

    }
}