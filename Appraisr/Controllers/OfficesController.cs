using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Data;
using System.Web.Mvc;
using System.Net;
using Appraisr.ViewModels.OfficeViewModels;
using Appraisr.Models;

namespace Appraisr.Controllers
{
    public class OfficesController : BaseController
    {
        private OfficesRepository _officeRepo = null;

        public OfficesController()
        {
            _officeRepo = new OfficesRepository(Context);
        }

        public ActionResult Index()
        {
            var offices = _officeRepo.GetList();
            return View(offices);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var office = _officeRepo.Get((int)id);

            if (office == null)
            {
                return HttpNotFound();
            }

            return View(office);
        }

        public ActionResult Add()
        {
            var viewModel = new OfficesAddViewModel();

           
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(OfficesAddViewModel viewModel)
        {
            // ValidateEmployee(viewModel.Employee);

            if (ModelState.IsValid)
            {
                var office = viewModel.Office;

                Context.Offices.Add(office);
                Context.SaveChanges();

                TempData["Message"] = "Office was successfully added!";

                return RedirectToAction("Detail", new { id = office.Id });
            }                      

            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var office = _officeRepo.Get((int)id);

            if (office == null)
            {
                return HttpNotFound();
            }

            var viewModel = new OfficesEditViewModel()
            {
                Office = office
            };           

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(OfficesEditViewModel viewModel)
        {
            // ValidateEmployee(viewModel.Employee);

            if (ModelState.IsValid)
            {
                var office = viewModel.Office;

                _officeRepo.Update(office);

                TempData["Message"] = "Office was successfully updated!";

                return RedirectToAction("Detail", new { id = office.Id });
            }
            
            return View(viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var office = _officeRepo.Get((int)id);

            if (office == null)
            {
                return HttpNotFound();
            }

            if (office.Employees.Count > 0)
            {
                TempData["Warning"] = "All employees must be assigned to a new office before an office can be deleted.";
                return RedirectToAction("Detail", new { id = office.Id });
            }

            return View(office);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _officeRepo.Delete(id);

            TempData["Message"] = "The office was successfully deleted!";

            return RedirectToAction("Index");
        }


    }
}