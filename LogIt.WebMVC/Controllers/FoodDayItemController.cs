using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogIt.WebMVC.Controllers
{
    public class FoodDayItemController : Controller
    {
        // GET: FoodDayItem
        public ActionResult Index()
        {
            return View();
        }
    }
}