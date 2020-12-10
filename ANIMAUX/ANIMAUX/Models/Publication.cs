using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMAUX.Models
{
    public class Publication
    {
        public int Id { get; set; }

        public DateTime AddedTime { get; set; }

        public string Main_photo { get; set; }

        public List<string> Photos { get; set; }

        public string City { get; set; }

        public int AnimalId { get; set; }

        // L for lost, F for found
        public char Type { get; set; }
    }
}