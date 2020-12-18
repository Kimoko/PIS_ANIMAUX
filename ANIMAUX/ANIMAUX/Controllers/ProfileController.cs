using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ANIMAUX.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Pets()
        {
            return View();
        }
        public ActionResult Notification()
        {
            return View();
        }
        public ActionResult MyPublications()
        {
            return View();
        }
    }
}