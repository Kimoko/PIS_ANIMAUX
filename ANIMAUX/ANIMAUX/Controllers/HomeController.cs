using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ANIMAUX.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Registry()
        {
//            ViewBag.Message = "Реестр";

            return View();
        }

        public ActionResult Publication()
        {
//            ViewBag.Message = "Объявления";

            return View();
        }
    }
}