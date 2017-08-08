using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Data;
using System.Web.Mvc;
using System.Net;
using Appraisr.ViewModels.OrderViewModels;
using Appraisr.Models;

namespace Appraisr.Controllers
{
    public class OrdersController : BaseController
    {
        private OrdersRepository _orderRepo = null;

        public OrdersController()
        {
            _orderRepo = new OrdersRepository(Context);
        }

        public ActionResult Index()
        {
            var orders = _orderRepo.GetList();
            return View(orders);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = _orderRepo.Get((int)id);

            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        public ActionResult Add()
        {
            var viewModel = new OrdersAddViewModel();

            viewModel.Init(Context);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(OrdersAddViewModel viewModel)
        {
            // ValidateEmployee(viewModel.Employee);

            if (ModelState.IsValid)
            {
                var order = viewModel.Order;

                Context.Orders.Add(order);
                Context.SaveChanges();

                TempData["Message"] = "Order was successfully added!";

                return RedirectToAction("Detail", new { id = order.Id });
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

            var order = _orderRepo.Get((int)id);

            if (order == null)
            {
                return HttpNotFound();
            }

            var viewModel = new OrdersEditViewModel()
            {
                Order = order
            };
            viewModel.Init(Context);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(OrdersEditViewModel viewModel)
        {
            // ValidateEmployee(viewModel.Employee);

            if (ModelState.IsValid)
            {
                var order = viewModel.Order;

                _orderRepo.Update(order);

                TempData["Message"] = "Order was successfully updated!";

                return RedirectToAction("Detail", new { id = order.Id });
            }

            viewModel.Init(Context);

            return View(viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = _orderRepo.Get((int)id);

            if (order == null)
            {
                return HttpNotFound();
            }
            

            return View(order);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _orderRepo.Delete(id);

            TempData["Message"] = "The order was successfully deleted!";

            return RedirectToAction("Index");
        }



    }
}