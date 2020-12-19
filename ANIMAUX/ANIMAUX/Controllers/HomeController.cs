using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMAUX.Models;
using ANIMAUX.Helpers;

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
            //////////////////////////Filter/////////////////////////////
            //Пероид размещения объявления
            //Пол животного (М / Ж)
            //Возраст животного (от 0 до 6 мес, от 6 мес до 1 года, от 1 года до 2 лет, от 2 лет до 5, от 5 и старше)
            //Населенный пункт
         
            ///////////////////////////Sort/////////////////////////////
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "По умолчанию", Value = "0", Selected = true });
            items.Add(new SelectListItem { Text = "По возрастанию", Value = "1" });
            items.Add(new SelectListItem { Text = "По убыванию", Value = "2"});

            ViewBag.SortType = items;

            //может сделать создание запросов в другом классе? или хотя бы вынести их как отдельные методы
            ///////////////////////////Query////////////////////////////
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