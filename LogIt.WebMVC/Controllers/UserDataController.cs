using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogIt.WebMVC.Controllers
{
    public class UserDataController : Controller
    {
        // GET: UserData
        public ActionResult Index()
        {
            return View();
        }
    }
}