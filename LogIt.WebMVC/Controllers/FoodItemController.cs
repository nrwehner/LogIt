using LogIt.Data;
using LogIt.Models;
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
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: FoodItem
        public ActionResult Index()
        {
            var model = new FoodItemListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}