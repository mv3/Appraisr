using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appraisr.ViewModels.OrderViewModels
{
    public class OrdersEditViewModel : OrdersBaseViewModel
    {
        public int Id
        {
            get { return Order.Id; }
            set { Order.Id = value; }
        }
    }
}