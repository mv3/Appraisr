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
            var reportURAR = new Report()
            {
                Form = "URAR",
                Description = "1004 Uniform Residential Appraisal Report",
                Fee = 350.00M,
                FhaCert = false,
                VaCert = false
            };
            context.Reports.Add(reportURAR);

            var report2055 = new Report()
            {
                Form = "2055",
                Description = "2055 Interior Limited Summary Appraisal Report",
                Fee = 325.00M,
                FhaCert = false,
                VaCert = false
            };
            context.Reports.Add(report2055);

            var NoOffice = new Office()
            {
                Id = 99,
                Address = "N/A",
                City = "N/A",
                Zip = "N/A",
                Phone = "N/A"
            };
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

            var app1 = new Employee()
            {
                FirstName = "Jim",
                LastName = "Smith",
                PhoneCell = "555-5555",
                PhoneExt = "555",
                Email = "JSmith@Appraisr.com",
                HireDate = new DateTime(2012, 5, 1),
                TerminationDate = new DateTime(1900, 1, 1),
                Office = JCOffice,
                Active = true,
                FhaApproved = true,
                IsLicensed = true,
                PayPercent = 50,
                LicenseExp = new DateTime(2020, 1, 1),
                Role = "Appraiser"
            };
            context.Employees.Add(app1);

            var app2 = new Employee()
            {
                FirstName = "Big",
                LastName = "Bird",
                PhoneCell = "123-4567",
                PhoneExt = "123",
                Email = "BBird@Appraisr.com",
                HireDate = new DateTime(2013, 4, 1),
                TerminationDate = new DateTime(1900, 1, 1),
                Office = ComoOffice,
                Active = true,
                FhaApproved = true,
                IsLicensed = true,
                PayPercent = 50,
                LicenseExp = new DateTime(2020, 1, 1),
                Role = "Appraiser"
            };
            context.Employees.Add(app2);

            var emp3 = new Employee()
            {
                FirstName = "Oscar",
                LastName = "Grouch",
                PhoneCell = "111-1111",
                PhoneExt = "111",
                Email = "OGrouch@Appraisr.com",
                HireDate = new DateTime(2014, 6, 1),
                TerminationDate = new DateTime(2015, 1, 1),
                TerminationReason = "Grouchy",
                Office = ComoOffice,
                Active = false,
                Role = "Staff"
            };
            context.Employees.Add(emp3);

            var emp4 = new Employee()
            {
                FirstName = "Lost",
                LastName = "Worker",
                PhoneCell = "111-1111",
                PhoneExt = "111",
                Email = "LWorker@Appraisr.com",
                HireDate = new DateTime(2014, 6, 1),
                TerminationDate = new DateTime(1900, 1, 1),
                TerminationReason = "",
                Office = NoOffice,
                Active = true,
                Role = "Staff"
            };
            context.Employees.Add(emp4);

            var client1 = new Client()
            {
                Name = "Acme Bank",
                Phone = "444-4444",
                Email = "Orders@AcmeBank.com",
                Type = "Morgage",
                SpecialInstructions = "",
                Address = new Address()
                {
                    Line1 = "134 Bank Road",
                    Line2 = "",
                    City = "Jeffesron City",
                    State = "MO",
                    ZipCode = "65101"
                }
            };
            context.Clients.Add(client1);

            context.SaveChanges();


        }
    }
}