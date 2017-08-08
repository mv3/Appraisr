using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Data;
using Appraisr.Models;

namespace Appraisr.ViewModels.OrderViewModels
{
    public class OrdersAddViewModel : OrdersBaseViewModel
    {
        public OrdersAddViewModel()
        {
            Order.DateOrdered = DateTime.Today;
        }

        public override void Init(Context context)
        {
            base.Init(context);
        }
    }
}