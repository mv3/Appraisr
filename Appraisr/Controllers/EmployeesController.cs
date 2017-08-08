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

            return View(employee);
        }

        public ActionResult Add(bool isAppraiser)
        {
            var viewModel = new EmployeesAddViewModel();

            viewModel.Init(Context);
            viewModel.IsAppraiser = isAppraiser;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(EmployeesAddViewModel viewModel)
        {
            // ValidateEmployee(viewModel.Employee);

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

        public ActionResult AddAppraiser()
        {
            var viewModel = new EmployeesAddViewModel();

            viewModel.Init(Context);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddAppraiser(EmployeesAddViewModel viewModel)
        {
            // ValidateEmployee(viewModel.Employee);

            if (ModelState.IsValid)
            {
                var employee = viewModel.Employee;

                Context.Employees.Add(employee);
                Context.SaveChanges();

                TempData["Message"] = "Appraiser was successfully added!";

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
            // ValidateEmployee(viewModel.Employee);

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
            // ValidateEmployee(viewModel.Employee);

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


    }    
}