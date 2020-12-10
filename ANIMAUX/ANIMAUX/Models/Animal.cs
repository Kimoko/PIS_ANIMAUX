using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMAUX
{
    public class Animal
    {
        public int PasportNumber { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Breed { get; set; }
        public char Sex { get; set; }

    }
}