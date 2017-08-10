using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Models;
using System.Data.Entity;


namespace Appraisr.Data
{
    public class ClientsRepository : BaseRepository<Client>
    {
        public ClientsRepository(Context context)
            : base(context)
        {

        }

        public override IList<Client> GetList()
        {
            return Context.Clients
                    .OrderBy(c => c.Name)
                    .ToList();
        }

        public override Client Get(int id, bool includeRelatedEntities = true)
        {
            var clients = Context.Clients.AsQueryable();

            if (includeRelatedEntities)
            {
                clients = clients
                    .Include(c => c.Orders)
                    .Include(c => c.Orders.Select(o => o.Appraiser))
                    .Include(c => c.Orders.Select(o => o.Report))
                    .Include(c => c.Address); 
            }

            return clients
                    .Where(c => c.Id == id)
                    .SingleOrDefault();
        }

    }
}