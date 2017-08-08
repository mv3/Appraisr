using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Models;
using System.Data.Entity;


namespace Appraisr.Data
{
    public class OrdersRepository : BaseRepository<Order>
    {
        public OrdersRepository(Context context)
            : base(context)
        {

        }

        public override IList<Order> GetList()
        {
            return Context.Orders
                    .Include(o => o.Address)
                    .Include(o => o.Appraiser)
                    .Include(o => o.Client)
                    .Include(o => o.Report)
                    .OrderBy(o => o.OrderNumber)
                    .ToList();
        }

        public override Order Get(int id, bool includeRelatedEntities = true)
        {
            var orders = Context.Orders.AsQueryable();

            if (includeRelatedEntities)
            {
                orders = orders
                    .Include(o => o.Address)
                    .Include(o => o.Appraiser)
                    .Include(o => o.Client)
                    .Include(o => o.Report); 
            }

            return orders
                    .Where(o => o.Id == id)
                    .SingleOrDefault();
        }

    }
}