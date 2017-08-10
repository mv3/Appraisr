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
                Office = JCOffice,
                Active = true,
                FhaApproved = true,
                IsLicensed = true,
                PayPercent = 50,
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
                Office = ComoOffice,
                Active = true,
                FhaApproved = true,
                IsLicensed = true,
                PayPercent = 50,
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
                Type = "Bank",
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

            var client2 = new Client()
            {
                Name = "Acme Mortgage",
                Phone = "555-5555",
                Email = "Orders@AcmeMortgage.com",
                Type = "Morgage",
                SpecialInstructions = "",
                Address = new Address()
                {
                    Line1 = "134 Mortgage Lane",
                    Line2 = "",
                    City = "Jeffesron City",
                    State = "MO",
                    ZipCode = "65101"
                }
            };
            context.Clients.Add(client2);

            var order1 = new Order()
            {
                OrderNumber = "17-0001",
                DateOrdered = new DateTime(2017, 6, 1),
                DateInspected = new DateTime(2017, 6, 2),
                DateCompleted = new DateTime(2017, 6, 3),
                DateDue = new DateTime(2017, 6, 7),
                DateDelivered = new DateTime(2017, 6, 4),
                DateInvoiced = new DateTime(2017, 6, 4),
                DatePaid = new DateTime(2017, 6, 5),
                Address = new Address()
                    {
                        Line1 = "456 Street Road",
                        Line2 = "",
                        City = "Jeffesron City",
                        State = "MO",
                        ZipCode = "65101"
                    },
                Client = client1,
                Appraiser = app1,
                AppraisedValue = 90000.00M,
                Report = reportURAR
            };
            context.Orders.Add(order1);

            var order2 = new Order()
            {
                OrderNumber = "17-0002",
                DateOrdered = new DateTime(2017, 6, 2),
                DateInspected = new DateTime(2017, 6, 3),
                DateCompleted = new DateTime(2017, 6, 4),
                DateDue = new DateTime(2017, 6, 8),
                DateDelivered = new DateTime(2017, 6, 5),
                DateInvoiced = new DateTime(2017, 6, 5),
                DatePaid = new DateTime(2017, 6, 6),
                Address = new Address()
                {
                    Line1 = "923 Road Street",
                    Line2 = "",
                    City = "Jeffesron City",
                    State = "MO",
                    ZipCode = "65101"
                },
                Client = client1,
                Appraiser = app1,
                AppraisedValue = 120000.00M,
                Report = reportURAR
            };
            context.Orders.Add(order2);

            var order3 = new Order()
            {
                OrderNumber = "17-0003",
                DateOrdered = new DateTime(2017, 6, 2),
                DateDue = new DateTime(2017, 6, 8),
                Address = new Address()
                {
                    Line1 = "445 Road Court",
                    Line2 = "",
                    City = "Jeffesron City",
                    State = "MO",
                    ZipCode = "65101"
                },
                Client = client2,
                Appraiser = app1,
                AppraisedValue = 120000.00M,
                Report = report2055
            };
            context.Orders.Add(order3);

            var order4 = new Order()
            {
                OrderNumber = "17-0004",
                DateOrdered = new DateTime(2017, 6, 2),
                DateDue = new DateTime(2017, 6, 8),
                Address = new Address()
                {
                    Line1 = "867 Road Place",
                    Line2 = "",
                    City = "Columbia",
                    State = "MO",
                    ZipCode = "65201"
                },
                Client = client1,
                Appraiser = app2,
                AppraisedValue = 120000.00M,
                Report = reportURAR
            };
            context.Orders.Add(order4);



            context.SaveChanges();


        }
    }
}