using LogIt.Data;
using LogIt.Models;
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
    public class FoodItemController : Controller
    {
        // GET: FoodItem
        public ActionResult Index()
        {
            var service = CreateFoodItemService();
            var model = service.GetFoodItems();

            return View(model);
        }

        //GET : FoodItem/Create
        public ActionResult Create()
        {
            return View();
        }

        //GET : FoodItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodItemCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateFoodItemService();

            if (service.CreateFoodItem(model))
            {
                TempData["SaveResult"] = "Your food item was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your food item could not be created.");

            return View(model);
        }

        private FoodItemService CreateFoodItemService()
        {
            var userId = User.Identity.GetUserId();
            var service = new FoodItemService(userId);
            return service;
        }
    }
}