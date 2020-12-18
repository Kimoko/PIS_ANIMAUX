using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMAUX.Models;

namespace ANIMAUX.Controllers
{
    public class HomeController : Controller
    {
        AnimauxEntities entities = new AnimauxEntities();

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Registry()
        {
//            ViewBag.Message = "Реестр";

            return View(entities.animals.ToList());
        }

        public ActionResult Publication()
        {
//            ViewBag.Message = "Объявления";

            return View();
        }
    }
}