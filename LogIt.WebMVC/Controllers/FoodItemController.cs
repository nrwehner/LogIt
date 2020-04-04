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
    }
}