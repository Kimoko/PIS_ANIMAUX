using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMAUX.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int UserRole { get; set; }
        public int UserOrganisation { get; set; }
        public int UserDistrict { get; set; }
    }
}