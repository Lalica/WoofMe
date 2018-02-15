using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WoofMe.Classes;

namespace WoofMe.Models.DogModels
{
    public class AddNewDogModel
    {
        [Display(Name = "Picture")]
        public string Picture { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Race")]
        public string Race { get; set; }
        [Display(Name = "Info")]
        public string Info { get; set; }
        [Display(Name = "Dog Size")]
        public DogSize Size { get; set; }
        [Display(Name = "Hair Lenght")]
        public HairLenght Lenght { get; set; }
    }
}
