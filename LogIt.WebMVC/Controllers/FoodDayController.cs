using LogIt.Models;
using LogIt.Models.FoodDay;
using LogIt.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogIt.WebMVC.Controllers
{
    [Authorize]
    public class FoodDayController : Controller
    {
        // GET: FoodDay
        public ActionResult Index()
        {
            var service = CreateFoodDayService();
            var model = service.GetFoodDays();

            return View(model);
        }

        //GET : FoodDay/Create
        public ActionResult Create()
        {
            return View();
        }

        //GET : FoodDay/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodDayCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateFoodDayService();

            if (service.CreateFoodDay(model))
            {
                TempData["SaveResult"] = "Your Food Day was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Food Day could not be created.");

            return View(model);
        }

        //GET : FoodDay/Details
        public ActionResult Details(int id)
        {
            var service = CreateFoodDayService();
            var model = service.GetFoodDayById(id);

            return View(model);
        }

        //GET : FoodDay/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateFoodDayService();
            var detail = service.GetFoodDayById(id);
            var model =
                new FoodDayEdit
                {
                    FoodDayId = detail.FoodDayId,
                    Date = detail.Date,
                };

            return View(model);
        }

        //GET : FoodDay/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FoodDayEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FoodDayId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFoodDayService();

            if (service.UpdateFoodDay(model))
            {
                TempData["SaveResult"] = "Your Food Day was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Food Day could not be updated.");
            return View(model);
        }

        //GET : FoodDay/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateFoodDayService();
            var model = service.GetFoodDayById(id);

            return View(model);
        }

        //GET : FoodDay/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFoodDayService();
            service.DeleteFoodDay(id);
            TempData["SaveResult"] = "Your Food Day was deleted";

            return RedirectToAction("Index");
        }


        private FoodDayService CreateFoodDayService()
        {
            var userId = User.Identity.GetUserId();
            var service = new FoodDayService(userId);
            return service;
        }
    }
}