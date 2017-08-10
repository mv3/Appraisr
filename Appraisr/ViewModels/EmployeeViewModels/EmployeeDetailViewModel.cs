using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Models;
using Appraisr.Data;

namespace Appraisr.ViewModels.EmployeeViewModels
{
    public class EmployeeDetailViewModel : EmployeesBaseViewModel
    {
        public EmployeeDetailViewModel()
        {

        }

        public List<Order> OpenOrders
        {
            get
            {
                List<Order> orders = new List<Order>();
                foreach(var order in Employee.Orders)
                {
                    if(order.DateCompleted == null)
                    {
                        orders.Add(order);
                    }
                }
                return orders;
            }
        }
        public List<Order> CompletedOrders
        {
            get
            {
                List<Order> orders = new List<Order>();
                foreach (var order in Employee.Orders)
                {
                    if (order.DateCompleted != null)
                    {
                        orders.Add(order);
                    }
                }
                return orders;
            }
        }

        public override void Init(Context context)
        {
            base.Init(context);
        }
    }
}