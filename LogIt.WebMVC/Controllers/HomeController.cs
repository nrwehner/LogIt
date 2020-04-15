using LogIt.Data;
using LogIt.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogIt.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var service = CreateHomeService();
            var model = service.GetModel();
            PopulateFullName();
            return View(model);
        }
        public ActionResult IndexPartial()
        {
            PopulateFullName();
            return PartialView();
        }

        public ActionResult ProfilesPartial()
        {
            var service = CreateHomeService();
            var model = service.GetProfiles();

            return View(model);
        }

        public ActionResult DaysPartial()
        {
            var service = CreateHomeService();
            var model = service.GetDays();

            return View(model);
        }

        public ActionResult FoodItemsPartial()
        {
            var service = CreateHomeService();
            var model = service.GetItems();

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Learn()
        {
            ViewBag.Message = "How It Works.";

            return View();
        }

        private HomeService CreateHomeService()
        {
            string userId;
            if (!User.Identity.IsAuthenticated)
            {
                userId = "";
            }
            else
            {
            userId = User.Identity.GetUserId();
            }
            var today = DateTime.Now;
            var service = new HomeService(userId,today);
            return service;
        }

        private void PopulateFullName()
        {
            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.FullName = null;
            }
            else
            {
                ViewBag.FullName = new ApplicationDbContext().Users.Find(User.Identity.GetUserId()).FirstName + " " + new ApplicationDbContext().Users.Find(User.Identity.GetUserId()).LastName;
            }
        }

    }
}