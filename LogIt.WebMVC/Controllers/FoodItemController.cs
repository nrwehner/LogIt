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
            var userId = User.Identity.GetUserId();
            var service = new FoodItemService(userId);
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

            var userId = User.Identity.GetUserId();
            var service = new FoodItemService(userId);

            service.CreateFoodItem(model);

            return RedirectToAction("Index");
        }
    }
}