using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WoofMe.Classes;

namespace WoofMe.Models.DogModels
{
    public class EditDogModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Current Picture name")]
        public string Picture { get; set; }
        [Display(Name = "New Picture")]
        public string NewPicture { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Breed")]
        public string Race { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
        [Display(Name = "Info")]
        public string Info { get; set; }
        [Required]
        [Display(Name = "Dog Size")]
        public DogSize Size { get; set; }
        [Required]
        [Display(Name = "Hair Lenght")]
        public HairLenght Lenght { get; set; }
        [Required]
        [Display(Name = "Adopted")]
        public bool HasHome { get; set; }
    }
}
