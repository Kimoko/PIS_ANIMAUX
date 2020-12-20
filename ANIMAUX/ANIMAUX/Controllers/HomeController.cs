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
            FillDropDowns();
            ViewData["registryItems"] = RegistryItems();
            return View(ViewData["registryItems"]);
        }
        [HttpPost]
        public ActionResult Registry(FormCollection form)
        {

            string date = form["dateInput"];
            string sex = form["dropDownSex"];
            char[] age = form["dropDownAge"].Where(c => Char.IsDigit(c)).ToArray();    
            string district = form["dropDownDistrict"];
            string sort_id = form["dropDownSort"];
            var registryItems = RegistryItems();
            IEnumerable<RegistryItems> result = registryItems;
            if (date != "")
            {
                var convertedDate = Convert.ToDateTime(date);
                result = registryItems.Where(z => z.cards.date_added >= convertedDate);
                registryItems = result;
            }
            if (sex != "-1")
            {
                result = registryItems.Where(z => z.animals.sex.Equals(sex));
                registryItems = result;
            }
            if (age.Length != 1)
            {
                result =registryItems.Where(z => (DateTime.Now.Year-z.animals.birth_date.Year)>=Convert.ToInt32(Char.GetNumericValue(age[0])) && (DateTime.Now.Year - z.animals.birth_date.Year) < Convert.ToInt32(Char.GetNumericValue(age[1])));
                registryItems = result;
            }
            if (district != "-1")
            {
                result = registryItems.Where(z => z.districts.name.Equals(district));
                registryItems = result;
            }
            ///////////////////////////Sort/////////////////////////////
            switch (sort_id)
            {
                case "По возрастанию":
                    result = registryItems.OrderBy(x => x.cards.animal_id);
                    break;
                case "По убыванию":
                    result = registryItems.OrderByDescending(x => x.cards.animal_id);
                    break;
                default:
                    result = registryItems;
                    break;
            }
            ViewData["registryItems"] = result;
            FillDropDowns();
            return View(ViewData["registryItems"]);
        }

        public ActionResult Publications()
        {
//            ViewBag.Message = "Объявления";

            return View(entities.publications.ToList());
        }

        public List<SelectListItem> CreateSelectList(List<string> list)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = list[0], Value = list[0], Selected = true });
            for (int i=1; i<list.Count; i++)
            {
                items.Add(new SelectListItem { Text = list[i], Value = list[i].ToString()});
            }
            return items;
        }

        public void FillDropDowns()
        {
            ViewBag.DropDownSort = CreateSelectList(new List<string>() { "По умолчанию", "По возрастанию", "По убыванию" });
            //////////////////////////Filter/////////////////////////////
            //Пероид размещения объявления
            //Пол животного (М / Ж)
            ViewBag.DropDownSex = CreateSelectList(new List<string>() { "М", "Ж" });
            //Возраст животного (от 0 до 6 мес, от 6 мес до 1 года, от 1 года до 2 лет, от 2 лет до 5, от 5 и старше)
            ViewBag.DropDownAge = CreateSelectList(new List<string>() { "0 - 1 года", "1 года - 2 лет", "2 - 4 года", "4 - 6 лет", "от 6 и старше" });
            //Округ
            ViewBag.DropDownCity = CreateSelectList(entities.districts.Select(z => z.name).Distinct().ToList());

        }
        public IEnumerable<RegistryItems> RegistryItems()
        {
            List<cards> cardsList = entities.cards.ToList();
            List<animals> animalsList = entities.animals.ToList();
            List <districts> districtsList = entities.districts.ToList();

            //может сделать создание запросов в другом классе? или хотя бы вынести их как отдельные методы
            ///////////////////////////Query////////////////////////////


            var registryItems = from c in cardsList
                                join a in animalsList on c.animal_id equals a.passport_number
                                into table1
                                from a in table1.DefaultIfEmpty()
                                join d in districtsList on c.district_id equals d.id
                                into table2
                                from d in table2.DefaultIfEmpty()
                                select new RegistryItems { cards = c, animals = a, districts = d };
            return registryItems;
        }

    }

}