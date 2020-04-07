using LogIt.Models;
using LogIt.Models.UserProfile;
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
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult Index()
        {
            var service = CreateUserProfileService();
            var model = service.GetUserProfiles();

            return View(model);
        }

        //GET : UserProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        //GET : UserProfile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProfileCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateUserProfileService();

            if (service.CreateUserProfile(model))
            {
                TempData["SaveResult"] = "Your Profile was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Profile could not be created.");

            return View(model);
        }

        //GET : UserProfile/Details
        public ActionResult Details(int id)
        {
            var service = CreateUserProfileService();
            var model = service.GetUserProfileById(id);

            return View(model);
        }

        //GET : UserProfile/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateUserProfileService();
            var detail = service.GetUserProfileById(id);
            var model =
                new UserProfileEdit
                {
                    UserProfileId = detail.UserProfileId,
                    Title = detail.Title,
                    Description = detail.Description,
                    CaloryTarget = detail.CaloryTarget,
                    CarbTarget = detail.CarbTarget,
                    FiberTarget = detail.FiberTarget,
                    FatTarget = detail.FatTarget,
                    ProteinTarget = detail.ProteinTarget,
                    SodiumTarget = detail.SodiumTarget,
                    PotassiumTarget = detail.PotassiumTarget,
                };

            return View(model);
        }

        //GET : UserProfile/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserProfileEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.UserProfileId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateUserProfileService();

            if (service.UpdateUserProfile(model))
            {
                TempData["SaveResult"] = "Your Profile was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Profile could not be updated.");
            return View(model);
        }

        //GET : UserProfile/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateUserProfileService();
            var model = service.GetUserProfileById(id);

            return View(model);
        }

        //GET : UserProfile/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateUserProfileService();
            service.DeleteUserProfile(id);
            TempData["SaveResult"] = "Your Profile was deleted";

            return RedirectToAction("Index");
        }


        private UserProfileService CreateUserProfileService()
        {
            var userId = User.Identity.GetUserId();
            var service = new UserProfileService(userId);
            return service;
        }

    }
}