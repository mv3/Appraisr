using Appraisr.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Appraisr.Models;
using Appraisr.ViewModels;
using Appraisr.ViewModels.EmployeeViewModels;
using System.Data.Entity;

namespace Appraisr.Controllers
{
    public class EmployeesController : BaseController
    {
        private EmployeeRepository _empRepo = null;

        public EmployeesController()
        {
            _empRepo = new EmployeeRepository(Context);
        }

        public ActionResult Index()
        {
            var employees = _empRepo.GetList();

            return View(employees);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _empRepo.Get((int)id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            var viewModel = new EmployeeDetailViewModel()
            {
                Employee = employee
            };

            return View(viewModel);
        }

        public ActionResult Promote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _empRepo.Get((int)id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            employee.Role = "Appraiser";
            _empRepo.Update(employee);

            TempData["Message"] = "Employee was successfully promoted to Appraiser!";

            return RedirectToAction("Detail", new { id = employee.Id });
        }

        public ActionResult Demote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _empRepo.Get((int)id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            employee.Role = "Staff";
            _empRepo.Update(employee);

            TempData["Message"] = "Employee was successfully demoted to Staff.";

            return RedirectToAction("Detail", new { id = employee.Id });
        }

        public ActionResult Add()
        {            
            var viewModel = new EmployeesAddViewModel();

            viewModel.Init(Context);
            
            if(TempData["Role"] != null)
            {
                viewModel.Employee.Role = TempData["Role"].ToString();
            }
            else
            {
                viewModel.Employee.Role = "Staff";
            }

            return View(viewModel);
        }

        public ActionResult AddAppraiser()
        {
            TempData["Role"] = "Appraiser";            

            return RedirectToAction("Add");
        }

        [HttpPost]
        public ActionResult Add(EmployeesAddViewModel viewModel)
        {
            ValidateEmployee(viewModel.Employee);

            if (ModelState.IsValid)
            {
                var employee = viewModel.Employee;

                Context.Employees.Add(employee);
                Context.SaveChanges();

                TempData["Message"] = "Employee was successfully added!";

                return RedirectToAction("Detail", new { id = employee.Id });
            }

            viewModel.Init(Context);

            return View(viewModel);
        }       

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _empRepo.Get((int)id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            var viewModel = new EmployeesEditViewModel()
            {
                Employee = employee
            };
            viewModel.Init(Context);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EmployeesEditViewModel viewModel)
        {
            ValidateEmployee(viewModel.Employee);

            if (ModelState.IsValid)
            {
                var employee = viewModel.Employee;

                _empRepo.Update(employee);

                TempData["Message"] = "Employee was successfully updated!";

                return RedirectToAction("Detail", new { id = employee.Id });
            }

            viewModel.Init(Context);

            return View(viewModel);
        }

        public ActionResult Terminate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _empRepo.Get((int)id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            var viewModel = new EmployeesEditViewModel()
            {
                Employee = employee
            };
            viewModel.Init(Context);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Terminate(EmployeesEditViewModel viewModel)
        {
            
            if (ModelState.IsValid)
            {
                var employee = viewModel.Employee;


                _empRepo.Terminate(employee);

                TempData["Message"] = "Employee terminated.";

                return RedirectToAction("Detail", new { id = employee.Id });
            }

            viewModel.Init(Context);

            return View(viewModel);
        }

        public ActionResult Reactivate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _empRepo.Get((int)id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            _empRepo.Reactivate((int)id);

            TempData["Message"] = "The employee was successfully reactivated!";

            return RedirectToAction("Detail", new { id = employee.Id });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _empRepo.Get((int)id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _empRepo.Delete(id);

            TempData["Message"] = "The employee was successfully deleted!";

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Validates a record on the server
        /// before adding a new record or updating an existing record.
        /// </summary>
        /// <param name="employee">The Employee to validate.</param>
        private void ValidateEmployee(Employee employee)
        {
            // If there aren't any "Name" field validation errors...
            if (ModelState.IsValidField("LastName") && ModelState.IsValidField("FirstName"))
            {
                // Then make sure that the provided Name is unique.
                if (Context.Employees
                        .Any(e => e.Id != employee.Id &&
                                  e.FirstName == employee.FirstName &&
                                  e.LastName == employee.LastName))
                {
                    ModelState.AddModelError("FirstName",
                        "An employee by this name already exists.");
                }
            }
        }


    }    
}