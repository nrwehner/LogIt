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
    public class FoodDayItemController : Controller
    {
        // GET: FoodDayItem
        public ActionResult Index()//not sure if i would ever want to land here - may need to edit this to show just the day's items
        {
            var service = CreateFoodDayItemService();
            var model = service.GetAllFoodDayItemsForUser();

            return View(model);
        }

        //GET : FoodDayItem/Create          //probably won't ever need to use this
        public ActionResult Create()
        {
            PopulateFoodDays();
            PopulateFoodItems();
            return View();
        }

        //GET : FoodDayItem/Create          //probably won't ever need to use this
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodDayItemCreate model)
        {
            if (!ModelState.IsValid)
            {
                PopulateFoodDays();
                PopulateFoodItems();
                return View(model);
            }

            var service = CreateFoodDayItemService();

            if (service.CreateFoodDayItem(model))
            {
                TempData["SaveResult"] = "Your Food Day Item was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Food Day Item could not be added.");

            PopulateFoodDays();
            PopulateFoodItems();

            return View(model);
        }


        //GET: FoodDayItem/CreateFoodDayItem(from FoodDay)
        public ActionResult CreateFoodDayItemFromFoodDay(int dayId)
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            var model =
                    new FoodDayItemCreate
                    {
                        FoodDayId = dayId,
                        FoodItemId = 1,
                    };

            PopulateFoodItems();

            return View(model);
        }
        //GET : FoodDay/CreateFoodDayItem (from FoodDay)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFoodDayItemFromFoodDay(int dayId, FoodDayItemCreate model)
        {
            if (!ModelState.IsValid)
            {
                PopulateFoodItems();
                return View(model);
            }

            if (model.FoodDayId != dayId)
            {
                PopulateFoodItems();
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFoodDayItemService();

            if (service.CreateFoodDayItem(model))
            {
                TempData["SaveResult"] = "Your Food Day Item was added.";
                return RedirectToAction("Index");
            };

            PopulateFoodItems();

            ModelState.AddModelError("", "Your Food Day Item could not be added.");

            return View(model);
        }

        //GET: FoodDayItem/CreateFoodDayItem(from FoodItem)
        public ActionResult CreateFoodDayItemFromFoodItem(int itemId)
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            var model =
                    new FoodDayItemCreate
                    {
                        FoodDayId = 3,
                        FoodItemId = itemId,
                    };

            PopulateFoodDays();

            return View(model);
        }
        //GET : FoodDay/CreateFoodDayItem(from FoodItem)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFoodDayItemFromFoodItem(int itemId, FoodDayItemCreate model)
        {
            if (!ModelState.IsValid)
            {
                PopulateFoodDays();
                return View(model);
            }

            if (model.FoodItemId != itemId)
            {
                PopulateFoodDays();
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFoodDayItemService();

            if (service.CreateFoodDayItem(model))
            {
                TempData["SaveResult"] = "Your Food Day Item was added.";
                return RedirectToAction("Index");
            };

            PopulateFoodDays();

            ModelState.AddModelError("", "Your Food Day Item could not be added.");

            return View(model);
        }

        //GET : FoodDayItem/Details
        public ActionResult Details(int id)
        {
            var service = CreateFoodDayItemService();
            var model = service.GetFoodDayItemById(id);

            return View(model);
        }

        //GET : FoodDayItem/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateFoodDayItemService();
            var detail = service.GetFoodDayItemById(id);
            var model =
                new FoodDayItemEdit
                {
                    FoodDayItemId = detail.FoodDayItemId,
                    FoodDayId = detail.FoodDayId,
                    FoodItemId = detail.FoodItemId,
                };

            PopulateFoodDays(detail.FoodDayId);
            PopulateFoodItems(detail.FoodItemId);

            return View(model);
        }

        //GET : FoodDay/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FoodDayItemEdit model)
        {
            if (!ModelState.IsValid)
            {
                PopulateFoodDays(model.FoodDayId);
                PopulateFoodItems(model.FoodItemId);

                return View(model);
            }
            if (model.FoodDayItemId != id)
            {
                PopulateFoodDays(model.FoodDayId);
                PopulateFoodItems(model.FoodItemId);
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFoodDayItemService();

            if (service.UpdateFoodDayItem(model))
            {
                TempData["SaveResult"] = "Your Food Day Item was updated.";
                return RedirectToAction("Index");
            }

            PopulateFoodDays(model.FoodDayId);
            PopulateFoodItems(model.FoodItemId);

            ModelState.AddModelError("", "Your Food Day Item could not be updated.");
            return View(model);
        }

        //GET : FoodDayItem/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateFoodDayItemService();
            var model = service.GetFoodDayItemById(id);

            return View(model);
        }

        //GET : FoodDayItem/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFoodDayItemService();
            service.DeleteFoodDayItem(id);
            TempData["SaveResult"] = "Your Food Day Item was deleted";

            return RedirectToAction("Index");
        }


        private FoodDayItemService CreateFoodDayItemService()
        {
            var userId = User.Identity.GetUserId();
            var service = new FoodDayItemService(userId);
            return service;
        }
        private void PopulateFoodItems()
        {
            ViewBag.FoodItemId = new SelectList(new FoodItemService(User.Identity.GetUserId()).GetFoodItems(), "FoodItemId", "Name");
        }
        private void PopulateFoodItems(int id)
        {
            ViewBag.FoodItemId = new SelectList(new FoodItemService(User.Identity.GetUserId()).GetFoodItems(), "FoodItemId", "Name",id);
        }
        private void PopulateFoodDays()
        {
            ViewBag.FoodDayId = new SelectList(new FoodDayService(User.Identity.GetUserId()).GetFoodDays(), "FoodDayId", "DateProfile");
        }
        private void PopulateFoodDays(int id)
        {
            ViewBag.FoodDayId = new SelectList(new FoodDayService(User.Identity.GetUserId()).GetFoodDays(), "FoodDayId", "DateProfile", id);
        }

    }
}