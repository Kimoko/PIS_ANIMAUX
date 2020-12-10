using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMAUX.Models
{
    public class Card
    {
        public int id {get; set;}

        public DateTime DateAdded { get; set; }

        public int OrganisationId { get; set; }

        public int DistrictId { get; set; }

        public int AnimalId { get; set; }
    }
}