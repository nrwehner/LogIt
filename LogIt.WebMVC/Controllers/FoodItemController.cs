using LogIt.Data;
using LogIt.Models;
using LogIt.Models.FoodItem;
using LogIt.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogIt.WebMVC.Controllers
{
    public class FoodItemController : Controller
    {
        // GET: FoodItem
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateFoodItemService();
            var model = service.GetFoodItems();

            return View(model);
        }

        // GET: FoodItem (for non-users (not logged in))
        public ActionResult NonUserIndex()
        {
            var service = CreateFoodItemService();
            var model = service.GetFoodItems();

            return View(model);
        }

        //GET : FoodItem/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //GET : FoodItem/Create
        [Authorize]
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

        //GET : FoodItem/Details
        [Authorize]
        public ActionResult Details(int id)
        {
            var service = CreateFoodItemService();
            var model = service.GetFoodItemById(id);

            return View(model);
        }

        //GET : FoodItem/Edit
        [Authorize]
        public ActionResult Edit(int id)
        {
            var service = CreateFoodItemService();
            var detail = service.GetFoodItemById(id);
            var model =
                new FoodItemEdit
                {
                    FoodItemId = detail.FoodItemId,
                    Name = detail.Name,
                    Description = detail.Description,
                    Calories = detail.Calories,
                    CarbohydrateGrams = detail.CarbohydrateGrams,
                    FiberGrams = detail.FiberGrams,
                    FatGrams = detail.FatGrams,
                    ProteinGrams = detail.ProteinGrams,
                    SodiumMilligrams = detail.SodiumMilligrams,
                    PotassiumMilligrams = detail.PotassiumMilligrams,
                };

            return View(model);
        }

        //GET : FoodItem/Edit
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FoodItemEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FoodItemId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFoodItemService();

            if (service.UpdateFoodItem(model))
            {
                TempData["SaveResult"] = "Your food item was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your food item could not be updated.");
            return View(model);
        }

        //GET : FoodItem/Delete
        [Authorize]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateFoodItemService();
            var model = service.GetFoodItemById(id);

            return View(model);
        }

        //GET : FoodItem/Delete
        [Authorize]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFoodItemService();
            service.DeleteFoodItem(id);
            TempData["SaveResult"] = "Your food item was deleted";

            return RedirectToAction("Index");
        }

        private FoodItemService CreateFoodItemService()
        {
            var userId = User.Identity.GetUserId();
            var service = new FoodItemService(userId);
            return service;
        }
    }
}