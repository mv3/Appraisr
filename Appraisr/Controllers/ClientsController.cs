using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Data;
using System.Web.Mvc;
using System.Net;
using Appraisr.ViewModels.ClientViewModels;


namespace Appraisr.Controllers
{
    public class ClientsController : BaseController
    {
        private ClientsRepository _clientRepo = null;

        public ClientsController()
        {
            _clientRepo = new ClientsRepository(Context);
        }

        public ActionResult Index()
        {
            var clients = _clientRepo.GetList();
            return View(clients);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = _clientRepo.Get((int)id);

            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        public ActionResult Add()
        {
            var viewModel = new ClientAddViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(ClientAddViewModel viewModel)
        {
            // ValidateEmployee(viewModel.Client);

            if (ModelState.IsValid)
            {
                var client = viewModel.Client;

                Context.Clients.Add(client);
                Context.SaveChanges();

                TempData["Message"] = "Client was successfully added!";

                return RedirectToAction("Detail", new { id = client.Id });
            }

            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = _clientRepo.Get((int)id);

            if (client == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ClientEditViewModel()
            {
                Client = client
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ClientEditViewModel viewModel)
        {
            // ValidateEmployee(viewModel.Client);

            if (ModelState.IsValid)
            {
                var client = viewModel.Client;

                _clientRepo.Update(client);

                TempData["Message"] = "Client was successfully updated!";

                return RedirectToAction("Detail", new { id = client.Id });
            }

            return View(viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var office = _clientRepo.Get((int)id);

            if (office == null)
            {
                return HttpNotFound();
            }

            return View(office);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _clientRepo.Delete(id);

            TempData["Message"] = "The client was successfully deleted!";

            return RedirectToAction("Index");
        }





    }
}