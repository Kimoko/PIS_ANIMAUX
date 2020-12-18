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
            List<cards> cardsList = entities.cards.ToList();
            List<animals> animalsList = entities.animals.ToList();
            List<districts> districtsList = entities.districts.ToList();
            ViewData["registryItems"] = from c in cardsList
                                        join a in animalsList on c.animal_id equals a.passport_number 
                                        into table1
                                        from a in table1.DefaultIfEmpty()
                                        join d in districtsList on c.district_id equals d.id
                                        into table2
                                        from d in table2.DefaultIfEmpty()
                                        select new RegistryItems { cards = c, animals = a, districts = d };

            return View(ViewData["registryItems"]);
        }

        public ActionResult Publications()
        {
//            ViewBag.Message = "Объявления";

            return View(entities.publications.ToList());
        }
    }
}