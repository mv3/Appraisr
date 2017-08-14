using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Models;
using Appraisr.Data;

namespace Appraisr.ViewModels.ClientViewModels
{
    public class ClientDetailViewModel : ClientBaseViewModel
    {
        public ClientDetailViewModel()
        {

        }

        public List<Order> OpenOrders
        {
            get
            {
                List<Order> orders = new List<Order>();
                foreach (var order in Client.Orders)
                {
                    if (order.DatePaid == null)
                    {
                        orders.Add(order);
                    }
                }
                return orders;
            }
        }
        public List<Order> ClosedOrders
        {
            get
            {
                List<Order> orders = new List<Order>();
                foreach (var order in Client.Orders)
                {
                    if (order.DatePaid != null)
                    {
                        orders.Add(order);
                    }
                }
                return orders;
            }
        }
    }
}