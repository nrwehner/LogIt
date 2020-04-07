using LogIt.Data;
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
        

        //GET: FoodDay/CreateFoodDay(from Profile)
        public ActionResult CreateFoodDayFromProfile(int profId)
        {
        ApplicationDbContext ctx = new ApplicationDbContext();
        var model =
                new FoodDayCreateFromProfile
                {
                    UserProfileId = profId,
                    ProfileTitle = ctx.UserProfiles.Find(profId).Title,
                    Date = DateTime.Now
                };

            return View(model);
        }
        //GET : FoodDay/CreateFoodDay(from Profile)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFoodDayFromProfile(int profId, FoodDayCreateFromProfile model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.UserProfileId != profId)//maybe don't want this check if you want to let the user change the profile 
                //they're choosing - but would you? - also, maybe pass the parameters from the userprofile view directly into this
                //post method rather than landing on a creation screen at all - just click from userprofile link, do the save, and land on
                // the foodday index screen (NEED TO COPY THE TEMPDATACONTAINSKEYSAVERESULT CODE FROM INDEX VIEW) with a "your foodday was created" message - for failures, need to land on creation screen?
                //maybe there can't be failures since the user is not giving any input? the question will be, can i figure how to pass a 
                //whole model from the userprofile link into this post method?
                //i might end up not end needing the foodday creation landing screen - you would always just pick a profile and select a date
                //those are the only parameters needed from the user - but then again, if the user isn't creating the foodday for today
                //how do i get the date parameter from them without a foodday creation landing page?
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFoodDayService();

            if (service.CreateFoodDayFromProfile(model))
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
                    ProfileTitle = detail.ProfileTitle,
                    Date = detail.Date
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