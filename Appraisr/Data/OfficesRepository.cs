﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Models;
using System.Data.Entity;

namespace Appraisr.Data
{
    public class OfficesRepository : BaseRepository<Office>
    {
        public OfficesRepository(Context context)
            : base(context)
        {
            
        }

        public override IList<Office> GetList()
        {
            return Context.Offices
                    .Include(o => o.Employees)
                    .Include(o => o.Employees.Select(e => e.Orders))
                    .OrderBy(e => e.City)
                    .ToList();
        }

        public override Office Get(int id, bool includeRelatedEntities = true)
        {
            var offices = Context.Offices.AsQueryable();

            if (includeRelatedEntities)
            {
                offices = offices
                    .Include(e => e.Employees); 
            }

            return offices
                    .Where(e => e.Id == id)
                    .SingleOrDefault();
        }        
    }
}