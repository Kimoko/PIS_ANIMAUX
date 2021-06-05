using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ANIMAUX.Models
{
    public class UpdatePublication
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Введите ссылку")]
        [Url]
        [Display(Name = "Foto")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "Выберите дату")]
        
        [Display(Name = "DateTime")]
        
        public string dateTime { get; set; }
      
        [Required(ErrorMessage = "Введите название города")]
        [Display(Name = "Sity")]
        public string Sity { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Выберите статус животного")]
        [Display(Name = "Status")]
        public string Status { get; set; }



    }
}