using Appraisr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Appraisr.Data
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(Context context)
            : base(context)
        {

        }

        public override IList<Employee> GetList()
        {
            return Context.Employees
                    .Include(e => e.Office)
                    .Include(e =>e.Orders)
                    .OrderByDescending(e => e.Active)
                    .ThenBy(e => e.LastName)
                    .ThenBy(e => e.FirstName)
                    .ToList();
        }

        public override Employee Get(int id, bool includeRelatedEntities = true)
        {
            var employees = Context.Employees.AsQueryable();

            if (includeRelatedEntities)
            {
                employees = employees
                    .Include(e => e.Office)
                    .Include(e => e.Orders)
                    .Include(e => e.Orders.Select(o => o.Report))
                    .Include(e => e.Orders.Select(o => o.Client));
            }

            return employees
                    .Where(e => e.Id == id)
                    .SingleOrDefault();
        }

        public void Terminate(Employee employee)
        {
            var emp = Get(employee.Id);
            emp.TerminationDate = employee.TerminationDate;
            emp.TerminationReason = employee.TerminationReason;
            emp.Active = false;
            Context.Entry(emp).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Reactivate(int id)
        {
            var emp = Get(id);            
            emp.Active = true;
            Context.Entry(emp).State = EntityState.Modified;
            Context.SaveChanges();
        }


    }
}