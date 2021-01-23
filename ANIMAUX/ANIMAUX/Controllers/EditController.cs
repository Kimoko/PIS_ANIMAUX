using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMAUX.Models;

namespace ANIMAUX.Controllers
{
    public class EditController : Controller
    {
        AnimauxEntities entities = new AnimauxEntities();
        public ActionResult Publication(int id)
        {
            var pub = entities.publications.Where(x => x.id == id).FirstOrDefault();
            ViewBag.animals = entities.animals;

            var month = pub.added_date.Month < 10 ? "0" + pub.added_date.Month.ToString() : pub.added_date.Month.ToString();
            var day = pub.added_date.Day < 10 ? "0" + pub.added_date.Day.ToString() : pub.added_date.Day.ToString();
            var year = pub.added_date.Year;

            ViewBag.added = year + "-" + month + "-" + day;

            ViewBag.id = pub.id;
            ViewBag.url = pub.photo;
            ViewBag.city = pub.city;
            ViewBag.type = pub.type;

            ViewBag.animal = entities.animals.Where(x => x.passport_number == pub.animal_id).FirstOrDefault().name;

            return View();
        }

        [HttpPost]
        public ActionResult Publication(FormCollection form)
        {
            var pubId = int.Parse(form["id"]);
            var pub = entities.publications.Where(x => x.id == pubId).FirstOrDefault();
            pub.photo = form["newUrlPhoto"];
            pub.city = form["newUrlCity"];
            pub.type = form["type"] == "lost" ? "l" : "f";
            var animalId = form["newAnimal"];

            pub.animal_id = entities.animals.Where(x => x.name == animalId).FirstOrDefault().passport_number;
            entities.SaveChanges();

            return Redirect(Url.Action("Publications", "Home"));
        }

        public ActionResult Card(int id)
        {
            var pub = entities.cards.Where(x => x.id == id).FirstOrDefault();

            var month = pub.date_added.Month < 10 ? "0" + pub.date_added.Month.ToString() : pub.date_added.Month.ToString();
            var day = pub.date_added.Day < 10 ? "0" + pub.date_added.Day.ToString() : pub.date_added.Day.ToString();
            var year = pub.date_added.Year;

            ViewBag.added = year + "-" + month + "-" + day;

            ViewBag.id = pub.id;
            ViewBag.name = pub.animals.name;
            ViewBag.sex = pub.animals.sex;
            ViewBag.districts = entities.districts;

            month = pub.animals.birth_date.Month < 10 ? "0" + pub.animals.birth_date.Month.ToString() : pub.animals.birth_date.Month.ToString();
            day = pub.animals.birth_date.Day < 10 ? "0" + pub.animals.birth_date.Day.ToString() : pub.animals.birth_date.Day.ToString();
            year = pub.date_added.Year;

            ViewBag.birthDate = year + "-" + month + "-" + day;

            ViewBag.animal = entities.animals.Where(x => x.passport_number == pub.animal_id).FirstOrDefault().name;

            ViewBag.dist = pub.districts.id;
            return View();
        }

        [HttpPost]
        public ActionResult Card(FormCollection form)
        {
            var pubId = int.Parse(form["id"]);
            var pub = entities.cards.Where(x => x.id == pubId).FirstOrDefault();
            pub.animals.name = form["newName"];
            pub.animals.sex = form["sex"];
            pub.animals.birth_date = Convert.ToDateTime(form["newBirthDate"]);
            pub.district_id = int.Parse(form["newDist"]);

            entities.SaveChanges();

            return Redirect(Url.Action("Cards", "Home"));
        }
    }
}