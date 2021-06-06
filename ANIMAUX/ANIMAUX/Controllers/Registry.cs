using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANIMAUX.Models;

namespace ANIMAUX.Controllers
{
    public class Registry
    {
        BDEntities entities = new BDEntities();

        static IEnumerable<RegistryItems> List;

        public Registry()
        {
            List = GetLists();
        }
        public IEnumerable<RegistryItems> GetLists()
        {      
            List<card> cardsList = entities.cards.ToList();
            List<animal> animalsList = entities.animals.ToList();
            List<district> districtsList = entities.districts.ToList();

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

        public IEnumerable<RegistryItems> GetListsByOrganisation(CurrentUser idUser)
        {
            var userOrganisationId = idUser.organisation;
            var organisations =  List.Where(x => x.cards.organisation_id == userOrganisationId);
            List = organisations;
            return List;
        }


        public IEnumerable<RegistryItems> GetListsByDistrict(CurrentUser idUser)
        {
            var userDistrictId = idUser.district;
            var districts =  List.Where(x => x.cards.district_id == userDistrictId);
            List = districts;
            return List;
        }
    }
}