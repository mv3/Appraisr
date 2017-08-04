using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Appraisr.Models;

namespace Appraisr.Data
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {           
        
            var JCOffice = new Office()
            {
                Address="123 Street Rd",
                City = "Jefferson City",
                Zip = "65101",
                Phone = "636-2121"
            };
            var ComoOffice = new Office()
            {
                Address = "123 Sesame St",
                City = "Columbia",
                Zip = "65201",
                Phone = "636-2121"
            };

            var emp1 = new Employee()
            {
                FirstName = "Jim",
                LastName  = "Smith",
                PhoneCell = "555-5555",
                PhoneExt = "555",
                Email = "JSmith@Appraisr.com",
                HireDate = new DateTime(2012, 5, 1),
                TerminationDate = new DateTime(1900, 1, 1),
                Office = JCOffice,
                Active = true
            };
            context.Employees.Add(emp1);

            var emp2 = new Employee()
            {
                FirstName = "Big",
                LastName = "Bird",
                PhoneCell = "123-4567",
                PhoneExt = "123",
                Email = "BBird@Appraisr.com",
                HireDate = new DateTime(2013, 4, 1),
                TerminationDate = new DateTime(1900, 1, 1),
                Office = ComoOffice,
                Active = true
            };
            context.Employees.Add(emp2);

            var emp3 = new Employee()
            {
                FirstName = "Bad",
                LastName = "Worker",
                PhoneCell = "111-1111",
                PhoneExt = "111",
                Email = "BWorker@Appraisr.com",
                HireDate = new DateTime(2014, 6, 1),
                TerminationDate = new DateTime(2015, 1, 1),
                TerminationReason = "Incompetence",
                Office = ComoOffice,
                Active = false
            };
            context.Employees.Add(emp3);

            context.SaveChanges();
        }


    }
}